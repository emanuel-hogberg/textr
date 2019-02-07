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
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(12, 12);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSource.Size = new System.Drawing.Size(652, 662);
            this.txtSource.TabIndex = 0;
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // txtSelectionView
            // 
            this.txtSelectionView.Location = new System.Drawing.Point(684, 12);
            this.txtSelectionView.Multiline = true;
            this.txtSelectionView.Name = "txtSelectionView";
            this.txtSelectionView.ReadOnly = true;
            this.txtSelectionView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSelectionView.Size = new System.Drawing.Size(652, 662);
            this.txtSelectionView.TabIndex = 1;
            // 
            // txtSelection
            // 
            this.txtSelection.Location = new System.Drawing.Point(12, 741);
            this.txtSelection.Name = "txtSelection";
            this.txtSelection.Size = new System.Drawing.Size(1137, 35);
            this.txtSelection.TabIndex = 2;
            this.txtSelection.TextChanged += new System.EventHandler(this.txtSelection_TextChanged);
            // 
            // txtTransform
            // 
            this.txtTransform.Location = new System.Drawing.Point(12, 820);
            this.txtTransform.Name = "txtTransform";
            this.txtTransform.Size = new System.Drawing.Size(1137, 35);
            this.txtTransform.TabIndex = 3;
            this.txtTransform.TextChanged += new System.EventHandler(this.txtTransform_TextChanged);
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(1825, 703);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(182, 111);
            this.btnCopyToClipboard.TabIndex = 4;
            this.btnCopyToClipboard.Text = "Copy to clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // btnUseAsTransform
            // 
            this.btnUseAsTransform.Location = new System.Drawing.Point(1825, 820);
            this.btnUseAsTransform.Name = "btnUseAsTransform";
            this.btnUseAsTransform.Size = new System.Drawing.Size(182, 102);
            this.btnUseAsTransform.TabIndex = 5;
            this.btnUseAsTransform.Text = "Use as transform";
            this.btnUseAsTransform.UseVisualStyleBackColor = true;
            this.btnUseAsTransform.Click += new System.EventHandler(this.btnUseAsTransform_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(1355, 12);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(652, 662);
            this.txtResult.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 703);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(939, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Selection (e.g. text*where* selects two groups in this text: \"text hello where so" +
    "mething\")";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 788);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1119, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Transform text from the above selection (e.g. text2*wear gives the new text \"text" +
    "2 hello wear something\")";
            // 
            // rdoSelection
            // 
            this.rdoSelection.AutoSize = true;
            this.rdoSelection.Checked = true;
            this.rdoSelection.Location = new System.Drawing.Point(1192, 703);
            this.rdoSelection.Name = "rdoSelection";
            this.rdoSelection.Size = new System.Drawing.Size(145, 33);
            this.rdoSelection.TabIndex = 9;
            this.rdoSelection.TabStop = true;
            this.rdoSelection.Text = "Selection";
            this.rdoSelection.UseVisualStyleBackColor = true;
            this.rdoSelection.CheckedChanged += new System.EventHandler(this.rdoSelection_CheckedChanged);
            // 
            // rdoFormat
            // 
            this.rdoFormat.AutoSize = true;
            this.rdoFormat.Location = new System.Drawing.Point(1192, 741);
            this.rdoFormat.Name = "rdoFormat";
            this.rdoFormat.Size = new System.Drawing.Size(120, 33);
            this.rdoFormat.TabIndex = 10;
            this.rdoFormat.Text = "Format";
            this.rdoFormat.UseVisualStyleBackColor = true;
            this.rdoFormat.CheckedChanged += new System.EventHandler(this.rdoFormat_CheckedChanged);
            // 
            // btnReInit
            // 
            this.btnReInit.Location = new System.Drawing.Point(1670, 858);
            this.btnReInit.Name = "btnReInit";
            this.btnReInit.Size = new System.Drawing.Size(136, 64);
            this.btnReInit.TabIndex = 11;
            this.btnReInit.Text = "Re-init";
            this.btnReInit.UseVisualStyleBackColor = true;
            this.btnReInit.Click += new System.EventHandler(this.btnReInit_Click);
            // 
            // BatchEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2028, 934);
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
    }
}