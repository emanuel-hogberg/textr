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
            this.chkXmlCasing = new System.Windows.Forms.CheckBox();
            this.btnXmlToJson = new System.Windows.Forms.Button();
            this.btnJsonToXml = new System.Windows.Forms.Button();
            this.btnJira = new System.Windows.Forms.Button();
            this.btnAsciiFrom = new System.Windows.Forms.Button();
            this.btnMoveTransformDown = new System.Windows.Forms.Button();
            this.btnMoveTransformUp = new System.Windows.Forms.Button();
            this.btnAddTableNames = new System.Windows.Forms.Button();
            this.btnEditSelectedTransform = new System.Windows.Forms.Button();
            this.btnMacroSqlValues = new System.Windows.Forms.Button();
            this.btnAsciiTo = new System.Windows.Forms.Button();
            this.btnRemoveSelectedTransform = new System.Windows.Forms.Button();
            this.btnMacroListStringComma = new System.Windows.Forms.Button();
            this.btnMacroListComma = new System.Windows.Forms.Button();
            this.pnlTransforms = new System.Windows.Forms.Panel();
            this.btnMath = new System.Windows.Forms.Button();
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
            this.txtMain.Location = new System.Drawing.Point(2, 2);
            this.txtMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 33);
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMain.Size = new System.Drawing.Size(629, 943);
            this.txtMain.TabIndex = 0;
            this.txtMain.Click += new System.EventHandler(this.TxtMain_Click);
            this.txtMain.TextChanged += new System.EventHandler(this.TxtMain_TextChanged);
            this.txtMain.Enter += new System.EventHandler(this.txtMain_Enter);
            this.txtMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMain_KeyPress);
            this.txtMain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtMain_KeyUp);
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(813, 2);
            this.txtResult.Margin = new System.Windows.Forms.Padding(2, 2, 2, 33);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(629, 943);
            this.txtResult.TabIndex = 1;
            this.txtResult.TextChanged += new System.EventHandler(this.TxtResult_TextChanged);
            this.txtResult.Enter += new System.EventHandler(this.txtResult_Enter);
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(6, 295);
            this.btnCopyToClipboard.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(174, 87);
            this.btnCopyToClipboard.TabIndex = 2;
            this.btnCopyToClipboard.Text = "Copy to clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.BtnCopyToClipboard_Click);
            // 
            // btnRemoveNewLines
            // 
            this.btnRemoveNewLines.Location = new System.Drawing.Point(0, 2);
            this.btnRemoveNewLines.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveNewLines.Name = "btnRemoveNewLines";
            this.btnRemoveNewLines.Size = new System.Drawing.Size(147, 76);
            this.btnRemoveNewLines.TabIndex = 3;
            this.btnRemoveNewLines.Text = "Remove new lines";
            this.btnRemoveNewLines.UseVisualStyleBackColor = true;
            this.btnRemoveNewLines.Click += new System.EventHandler(this.BtnRemoveNewLines_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(0, 875);
            this.btnApply.Margin = new System.Windows.Forms.Padding(2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(174, 66);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // chkAutoApply
            // 
            this.chkAutoApply.AutoSize = true;
            this.chkAutoApply.Location = new System.Drawing.Point(-4, 847);
            this.chkAutoApply.Margin = new System.Windows.Forms.Padding(2);
            this.chkAutoApply.Name = "chkAutoApply";
            this.chkAutoApply.Size = new System.Drawing.Size(130, 29);
            this.chkAutoApply.TabIndex = 5;
            this.chkAutoApply.Text = "auto-apply";
            this.chkAutoApply.UseVisualStyleBackColor = true;
            // 
            // lblFindReplace
            // 
            this.lblFindReplace.AutoSize = true;
            this.lblFindReplace.Location = new System.Drawing.Point(0, 94);
            this.lblFindReplace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFindReplace.Name = "lblFindReplace";
            this.lblFindReplace.Size = new System.Drawing.Size(149, 25);
            this.lblFindReplace.TabIndex = 7;
            this.lblFindReplace.Text = "Find + Replace:";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(4, 120);
            this.txtFind.Margin = new System.Windows.Forms.Padding(2);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(162, 29);
            this.txtFind.TabIndex = 8;
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFind_KeyPress);
            // 
            // txtReplace
            // 
            this.txtReplace.Location = new System.Drawing.Point(4, 153);
            this.txtReplace.Margin = new System.Windows.Forms.Padding(2);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(162, 29);
            this.txtReplace.TabIndex = 9;
            this.txtReplace.Click += new System.EventHandler(this.txtReplace_Click);
            this.txtReplace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtReplace_KeyPress);
            // 
            // btnUndoTransform
            // 
            this.btnUndoTransform.Location = new System.Drawing.Point(9, 6);
            this.btnUndoTransform.Margin = new System.Windows.Forms.Padding(2);
            this.btnUndoTransform.Name = "btnUndoTransform";
            this.btnUndoTransform.Size = new System.Drawing.Size(90, 65);
            this.btnUndoTransform.TabIndex = 10;
            this.btnUndoTransform.Text = "undo last";
            this.btnUndoTransform.UseVisualStyleBackColor = true;
            this.btnUndoTransform.Click += new System.EventHandler(this.BtnUndoTransform_Click);
            // 
            // txtNewLineAfterXOccurences
            // 
            this.txtNewLineAfterXOccurences.Location = new System.Drawing.Point(2, 310);
            this.txtNewLineAfterXOccurences.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewLineAfterXOccurences.Name = "txtNewLineAfterXOccurences";
            this.txtNewLineAfterXOccurences.Size = new System.Drawing.Size(79, 29);
            this.txtNewLineAfterXOccurences.TabIndex = 11;
            this.txtNewLineAfterXOccurences.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewLineAfterXOccurences_KeyPress);
            // 
            // txtNewLineAfterXOccurencesOfY
            // 
            this.txtNewLineAfterXOccurencesOfY.Location = new System.Drawing.Point(4, 367);
            this.txtNewLineAfterXOccurencesOfY.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewLineAfterXOccurencesOfY.Name = "txtNewLineAfterXOccurencesOfY";
            this.txtNewLineAfterXOccurencesOfY.Size = new System.Drawing.Size(162, 29);
            this.txtNewLineAfterXOccurencesOfY.TabIndex = 12;
            this.txtNewLineAfterXOccurencesOfY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNewLineAfterXOccurencesOfY_KeyPress);
            // 
            // lblNewLineAfterX
            // 
            this.lblNewLineAfterX.AutoSize = true;
            this.lblNewLineAfterX.Location = new System.Drawing.Point(-2, 284);
            this.lblNewLineAfterX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewLineAfterX.Name = "lblNewLineAfterX";
            this.lblNewLineAfterX.Size = new System.Drawing.Size(135, 25);
            this.lblNewLineAfterX.TabIndex = 13;
            this.lblNewLineAfterX.Text = "New line after:";
            // 
            // lblNewLineOccurence
            // 
            this.lblNewLineOccurence.AutoSize = true;
            this.lblNewLineOccurence.Location = new System.Drawing.Point(0, 342);
            this.lblNewLineOccurence.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewLineOccurence.Name = "lblNewLineOccurence";
            this.lblNewLineOccurence.Size = new System.Drawing.Size(140, 25);
            this.lblNewLineOccurence.TabIndex = 14;
            this.lblNewLineOccurence.Text = "occurences of:";
            // 
            // lblMacros
            // 
            this.lblMacros.AutoSize = true;
            this.lblMacros.Location = new System.Drawing.Point(9, 89);
            this.lblMacros.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMacros.Name = "lblMacros";
            this.lblMacros.Size = new System.Drawing.Size(83, 25);
            this.lblMacros.TabIndex = 15;
            this.lblMacros.Text = "Macros:";
            // 
            // btnMacroSqlQuery
            // 
            this.btnMacroSqlQuery.Location = new System.Drawing.Point(9, 122);
            this.btnMacroSqlQuery.Margin = new System.Windows.Forms.Padding(2);
            this.btnMacroSqlQuery.Name = "btnMacroSqlQuery";
            this.btnMacroSqlQuery.Size = new System.Drawing.Size(125, 81);
            this.btnMacroSqlQuery.TabIndex = 16;
            this.btnMacroSqlQuery.Text = "Sql formatter";
            this.btnMacroSqlQuery.UseVisualStyleBackColor = true;
            this.btnMacroSqlQuery.Click += new System.EventHandler(this.BtnMacroSqlQuery_Click);
            // 
            // btnMacroSqlSelectFormatter
            // 
            this.btnMacroSqlSelectFormatter.Location = new System.Drawing.Point(136, 114);
            this.btnMacroSqlSelectFormatter.Margin = new System.Windows.Forms.Padding(2);
            this.btnMacroSqlSelectFormatter.Name = "btnMacroSqlSelectFormatter";
            this.btnMacroSqlSelectFormatter.Size = new System.Drawing.Size(126, 50);
            this.btnMacroSqlSelectFormatter.TabIndex = 17;
            this.btnMacroSqlSelectFormatter.Text = "SELECT";
            this.btnMacroSqlSelectFormatter.UseVisualStyleBackColor = true;
            this.btnMacroSqlSelectFormatter.Click += new System.EventHandler(this.BtnMacroSqlSelectFormatter_Click);
            // 
            // btnClearTransforms
            // 
            this.btnClearTransforms.Location = new System.Drawing.Point(343, 68);
            this.btnClearTransforms.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearTransforms.Name = "btnClearTransforms";
            this.btnClearTransforms.Size = new System.Drawing.Size(79, 65);
            this.btnClearTransforms.TabIndex = 18;
            this.btnClearTransforms.Text = "clear";
            this.btnClearTransforms.UseVisualStyleBackColor = true;
            this.btnClearTransforms.Click += new System.EventHandler(this.BtnClearTransforms_Click);
            // 
            // btnBatchEdit
            // 
            this.btnBatchEdit.Location = new System.Drawing.Point(194, 318);
            this.btnBatchEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnBatchEdit.Name = "btnBatchEdit";
            this.btnBatchEdit.Size = new System.Drawing.Size(138, 65);
            this.btnBatchEdit.TabIndex = 19;
            this.btnBatchEdit.Text = "Batch edit";
            this.btnBatchEdit.UseVisualStyleBackColor = true;
            this.btnBatchEdit.Click += new System.EventHandler(this.BtnBatchEdit_Click);
            // 
            // btnNewLineChars
            // 
            this.btnNewLineChars.Location = new System.Drawing.Point(2, 498);
            this.btnNewLineChars.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewLineChars.Name = "btnNewLineChars";
            this.btnNewLineChars.Size = new System.Drawing.Size(174, 68);
            this.btnNewLineChars.TabIndex = 20;
            this.btnNewLineChars.Text = "\\n or \\r to new line";
            this.btnNewLineChars.UseVisualStyleBackColor = true;
            this.btnNewLineChars.Click += new System.EventHandler(this.BtnNewLineChars_Click);
            // 
            // chkCaseSensitive
            // 
            this.chkCaseSensitive.AutoSize = true;
            this.chkCaseSensitive.Checked = true;
            this.chkCaseSensitive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCaseSensitive.Location = new System.Drawing.Point(0, 412);
            this.chkCaseSensitive.Margin = new System.Windows.Forms.Padding(2);
            this.chkCaseSensitive.Name = "chkCaseSensitive";
            this.chkCaseSensitive.Size = new System.Drawing.Size(166, 29);
            this.chkCaseSensitive.TabIndex = 21;
            this.chkCaseSensitive.Text = "Case sensitive";
            this.chkCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // chkBeforeOrAfter
            // 
            this.chkBeforeOrAfter.AutoSize = true;
            this.chkBeforeOrAfter.Location = new System.Drawing.Point(134, 286);
            this.chkBeforeOrAfter.Margin = new System.Windows.Forms.Padding(2);
            this.chkBeforeOrAfter.Name = "chkBeforeOrAfter";
            this.chkBeforeOrAfter.Size = new System.Drawing.Size(22, 21);
            this.chkBeforeOrAfter.TabIndex = 22;
            this.chkBeforeOrAfter.UseVisualStyleBackColor = true;
            this.chkBeforeOrAfter.CheckedChanged += new System.EventHandler(this.ChkBeforeOrAfter_CheckedChanged);
            // 
            // tblLayout
            // 
            this.tblLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblLayout.ColumnCount = 4;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblLayout.Controls.Add(this.pnlActions, 3, 0);
            this.tblLayout.Controls.Add(this.txtMain, 0, 0);
            this.tblLayout.Controls.Add(this.pnlTransforms, 1, 0);
            this.tblLayout.Controls.Add(this.txtResult, 2, 0);
            this.tblLayout.Location = new System.Drawing.Point(29, 26);
            this.tblLayout.Margin = new System.Windows.Forms.Padding(2);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 2;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tblLayout.Size = new System.Drawing.Size(1868, 1015);
            this.tblLayout.TabIndex = 23;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.txtInfo);
            this.pnlActions.Controls.Add(this.lstTransforms);
            this.pnlActions.Controls.Add(this.pnlActionButtons);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActions.Location = new System.Drawing.Point(1446, 2);
            this.pnlActions.Margin = new System.Windows.Forms.Padding(2);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(420, 974);
            this.pnlActions.TabIndex = 0;
            // 
            // txtInfo
            // 
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtInfo.Location = new System.Drawing.Point(0, 531);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(2);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(420, 29);
            this.txtInfo.TabIndex = 22;
            // 
            // lstTransforms
            // 
            this.lstTransforms.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstTransforms.FormattingEnabled = true;
            this.lstTransforms.ItemHeight = 24;
            this.lstTransforms.Location = new System.Drawing.Point(0, 0);
            this.lstTransforms.Margin = new System.Windows.Forms.Padding(2);
            this.lstTransforms.Name = "lstTransforms";
            this.lstTransforms.Size = new System.Drawing.Size(420, 556);
            this.lstTransforms.TabIndex = 21;
            this.lstTransforms.SelectedValueChanged += new System.EventHandler(this.LstTransforms_SelectedValueChanged);
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Controls.Add(this.chkXmlCasing);
            this.pnlActionButtons.Controls.Add(this.btnXmlToJson);
            this.pnlActionButtons.Controls.Add(this.btnJsonToXml);
            this.pnlActionButtons.Controls.Add(this.btnJira);
            this.pnlActionButtons.Controls.Add(this.btnAsciiFrom);
            this.pnlActionButtons.Controls.Add(this.btnMoveTransformDown);
            this.pnlActionButtons.Controls.Add(this.btnMoveTransformUp);
            this.pnlActionButtons.Controls.Add(this.btnAddTableNames);
            this.pnlActionButtons.Controls.Add(this.btnEditSelectedTransform);
            this.pnlActionButtons.Controls.Add(this.btnMacroSqlValues);
            this.pnlActionButtons.Controls.Add(this.btnAsciiTo);
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
            this.pnlActionButtons.Location = new System.Drawing.Point(0, 560);
            this.pnlActionButtons.Margin = new System.Windows.Forms.Padding(2);
            this.pnlActionButtons.Name = "pnlActionButtons";
            this.pnlActionButtons.Size = new System.Drawing.Size(420, 414);
            this.pnlActionButtons.TabIndex = 20;
            // 
            // chkXmlCasing
            // 
            this.chkXmlCasing.AutoSize = true;
            this.chkXmlCasing.Checked = true;
            this.chkXmlCasing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXmlCasing.Location = new System.Drawing.Point(180, 253);
            this.chkXmlCasing.Margin = new System.Windows.Forms.Padding(6);
            this.chkXmlCasing.Name = "chkXmlCasing";
            this.chkXmlCasing.Size = new System.Drawing.Size(168, 29);
            this.chkXmlCasing.TabIndex = 34;
            this.chkXmlCasing.Text = "<PascalCase>";
            this.chkXmlCasing.UseVisualStyleBackColor = true;
            this.chkXmlCasing.CheckedChanged += new System.EventHandler(this.chkXmlCasing_CheckedChanged);
            // 
            // btnXmlToJson
            // 
            this.btnXmlToJson.Location = new System.Drawing.Point(308, 212);
            this.btnXmlToJson.Margin = new System.Windows.Forms.Padding(6);
            this.btnXmlToJson.Name = "btnXmlToJson";
            this.btnXmlToJson.Size = new System.Drawing.Size(59, 42);
            this.btnXmlToJson.TabIndex = 33;
            this.btnXmlToJson.Text = "<=";
            this.btnXmlToJson.UseVisualStyleBackColor = true;
            this.btnXmlToJson.Click += new System.EventHandler(this.btnXmlToJson_Click);
            // 
            // btnJsonToXml
            // 
            this.btnJsonToXml.Location = new System.Drawing.Point(180, 212);
            this.btnJsonToXml.Margin = new System.Windows.Forms.Padding(6);
            this.btnJsonToXml.Name = "btnJsonToXml";
            this.btnJsonToXml.Size = new System.Drawing.Size(130, 42);
            this.btnJsonToXml.TabIndex = 32;
            this.btnJsonToXml.Text = "json => xml";
            this.btnJsonToXml.UseVisualStyleBackColor = true;
            this.btnJsonToXml.Click += new System.EventHandler(this.btnJsonToXml_Click);
            // 
            // btnJira
            // 
            this.btnJira.Location = new System.Drawing.Point(339, 340);
            this.btnJira.Margin = new System.Windows.Forms.Padding(6);
            this.btnJira.Name = "btnJira";
            this.btnJira.Size = new System.Drawing.Size(81, 42);
            this.btnJira.TabIndex = 24;
            this.btnJira.Text = "jira";
            this.btnJira.UseVisualStyleBackColor = true;
            this.btnJira.Click += new System.EventHandler(this.BtnJira_Click);
            // 
            // btnAsciiFrom
            // 
            this.btnAsciiFrom.Location = new System.Drawing.Point(99, 212);
            this.btnAsciiFrom.Margin = new System.Windows.Forms.Padding(6);
            this.btnAsciiFrom.Name = "btnAsciiFrom";
            this.btnAsciiFrom.Size = new System.Drawing.Size(70, 42);
            this.btnAsciiFrom.TabIndex = 31;
            this.btnAsciiFrom.Text = "<=";
            this.btnAsciiFrom.UseVisualStyleBackColor = true;
            this.btnAsciiFrom.Click += new System.EventHandler(this.btnAsciiFrom_Click);
            // 
            // btnMoveTransformDown
            // 
            this.btnMoveTransformDown.Location = new System.Drawing.Point(187, 35);
            this.btnMoveTransformDown.Margin = new System.Windows.Forms.Padding(6);
            this.btnMoveTransformDown.Name = "btnMoveTransformDown";
            this.btnMoveTransformDown.Size = new System.Drawing.Size(77, 39);
            this.btnMoveTransformDown.TabIndex = 29;
            this.btnMoveTransformDown.Text = "down";
            this.btnMoveTransformDown.UseVisualStyleBackColor = true;
            this.btnMoveTransformDown.Click += new System.EventHandler(this.BtnMoveTransformDown_Click);
            // 
            // btnMoveTransformUp
            // 
            this.btnMoveTransformUp.Location = new System.Drawing.Point(187, 0);
            this.btnMoveTransformUp.Margin = new System.Windows.Forms.Padding(6);
            this.btnMoveTransformUp.Name = "btnMoveTransformUp";
            this.btnMoveTransformUp.Size = new System.Drawing.Size(77, 42);
            this.btnMoveTransformUp.TabIndex = 28;
            this.btnMoveTransformUp.Text = "up";
            this.btnMoveTransformUp.UseVisualStyleBackColor = true;
            this.btnMoveTransformUp.Click += new System.EventHandler(this.BtnMoveTransformUp_Click);
            // 
            // btnAddTableNames
            // 
            this.btnAddTableNames.Location = new System.Drawing.Point(136, 162);
            this.btnAddTableNames.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddTableNames.Name = "btnAddTableNames";
            this.btnAddTableNames.Size = new System.Drawing.Size(126, 42);
            this.btnAddTableNames.TabIndex = 24;
            this.btnAddTableNames.Text = "tbl names";
            this.btnAddTableNames.UseVisualStyleBackColor = true;
            this.btnAddTableNames.Click += new System.EventHandler(this.BtnAddTableNames_Click);
            // 
            // btnEditSelectedTransform
            // 
            this.btnEditSelectedTransform.Enabled = false;
            this.btnEditSelectedTransform.Location = new System.Drawing.Point(336, 4);
            this.btnEditSelectedTransform.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditSelectedTransform.Name = "btnEditSelectedTransform";
            this.btnEditSelectedTransform.Size = new System.Drawing.Size(84, 65);
            this.btnEditSelectedTransform.TabIndex = 23;
            this.btnEditSelectedTransform.Text = "Edit";
            this.btnEditSelectedTransform.UseVisualStyleBackColor = true;
            this.btnEditSelectedTransform.Click += new System.EventHandler(this.BtnEditSelectedTransform_Click);
            // 
            // btnMacroSqlValues
            // 
            this.btnMacroSqlValues.Location = new System.Drawing.Point(258, 164);
            this.btnMacroSqlValues.Margin = new System.Windows.Forms.Padding(2);
            this.btnMacroSqlValues.Name = "btnMacroSqlValues";
            this.btnMacroSqlValues.Size = new System.Drawing.Size(94, 41);
            this.btnMacroSqlValues.TabIndex = 24;
            this.btnMacroSqlValues.Text = "Values()";
            this.btnMacroSqlValues.UseVisualStyleBackColor = true;
            this.btnMacroSqlValues.Click += new System.EventHandler(this.BtnMacroSqlValues_Click);
            // 
            // btnAsciiTo
            // 
            this.btnAsciiTo.Location = new System.Drawing.Point(6, 210);
            this.btnAsciiTo.Margin = new System.Windows.Forms.Padding(6);
            this.btnAsciiTo.Name = "btnAsciiTo";
            this.btnAsciiTo.Size = new System.Drawing.Size(95, 44);
            this.btnAsciiTo.TabIndex = 2;
            this.btnAsciiTo.Text = "=> Ascii";
            this.btnAsciiTo.UseVisualStyleBackColor = true;
            this.btnAsciiTo.Click += new System.EventHandler(this.btnAsciiTo_Click);
            // 
            // btnRemoveSelectedTransform
            // 
            this.btnRemoveSelectedTransform.Location = new System.Drawing.Point(126, 6);
            this.btnRemoveSelectedTransform.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveSelectedTransform.Name = "btnRemoveSelectedTransform";
            this.btnRemoveSelectedTransform.Size = new System.Drawing.Size(57, 65);
            this.btnRemoveSelectedTransform.TabIndex = 22;
            this.btnRemoveSelectedTransform.Text = "del";
            this.btnRemoveSelectedTransform.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedTransform.Click += new System.EventHandler(this.BtnRemoveSelectedTransform_Click);
            // 
            // btnMacroListStringComma
            // 
            this.btnMacroListStringComma.Location = new System.Drawing.Point(258, 135);
            this.btnMacroListStringComma.Margin = new System.Windows.Forms.Padding(2);
            this.btnMacroListStringComma.Name = "btnMacroListStringComma";
            this.btnMacroListStringComma.Size = new System.Drawing.Size(77, 37);
            this.btnMacroListStringComma.TabIndex = 27;
            this.btnMacroListStringComma.Text = "\'List\',";
            this.btnMacroListStringComma.UseVisualStyleBackColor = true;
            this.btnMacroListStringComma.Click += new System.EventHandler(this.BtnMacroListStringComma_Click);
            // 
            // btnMacroListComma
            // 
            this.btnMacroListComma.Location = new System.Drawing.Point(258, 103);
            this.btnMacroListComma.Margin = new System.Windows.Forms.Padding(2);
            this.btnMacroListComma.Name = "btnMacroListComma";
            this.btnMacroListComma.Size = new System.Drawing.Size(77, 35);
            this.btnMacroListComma.TabIndex = 20;
            this.btnMacroListComma.Text = "List,";
            this.btnMacroListComma.UseVisualStyleBackColor = true;
            this.btnMacroListComma.Click += new System.EventHandler(this.BtnMacroListComma_Click);
            // 
            // pnlTransforms
            // 
            this.pnlTransforms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTransforms.Controls.Add(this.btnMath);
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
            this.pnlTransforms.Location = new System.Drawing.Point(635, 2);
            this.pnlTransforms.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTransforms.Name = "pnlTransforms";
            this.pnlTransforms.Size = new System.Drawing.Size(174, 974);
            this.pnlTransforms.TabIndex = 1;
            // 
            // btnMath
            // 
            this.btnMath.Location = new System.Drawing.Point(4, 803);
            this.btnMath.Margin = new System.Windows.Forms.Padding(6);
            this.btnMath.Name = "btnMath";
            this.btnMath.Size = new System.Drawing.Size(165, 37);
            this.btnMath.TabIndex = 32;
            this.btnMath.Text = "Math expr";
            this.btnMath.UseVisualStyleBackColor = true;
            this.btnMath.Click += new System.EventHandler(this.btnMath_Click);
            this.btnMath.MouseEnter += new System.EventHandler(this.btnMath_MouseEnter);
            this.btnMath.MouseLeave += new System.EventHandler(this.btnMath_MouseLeave);
            // 
            // btnCopyTab
            // 
            this.btnCopyTab.Location = new System.Drawing.Point(0, 454);
            this.btnCopyTab.Margin = new System.Windows.Forms.Padding(6);
            this.btnCopyTab.Name = "btnCopyTab";
            this.btnCopyTab.Size = new System.Drawing.Size(174, 41);
            this.btnCopyTab.TabIndex = 30;
            this.btnCopyTab.Text = "Tab to clipboard";
            this.btnCopyTab.UseVisualStyleBackColor = true;
            this.btnCopyTab.Click += new System.EventHandler(this.BtnCopyTab_Click);
            // 
            // btnParagraphToAsterisk
            // 
            this.btnParagraphToAsterisk.Location = new System.Drawing.Point(94, 713);
            this.btnParagraphToAsterisk.Margin = new System.Windows.Forms.Padding(6);
            this.btnParagraphToAsterisk.Name = "btnParagraphToAsterisk";
            this.btnParagraphToAsterisk.Size = new System.Drawing.Size(75, 42);
            this.btnParagraphToAsterisk.TabIndex = 29;
            this.btnParagraphToAsterisk.Text = "§=>*";
            this.btnParagraphToAsterisk.UseVisualStyleBackColor = true;
            this.btnParagraphToAsterisk.Click += new System.EventHandler(this.BtnParagraphToAsterisk_Click);
            // 
            // lblTruncate
            // 
            this.lblTruncate.AutoSize = true;
            this.lblTruncate.Location = new System.Drawing.Point(2, 227);
            this.lblTruncate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTruncate.Name = "lblTruncate";
            this.lblTruncate.Size = new System.Drawing.Size(90, 25);
            this.lblTruncate.TabIndex = 26;
            this.lblTruncate.Text = "Truncate";
            // 
            // btnAsteriskToParagraph
            // 
            this.btnAsteriskToParagraph.Location = new System.Drawing.Point(6, 713);
            this.btnAsteriskToParagraph.Margin = new System.Windows.Forms.Padding(6);
            this.btnAsteriskToParagraph.Name = "btnAsteriskToParagraph";
            this.btnAsteriskToParagraph.Size = new System.Drawing.Size(82, 42);
            this.btnAsteriskToParagraph.TabIndex = 28;
            this.btnAsteriskToParagraph.Text = "*=>§";
            this.btnAsteriskToParagraph.UseVisualStyleBackColor = true;
            this.btnAsteriskToParagraph.Click += new System.EventHandler(this.BtnAsteriskToParagraph_Click);
            // 
            // txtTruncate
            // 
            this.txtTruncate.Location = new System.Drawing.Point(4, 251);
            this.txtTruncate.Margin = new System.Windows.Forms.Padding(2);
            this.txtTruncate.Name = "txtTruncate";
            this.txtTruncate.Size = new System.Drawing.Size(169, 29);
            this.txtTruncate.TabIndex = 25;
            this.txtTruncate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTruncate_KeyPress);
            // 
            // btnRemoveBlankLines
            // 
            this.btnRemoveBlankLines.Location = new System.Drawing.Point(4, 622);
            this.btnRemoveBlankLines.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveBlankLines.Name = "btnRemoveBlankLines";
            this.btnRemoveBlankLines.Size = new System.Drawing.Size(169, 61);
            this.btnRemoveBlankLines.TabIndex = 24;
            this.btnRemoveBlankLines.Text = "remove blank lines";
            this.btnRemoveBlankLines.UseVisualStyleBackColor = true;
            this.btnRemoveBlankLines.Click += new System.EventHandler(this.BtnRemoveBlankLines_Click);
            // 
            // btnDistinct
            // 
            this.btnDistinct.Location = new System.Drawing.Point(4, 578);
            this.btnDistinct.Margin = new System.Windows.Forms.Padding(2);
            this.btnDistinct.Name = "btnDistinct";
            this.btnDistinct.Size = new System.Drawing.Size(169, 44);
            this.btnDistinct.TabIndex = 23;
            this.btnDistinct.Text = "Distinct";
            this.btnDistinct.UseVisualStyleBackColor = true;
            this.btnDistinct.Click += new System.EventHandler(this.BtnDistinct_Click);
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.AutoSize = true;
            this.lblStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatusBar.Location = new System.Drawing.Point(0, 1057);
            this.lblStatusBar.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(220, 25);
            this.lblStatusBar.TabIndex = 24;
            this.lblStatusBar.Text = "Left textbox: Line: Char:";
            // 
            // TextTransforms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1930, 1082);
            this.Controls.Add(this.lblStatusBar);
            this.Controls.Add(this.tblLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Button btnAsciiFrom;
        private System.Windows.Forms.Button btnAsciiTo;
        private System.Windows.Forms.Button btnMath;
        private System.Windows.Forms.Button btnXmlToJson;
        private System.Windows.Forms.Button btnJsonToXml;
        private System.Windows.Forms.CheckBox chkXmlCasing;
    }
}

