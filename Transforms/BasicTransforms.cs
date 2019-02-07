using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using emanuel.Extensions;
using static emanuel.Transforms.FindReplaceTransform;

namespace emanuel.Transforms
{
    class RemoveNewLineTransform : ITransform
    {
        public string Transform(string text)
        => text.Replace(Environment.NewLine, " ");

        public override string ToString()
        => "Remove newlines";
    }
    class FindReplaceTransform : EditableTransform
    {
        private string find;
        private string replace;
        private bool caseSensitive;

        public FindReplaceTransform(string find, string replace, bool caseSensitive = true)
        {
            this.find = find;
            this.replace = replace;
            this.caseSensitive = caseSensitive;
        }

        public override string Transform(string text)
        => caseSensitive ? text.Replace(find, replace)
            : text.ReplaceCaseInsensitive(find, replace);

        public override string ToString()
        => caseSensitive
            .Forward(c => c ? "" : ", case insensitive")
            .Forward(sensitivity => $"Replace('{find}', '{replace}'{sensitivity})");

        internal override IEditableProperties GetEditableProperties()
        => new FindReplaceEdit() { CaseSensitive = caseSensitive, Find = find, Replace = replace };

        public override void Save(IEditableProperties amendments)
        {
            var p = amendments as FindReplaceEdit;
            find = p.Find;
            replace = p.Replace;
            caseSensitive = p.CaseSensitive;
        }

        public class FindReplaceEdit : IEditableProperties
        {
            public string Find { get; set; }
            public string Replace { get; set; }
            public bool CaseSensitive { get; set; }
        }
    }

    public class NewLineCharFix : ITransform
    {
        public string Transform(string text)
        => text
            .Replace("\\n\\r", "§§§§")
            .Replace("\\r\\n", "§§§§")
            .Replace("\\n", "§§§§")
            .Replace("\\r", "§§§§")
            .Replace("§§§§", "§§")
            .Replace("§§§§", "§§")
            .Replace("§§", Environment.NewLine);

        public override string ToString()
        => "new line char fix";
    }

    public class DistinctTransform : ListTransform
    {
        override public string TransformList(string[] lines)
        => lines
            .Distinct()
            .AggregateToString(Environment.NewLine);

        public override string ToString()
        => "Distinct";
    }

    public class RemoveBlankLinesTransform : ListTransform
    {
        public override string TransformList(string[] lines)
        => lines
            .Where(line => !string.IsNullOrEmpty(line))
            .AggregateToString(Environment.NewLine);

        public override string ToString()
        => "Remove blank lines";
    }

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

        internal override IEditableProperties GetEditableProperties()
        => new TruncateEdit() { Truncate = Truncate, FromStart = FromStart, IgnoreCase = IgnoreCase };

        public class TruncateEdit : IEditableProperties
        {
            public string Truncate { get; set; }
            public bool FromStart { get; set; }
            public bool IgnoreCase { get; set; }
        }
    }
}
