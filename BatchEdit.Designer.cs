namespace emanuel
{
    partial class BatchEdit
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
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtSelectionView = new System.Windows.Forms.TextBox();
            this.txtSelection = new System.Windows.Forms.TextBox();
            this.txtTransform = new System.Windows.Forms.TextBox();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.btnUseAsTransform = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoSelection = new System.Windows.Forms.RadioButton();
            this.rdoFormat = new System.Windows.Forms.RadioButton();
            this.btnReInit = new System.Windows.Forms.Button();
            this.chkChangeAsteriskIntoParagraph = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(5, 5);
            this.txtSource.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSource.Size = new System.Drawing.Size(282, 299);
            this.txtSource.TabIndex = 0;
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // txtSelectionView
            // 
            this.txtSelectionView.Location = new System.Drawing.Point(293, 5);
            this.txtSelectionView.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtSelectionView.Multiline = true;
            this.txtSelectionView.Name = "txtSelectionView";
            this.txtSelectionView.ReadOnly = true;
            this.txtSelectionView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSelectionView.Size = new System.Drawing.Size(282, 299);
            this.txtSelectionView.TabIndex = 1;
            // 
            // txtSelection
            // 
            this.txtSelection.Location = new System.Drawing.Point(5, 332);
            this.txtSelection.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtSelection.Name = "txtSelection";
            this.txtSelection.Size = new System.Drawing.Size(490, 20);
            this.txtSelection.TabIndex = 2;
            this.txtSelection.TextChanged += new System.EventHandler(this.txtSelection_TextChanged);
            // 
            // txtTransform
            // 
            this.txtTransform.Location = new System.Drawing.Point(5, 368);
            this.txtTransform.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtTransform.Name = "txtTransform";
            this.txtTransform.Size = new System.Drawing.Size(490, 20);
            this.txtTransform.TabIndex = 3;
            this.txtTransform.TextChanged += new System.EventHandler(this.txtTransform_TextChanged);
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(782, 315);
            this.btnCopyToClipboard.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(78, 50);
            this.btnCopyToClipboard.TabIndex = 4;
            this.btnCopyToClipboard.Text = "Copy to clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // btnUseAsTransform
            // 
            this.btnUseAsTransform.Location = new System.Drawing.Point(782, 368);
            this.btnUseAsTransform.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnUseAsTransform.Name = "btnUseAsTransform";
            this.btnUseAsTransform.Size = new System.Drawing.Size(78, 46);
            this.btnUseAsTransform.TabIndex = 5;
            this.btnUseAsTransform.Text = "Use as transform";
            this.btnUseAsTransform.UseVisualStyleBackColor = true;
            this.btnUseAsTransform.Click += new System.EventHandler(this.btnUseAsTransform_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(581, 5);
            this.txtResult.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(282, 299);
            this.txtResult.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 315);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Selection (e.g. text*where* selects two groups in this text: \"text hello where so" +
    "mething\")";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 353);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Transform text from the above selection (e.g. text2*wear gives the new text \"text" +
    "2 hello wear something\")";
            // 
            // rdoSelection
            // 
            this.rdoSelection.AutoSize = true;
            this.rdoSelection.Checked = true;
            this.rdoSelection.Location = new System.Drawing.Point(511, 315);
            this.rdoSelection.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.rdoSelection.Name = "rdoSelection";
            this.rdoSelection.Size = new System.Drawing.Size(69, 17);
            this.rdoSelection.TabIndex = 9;
            this.rdoSelection.TabStop = true;
            this.rdoSelection.Text = "Selection";
            this.rdoSelection.UseVisualStyleBackColor = true;
            this.rdoSelection.CheckedChanged += new System.EventHandler(this.rdoSelection_CheckedChanged);
            // 
            // rdoFormat
            // 
            this.rdoFormat.AutoSize = true;
            this.rdoFormat.Location = new System.Drawing.Point(511, 332);
            this.rdoFormat.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.rdoFormat.Name = "rdoFormat";
            this.rdoFormat.Size = new System.Drawing.Size(57, 17);
            this.rdoFormat.TabIndex = 10;
            this.rdoFormat.Text = "Format";
            this.rdoFormat.UseVisualStyleBackColor = true;
            this.rdoFormat.CheckedChanged += new System.EventHandler(this.rdoFormat_CheckedChanged);
            // 
            // btnReInit
            // 
            this.btnReInit.Location = new System.Drawing.Point(507, 351);
            this.btnReInit.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnReInit.Name = "btnReInit";
            this.btnReInit.Size = new System.Drawing.Size(58, 29);
            this.btnReInit.TabIndex = 11;
            this.btnReInit.Text = "Re-init";
            this.btnReInit.UseVisualStyleBackColor = true;
            this.btnReInit.Click += new System.EventHandler(this.btnReInit_Click);
            // 
            // chkChangeAsteriskIntoParagraph
            // 
            this.chkChangeAsteriskIntoParagraph.AutoSize = true;
            this.chkChangeAsteriskIntoParagraph.Location = new System.Drawing.Point(623, 390);
            this.chkChangeAsteriskIntoParagraph.Name = "chkChangeAsteriskIntoParagraph";
            this.chkChangeAsteriskIntoParagraph.Size = new System.Drawing.Size(155, 17);
            this.chkChangeAsteriskIntoParagraph.TabIndex = 12;
            this.chkChangeAsteriskIntoParagraph.Text = "Temporarily change * into §";
            this.chkChangeAsteriskIntoParagraph.UseVisualStyleBackColor = true;
            this.chkChangeAsteriskIntoParagraph.CheckedChanged += new System.EventHandler(this.chkChangeAsteriskIntoParagraph_CheckedChanged);
            // 
            // BatchEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 419);
            this.Controls.Add(this.chkChangeAsteriskIntoParagraph);
            this.Controls.Add(this.btnReInit);
            this.Controls.Add(this.rdoFormat);
            this.Controls.Add(this.rdoSelection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnUseAsTransform);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.txtTransform);
            this.Controls.Add(this.txtSelection);
            this.Controls.Add(this.txtSelectionView);
            this.Controls.Add(this.txtSource);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "BatchEdit";
            this.Text = "BatchEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtSelectionView;
        private System.Windows.Forms.TextBox txtSelection;
        private System.Windows.Forms.TextBox txtTransform;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.Button btnUseAsTransform;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoSelection;
        private System.Windows.Forms.RadioButton rdoFormat;
        private System.Windows.Forms.Button btnReInit;
        private System.Windows.Forms.CheckBox chkChangeAsteriskIntoParagraph;
    }
}