using System;
using System.Collections.Generic;
using System.Linq;
using emanuel.Extensions;

namespace emanuel.Transforms
{
    class NewLineAfterXOccurencesOfY : ITransform
    {
        public int Occurences { get; set; }
        public string Text { get; set; }
        public bool CaseSensitive { get; set; }
        public bool Before { get; set; }

        public NewLineAfterXOccurencesOfY(int occurences, string text, bool caseSensitive = true, bool before = false)
        {
            Occurences = occurences;
            Text = text;
            CaseSensitive = caseSensitive;
            Before = before;
        }

        public string Transform(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            string r = string.Empty;

            var find = CaseSensitive ? new[] { Text } :
                text.Forward(t =>
                {
                    var variants = new List<string>();

                    while(t.IndexOf(Text, StringComparison.InvariantCultureIgnoreCase)
                        .AssignForwardIf(i => i >= 0, out int index))
                    {
                        variants.Add(t.Substring(index, Text.Length));
                        t = t.Substring(index + Text.Length);
                    }

                    return variants
                        .Distinct()
                        .ToArray();
                });

            if (!find.Any())
            {
                return text;
            }

            var split = text.Split(find, StringSplitOptions.None);

            int c = 0;
            for(int i = 0; i < split.Count(); i++)
            {
                string s = split[i];

                if (r != string.Empty && c > 0)
                    r = r + Text;

                c++;

                r = r + s.Trim();
                if (c >= Occurences && i != split.Count() - 1)
                {
                    c = 0;
                    r = string.Concat(r,
                        Before ? Environment.NewLine : string.Empty,
                        Text,
                        Before ? string.Empty : Environment.NewLine);
                }
            }

            return r;
        }

        public override string ToString()
        => CaseSensitive
            .Forward(c => c ? string.Empty : " (case insensitive)")
            .Forward(c => $"New line after {Occurences} {Text}'s{c}");
    }
}
