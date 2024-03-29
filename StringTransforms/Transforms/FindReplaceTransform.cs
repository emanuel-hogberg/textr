﻿using emanuel.Extensions;
using StringTransforms.Interfaces;

namespace StringTransforms.Transforms
{
    internal class FindReplaceTransform : EditableTransform
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

        public override IEditableProperties GetEditableProperties()
        => new FindReplaceProperties() { CaseSensitive = caseSensitive, Find = find, Replace = replace };

        public override void Save(IEditableProperties amendments)
        {
            var p = amendments as FindReplaceProperties;
            find = p.Find;
            replace = p.Replace;
            caseSensitive = p.CaseSensitive;
        }
    }
}
