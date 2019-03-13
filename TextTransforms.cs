using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using emanuel.Extensions;
using emanuel.Macros;
using emanuel.Transforms;
using textr.Editables;
using JiraHelper;

namespace emanuel
{
    public partial class TextTransforms : Form
    {
        IEditableProperties editing = null;

        public TextTransforms()
        {
            InitializeComponent();
            InitEditableTransforms();
        }

        List<ITransform> transforms = new List<ITransform>();
        public string MainText { get => txtMain.Text; }

        private TextTransforms AddTransform(ITransform transform)
        {
            if (editing != null && transform is EditableTransform && EditEventController.Instance.Save((transform as EditableTransform).GetEditableProperties()))
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
        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            if (chkAutoApply.Checked)
            {
                ApplyEdits();
            }
        }
        private void txtMain_TextChanged(object sender, EventArgs e)
        {
            UpdateResult();
        }
        #endregion

        #region Enter pressed

        private bool EnterPressed(KeyPressEventArgs e)
        => e.KeyChar == (char)13;

        private void txtReplace_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EnterPressed(e))
            {
                AddTransform(new FindReplaceTransform(txtFind.Text, txtReplace.Text, chkCaseSensitive.Checked));
            }
        }

        private void txtNewLineAfterXOccurencesOfY_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtTruncate_KeyPress(object sender, KeyPressEventArgs e)
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
        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyEdits();
        }

        private void btnRemoveNewLines_Click(object sender, EventArgs e)
        {
            AddTransform(new RemoveNewLineTransform());
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtResult.Text);
        }
        private void btnUndoTransform_Click(object sender, EventArgs e)
        {
            if (transforms.Any())
                transforms.Remove(transforms.Last());
            UpdateResult();
        }

        private void btnClearTransforms_Click(object sender, EventArgs e)
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

        private void btnRemoveSelectedTransform_Click(object sender, EventArgs e)
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

        private void btnMoveTransformUp_Click(object sender, EventArgs e)
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

        private void btnMoveTransformDown_Click(object sender, EventArgs e)
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

        private void btnBatchEdit_Click(object sender, EventArgs e)
        {
            var be = new BatchEdit(txtResult.Text);
            be.TransformFound += BatchEdit_TransformFound;
            be.Show();
        }

        private void btnNewLineChars_Click(object sender, EventArgs e)
        {
            AddTransform(new NewLineCharFix());
        }

        private void btnDistinct_Click(object sender, EventArgs e)
        {
            AddTransform(new DistinctTransform());
        }

        private void btnRemoveBlankLines_Click(object sender, EventArgs e)
        {
            AddTransform(new RemoveBlankLinesTransform());
        }

        #endregion

        #region Macro button clicks

        private void AddMacro(IEnumerable<ITransform> list) { list.DoForEach(t => AddTransform(t)); }

        private void btnMacroListStringComma_Click(object sender, EventArgs e)
        {
            SqlMacros.SqlListStringComma()
                .Do(list => AddMacro(list));
        }

        private void btnMacroListComma_Click(object sender, EventArgs e)
        {
            SqlMacros.SqlListComma()
                .Do(list => AddMacro(list));
        }

        private void btnMacroSqlSelectFormatter_Click(object sender, EventArgs e)
        {
            SqlMacros.SqlSelectFormat()
                .Do(list => AddMacro(list));
        }

        private void btnMacroSqlQuery_Click(object sender, EventArgs e)
        {
            SqlMacros.SqlQueryFormat()
                .Do(list => AddMacro(list));
        }
        private void btnMacroSqlValues_Click(object sender, EventArgs e)
        {
            SqlMacros.SqlValues()
                .Do(list => AddMacro(list));
        }

        private void btnAddTableNames_Click(object sender, EventArgs e)
        {
            SqlMacros.SqlAddTableNamesToSelect()
                .Do(list => AddMacro(list));
        }

        #endregion

        #region EventHandlers
        private void BatchEdit_TransformFound(object sender, EventArgs e)
        {
            var be = (BatchEdit)sender;
            AddTransform(be.FoundTransform);
        }

        #endregion

        #region Checked changed

        private void chkBeforeOrAfter_CheckedChanged(object sender, EventArgs e)
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
        }

        private void StopEditing()
        {
            lstTransforms.Enabled = true;
            btnEditSelectedTransform.Text = "Edit";
            editing = null;
            btnApply.Enabled = true;
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

        private void btnEditSelectedTransform_Click(object sender, EventArgs e)
        {
            if (btnEditSelectedTransform.Text == "Edit")
            {
                if (lstTransforms.SelectedItem.AssignForwardIf(s => s != null && s is EditableTransform, out object selectedTransform))
                {
                    editing = (selectedTransform as EditableTransform).Edit();
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

        private void btnAsteriskToParagraph_Click(object sender, EventArgs e)
        {
            AddTransform(new FindReplaceTransform("*", "§"));
        }

        private void btnParagraphToAsterisk_Click(object sender, EventArgs e)
        {
            AddTransform(new FindReplaceTransform("§", "*"));
        }

        private void lstTransforms_SelectedValueChanged(object sender, EventArgs e)
        {
            btnEditSelectedTransform.Enabled = (lstTransforms.SelectedItem is EditableTransform);
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EnterPressed(e))
            {
                txtReplace.Select();
            }
        }

        private void btnCopyTab_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(@"	");
        }

        private void btnJira_Click(object sender, EventArgs e)
        {
            new JiraHelperForm().Show();
        }
    }
}
