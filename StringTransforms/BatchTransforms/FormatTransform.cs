using emanuel.Extensions;
using System.Linq;

namespace StringTransforms.BatchTransforms
{
    public class FormatTransform : GroupTransform
    {
        public FormatTransform(string line) : base(line)
        {
        }

        public override string ToString()
        => $"Format {select} into {transform}";

        internal override void FindAndTransform()
        {
            if (!string.IsNullOrEmpty(Line) && !string.IsNullOrEmpty(select)
                && Line.Replace("*", "").Length >= select.Length
                && select.IndexOf("*").AssignForwardIf(i => i >= 0, out int index))
            {
                var parts = Line
                    .Forward(l => new
                    {
                        Start = l.Substring(0, index),
                        Rest = l.Substring(index)
                    })
                    .Forward(p => new
                    {
                        p.Start,
                        End = index == select.Length - 1 ? string.Empty :
                            select.Substring(index + 1)
                    })
                    .Forward(p => (
                        p.Start,
                        Match: Line.Substring(p.Start.Length, Line.Length - p.Start.Length - p.End.Length),
                        p.End));

                if (Line == parts.Start + parts.Match + parts.End &&
                    select == parts.Start + "*" + parts.End)
                {
                    Selection = string.Concat(parts.Start, parts.Match.ToUpper(), parts.End);
                    Match = true;
                }
                else
                {
                    Selection = string.Empty;
                    Match = false;
                }

                if (Match && !string.IsNullOrEmpty(transform))
                {
                    bool crunched = false;
                    string rest = transform;
                    Result = string.Empty;
                    while (rest.Crunch("*")
                        .AssignForward(out var crunch)
                        .Forward(c => c.Tail != string.Empty || c.Found))
                    {
                        crunched = true;
                        Result = string.Concat(
                            Result,
                            crunch.Head,
                            crunch.Found ? parts.Match : string.Empty);
                        rest = crunch.Tail;
                    }
                    if (crunched)
                    {
                        Result = string.Concat(Result, rest);
                    }
                    else
                    {
                        Result = OnlyViewAffectedLines ? string.Empty : Line;
                    }
                }

            }
        }

        internal override void PerformSelectionAndTransform(ref string found, ref string rest, string[] parts, string[] newParts, bool performTransform, string transformLead, string transformTrail)
        {
            if (parts.Count() > 2)
            {
                Result = "Unable to select: you can only have one *!";
                return;
            }

            string leftSelect, rightSelect;
            if (parts.Count() == 2)
            {
                leftSelect = parts.First();
                rightSelect = parts.Last();
            }
            else if (parts.Count() == 1)
            {
                if (rest.StartsWith(parts.First()))
                {
                    leftSelect = parts.First();
                    rightSelect = string.Empty;
                }
                else
                {
                    leftSelect = string.Empty;
                    rightSelect = parts.First();
                }
            }

            foreach (string part in parts)
            {
                if (rest.StartsWith(part))
                {
                    found = string.Concat(part.ToUpper());
                    rest = rest.Substring(part.Length, rest.Length - part.Length);
                }
                else
                {
                    found = "";
                }
            }
        }

        public override string GetDescription()
        => "Format selection (e.g. text 'hello *!' selects 'friend' in this text: 'hello friend!')";

        override public string GetTransformDescription()
            => "Transform selection (e.g. 'hello * of *s!' gives the new text 'hello friend of friends!')";

        public override string GetTransformHint()
        => "";
    }
}
