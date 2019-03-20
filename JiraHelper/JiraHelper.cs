using emanuel.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiraHelper
{
    public partial class JiraHelperForm : Form
    {
        private string txtFileNamesDescription = "Paste the path to a directory here to copy a list of its contents to the clipboard";

        public JiraHelperForm()
        {
            InitializeComponent();
            SetRichTextShortcuts();
        }

        private bool EnterPressed(KeyPressEventArgs e)
            => e.KeyChar == (char)13;

        private string Clip
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Clipboard.SetText(value);
                    txtResult.Text = $"Clipboard set to: {value.Replace(Environment.NewLine, "\\n")}";
                }
                else
                {
                    txtResult.Text = "Nothing to copy.";
                }
            }
        }

        private void txtImage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EnterPressed(e))
            {
                if (rdoLink.Checked)
                {
                    txtLinkText.Select();
                }
                else
                {
                    Clip = Apply(txtImage.Text.Trim());
                }
            }
        }

        private void Apply()
        {
            Clip = txtMultiImage.Text.Any() ?
                            txtMultiImage.Text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => Apply(s))
                            .AggregateToString(Environment.NewLine)
                            : Apply(txtImage.Text.Trim());
        }

        private string Apply(string text)
            => rdoImage.Checked ? FormatAsImage(text)
                : rdoLink.Checked ? FormatAsLink(text)
                : FormatAsAttachement(text);

        private string FormatAsAttachement(string text)
            => $"[^{text}]";

        private string FormatAsLink(string text)
            => txtLinkText
                .Forward(l => l.Text.Any() ? $"{l.Text}|" : string.Empty)
                .Forward(linkText => $"[{linkText}{text}]");

        private string FormatAsImage(string text)
        => chkImageThumbnail
                .Forward(chk => chk.Checked ? "|thumbnail" : string.Empty)
                .Forward(thumb => $"!{text}{thumb}!");

        private void btnCopyMultiImage_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void txtLinkText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EnterPressed(e))
            {
                rdoLink.Checked = true;
                if (txtImage.Text.Any())
                {
                    Apply();
                }
                else
                {
                    txtImage.Select();
                }
            }
        }

        private void rdoImage_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoImage.Checked)
            {
                lblImage.Text = "image";
                lblMultiImage.Text = "multi image";
                lblLinkText.Enabled = false;
                chkImageThumbnail.Enabled = true;
                txtImage.Select();
                lblExample.Visible = false;
                lblExampleText.Visible = false;
            }
        }

        private void rdoAttachedFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAttachedFile.Checked)
            {
                lblImage.Text = "attachment";
                lblMultiImage.Text = "multi attachment";
                lblLinkText.Enabled = false;
                chkImageThumbnail.Enabled = false;
                txtImage.Select();
                lblExample.Visible = false;
                lblExampleText.Visible = false;
            }
        }

        private void rdoLink_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoLink.Checked)
            {
                lblImage.Text = "link";
                lblMultiImage.Text = "link image";
                lblLinkText.Enabled = true;
                chkImageThumbnail.Enabled = false;
                txtImage.Select();
                lblExample.Visible = true;
                lblExampleText.Visible = true;
            }
        }

        private void txtFileNames_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EnterPressed(e))
            {
                txtFileNames.Text.Do(path => {
                    if (path.Any())
                    {
                        if (Directory.Exists(path))
                        {
                            Clip = Directory.EnumerateFiles(path)
                                .Select(f => f.Replace(path, string.Empty).Replace("\\", string.Empty))
                                .AggregateToString(Environment.NewLine);
                        }
                        else
                        {
                            txtResult.Text = $"Directory {path} does not exist!";
                        }
                    }
                    else
                    {
                        new FolderBrowserDialog().Do(d =>
                        {
                            if (d.ShowDialog() == DialogResult.OK)
                            {
                                txtFileNames.Text = d.SelectedPath;
                            }
                        });
                    }
                });
            }
        }

        private void SetRichTextShortcuts()
        {
            lblRichTextShortcuts.Text = new string[] { "F3 = Bold", "F4 = Italics", "F5 = noformat", "F6 = color", "F7 = underscore", "F8 = strikethrough" }
                .AggregateToString(Environment.NewLine);
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtRichEditor.SelectedText.Any())
            {
                Func<string, string, string> Concat = (s1, s2) => string.Concat(s1, txtRichEditor.SelectedText, s2);
                Func<string, string> Surround = (s) => Concat(s, s);
                Func<string, string, string> SurroundAgain = (s, surrounding) => String.Concat(s, surrounding, s);
                Func<FontStyle, bool, FontStyle> ToggleFontStyle = (fontStyleToToggle, currentSetting) => (currentSetting ? FontStyle.Regular : fontStyleToToggle);

                FontStyle Italics = txtRichEditor.SelectionFont.Italic ? FontStyle.Italic : FontStyle.Regular;
                FontStyle Bold = txtRichEditor.SelectionFont.Bold ? FontStyle.Bold : FontStyle.Regular;
                FontStyle Underline = txtRichEditor.SelectionFont.Underline ? FontStyle.Underline : FontStyle.Regular;
                FontStyle Strikeout = txtRichEditor.SelectionFont.Strikeout ? FontStyle.Strikeout : FontStyle.Regular;
                FontStyle AmendFont;
                
                switch (e.KeyData)
                {
                    case Keys.F3:
                        AmendFont = ToggleFontStyle(FontStyle.Bold, txtRichEditor.SelectionFont.Bold);
                        txtRichEditor.SelectionFont = new Font(txtRichEditor.SelectionFont, AmendFont | Italics | Underline | Strikeout);
                        return;
                    case Keys.F4:
                        AmendFont = ToggleFontStyle(FontStyle.Italic, txtRichEditor.SelectionFont.Italic);
                        txtRichEditor.SelectionFont = new Font(txtRichEditor.SelectionFont, AmendFont | Bold | Underline | Strikeout);
                        return;
                    case Keys.F5:
                        txtRichEditor.SelectedText = SurroundAgain(Environment.NewLine, Surround("{noformat}"));
                        return;
                    case Keys.F6:
                        txtRichEditor.SelectedText = Concat("{color:red}", "{color}");
                        return;
                    case Keys.F7:
                        AmendFont = ToggleFontStyle(FontStyle.Strikeout, txtRichEditor.SelectionFont.Strikeout);
                        txtRichEditor.SelectionFont = new Font(txtRichEditor.SelectionFont, AmendFont | Bold | Italics | Underline);
                        return;
                    case Keys.F8:
                        AmendFont = ToggleFontStyle(FontStyle.Underline, txtRichEditor.SelectionFont.Underline);
                        txtRichEditor.SelectionFont = new Font(txtRichEditor.SelectionFont, AmendFont | Bold | Italics | Strikeout);
                        return;
                    default:
                        return;
                }
            }
        }

        private void btnCopyRichText_Click(object sender, EventArgs e)
        {
            if (txtRichEditor.Text.Any())
            {
                Clip = EnumeratePerFont(txtRichEditor)
                    .AggregateToString(string.Empty);
            }
        }

        /// <summary>
        /// tuple (bold, italics, underline, strikeout) returns *txt*, _txt_, -txt- or +txt+.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private IEnumerable<string> EnumeratePerFont(RichTextBox t)
        {
            (int s, int i, string newLine) = (0, 0, string.Empty);
            var font = (false, false, false, false);

            Func<Font, (bool, bool, bool, bool)> tuple = f => (f.Bold, f.Italic, f.Underline, f.Strikeout);
            Func<int, int, (bool, bool, bool, bool)> getFont = (a, b) =>
            {
                t.SelectionStart = a;
                t.SelectionLength = b - a + 1;
                return tuple(t.SelectionFont);
            };
            Func<bool> currentCharIsNewline = () => t.Text.Substring(i, 1) == "\n";
            Func<bool> nextCharIsNewline = () => t.Text.Length > i + 1 && t.Text.Substring(i + 1, 1) == "\n";
            Func<bool> notSameFont = () => getFont(i + 1, i + 1)
                .Forward(iFont => font.Item1 != iFont.Item1 || font.Item2 != iFont.Item2 || font.Item3 != iFont.Item3 || font.Item4 != iFont.Item4);
            Func<string> yieldSelection = () => t
                .Forward(r =>
                {
                    t.SelectionStart = s;
                    t.SelectionLength = i - s + 1;
                    return t.SelectedText;
                })
                .Forward(sel => font.Item1 ? $"*{sel}*" : sel)
                .Forward(sel => font.Item2 ? $"_{sel}_" : sel)
                .Forward(sel => font.Item3 ? $"-{sel}-" : sel)
                .Forward(sel => font.Item4 ? $"+{sel}+" : sel);

            for (i = 0; i < t.Text.Length; i++)
            {
                if (s == i)
                {
                    if (currentCharIsNewline())
                    {
                        if (i == 0 || nextCharIsNewline())
                            yield return Environment.NewLine;
                        s = i + 1;
                        continue;
                    }
                    font = getFont(s, i);
                }
                
                if (notSameFont().OrForceEvaluation(() => nextCharIsNewline().AssignForward(isNewLine => isNewLine ? Environment.NewLine : string.Empty, out newLine)))
                {
                    yield return yieldSelection() + newLine;
                    s = i + 1;
                }
            }
            yield return yieldSelection();
        }


        private void txtFileNames_Leave(object sender, EventArgs e)
        {
            if (txtFileNames.Text == "")
                txtFileNames.Text = txtFileNamesDescription;
        }

        private void txtFileNames_Enter(object sender, EventArgs e)
        {
            if (txtFileNames.Text == txtFileNamesDescription)
                txtFileNames.Text = "";
        }
    }
}
