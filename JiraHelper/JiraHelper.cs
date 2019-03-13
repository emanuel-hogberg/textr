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
        public JiraHelperForm()
        {
            InitializeComponent();
            SetRichTextShortcuts();
        }

        private bool EnterPressed(KeyPressEventArgs e)
            => e.KeyChar == (char)13;

        private string Clip { set { Clipboard.SetText(value); txtResult.Text = $"Clipboard set to: {value.Replace(Environment.NewLine, "\\n")}"; } }

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
            lblRichTextShortcuts.Text = new string[] { "F3 = Bold", "F4 = Italics", "F5 = noformat", "F6 = color" }
                .AggregateToString(Environment.NewLine);
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtRichEditor.SelectedText.Any())
            {
                switch (e.KeyData)
                {
                    case Keys.F3:
                        txtRichEditor.SelectionFont = new Font(txtRichEditor.SelectionFont, (txtRichEditor.SelectionFont.Bold ? FontStyle.Regular : FontStyle.Bold) | (txtRichEditor.SelectionFont.Italic ? FontStyle.Italic : FontStyle.Regular));
                        return;
                    case Keys.F4:
                        txtRichEditor.SelectionFont = new Font(txtRichEditor.SelectionFont, (txtRichEditor.SelectionFont.Italic ? FontStyle.Regular : FontStyle.Italic) | (txtRichEditor.SelectionFont.Bold ? FontStyle.Bold : FontStyle.Regular));
                        return;
                    case Keys.F5:
                        txtRichEditor.SelectedText = string.Concat(Environment.NewLine, "{noformat}", txtRichEditor.SelectedText, "{noformat}", Environment.NewLine);
                        return;
                    case Keys.F6:
                        txtRichEditor.SelectedText = string.Concat("{color:red}", txtRichEditor.SelectedText, "{color}");
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
        /// tuple (bold, italics) returns *txt* or _txt_.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private IEnumerable<string> EnumeratePerFont(RichTextBox t)
        {
            (int s, int i) = (0, 0);
            var font = (false, false);

            Func<Font, (bool, bool)> tuple = f => (f.Bold, f.Italic);
            Func<int, int, (bool, bool)> getFont = (a, b) =>
            {
                t.SelectionStart = a;
                t.SelectionLength = b - a + 1;
                return tuple(t.SelectionFont);
            };
            Func<bool> notSameFont = () => getFont(i + 1, i + 1)
                .Forward(iFont => font.Item1 != iFont.Item1 || font.Item2 != iFont.Item2);
            Func<string> yieldSelection = () => t
                .Forward(r =>
                {
                    t.SelectionStart = s;
                    t.SelectionLength = i - s + 1;
                    return t.SelectedText;
                })
                .Forward(sel => font.Item1 ? $"*{sel}*" : sel)
                .Forward(sel => font.Item2 ? $"_{sel}_" : sel);

            for (i = 0; i < t.Text.Length; i++)
            {
                if (s == i)
                {
                    font = getFont(s, i);
                }
                
                if (notSameFont())
                {
                    yield return yieldSelection();
                    s = i + 1;
                }
            }
            yield return yieldSelection();
        }
    }
}
