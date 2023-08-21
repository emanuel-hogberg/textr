using emanuel.Extensions;
using StringTransforms;
using StringTransforms.Interfaces;

namespace StringTransforms.Transforms
{
    public class TruncateTransform : EditableTransform
    {
        public string Truncate { get; set; }
        public bool FromStart { get; set; }
        public bool IgnoreCase { get; set; }

        public override void Save(IEditableProperties amendments)
        {
            amendments.DoAs<TruncateEdit>(a =>
            {
                Truncate = a.Truncate;
                FromStart = a.FromStart;
                IgnoreCase = a.IgnoreCase;
            });
        }

        public override string ToString()
            => (FromStart ? "start" : "end")
                .Forward(from => $"Truncate {Truncate} from {from}");

        public override string Transform(string text)
        {
            string tx = IgnoreCase ? text.ToUpper() : text;
            string tc = IgnoreCase ? Truncate.ToUpper() : Truncate;
            if (FromStart && tx.StartsWith(tc))
            {
                return text.Substring(Truncate.Length);
            }
            else if (tx.EndsWith(tc))
            {
                return text.Substring(0, text.Length - Truncate.Length);
            }
            return text;
        }

        public override IEditableProperties GetEditableProperties()
            => new TruncateEdit() { Truncate = Truncate, FromStart = FromStart, IgnoreCase = IgnoreCase };

        public class TruncateEdit : IEditableProperties
        {
            public string Truncate { get; set; }
            public bool FromStart { get; set; }
            public bool IgnoreCase { get; set; }
        }
    }
}