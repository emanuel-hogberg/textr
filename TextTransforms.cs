using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using emanuel.Extensions;
using emanuel.Macros;
using emanuel.Transforms;
using textr.Editables;
using JiraHelper;
using textr.Helpers;
using textr.Transforms;

namespace emanuel
{
    public partial class TextTransforms : Form
    {
        IEditableProperties _editing = null;
        private string _mathTooltip = string.Empty;
        private TextBox _txtSelectionTarget = null;

        public TextTransforms()
        {
            InitializeComponent();
            InitEditableTransforms();
        }

        readonly List<ITransform> transforms = new List<ITransform>();
        public string MainText { get => txtMain.Text; }

        private TextTransforms AddTransform(ITransform transform)
        {
            if (_editing != null && transform is EditableTransform && EditEventController.Instance.Save((transform as EditableTransform).GetEditableProperties()))
            {
                StopEditing();
            }
            else
            {
                transforms.Add(transform);
                EditEventController.Instance.NewTransformAdded(transforms);
            }

            UpdateResult();
            return this;
        }

        private void UpdateResult()
        {
            txtResult.Text = ApplyTransforms();
            lstTransforms.DataSource = null;
            lstTransforms.DataSource = transforms;
        }

        private string ApplyTransforms()
        {
            string r = txtMain.Text;
            foreach(ITransform t in transforms)
            {
                r = t.Transform(r);
            }
            return r;
        }

        #region text changed
        private void TxtResult_TextChanged(object sender, EventArgs e)
        {
            if (chkAutoApply.Checked)
            {
                ApplyEdits();
            }
        }
        private void TxtMain_TextChanged(object sender, EventArgs e)
        {
            UpdateResult();
            UpdateStatusText();
        }

        private void UpdateStatusText()
        {
            try
            {
                if (_txtSelectionTarget == null)
                {
                    _txtSelectionTarget = txtMain;
                }

                lblStatusBar.Text =
                    _mathTooltip +
                    $"Selection start: {_txtSelectionTarget.SelectionStart}, " +
                    $"length: {_txtSelectionTarget.SelectionLength}, " +
                    $"line: {0 + _txtSelectionTarget.GetLineFromCharIndex(txtMain.SelectionStart)}, " +
                    $"total length: {_txtSelectionTarget.TextLength}";
            }
            catch (Exception ex)
            {
                lblStatusBar.Text = ex.ToString();
            }
        }
        #endregion

        #region Enter pressed

        private bool EnterPressed(KeyPressEventArgs e)
        => e.KeyChar == (char)13;

        private void TxtReplace_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EnterPressed(e))
            {
                AddTransform(new FindReplaceTransform(txtFind.Text, txtReplace.Text, chkCaseSensitive.Checked));
            }
        }

        private void TxtNewLineAfterXOccurencesOfY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EnterPressed(e))
            {
                if (int.TryParse(txtNewLineAfterXOccurences.Text.Trim(), out int occurences))
                {
                    AddTransform(new NewLineAfterXOccurencesOfY(occurences, txtNewLineAfterXOccurencesOfY.Text, chkCaseSensitive.Checked, chkBeforeOrAfter.Checked));
                }
                else
                {
                    txtInfo.Text = $"{txtNewLineAfterXOccurences.Text} is not an int!";
                }
            }
        }
        private void TxtTruncate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EnterPressed(e))
            {
                AddTransform(new TruncateTransform()
                {
                    FromStart = chkBeforeOrAfter.Checked,
                    IgnoreCase = !chkCaseSensitive.Checked,
                    Truncate = txtTruncate.Text
                });
            }
        }


        #endregion

        #region  Button clicks
        private void BtnApply_Click(object sender, EventArgs e)
        {
            ApplyEdits();
        }

        private void BtnRemoveNewLines_Click(object sender, EventArgs e)
        {
            AddTransform(new RemoveNewLineTransform());
        }

        private void BtnCopyToClipboard_Click(object sender, EventArgs e)
        {

            if (txtResult.Text.AssignForwardIf((s) => !string.IsNullOrEmpty(s), out string value))
            {
                Clipboard.SetText(value);
                txtInfo.Text = $"Clipboard set to: {value.Replace(Environment.NewLine, "\\n").Cutoff(25, "...")}";
            }
            else
            {
                txtInfo.Text = "Nothing to copy.";
            }
        }
        private void BtnUndoTransform_Click(object sender, EventArgs e)
        {
            if (transforms.Any())
                transforms.Remove(transforms.Last());
            UpdateResult();
        }

        private void BtnClearTransforms_Click(object sender, EventArgs e)
        {
            transforms.Clear();
            UpdateResult();
        }

        private void IfValidIndexSelected(Action<int> action)
            => lstTransforms.SelectedIndex
                .Do(i =>
                {
                    if (i.Between(0, transforms.Count - 1))
                        action(i);
                });

        private void BtnRemoveSelectedTransform_Click(object sender, EventArgs e)
        {
            IfValidIndexSelected(i =>
            {
                transforms.RemoveAt(i);
                UpdateResult();
                if (i.Between(0, transforms.Count - 1))
                    lstTransforms.SelectedIndex = i;
                if (i == transforms.Count && transforms.Any())
                    lstTransforms.SelectedIndex = i - 1;
            });
        }

        private void BtnMoveTransformUp_Click(object sender, EventArgs e)
        {
            IfValidIndexSelected(i =>
            {
                if (i > 0)
                {
                    var t = transforms[i];
                    transforms.Remove(t);
                    transforms.Insert(i - 1, t);

                    UpdateResult();
                    lstTransforms.SelectedIndex = i - 1;
                }
            });
        }

        private void BtnMoveTransformDown_Click(object sender, EventArgs e)
        {
            IfValidIndexSelected(i =>
            {
                if (i < transforms.Count - 1)
                {
                    var t = transforms[i];
                    transforms.Remove(t);
                    transforms.Insert(i + 1, t);

                    UpdateResult();
                    lstTransforms.SelectedIndex = i + 1;
                }
            });
        }

        private void BtnBatchEdit_Click(object sender, EventArgs e)
        {
            var be = new BatchEdit(txtResult.Text);
            be.TransformFound += BatchEdit_TransformFound;
            be.Show();
        }

        private void BtnNewLineChars_Click(object sender, EventArgs e)
        {
            AddTransform(new NewLineCharFix());
        }

        private void BtnDistinct_Click(object sender, EventArgs e)
        {
            AddTransform(new DistinctTransform());
        }

        private void BtnRemoveBlankLines_Click(object sender, EventArgs e)
        {
            AddTransform(new RemoveBlankLinesTransform());
        }

        #endregion

        #region Macro button clicks

        private void AddMacro(IEnumerable<ITransform> list) { list.DoForEach(t => AddTransform(t)); }

        private void BtnMacroListStringComma_Click(object sender, EventArgs e)
        {
            SqlMacros.SqlListStringComma()
                .Do(list => AddMacro(list));
        }

        private void BtnMacroListComma_Click(object sender, EventArgs e)
        {
            SqlMacros.SqlListComma()
                .Do(list => AddMacro(list));
        }

        private void BtnMacroSqlSelectFormatter_Click(object sender, EventArgs e)
        {
            SqlMacros.SqlSelectFormat()
                .Do(list => AddMacro(list));
        }

        private void BtnMacroSqlQuery_Click(object sender, EventArgs e)
        {
            SqlMacros.SqlQueryFormat()
                .Do(list => AddMacro(list));
        }
        private void BtnMacroSqlValues_Click(object sender, EventArgs e)
        {
            SqlMacros.SqlValues()
                .Do(list => AddMacro(list));
        }

        private void BtnAddTableNames_Click(object sender, EventArgs e)
        {
            SqlMacros.SqlAddTableNamesToSelect()
                .Do(list => AddMacro(list));
        }

        #endregion

        #region EventHandlers
        private void BatchEdit_TransformFound(object sender, EventArgs e)
        {
            var be = (BatchEdit)sender;

            AddMacro(be.FoundTransforms);
        }

        #endregion

        #region Checked changed

        private void ChkBeforeOrAfter_CheckedChanged(object sender, EventArgs e)
        {
            lblNewLineAfterX.Text = chkBeforeOrAfter.Checked
                .Forward(c => c ? "before" : "after")
                .Forward(beforeOrAfter => $"New line {beforeOrAfter}:");
        }


        #endregion

        #region Edit

        private void InitEditableTransforms()
        {
            EditEventController.Instance.Editing += EditEventcontroller_Editing;
            EditEventController.Instance.RegisterEditableType(typeof(FindReplaceTransform), Edit_FindReplaceTransform);
            EditEventController.Instance.RegisterEditableType(typeof(TruncateTransform), Edit_TruncateTransform);
        }

        private void EditEventcontroller_Editing(object sender, EventArgs e)
        {
            lstTransforms.Enabled = false;
            btnEditSelectedTransform.Text = "Cancel";
            btnApply.Enabled = false;
            btnClearTransforms.Enabled = false;
        }

        private void StopEditing()
        {
            lstTransforms.Enabled = true;
            btnEditSelectedTransform.Text = "Edit";
            _editing = null;
            btnApply.Enabled = true;
            btnClearTransforms.Enabled = true;
        }

        public TextTransforms ApplyEdits()
        {
            transforms.Clear();
            txtMain.Text = txtResult.Text;
            return this;
        }
        #endregion

        #region EditTransforms

        private void Edit_FindReplaceTransform(IEditableProperties props)
        {
            var p = props as FindReplaceTransform.FindReplaceEdit;
            txtFind.Text = p.Find;
            txtReplace.Text = p.Replace;
            chkCaseSensitive.Checked = p.CaseSensitive;
            txtFind.Select();
        }

        private void Edit_TruncateTransform(IEditableProperties props)
        {
            var p = props as TruncateTransform.TruncateEdit;
            txtTruncate.Text = p.Truncate;
            chkBeforeOrAfter.Checked = p.FromStart;
            chkCaseSensitive.Checked = p.IgnoreCase;
            txtTruncate.Select();
        }

        #endregion

        private void BtnEditSelectedTransform_Click(object sender, EventArgs e)
        {
            if (btnEditSelectedTransform.Text == "Edit")
            {
                if (lstTransforms.SelectedItem.AssignForwardIf(s => s != null && s is EditableTransform, out object selectedTransform))
                {
                    _editing = (selectedTransform as EditableTransform).Edit();
                    txtInfo.Text = $"Editing {selectedTransform}";
                }
                else if (lstTransforms.SelectedItem is EditableTransform)
                {
                    txtInfo.Text = "Selected transform is not editable.";
                }
                else
                {
                    txtInfo.Text = "Please select a transform first.";
                }
            }
            else
            {
                EditEventController.Instance.CancelEdit();
                StopEditing();
                txtInfo.Text = "Cancelled edit.";
            }
        }

        private void BtnAsteriskToParagraph_Click(object sender, EventArgs e)
        {
            AddTransform(new FindReplaceTransform("*", "§"));
        }

        private void BtnParagraphToAsterisk_Click(object sender, EventArgs e)
        {
            AddTransform(new FindReplaceTransform("§", "*"));
        }

        private void LstTransforms_SelectedValueChanged(object sender, EventArgs e)
        {
            btnEditSelectedTransform.Enabled = (lstTransforms.SelectedItem is EditableTransform);
        }

        private void TxtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EnterPressed(e))
            {
                txtReplace.Select();
            }
        }

        private void BtnCopyTab_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(@"	");
        }

        private void BtnJira_Click(object sender, EventArgs e)
        {
            new JiraHelperForm().Show();
        }

        private void TxtMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            UpdateStatusText();
        }

        private void TxtMain_Click(object sender, EventArgs e)
        {
            _txtSelectionTarget = txtMain;

            UpdateStatusText();
        }

        private void TxtMain_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateStatusText();
        }

        private void txtMain_Enter(object sender, EventArgs e)
        {
            _txtSelectionTarget = txtMain;
        }

        private void txtResult_Enter(object sender, EventArgs e)
        {
            _txtSelectionTarget = txtResult;
        }

        private void txtReplace_Click(object sender, EventArgs e)
        {
            _txtSelectionTarget = txtMain;

            UpdateStatusText();
        }

        private void txtNewLineAfterXOccurences_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EnterPressed(e) && !int.TryParse(txtNewLineAfterXOccurences.Text, out _))
            {
                txtNewLineAfterXOccurencesOfY.Text = txtNewLineAfterXOccurences.Text;
                txtNewLineAfterXOccurences.Text = "1";
                txtNewLineAfterXOccurencesOfY.Focus();
            }
        }

        private void btnAsciiTo_Click(object sender, EventArgs e)
        {
            AddTransform(new FindReplaceTransform("\u00e5", @"\u00e5"))
                .AddTransform(new FindReplaceTransform("\u00e4", @"\u00e4"))
                .AddTransform(new FindReplaceTransform("\u00f6", @"\u00f6"))
                .AddTransform(new FindReplaceTransform("\u00c5", @"\u00c5"))
                .AddTransform(new FindReplaceTransform("\u00c4", @"\u00c4"))
                .AddTransform(new FindReplaceTransform("\u00d6", @"\u00d6"));
        }

        private void btnAsciiFrom_Click(object sender, EventArgs e)
        {
            AddTransform(new FindReplaceTransform(@"\u00e5", "\u00e5"))
                .AddTransform(new FindReplaceTransform(@"\u00e4", "\u00e4"))
                .AddTransform(new FindReplaceTransform(@"\u00f6", "\u00f6"))
                .AddTransform(new FindReplaceTransform(@"\u00c5", "\u00c5"))
                .AddTransform(new FindReplaceTransform(@"\u00c4", "\u00c4"))
                .AddTransform(new FindReplaceTransform(@"\u00d6", "\u00d6"));
        }

        private void btnMath_Click(object sender, EventArgs e)
        {
            AddTransform(new MathTransform());
        }

        private void btnMath_MouseEnter(object sender, EventArgs e)
        {
            string selection = txtMain.SelectionLength > 0 ?
                txtMain.SelectedText :
                MathHelper.SplitOutHooks(txtMain.Text);

            if (string.IsNullOrEmpty(selection))
            {
                _mathTooltip = "Math expression using https://mathparser.org/.";
            }
            else
            {
                string resultString = "error";

                if (MathHelper.MathExpression(selection, out string error, out double result))
                {
                    resultString = result.ToString();
                }
                else
                {
                    resultString = error;
                }

                _mathTooltip = $"{selection} = {resultString} (from https://mathparser.org/)";
            }

            UpdateStatusText();
        }

        private void btnMath_MouseLeave(object sender, EventArgs e)
        {
            _mathTooltip = "";

            UpdateStatusText();
        }

        private void btnJsonToXml_Click(object sender, EventArgs e)
        {
            AddTransform(new JsonXmlTransform
            {
                PascalCasing = chkXmlCasing.Checked
            });

            if (txtFind.Text.Length == 0 && txtReplace.Text.Length == 0)
            {
                txtFind.Text = JsonXmlTransform.DeserializeRootElementName;
                txtReplace.Select();
            }
        }

        private void btnXmlToJson_Click(object sender, EventArgs e)
        {
            AddTransform(new XmlJsonTransform());
        }

        private void chkXmlCasing_CheckedChanged(object sender, EventArgs e)
        {
            chkXmlCasing.Text = chkXmlCasing.Checked
                ? "<PascalCase>"
                : "<anyCase>";
        }

        private void btnGremlin_Click(object sender, EventArgs e)
        {
            GremlinMacros.GremlinFormat()
                .Do(list => AddMacro(list));
        }

        private void btnToMd5_Click(object sender, EventArgs e)
        {
            AddTransform(new Base64EncodeTransform());
        }

        private void btnFromBase64_Click(object sender, EventArgs e)
        {
            AddTransform(new Base64DecodeTransform());
        }
    }
}
