using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using emanuel.Extensions;
using emanuel.Transforms;
using StringTransforms.Interfaces;

namespace emanuel
{
    public partial class BatchEdit : Form
    {
        public BatchEdit(string source = "")
        {
            InitializeComponent();

            txtSource.Text = source;
        }
        public event EventHandler TransformFound;
        private IBatchEditLineTransform foundTransform;
        public List<ITransform> FoundTransforms
        {
            get => foundTransform
                .With(transform =>
                {
                    transform.OnlyViewAffectedLines = true;
                    transform.Predecessor = null;
                })
                .Forward(t => chkChangeAsteriskIntoParagraph.Checked ?
                    new List<ITransform>()
                    {
                        findReplaceAsterisk,
                        t,
                        new FindReplaceTransform("§", "*")
                    }
                : new List<ITransform>() { t });
        }

        private bool justOpened = true;
        private bool transformNotChanged = true;

        public string Source { get; set; }
        public string Selection { get; set; }
        public string Transform { get; set; }

        private List<IBatchEditLineTransform> Lines { get; set; }

        private FindReplaceTransform findReplaceAsterisk = new FindReplaceTransform("*", "§");

        private enum UpdatePart
        {
            Source,
            Selection,
            Transform
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            Source = txtSource.Text;

            if (justOpened)
            {
                txtSelection.TextChanged -= txtSelection_TextChanged;
                txtTransform.TextChanged -= txtTransform_TextChanged;

                txtSelection.Text = txtSource.Text.Trim().Length > 0 ? txtSource.Text.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).First() : txtSource.Text;
                Selection = txtSelection.Text;

                txtTransform.Text = txtSelection.Text;
                Transform = txtTransform.Text;

                txtTransform.TextChanged += txtTransform_TextChanged;
                txtSelection.TextChanged += txtSelection_TextChanged;

                UpdateResult(UpdatePart.Source);
                UpdateResult(UpdatePart.Selection);
                UpdateResult(UpdatePart.Transform);
            }
            else
            {
                UpdateResult(UpdatePart.Source);
            }
        }
        private void txtSelection_TextChanged(object sender, EventArgs e)
        {
            Selection = txtSelection.Text;

            if (transformNotChanged && txtSelection.Text != string.Empty)
            {
                txtTransform.TextChanged -= txtTransform_TextChanged;
                txtTransform.Text = txtSelection.Text;
                Transform = txtTransform.Text;
                txtTransform.TextChanged += txtTransform_TextChanged;
                UpdateResult(UpdatePart.Selection);
                UpdateResult(UpdatePart.Transform);
            }
            else
            {
                UpdateResult(UpdatePart.Selection);
            }


            if (justOpened)
                justOpened = false;
        }

        private void txtTransform_TextChanged(object sender, EventArgs e)
        {
            Transform = txtTransform.Text;
            UpdateResult(UpdatePart.Transform);

            if (transformNotChanged)
            {
                justOpened = false;
                transformNotChanged = false;
            }
        }

        private IBatchEditLineTransform NewTransform(string text)
            => rdoSelection.Checked ? new GroupTransform(text) { Predecessor = chkChangeAsteriskIntoParagraph.Checked ? findReplaceAsterisk : null } : new FormatTransform(text) { Predecessor = chkChangeAsteriskIntoParagraph.Checked ? findReplaceAsterisk : null };

        private void UpdateResult(UpdatePart part)
        {
            bool sourceUpdated = false;

            if (part == UpdatePart.Source || Lines == null)
            {
                Lines = txtSource.Text
                    .Split(new string[] { Environment.NewLine }, StringSplitOptions.None)
                    .Select(text => NewTransform(text))
                    .ToList();
                sourceUpdated = true;
            }

            Func<Action<IBatchEditLineTransform>, string> updateResult = func =>
                Lines
                    .Do(line => func(line))
                    .Select(line => line.Result)
                    .AggregateToString(Environment.NewLine);

            if (!string.IsNullOrEmpty(Selection) && (part == UpdatePart.Selection || sourceUpdated))
            {
                txtResult.Text = updateResult(line => line
                        .Select(Selection)
                        .SetTransform(Transform));
                txtSelectionView.Text = Lines
                    .Select(line => line.Selection)
                    .AggregateToString(Environment.NewLine);
            }
            else if (!string.IsNullOrEmpty(Selection) && !string.IsNullOrEmpty(Transform))
            {
                txtResult.Text = updateResult(line => line
                        .SetTransform(Transform));
            }
            else if (string.IsNullOrEmpty(Transform) && part == UpdatePart.Transform)
            {
                Lines.ForEach(line => line.SetTransform(Transform));
                txtResult.Text = string.Empty;
            }
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtResult.Text);
        }

        private void btnUseAsTransform_Click(object sender, EventArgs e)
        {
            if (TransformFound != null && Lines.Any(line => line.Match))
            {
                foundTransform = Lines.First(line => line.Match);
                TransformFound(this, new EventArgs());
                this.Close();
            }
        }

        private void ChangeBatchEditMode()
        {
            if (Lines != null && Lines.First().GetType() != NewTransform("").GetType())
            {
                Lines = Lines
                    .Select(line => line.CopyTo(NewTransform(line.Line)))
                    .ToList();
            }

            (Lines.AnyAndNotNull() ? Lines.First() : NewTransform(""))
                .With(t =>
                {
                    label1.Text = t.GetDescription();
                    label2.Text = t.GetTransformDescription();
                    lblHint.Text = t.GetTransformHint()
                        .Forward(hint => string.IsNullOrEmpty(hint) ? string.Empty : string.Concat("Hint: ", hint));
                });
        }

        private void rdoSelection_CheckedChanged(object sender, EventArgs e)
        {
            ChangeBatchEditMode();
        }

        private void btnReInit_Click(object sender, EventArgs e)
        {
            txtSelection.Text = txtTransform.Text = string.Empty;
            justOpened = true;
            transformNotChanged = true;
            string t;
            (txtSource.Text, t) = (string.Empty, txtSource.Text);
            txtSource.Text = t;
        }

        private void chkChangeAsteriskIntoParagraph_CheckedChanged(object sender, EventArgs e)
        {
            Lines
                .Do(line => line.Predecessor = chkChangeAsteriskIntoParagraph.Checked ? findReplaceAsterisk : null);
            UpdateResult(UpdatePart.Selection);
        }
    }
}
