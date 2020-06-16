namespace JiraHelper
{
    partial class JiraHelperForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JiraHelperForm));
            this.lblImage = new System.Windows.Forms.Label();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.chkImageThumbnail = new System.Windows.Forms.CheckBox();
            this.txtRichEditor = new System.Windows.Forms.RichTextBox();
            this.btnCopyMultiImage = new System.Windows.Forms.Button();
            this.txtMultiImage = new System.Windows.Forms.TextBox();
            this.lblMultiImage = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.rdoImage = new System.Windows.Forms.RadioButton();
            this.rdoAttachedFile = new System.Windows.Forms.RadioButton();
            this.rdoLink = new System.Windows.Forms.RadioButton();
            this.txtLinkText = new System.Windows.Forms.TextBox();
            this.lblLinkText = new System.Windows.Forms.Label();
            this.lblExample = new System.Windows.Forms.Label();
            this.lblExampleText = new System.Windows.Forms.Label();
            this.txtFileNames = new System.Windows.Forms.TextBox();
            this.lblFileNames = new System.Windows.Forms.Label();
            this.lblRichTextShortcuts = new System.Windows.Forms.Label();
            this.btnCopyRichText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(12, 38);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(35, 13);
            this.lblImage.TabIndex = 0;
            this.lblImage.Text = "image";
            // 
            // txtImage
            // 
            this.txtImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImage.Location = new System.Drawing.Point(72, 35);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(322, 20);
            this.txtImage.TabIndex = 1;
            this.txtImage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImage_KeyPress);
            // 
            // chkImageThumbnail
            // 
            this.chkImageThumbnail.AutoSize = true;
            this.chkImageThumbnail.Checked = true;
            this.chkImageThumbnail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImageThumbnail.Location = new System.Drawing.Point(19, 99);
            this.chkImageThumbnail.Name = "chkImageThumbnail";
            this.chkImageThumbnail.Size = new System.Drawing.Size(71, 17);
            this.chkImageThumbnail.TabIndex = 2;
            this.chkImageThumbnail.Text = "thumbnail";
            this.chkImageThumbnail.UseVisualStyleBackColor = true;
            // 
            // txtRichEditor
            // 
            this.txtRichEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRichEditor.Location = new System.Drawing.Point(125, 273);
            this.txtRichEditor.Name = "txtRichEditor";
            this.txtRichEditor.Size = new System.Drawing.Size(269, 135);
            this.txtRichEditor.TabIndex = 3;
            this.txtRichEditor.Text = "";
            this.txtRichEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // btnCopyMultiImage
            // 
            this.btnCopyMultiImage.Location = new System.Drawing.Point(46, 122);
            this.btnCopyMultiImage.Name = "btnCopyMultiImage";
            this.btnCopyMultiImage.Size = new System.Drawing.Size(44, 23);
            this.btnCopyMultiImage.TabIndex = 4;
            this.btnCopyMultiImage.Text = "copy";
            this.btnCopyMultiImage.UseVisualStyleBackColor = true;
            this.btnCopyMultiImage.Click += new System.EventHandler(this.btnCopyMultiImage_Click);
            // 
            // txtMultiImage
            // 
            this.txtMultiImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMultiImage.Location = new System.Drawing.Point(96, 73);
            this.txtMultiImage.Multiline = true;
            this.txtMultiImage.Name = "txtMultiImage";
            this.txtMultiImage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMultiImage.Size = new System.Drawing.Size(298, 72);
            this.txtMultiImage.TabIndex = 5;
            // 
            // lblMultiImage
            // 
            this.lblMultiImage.AutoSize = true;
            this.lblMultiImage.Location = new System.Drawing.Point(12, 76);
            this.lblMultiImage.Name = "lblMultiImage";
            this.lblMultiImage.Size = new System.Drawing.Size(59, 13);
            this.lblMultiImage.TabIndex = 6;
            this.lblMultiImage.Text = "multi image";
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtResult.Location = new System.Drawing.Point(0, 413);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(406, 20);
            this.txtResult.TabIndex = 7;
            // 
            // rdoImage
            // 
            this.rdoImage.AutoSize = true;
            this.rdoImage.Checked = true;
            this.rdoImage.Location = new System.Drawing.Point(15, 12);
            this.rdoImage.Name = "rdoImage";
            this.rdoImage.Size = new System.Drawing.Size(54, 17);
            this.rdoImage.TabIndex = 8;
            this.rdoImage.TabStop = true;
            this.rdoImage.Text = "Image";
            this.rdoImage.UseVisualStyleBackColor = true;
            this.rdoImage.CheckedChanged += new System.EventHandler(this.rdoImage_CheckedChanged);
            // 
            // rdoAttachedFile
            // 
            this.rdoAttachedFile.AutoSize = true;
            this.rdoAttachedFile.Location = new System.Drawing.Point(125, 12);
            this.rdoAttachedFile.Name = "rdoAttachedFile";
            this.rdoAttachedFile.Size = new System.Drawing.Size(84, 17);
            this.rdoAttachedFile.TabIndex = 9;
            this.rdoAttachedFile.Text = "Attached file";
            this.rdoAttachedFile.UseVisualStyleBackColor = true;
            this.rdoAttachedFile.CheckedChanged += new System.EventHandler(this.rdoAttachedFile_CheckedChanged);
            // 
            // rdoLink
            // 
            this.rdoLink.AutoSize = true;
            this.rdoLink.Location = new System.Drawing.Point(266, 12);
            this.rdoLink.Name = "rdoLink";
            this.rdoLink.Size = new System.Drawing.Size(45, 17);
            this.rdoLink.TabIndex = 10;
            this.rdoLink.TabStop = true;
            this.rdoLink.Text = "Link";
            this.rdoLink.UseVisualStyleBackColor = true;
            this.rdoLink.CheckedChanged += new System.EventHandler(this.rdoLink_CheckedChanged);
            // 
            // txtLinkText
            // 
            this.txtLinkText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLinkText.Location = new System.Drawing.Point(96, 155);
            this.txtLinkText.Name = "txtLinkText";
            this.txtLinkText.Size = new System.Drawing.Size(298, 20);
            this.txtLinkText.TabIndex = 11;
            this.txtLinkText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLinkText_KeyPress);
            // 
            // lblLinkText
            // 
            this.lblLinkText.AutoSize = true;
            this.lblLinkText.Enabled = false;
            this.lblLinkText.Location = new System.Drawing.Point(12, 158);
            this.lblLinkText.Name = "lblLinkText";
            this.lblLinkText.Size = new System.Drawing.Size(43, 13);
            this.lblLinkText.TabIndex = 12;
            this.lblLinkText.Text = "link text";
            // 
            // lblExample
            // 
            this.lblExample.AutoSize = true;
            this.lblExample.Location = new System.Drawing.Point(69, 57);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(166, 13);
            this.lblExample.TabIndex = 13;
            this.lblExample.Text = "example: http://www.google.korv";
            this.lblExample.Visible = false;
            // 
            // lblExampleText
            // 
            this.lblExampleText.AutoSize = true;
            this.lblExampleText.Location = new System.Drawing.Point(93, 176);
            this.lblExampleText.Name = "lblExampleText";
            this.lblExampleText.Size = new System.Drawing.Size(84, 13);
            this.lblExampleText.TabIndex = 14;
            this.lblExampleText.Text = "example: google";
            this.lblExampleText.Visible = false;
            // 
            // txtFileNames
            // 
            this.txtFileNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileNames.Location = new System.Drawing.Point(12, 223);
            this.txtFileNames.Name = "txtFileNames";
            this.txtFileNames.Size = new System.Drawing.Size(382, 20);
            this.txtFileNames.TabIndex = 15;
            this.txtFileNames.Text = "Paste the path to a directory here to copy a list of its contents to the clipboar" +
    "d";
            this.txtFileNames.Enter += new System.EventHandler(this.txtFileNames_Enter);
            this.txtFileNames.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFileNames_KeyPress);
            this.txtFileNames.Leave += new System.EventHandler(this.txtFileNames_Leave);
            // 
            // lblFileNames
            // 
            this.lblFileNames.AutoSize = true;
            this.lblFileNames.Location = new System.Drawing.Point(12, 207);
            this.lblFileNames.Name = "lblFileNames";
            this.lblFileNames.Size = new System.Drawing.Size(47, 13);
            this.lblFileNames.TabIndex = 16;
            this.lblFileNames.Text = "List files:";
            // 
            // lblRichTextShortcuts
            // 
            this.lblRichTextShortcuts.AutoSize = true;
            this.lblRichTextShortcuts.Location = new System.Drawing.Point(9, 276);
            this.lblRichTextShortcuts.Name = "lblRichTextShortcuts";
            this.lblRichTextShortcuts.Size = new System.Drawing.Size(172, 13);
            this.lblRichTextShortcuts.TabIndex = 17;
            this.lblRichTextShortcuts.Text = "shortcuts = SetRichTextShortcuts()";
            // 
            // btnCopyRichText
            // 
            this.btnCopyRichText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyRichText.Location = new System.Drawing.Point(57, 384);
            this.btnCopyRichText.Name = "btnCopyRichText";
            this.btnCopyRichText.Size = new System.Drawing.Size(62, 23);
            this.btnCopyRichText.TabIndex = 18;
            this.btnCopyRichText.Text = "copy";
            this.btnCopyRichText.UseVisualStyleBackColor = true;
            this.btnCopyRichText.Click += new System.EventHandler(this.btnCopyRichText_Click);
            // 
            // JiraHelperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 433);
            this.Controls.Add(this.btnCopyRichText);
            this.Controls.Add(this.lblRichTextShortcuts);
            this.Controls.Add(this.txtRichEditor);
            this.Controls.Add(this.lblFileNames);
            this.Controls.Add(this.txtFileNames);
            this.Controls.Add(this.lblExampleText);
            this.Controls.Add(this.lblExample);
            this.Controls.Add(this.lblLinkText);
            this.Controls.Add(this.txtLinkText);
            this.Controls.Add(this.rdoLink);
            this.Controls.Add(this.rdoAttachedFile);
            this.Controls.Add(this.rdoImage);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblMultiImage);
            this.Controls.Add(this.txtMultiImage);
            this.Controls.Add(this.btnCopyMultiImage);
            this.Controls.Add(this.chkImageThumbnail);
            this.Controls.Add(this.txtImage);
            this.Controls.Add(this.lblImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JiraHelperForm";
            this.Text = "jira helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.CheckBox chkImageThumbnail;
        private System.Windows.Forms.RichTextBox txtRichEditor;
        private System.Windows.Forms.Button btnCopyMultiImage;
        private System.Windows.Forms.TextBox txtMultiImage;
        private System.Windows.Forms.Label lblMultiImage;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.RadioButton rdoImage;
        private System.Windows.Forms.RadioButton rdoAttachedFile;
        private System.Windows.Forms.RadioButton rdoLink;
        private System.Windows.Forms.TextBox txtLinkText;
        private System.Windows.Forms.Label lblLinkText;
        private System.Windows.Forms.Label lblExample;
        private System.Windows.Forms.Label lblExampleText;
        private System.Windows.Forms.TextBox txtFileNames;
        private System.Windows.Forms.Label lblFileNames;
        private System.Windows.Forms.Label lblRichTextShortcuts;
        private System.Windows.Forms.Button btnCopyRichText;
    }
}

