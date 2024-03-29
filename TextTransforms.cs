﻿using emanuel.Extensions;
using JiraHelper;
using StringTransforms;
using StringTransforms.Interfaces;
using StringTransforms.Macros;
using StringTransforms.Services;
using StringTransforms.Transforms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace emanuel
{
    public partial class TextTransforms : Form, ITextTransformations
    {
        IEditableProperties _editing = null;
        private string _mathTooltip = string.Empty;
        private TextBox _txtSelectionTarget = null;
        //TODO: use factories if applicable
        private ITransformFactoryService _transformFactoryService;
        private IMacroFactoryService _macroFactoryService;
        private ITransformService _transformService;
        private readonly IEditEventService _editEventService;
        private readonly IMathService _mathService;
        ITransformCollection _transformCollection;

        public TextTransforms(
            ITransformFactoryService transformFactoryService,
            IMacroFactoryService macroFactoryService,
            ITransformService transformService,
            IEditEventService editEventService,
            IMathService mathService)
        {
            _transformFactoryService = transformFactoryService;
            _macroFactoryService = macroFactoryService;
            _transformService = transformService;
            _editEventService = editEventService;
            _mathService = mathService;

            InitializeComponent();
            InitEditableTransforms();

            _transformCollection = _transformService.GetNewTransformCollection();
        }

        public string MainText { get => txtMain.Text; }

        private TextTransforms AddTransform(ITransform transform)
        {
            if (_editing != null &&
                transform is EditableTransform &&
                _editEventService
                    .Save((transform as EditableTransform)
                    .GetEditableProperties()))
            {
                StopEditing();
            }
            else
            {
                _transformService.AddTransform(transform, _transformCollection);

                _editEventService.NewTransformAdded(_transformCollection);
            }

            UpdateTransforms();

            return this;
        }

        private void UpdateTransforms()
        {
            var index = _transformCollection.GetSelector().GetIndex();

            lstTransforms.DataSource = null;
            lstTransforms.DataSource = _transformCollection.AsDataSource();

            lstTransforms.SelectedIndex = Math.Min(index, _transformCollection.Count - 1);

            UpdateResult();
        }


        private void UpdateResult()
        {
            txtResult.Text = ApplyTransforms();
        }

        private string ApplyTransforms()
        => _transformService.ApplyTransforms(_transformCollection, txtMain.Text);

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
                AddTransform(_transformFactoryService.CreateFindReplaceTransform(txtFind.Text, txtReplace.Text, chkCaseSensitive.Checked));
            }
        }

        private void TxtNewLineAfterXOccurencesOfY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EnterPressed(e))
            {
                if (int.TryParse(txtNewLineAfterXOccurences.Text.Trim(), out int occurences))
                {
                    AddTransform(_transformFactoryService.CreateNewLineAfterXOccurencesOfY(occurences, txtNewLineAfterXOccurencesOfY.Text, chkCaseSensitive.Checked, chkBeforeOrAfter.Checked));
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
                AddTransform(_transformFactoryService.CreateTruncateTransform(chkBeforeOrAfter.Checked, !chkCaseSensitive.Checked, txtTruncate.Text));
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
            AddTransform(_transformFactoryService.CreateRemoveNewLineTransform());
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
            _transformService.Undo(_transformCollection);

            UpdateTransforms();
        }

        private void BtnClearTransforms_Click(object sender, EventArgs e)
        {
            _transformService.RemoveAllTransforms(_transformCollection);

            UpdateTransforms();
        }

        private void BtnRemoveSelectedTransform_Click(object sender, EventArgs e)
        {
            _transformService.RemoveTranform(_transformCollection);

            UpdateTransforms();
        }

        private void BtnMoveTransformUp_Click(object sender, EventArgs e)
        {
            _transformService.MoveSelectedTransform(_transformCollection, up: true);

            UpdateTransforms();
        }

        private void BtnMoveTransformDown_Click(object sender, EventArgs e)
        {
            _transformService.MoveSelectedTransform(_transformCollection, up: false);

            UpdateTransforms();
        }

        private void BtnBatchEdit_Click(object sender, EventArgs e)
        {
            var be = new BatchEdit(_transformFactoryService, txtResult.Text);
            be.TransformFound += BatchEdit_TransformFound;
            be.Show();
        }

        private void BtnNewLineChars_Click(object sender, EventArgs e)
        {
            AddTransform(_transformFactoryService.CreateNewLineCharFix());
        }

        private void BtnDistinct_Click(object sender, EventArgs e)
        {
            AddTransform(_transformFactoryService.CreateDistinctTransform());
        }

        private void BtnRemoveBlankLines_Click(object sender, EventArgs e)
        {
            AddTransform(_transformFactoryService.CreateRemoveBlankLinesTransform());
        }

        #endregion

        #region Macro button clicks

        private void AddMacro(IEnumerable<ITransform> list) { list.DoForEach(t => AddTransform(t)); }

        private void BtnMacroListStringComma_Click(object sender, EventArgs e)
        {
            _macroFactoryService.CreateSqlListStringComma()
                .Do(list => AddMacro(list));
        }

        private void BtnMacroListComma_Click(object sender, EventArgs e)
        {
            _macroFactoryService.CreateSqlListComma()
                .Do(list => AddMacro(list));
        }

        private void BtnMacroSqlSelectFormatter_Click(object sender, EventArgs e)
        {
            _macroFactoryService.CreateSqlSelectFormat()
                .Do(list => AddMacro(list));
        }

        private void BtnMacroSqlQuery_Click(object sender, EventArgs e)
        {
            _macroFactoryService.CreateSqlQueryFormat()
                .Do(list => AddMacro(list));
        }
        private void BtnMacroSqlValues_Click(object sender, EventArgs e)
        {
            _macroFactoryService.CreateSqlValues()
                .Do(list => AddMacro(list));
        }

        private void BtnAddTableNames_Click(object sender, EventArgs e)
        {
            _macroFactoryService.CreateSqlAddTableNamesToSelect()
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
            _editEventService.SetEditingEvent(EditEventcontroller_Editing);

            _editEventService.RegisterEditableType(FindReplaceEdit.Transform, Edit_FindReplaceTransform);
            _editEventService.RegisterEditableType(TruncateEdit.Transform, Edit_TruncateTransform);
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
            _transformCollection.Clear();
            txtMain.Text = txtResult.Text;
            return this;
        }
        #endregion

        #region EditTransforms

        private void Edit_FindReplaceTransform(IEditableProperties props)
        {
            var p = props as FindReplaceProperties;

            txtFind.Text = p.Find;
            txtReplace.Text = p.Replace;
            chkCaseSensitive.Checked = p.CaseSensitive;

            txtFind.Select();
        }

        private void Edit_TruncateTransform(IEditableProperties props)
        {
            var p = props as TruncateProperties;

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
                _editEventService.CancelEdit();
                StopEditing();
                txtInfo.Text = "Cancelled edit.";
            }
        }

        private void BtnAsteriskToParagraph_Click(object sender, EventArgs e)
        {
            AddTransform(_transformFactoryService.CreateFindReplaceTransform("*", "§"));
        }

        private void BtnParagraphToAsterisk_Click(object sender, EventArgs e)
        {
            AddTransform(_transformFactoryService.CreateFindReplaceTransform("§", "*"));
        }

        private void LstTransforms_SelectedValueChanged(object sender, EventArgs e)
        {
            btnEditSelectedTransform.Enabled = (lstTransforms.SelectedItem is IEditableTransform);

            _transformCollection.GetSelector().SetIndex(lstTransforms.SelectedIndex);
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
            AddTransform(_transformFactoryService.CreateFindReplaceTransform("\u00e5", @"\u00e5"))
                .AddTransform(_transformFactoryService.CreateFindReplaceTransform("\u00e4", @"\u00e4"))
                .AddTransform(_transformFactoryService.CreateFindReplaceTransform("\u00f6", @"\u00f6"))
                .AddTransform(_transformFactoryService.CreateFindReplaceTransform("\u00c5", @"\u00c5"))
                .AddTransform(_transformFactoryService.CreateFindReplaceTransform("\u00c4", @"\u00c4"))
                .AddTransform(_transformFactoryService.CreateFindReplaceTransform("\u00d6", @"\u00d6"));
        }

        private void btnAsciiFrom_Click(object sender, EventArgs e)
        {
            AddTransform(_transformFactoryService.CreateFindReplaceTransform(@"\u00e5", "\u00e5"))
                .AddTransform(_transformFactoryService.CreateFindReplaceTransform(@"\u00e4", "\u00e4"))
                .AddTransform(_transformFactoryService.CreateFindReplaceTransform(@"\u00f6", "\u00f6"))
                .AddTransform(_transformFactoryService.CreateFindReplaceTransform(@"\u00c5", "\u00c5"))
                .AddTransform(_transformFactoryService.CreateFindReplaceTransform(@"\u00c4", "\u00c4"))
                .AddTransform(_transformFactoryService.CreateFindReplaceTransform(@"\u00d6", "\u00d6"));
        }

        private void btnMath_Click(object sender, EventArgs e)
        {
            AddTransform(_transformFactoryService.CreateMathTransform(_mathService));
        }

        private void btnMath_MouseEnter(object sender, EventArgs e)
        {
            string selection = txtMain.SelectionLength > 0 ?
                txtMain.SelectedText :
                _mathService.SplitOutHooks(txtMain.Text);

            if (string.IsNullOrEmpty(selection))
            {
                _mathTooltip = "Math expression using https://mathparser.org/.";
            }
            else
            {
                string resultString = "error";

                if (_mathService.MathExpression(selection, out string error, out double result))
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
            var jsonXmlTransform = _transformFactoryService.CreateJsonXmlTransform(chkXmlCasing.Checked);

            AddTransform(jsonXmlTransform);

            if (txtFind.Text.Length == 0 && txtReplace.Text.Length == 0)
            {
                txtFind.Text = jsonXmlTransform.DeserializeRootElementName;

                txtReplace.Select();
            }
        }

        private void btnXmlToJson_Click(object sender, EventArgs e)
        {
            AddTransform(_transformFactoryService.CreateXmlJsonTransform());
        }

        private void chkXmlCasing_CheckedChanged(object sender, EventArgs e)
        {
            chkXmlCasing.Text = chkXmlCasing.Checked
                ? "<PascalCase>"
                : "<anyCase>";
        }

        private void btnGremlin_Click(object sender, EventArgs e)
        {
            _macroFactoryService.CreateGremlinFormat()
                .Do(list => AddMacro(list));
        }

        private void btnToMd5_Click(object sender, EventArgs e)
        {
            AddTransform(_transformFactoryService.CreateBase64EncodeTransform());
        }

        private void btnFromBase64_Click(object sender, EventArgs e)
        {
            AddTransform(_transformFactoryService.CreateBase64DecodeTransform());
        }
    }
}
