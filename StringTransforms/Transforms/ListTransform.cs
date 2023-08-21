using StringTransforms.Interfaces;
using System;

namespace StringTransforms.Transforms
{
    public abstract class ListTransform : ITransform
    {
        public ListTransform()
        {

        }

        public string Transform(string text, StringSplitOptions options)
        => TransformList(text.Split(new[] { Environment.NewLine }, options));

        public string Transform(string text) => Transform(text, StringSplitOptions.None);

        public abstract string TransformList(string[] lines);
    }
}