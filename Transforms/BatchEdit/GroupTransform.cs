using emanuel.Extensions;
using StringTransforms.Interfaces;
using System;
using System.Linq;
using System.Text;

namespace emanuel.Transforms
{
    public class GroupTransform : ListTransform, IBatchEditLineTransform
    {
        public GroupTransform()
        {
            OnlyViewAffectedLines = true;
        }

        override public string TransformList(string[] lines)
        {
            var results = new StringBuilder();
            foreach (string line in lines)
            {
                Line = line;
                Result = string.Empty;
                Select(select);
                SetTransform(transform);
                results.AppendLine(string.IsNullOrEmpty(Result) ? Line : Result);
            }
            return results.ToString();
        }
        private string line;
        public string Line
        {
            get
            {
                return Predecessor?.Transform(line) ?? line;
            }
            set
            {
                line = value;
            }
        }
        public string Selection { get; internal set; }
        public bool Match { get; internal set; }
        public string Result { get; internal set; }
        public bool OnlyViewAffectedLines { get; set; }
        public ITransform Predecessor { get; set; }

        internal string select;

        internal string transform;

        public override string ToString()
        => $"'{select}' into '{transform}'";

        public GroupTransform(string line)
        {
            Line = line;
            Match = false;
        }

        public IBatchEditLineTransform Select(string select)
        {
            Selection = Line;
            this.select = select;
            Match = false;

            FindAndTransform();

            return this;
        }

        internal virtual void FindAndTransform()
        {
            if (!string.IsNullOrEmpty(select))
            {
                string found = string.Empty;
                string rest = Line;

                bool selectStartsWithAsterisk = select.StartsWith("*"),
                    selectEndsWithAsterisk = select.EndsWith("*");

                var parts = select.Split("*".ToCharArray(), StringSplitOptions.None);
                var newParts = !string.IsNullOrEmpty(transform) && Match ? transform.Split("*".ToCharArray(), StringSplitOptions.None) : null;

                bool performTransform = Match && newParts.Count().Between(parts.Count(), parts.Count() + (selectStartsWithAsterisk ? 1 : 0) + (selectEndsWithAsterisk ? 1 : 0));

                string transformLead = string.Empty, transformTrail = string.Empty;
                if (performTransform)
                {
                    Result = string.Empty;
                    Action setLead = () =>
                    {
                        transformLead = newParts.First();
                        newParts = newParts.Skip(1).ToArray();
                    };
                    Action setTrail = () =>
                    {
                        transformTrail = newParts.Last();
                        newParts = newParts.Take(newParts.Count() - 1).ToArray();
                    };

                    if (selectStartsWithAsterisk && selectEndsWithAsterisk && parts.Count() + 2 == newParts.Count())
                    {
                        setLead();
                        setTrail();
                    }
                    else if (selectStartsWithAsterisk && parts.Count() < newParts.Count() && transform.EndsWith("*"))
                    {
                        setLead();
                    }
                    else if (selectEndsWithAsterisk && parts.Count() < newParts.Count() && transform.EndsWith("*"))
                    {
                        setTrail();
                    }
                }
                PerformSelectionAndTransform(ref found, ref rest, parts, newParts, performTransform, transformLead, transformTrail);
            }
            /*
            else if (select == "*") // special case.
            {
                Match = true;
                Selection = Line;
                if (!string.IsNullOrEmpty(transform) && new[] { transform.Length - 1, transform.Length }.Contains(transform.Replace("*", "").Length))
                {
                    var newParts = transform == "*" ? new[] { string.Empty, string.Empty } :
                        transform.Contains("*") ?
                            transform.IndexOf('*')
                            .Forward(i => new[] { transform.Substring(0, i), transform.Substring(i).Replace("*", "") })
                        : new[] { transform, string.Empty };

                    Result = string.Concat(newParts[0], Selection, newParts[1]);
                }
            }
            */
        }

        internal virtual void PerformSelectionAndTransform(ref string found, ref string rest, string[] parts, string[] newParts, bool performTransform, string transformLead, string transformTrail)
        {
            for (int i = 0; i < parts.Count(); i++)
            {
                string part = parts[i];
                if (rest.IndexOf(part)
                    .AssignForwardIf(foundPartInRest => foundPartInRest >= 0, out int index))
                {
                    if (part == string.Empty && i == parts.Count() - 1)
                        index = rest.Count(); // if last part, grab entire rest

                    // Selection
                    found = string.Concat(found,
                        rest.Substring(0, index),
                        part.ToUpper());

                    // Transform
                    if (performTransform)
                    {
                        var newPart = newParts[i];

                        var asteriskPart = rest.Substring(0, index);

                        // writing \* should remove the asterisk part.
                        if (Result.EndsWith("\\"))
                        {
                            asteriskPart = string.Empty;
                            Result = Result.Substring(0, Result.Length - 1);
                        }

                        Result = string.Concat(Result,
                            asteriskPart,
                            newPart);
                    }

                    rest = rest.Substring(index + part.Length);
                }
                else
                {
                    Match = false;
                    break;
                }
                Match = true;
            }
            Selection = found + rest;
            if (performTransform)
                Result = transformLead + Result + rest + transformTrail;
            else if (!OnlyViewAffectedLines)
                Result = Selection;
        }

        public IBatchEditLineTransform SetTransform(string transform)
        {
            this.transform = transform;
            Result = string.Empty;
            if (Match && !string.IsNullOrEmpty(transform))
            {
                FindAndTransform();
            }
            else if (string.IsNullOrEmpty(transform))
            {
                Result = string.Empty;
            }
            return this;
        }

        public virtual string GetDescription()
         => "Selection (e.g. text*where* selects two groups in this text: \"text hello where something\")";
        public virtual string GetTransformDescription()
         => "Transform text from the above selection (e.g. text2*wear gives the new text \"text2 hello wear something\")";


        public virtual string GetTransformHint()
        => "Replace a * group by typing \\*";

        public IBatchEditLineTransform CopyTo(IBatchEditLineTransform newTransform)
        => newTransform
                .Select(select)
                .SetTransform(transform);
    }
}
