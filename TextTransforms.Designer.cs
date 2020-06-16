namespace emanuel
{
    partial class TextTransforms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextTransforms));
            this.txtMain = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.btnRemoveNewLines = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.chkAutoApply = new System.Windows.Forms.CheckBox();
            this.lblFindReplace = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.btnUndoTransform = new System.Windows.Forms.Button();
            this.txtNewLineAfterXOccurences = new System.Windows.Forms.TextBox();
            this.txtNewLineAfterXOccurencesOfY = new System.Windows.Forms.TextBox();
            this.lblNewLineAfterX = new System.Windows.Forms.Label();
            this.lblNewLineOccurence = new System.Windows.Forms.Label();
            this.lblMacros = new System.Windows.Forms.Label();
            this.btnMacroSqlQuery = new System.Windows.Forms.Button();
            this.btnMacroSqlSelectFormatter = new System.Windows.Forms.Button();
            this.btnClearTransforms = new System.Windows.Forms.Button();
            this.btnBatchEdit = new System.Windows.Forms.Button();
            this.btnNewLineChars = new System.Windows.Forms.Button();
            this.chkCaseSensitive = new System.Windows.Forms.CheckBox();
            this.chkBeforeOrAfter = new System.Windows.Forms.CheckBox();
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.lstTransforms = new System.Windows.Forms.ListBox();
            this.pnlActionButtons = new System.Windows.Forms.Panel();
            this.btnJira = new System.Windows.Forms.Button();
            this.btnMoveTransformDown = new System.Windows.Forms.Button();
            this.btnMoveTransformUp = new System.Windows.Forms.Button();
            this.btnAddTableNames = new System.Windows.Forms.Button();
            this.btnEditSelectedTransform = new System.Windows.Forms.Button();
            this.btnMacroSqlValues = new System.Windows.Forms.Button();
            this.btnRemoveSelectedTransform = new System.Windows.Forms.Button();
            this.btnMacroListStringComma = new System.Windows.Forms.Button();
            this.btnMacroListComma = new System.Windows.Forms.Button();
            this.pnlTransforms = new System.Windows.Forms.Panel();
            this.btnCopyTab = new System.Windows.Forms.Button();
            this.btnParagraphToAsterisk = new System.Windows.Forms.Button();
            this.lblTruncate = new System.Windows.Forms.Label();
            this.btnAsteriskToParagraph = new System.Windows.Forms.Button();
            this.txtTruncate = new System.Windows.Forms.TextBox();
            this.btnRemoveBlankLines = new System.Windows.Forms.Button();
            this.btnDistinct = new System.Windows.Forms.Button();
            this.lblStatusBar = new System.Windows.Forms.Label();
            this.tblLayout.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlActionButtons.SuspendLayout();
            this.pnlTransforms.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMain
            // 
            this.txtMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMain.Location = new System.Drawing.Point(1, 1);
            this.txtMain.Margin = new System.Windows.Forms.Padding(1, 1, 1, 58);
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMain.Size = new System.Drawing.Size(343, 491);
            this.txtMain.TabIndex = 0;
            this.txtMain.Click += new System.EventHandler(this.txtMain_Click);
            this.txtMain.TextChanged += new System.EventHandler(this.txtMain_TextChanged);
            this.txtMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMain_KeyPress);
            this.txtMain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMain_KeyUp);
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(443, 1);
            this.txtResult.Margin = new System.Windows.Forms.Padding(1, 1, 1, 58);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(343, 491);
            this.txtResult.TabIndex = 1;
            this.txtResult.TextChanged += new System.EventHandler(this.txtResult_TextChanged);
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(5, 119);
            this.btnCopyToClipboard.Margin = new System.Windows.Forms.Padding(1);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(95, 47);
            this.btnCopyToClipboard.TabIndex = 2;
            this.btnCopyToClipboard.Text = "Copy to clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // btnRemoveNewLines
            // 
            this.btnRemoveNewLines.Location = new System.Drawing.Point(0, 1);
            this.btnRemoveNewLines.Margin = new System.Windows.Forms.Padding(1);
            this.btnRemoveNewLines.Name = "btnRemoveNewLines";
            this.btnRemoveNewLines.Size = new System.Drawing.Size(80, 41);
            this.btnRemoveNewLines.TabIndex = 3;
            this.btnRemoveNewLines.Text = "Remove new lines";
            this.btnRemoveNewLines.UseVisualStyleBackColor = true;
            this.btnRemoveNewLines.Click += new System.EventHandler(this.btnRemoveNewLines_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(2, 455);
            this.btnApply.Margin = new System.Windows.Forms.Padding(1);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(95, 36);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // chkAutoApply
            // 
            this.chkAutoApply.AutoSize = true;
            this.chkAutoApply.Location = new System.Drawing.Point(0, 440);
            this.chkAutoApply.Margin = new System.Windows.Forms.Padding(1);
            this.chkAutoApply.Name = "chkAutoApply";
            this.chkAutoApply.Size = new System.Drawing.Size(75, 17);
            this.chkAutoApply.TabIndex = 5;
            this.chkAutoApply.Text = "auto-apply";
            this.chkAutoApply.UseVisualStyleBackColor = true;
            // 
            // lblFindReplace
            // 
            this.lblFindReplace.AutoSize = true;
            this.lblFindReplace.Location = new System.Drawing.Point(0, 51);
            this.lblFindReplace.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblFindReplace.Name = "lblFindReplace";
            this.lblFindReplace.Size = new System.Drawing.Size(82, 13);
            this.lblFindReplace.TabIndex = 7;
            this.lblFindReplace.Text = "Find + Replace:";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(2, 65);
            this.txtFind.Margin = new System.Windows.Forms.Padding(1);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(81, 20);
            this.txtFind.TabIndex = 8;
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(2, 83);
            this.txtReplace.Margin = new System.Windows.Forms.Padding(1);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(81, 20);
            this.txtReplace.TabIndex = 9;
            this.txtReplace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReplace_KeyPress);
            // 
            // btnUndoTransform
            // 
            this.btnUndoTransform.Location = new System.Drawing.Point(5, 3);
            this.btnUndoTransform.Margin = new System.Windows.Forms.Padding(1);
            this.btnUndoTransform.Name = "btnUndoTransform";
            this.btnUndoTransform.Size = new System.Drawing.Size(49, 35);
            this.btnUndoTransform.TabIndex = 10;
            this.btnUndoTransform.Text = "undo last";
            this.btnUndoTransform.UseVisualStyleBackColor = true;
            this.btnUndoTransform.Click += new System.EventHandler(this.btnUndoTransform_Click);
            // 
            // txtNewLineAfterXOccurences
            // 
            this.txtNewLineAfterXOccurences.Location = new System.Drawing.Point(1, 168);
            this.txtNewLineAfterXOccurences.Margin = new System.Windows.Forms.Padding(1);
            this.txtNewLineAfterXOccurences.Name = "txtNewLineAfterXOccurences";
            this.txtNewLineAfterXOccurences.Size = new System.Drawing.Size(45, 20);
            this.txtNewLineAfterXOccurences.TabIndex = 11;
            // 
            // txtNewLineAfterXOccurencesOfY
            // 
            this.txtNewLineAfterXOccurencesOfY.Location = new System.Drawing.Point(2, 199);
            this.txtNewLineAfterXOccurencesOfY.Margin = new System.Windows.Forms.Padding(1);
            this.txtNewLineAfterXOccurencesOfY.Name = "txtNewLineAfterXOccurencesOfY";
            this.txtNewLineAfterXOccurencesOfY.Size = new System.Drawing.Size(45, 20);
            this.txtNewLineAfterXOccurencesOfY.TabIndex = 12;
            this.txtNewLineAfterXOccurencesOfY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewLineAfterXOccurencesOfY_KeyPress);
            // 
            // lblNewLineAfterX
            // 
            this.lblNewLineAfterX.AutoSize = true;
            this.lblNewLineAfterX.Location = new System.Drawing.Point(-1, 154);
            this.lblNewLineAfterX.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblNewLineAfterX.Name = "lblNewLineAfterX";
            this.lblNewLineAfterX.Size = new System.Drawing.Size(75, 13);
            this.lblNewLineAfterX.TabIndex = 13;
            this.lblNewLineAfterX.Text = "New line after:";
            // 
            // lblNewLineOccurence
            // 
            this.lblNewLineOccurence.AutoSize = true;
            this.lblNewLineOccurence.Location = new System.Drawing.Point(0, 185);
            this.lblNewLineOccurence.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblNewLineOccurence.Name = "lblNewLineOccurence";
            this.lblNewLineOccurence.Size = new System.Drawing.Size(78, 13);
            this.lblNewLineOccurence.TabIndex = 14;
            this.lblNewLineOccurence.Text = "occurences of:";
            // 
            // lblMacros
            // 
            this.lblMacros.AutoSize = true;
            this.lblMacros.Location = new System.Drawing.Point(5, 48);
            this.lblMacros.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblMacros.Name = "lblMacros";
            this.lblMacros.Size = new System.Drawing.Size(45, 13);
            this.lblMacros.TabIndex = 15;
            this.lblMacros.Text = "Macros:";
            // 
            // btnMacroSqlQuery
            // 
            this.btnMacroSqlQuery.Location = new System.Drawing.Point(5, 66);
            this.btnMacroSqlQuery.Margin = new System.Windows.Forms.Padding(1);
            this.btnMacroSqlQuery.Name = "btnMacroSqlQuery";
            this.btnMacroSqlQuery.Size = new System.Drawing.Size(68, 44);
            this.btnMacroSqlQuery.TabIndex = 16;
            this.btnMacroSqlQuery.Text = "Sql formatter";
            this.btnMacroSqlQuery.UseVisualStyleBackColor = true;
            this.btnMacroSqlQuery.Click += new System.EventHandler(this.btnMacroSqlQuery_Click);
            // 
            // btnMacroSqlSelectFormatter
            // 
            this.btnMacroSqlSelectFormatter.Location = new System.Drawing.Point(74, 62);
            this.btnMacroSqlSelectFormatter.Margin = new System.Windows.Forms.Padding(1);
            this.btnMacroSqlSelectFormatter.Name = "btnMacroSqlSelectFormatter";
            this.btnMacroSqlSelectFormatter.Size = new System.Drawing.Size(69, 27);
            this.btnMacroSqlSelectFormatter.TabIndex = 17;
            this.btnMacroSqlSelectFormatter.Text = "SELECT";
            this.btnMacroSqlSelectFormatter.UseVisualStyleBackColor = true;
            this.btnMacroSqlSelectFormatter.Click += new System.EventHandler(this.btnMacroSqlSelectFormatter_Click);
            // 
            // btnClearTransforms
            // 
            this.btnClearTransforms.Location = new System.Drawing.Point(187, 37);
            this.btnClearTransforms.Margin = new System.Windows.Forms.Padding(1);
            this.btnClearTransforms.Name = "btnClearTransforms";
            this.btnClearTransforms.Size = new System.Drawing.Size(43, 35);
            this.btnClearTransforms.TabIndex = 18;
            this.btnClearTransforms.Text = "clear";
            this.btnClearTransforms.UseVisualStyleBackColor = true;
            this.btnClearTransforms.Click += new System.EventHandler(this.btnClearTransforms_Click);
            // 
            // btnBatchEdit
            // 
            this.btnBatchEdit.Location = new System.Drawing.Point(108, 131);
            this.btnBatchEdit.Margin = new System.Windows.Forms.Padding(1);
            this.btnBatchEdit.Name = "btnBatchEdit";
            this.btnBatchEdit.Size = new System.Drawing.Size(75, 35);
            this.btnBatchEdit.TabIndex = 19;
            this.btnBatchEdit.Text = "Batch edit";
            this.btnBatchEdit.UseVisualStyleBackColor = true;
            this.btnBatchEdit.Click += new System.EventHandler(this.btnBatchEdit_Click);
            // 
            // btnNewLineChars
            // 
            this.btnNewLineChars.Location = new System.Drawing.Point(1, 270);
            this.btnNewLineChars.Margin = new System.Windows.Forms.Padding(1);
            this.btnNewLineChars.Name = "btnNewLineChars";
            this.btnNewLineChars.Size = new System.Drawing.Size(95, 37);
            this.btnNewLineChars.TabIndex = 20;
            this.btnNewLineChars.Text = "\\n or \\r to new line";
            this.btnNewLineChars.UseVisualStyleBackColor = true;
            this.btnNewLineChars.Click += new System.EventHandler(this.btnNewLineChars_Click);
            // 
            // chkCaseSensitive
            // 
            this.chkCaseSensitive.AutoSize = true;
            this.chkCaseSensitive.Checked = true;
            this.chkCaseSensitive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCaseSensitive.Location = new System.Drawing.Point(0, 223);
            this.chkCaseSensitive.Margin = new System.Windows.Forms.Padding(1);
            this.chkCaseSensitive.Name = "chkCaseSensitive";
            this.chkCaseSensitive.Size = new System.Drawing.Size(94, 17);
            this.chkCaseSensitive.TabIndex = 21;
            this.chkCaseSensitive.Text = "Case sensitive";
            this.chkCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // chkBeforeOrAfter
            // 
            this.chkBeforeOrAfter.AutoSize = true;
            this.chkBeforeOrAfter.Location = new System.Drawing.Point(73, 155);
            this.chkBeforeOrAfter.Margin = new System.Windows.Forms.Padding(1);
            this.chkBeforeOrAfter.Name = "chkBeforeOrAfter";
            this.chkBeforeOrAfter.Size = new System.Drawing.Size(15, 14);
            this.chkBeforeOrAfter.TabIndex = 22;
            this.chkBeforeOrAfter.UseVisualStyleBackColor = true;
            this.chkBeforeOrAfter.CheckedChanged += new System.EventHandler(this.chkBeforeOrAfter_CheckedChanged);
            // 
            // tblLayout
            // 
            this.tblLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblLayout.ColumnCount = 4;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblLayout.Controls.Add(this.pnlActions, 3, 0);
            this.tblLayout.Controls.Add(this.txtMain, 0, 0);
            this.tblLayout.Controls.Add(this.pnlTransforms, 1, 0);
            this.tblLayout.Controls.Add(this.txtResult, 2, 0);
            this.tblLayout.Location = new System.Drawing.Point(16, 14);
            this.tblLayout.Margin = new System.Windows.Forms.Padding(1);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 1;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Size = new System.Drawing.Size(1019, 550);
            this.tblLayout.TabIndex = 23;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.txtInfo);
            this.pnlActions.Controls.Add(this.lstTransforms);
            this.pnlActions.Controls.Add(this.pnlActionButtons);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActions.Location = new System.Drawing.Point(788, 1);
            this.pnlActions.Margin = new System.Windows.Forms.Padding(1);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(230, 548);
            this.pnlActions.TabIndex = 0;
            // 
            // txtInfo
            // 
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtInfo.Location = new System.Drawing.Point(0, 304);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(1);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(230, 20);
            this.txtInfo.TabIndex = 22;
            // 
            // lstTransforms
            // 
            this.lstTransforms.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstTransforms.FormattingEnabled = true;
            this.lstTransforms.Location = new System.Drawing.Point(0, 0);
            this.lstTransforms.Margin = new System.Windows.Forms.Padding(1);
            this.lstTransforms.Name = "lstTransforms";
            this.lstTransforms.Size = new System.Drawing.Size(230, 303);
            this.lstTransforms.TabIndex = 21;
            this.lstTransforms.SelectedValueChanged += new System.EventHandler(this.lstTransforms_SelectedValueChanged);
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Controls.Add(this.btnJira);
            this.pnlActionButtons.Controls.Add(this.btnMoveTransformDown);
            this.pnlActionButtons.Controls.Add(this.btnMoveTransformUp);
            this.pnlActionButtons.Controls.Add(this.btnAddTableNames);
            this.pnlActionButtons.Controls.Add(this.btnEditSelectedTransform);
            this.pnlActionButtons.Controls.Add(this.btnMacroSqlValues);
            this.pnlActionButtons.Controls.Add(this.btnRemoveSelectedTransform);
            this.pnlActionButtons.Controls.Add(this.btnMacroListStringComma);
            this.pnlActionButtons.Controls.Add(this.btnMacroListComma);
            this.pnlActionButtons.Controls.Add(this.btnUndoTransform);
            this.pnlActionButtons.Controls.Add(this.btnMacroSqlSelectFormatter);
            this.pnlActionButtons.Controls.Add(this.btnMacroSqlQuery);
            this.pnlActionButtons.Controls.Add(this.btnCopyToClipboard);
            this.pnlActionButtons.Controls.Add(this.btnClearTransforms);
            this.pnlActionButtons.Controls.Add(this.btnBatchEdit);
            this.pnlActionButtons.Controls.Add(this.lblMacros);
            this.pnlActionButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActionButtons.Location = new System.Drawing.Point(0, 324);
            this.pnlActionButtons.Margin = new System.Windows.Forms.Padding(1);
            this.pnlActionButtons.Name = "pnlActionButtons";
            this.pnlActionButtons.Size = new System.Drawing.Size(230, 224);
            this.pnlActionButtons.TabIndex = 20;
            // 
            // btnJira
            // 
            this.btnJira.Location = new System.Drawing.Point(187, 143);
            this.btnJira.Name = "btnJira";
            this.btnJira.Size = new System.Drawing.Size(44, 23);
            this.btnJira.TabIndex = 24;
            this.btnJira.Text = "jira";
            this.btnJira.UseVisualStyleBackColor = true;
            this.btnJira.Click += new System.EventHandler(this.btnJira_Click);
            // 
            // btnMoveTransformDown
            // 
            this.btnMoveTransformDown.Location = new System.Drawing.Point(102, 19);
            this.btnMoveTransformDown.Name = "btnMoveTransformDown";
            this.btnMoveTransformDown.Size = new System.Drawing.Size(42, 21);
            this.btnMoveTransformDown.TabIndex = 29;
            this.btnMoveTransformDown.Text = "down";
            this.btnMoveTransformDown.UseVisualStyleBackColor = true;
            this.btnMoveTransformDown.Click += new System.EventHandler(this.btnMoveTransformDown_Click);
            // 
            // btnMoveTransformUp
            // 
            this.btnMoveTransformUp.Location = new System.Drawing.Point(102, 0);
            this.btnMoveTransformUp.Name = "btnMoveTransformUp";
            this.btnMoveTransformUp.Size = new System.Drawing.Size(42, 23);
            this.btnMoveTransformUp.TabIndex = 28;
            this.btnMoveTransformUp.Text = "up";
            this.btnMoveTransformUp.UseVisualStyleBackColor = true;
            this.btnMoveTransformUp.Click += new System.EventHandler(this.btnMoveTransformUp_Click);
            // 
            // btnAddTableNames
            // 
            this.btnAddTableNames.Location = new System.Drawing.Point(74, 88);
            this.btnAddTableNames.Name = "btnAddTableNames";
            this.btnAddTableNames.Size = new System.Drawing.Size(69, 23);
            this.btnAddTableNames.TabIndex = 24;
            this.btnAddTableNames.Text = "tbl names";
            this.btnAddTableNames.UseVisualStyleBackColor = true;
            this.btnAddTableNames.Click += new System.EventHandler(this.btnAddTableNames_Click);
            // 
            // btnEditSelectedTransform
            // 
            this.btnEditSelectedTransform.Enabled = false;
            this.btnEditSelectedTransform.Location = new System.Drawing.Point(183, 2);
            this.btnEditSelectedTransform.Margin = new System.Windows.Forms.Padding(1);
            this.btnEditSelectedTransform.Name = "btnEditSelectedTransform";
            this.btnEditSelectedTransform.Size = new System.Drawing.Size(46, 35);
            this.btnEditSelectedTransform.TabIndex = 23;
            this.btnEditSelectedTransform.Text = "Edit";
            this.btnEditSelectedTransform.UseVisualStyleBackColor = true;
            this.btnEditSelectedTransform.Click += new System.EventHandler(this.btnEditSelectedTransform_Click);
            // 
            // btnMacroSqlValues
            // 
            this.btnMacroSqlValues.Location = new System.Drawing.Point(141, 89);
            this.btnMacroSqlValues.Margin = new System.Windows.Forms.Padding(1);
            this.btnMacroSqlValues.Name = "btnMacroSqlValues";
            this.btnMacroSqlValues.Size = new System.Drawing.Size(51, 22);
            this.btnMacroSqlValues.TabIndex = 24;
            this.btnMacroSqlValues.Text = "Values()";
            this.btnMacroSqlValues.UseVisualStyleBackColor = true;
            this.btnMacroSqlValues.Click += new System.EventHandler(this.btnMacroSqlValues_Click);
            // 
            // btnRemoveSelectedTransform
            // 
            this.btnRemoveSelectedTransform.Location = new System.Drawing.Point(69, 3);
            this.btnRemoveSelectedTransform.Margin = new System.Windows.Forms.Padding(1);
            this.btnRemoveSelectedTransform.Name = "btnRemoveSelectedTransform";
            this.btnRemoveSelectedTransform.Size = new System.Drawing.Size(31, 35);
            this.btnRemoveSelectedTransform.TabIndex = 22;
            this.btnRemoveSelectedTransform.Text = "del";
            this.btnRemoveSelectedTransform.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedTransform.Click += new System.EventHandler(this.btnRemoveSelectedTransform_Click);
            // 
            // btnMacroListStringComma
            // 
            this.btnMacroListStringComma.Location = new System.Drawing.Point(141, 73);
            this.btnMacroListStringComma.Margin = new System.Windows.Forms.Padding(1);
            this.btnMacroListStringComma.Name = "btnMacroListStringComma";
            this.btnMacroListStringComma.Size = new System.Drawing.Size(42, 20);
            this.btnMacroListStringComma.TabIndex = 27;
            this.btnMacroListStringComma.Text = "\'List\',";
            this.btnMacroListStringComma.UseVisualStyleBackColor = true;
            this.btnMacroListStringComma.Click += new System.EventHandler(this.btnMacroListStringComma_Click);
            // 
            // btnMacroListComma
            // 
            this.btnMacroListComma.Location = new System.Drawing.Point(141, 56);
            this.btnMacroListComma.Margin = new System.Windows.Forms.Padding(1);
            this.btnMacroListComma.Name = "btnMacroListComma";
            this.btnMacroListComma.Size = new System.Drawing.Size(42, 19);
            this.btnMacroListComma.TabIndex = 20;
            this.btnMacroListComma.Text = "List,";
            this.btnMacroListComma.UseVisualStyleBackColor = true;
            this.btnMacroListComma.Click += new System.EventHandler(this.btnMacroListComma_Click);
            // 
            // pnlTransforms
            // 
            this.pnlTransforms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTransforms.Controls.Add(this.btnCopyTab);
            this.pnlTransforms.Controls.Add(this.btnParagraphToAsterisk);
            this.pnlTransforms.Controls.Add(this.lblTruncate);
            this.pnlTransforms.Controls.Add(this.btnAsteriskToParagraph);
            this.pnlTransforms.Controls.Add(this.txtTruncate);
            this.pnlTransforms.Controls.Add(this.btnRemoveBlankLines);
            this.pnlTransforms.Controls.Add(this.btnDistinct);
            this.pnlTransforms.Controls.Add(this.btnRemoveNewLines);
            this.pnlTransforms.Controls.Add(this.btnApply);
            this.pnlTransforms.Controls.Add(this.chkAutoApply);
            this.pnlTransforms.Controls.Add(this.chkBeforeOrAfter);
            this.pnlTransforms.Controls.Add(this.lblFindReplace);
            this.pnlTransforms.Controls.Add(this.chkCaseSensitive);
            this.pnlTransforms.Controls.Add(this.txtFind);
            this.pnlTransforms.Controls.Add(this.btnNewLineChars);
            this.pnlTransforms.Controls.Add(this.txtReplace);
            this.pnlTransforms.Controls.Add(this.txtNewLineAfterXOccurences);
            this.pnlTransforms.Controls.Add(this.txtNewLineAfterXOccurencesOfY);
            this.pnlTransforms.Controls.Add(this.lblNewLineAfterX);
            this.pnlTransforms.Controls.Add(this.lblNewLineOccurence);
            this.pnlTransforms.Location = new System.Drawing.Point(346, 1);
            this.pnlTransforms.Margin = new System.Windows.Forms.Padding(1);
            this.pnlTransforms.Name = "pnlTransforms";
            this.pnlTransforms.Size = new System.Drawing.Size(95, 548);
            this.pnlTransforms.TabIndex = 1;
            // 
            // btnCopyTab
            // 
            this.btnCopyTab.Location = new System.Drawing.Point(0, 246);
            this.btnCopyTab.Name = "btnCopyTab";
            this.btnCopyTab.Size = new System.Drawing.Size(95, 22);
            this.btnCopyTab.TabIndex = 30;
            this.btnCopyTab.Text = "Tab to clipboard";
            this.btnCopyTab.UseVisualStyleBackColor = true;
            this.btnCopyTab.Click += new System.EventHandler(this.btnCopyTab_Click);
            // 
            // btnParagraphToAsterisk
            // 
            this.btnParagraphToAsterisk.Location = new System.Drawing.Point(51, 386);
            this.btnParagraphToAsterisk.Name = "btnParagraphToAsterisk";
            this.btnParagraphToAsterisk.Size = new System.Drawing.Size(41, 23);
            this.btnParagraphToAsterisk.TabIndex = 29;
            this.btnParagraphToAsterisk.Text = "§=>*";
            this.btnParagraphToAsterisk.UseVisualStyleBackColor = true;
            this.btnParagraphToAsterisk.Click += new System.EventHandler(this.btnParagraphToAsterisk_Click);
            // 
            // lblTruncate
            // 
            this.lblTruncate.AutoSize = true;
            this.lblTruncate.Location = new System.Drawing.Point(1, 123);
            this.lblTruncate.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTruncate.Name = "lblTruncate";
            this.lblTruncate.Size = new System.Drawing.Size(50, 13);
            this.lblTruncate.TabIndex = 26;
            this.lblTruncate.Text = "Truncate";
            // 
            // btnAsteriskToParagraph
            // 
            this.btnAsteriskToParagraph.Location = new System.Drawing.Point(3, 386);
            this.btnAsteriskToParagraph.Name = "btnAsteriskToParagraph";
            this.btnAsteriskToParagraph.Size = new System.Drawing.Size(45, 23);
            this.btnAsteriskToParagraph.TabIndex = 28;
            this.btnAsteriskToParagraph.Text = "*=>§";
            this.btnAsteriskToParagraph.UseVisualStyleBackColor = true;
            this.btnAsteriskToParagraph.Click += new System.EventHandler(this.btnAsteriskToParagraph_Click);
            // 
            // txtTruncate
            // 
            this.txtTruncate.Location = new System.Drawing.Point(2, 136);
            this.txtTruncate.Margin = new System.Windows.Forms.Padding(1);
            this.txtTruncate.Name = "txtTruncate";
            this.txtTruncate.Size = new System.Drawing.Size(94, 20);
            this.txtTruncate.TabIndex = 25;
            this.txtTruncate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTruncate_KeyPress);
            // 
            // btnRemoveBlankLines
            // 
            this.btnRemoveBlankLines.Location = new System.Drawing.Point(2, 337);
            this.btnRemoveBlankLines.Margin = new System.Windows.Forms.Padding(1);
            this.btnRemoveBlankLines.Name = "btnRemoveBlankLines";
            this.btnRemoveBlankLines.Size = new System.Drawing.Size(92, 33);
            this.btnRemoveBlankLines.TabIndex = 24;
            this.btnRemoveBlankLines.Text = "remove blank lines";
            this.btnRemoveBlankLines.UseVisualStyleBackColor = true;
            this.btnRemoveBlankLines.Click += new System.EventHandler(this.btnRemoveBlankLines_Click);
            // 
            // btnDistinct
            // 
            this.btnDistinct.Location = new System.Drawing.Point(2, 313);
            this.btnDistinct.Margin = new System.Windows.Forms.Padding(1);
            this.btnDistinct.Name = "btnDistinct";
            this.btnDistinct.Size = new System.Drawing.Size(92, 24);
            this.btnDistinct.TabIndex = 23;
            this.btnDistinct.Text = "Distinct";
            this.btnDistinct.UseVisualStyleBackColor = true;
            this.btnDistinct.Click += new System.EventHandler(this.btnDistinct_Click);
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.AutoSize = true;
            this.lblStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatusBar.Location = new System.Drawing.Point(0, 573);
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(119, 13);
            this.lblStatusBar.TabIndex = 24;
            this.lblStatusBar.Text = "Left textbox: Line: Char:";
            // 
            // TextTransforms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 586);
            this.Controls.Add(this.lblStatusBar);
            this.Controls.Add(this.tblLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "TextTransforms";
            this.Text = "textr";
            this.tblLayout.ResumeLayout(false);
            this.tblLayout.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.pnlActionButtons.ResumeLayout(false);
            this.pnlActionButtons.PerformLayout();
            this.pnlTransforms.ResumeLayout(false);
            this.pnlTransforms.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMain;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.Button btnRemoveNewLines;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.CheckBox chkAutoApply;
        private System.Windows.Forms.Label lblFindReplace;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Button btnUndoTransform;
        private System.Windows.Forms.TextBox txtNewLineAfterXOccurences;
        private System.Windows.Forms.TextBox txtNewLineAfterXOccurencesOfY;
        private System.Windows.Forms.Label lblNewLineAfterX;
        private System.Windows.Forms.Label lblNewLineOccurence;
        private System.Windows.Forms.Label lblMacros;
        private System.Windows.Forms.Button btnMacroSqlQuery;
        private System.Windows.Forms.Button btnMacroSqlSelectFormatter;
        private System.Windows.Forms.Button btnClearTransforms;
        private System.Windows.Forms.Button btnBatchEdit;
        private System.Windows.Forms.Button btnNewLineChars;
        private System.Windows.Forms.CheckBox chkCaseSensitive;
        private System.Windows.Forms.CheckBox chkBeforeOrAfter;
        private System.Windows.Forms.TableLayoutPanel tblLayout;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Panel pnlTransforms;
        private System.Windows.Forms.Panel pnlActionButtons;
        private System.Windows.Forms.ListBox lstTransforms;
        private System.Windows.Forms.Button btnDistinct;
        private System.Windows.Forms.Button btnMacroListComma;
        private System.Windows.Forms.Button btnRemoveBlankLines;
        private System.Windows.Forms.Label lblTruncate;
        private System.Windows.Forms.TextBox txtTruncate;
        private System.Windows.Forms.Button btnMacroListStringComma;
        private System.Windows.Forms.Button btnMacroSqlValues;
        private System.Windows.Forms.Button btnEditSelectedTransform;
        private System.Windows.Forms.Button btnRemoveSelectedTransform;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button btnAddTableNames;
        private System.Windows.Forms.Button btnParagraphToAsterisk;
        private System.Windows.Forms.Button btnAsteriskToParagraph;
        private System.Windows.Forms.Button btnMoveTransformDown;
        private System.Windows.Forms.Button btnMoveTransformUp;
        private System.Windows.Forms.Button btnCopyTab;
        private System.Windows.Forms.Button btnJira;
        private System.Windows.Forms.Label lblStatusBar;
    }
}

