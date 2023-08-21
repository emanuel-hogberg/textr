using StringTransforms.Interfaces;
using System;

namespace StringTransforms.Transforms
{
    public class RemoveNewLineTransform : ITransform
    {
        public string Transform(string text)
            => text.Replace(Environment.NewLine, " ");

        public override string ToString()
            => "Remove newlines";
    }
}