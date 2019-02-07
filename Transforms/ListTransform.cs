using System;

namespace emanuel.Transforms
{
    public abstract class ListTransform : ITransform
    {
        public StringSplitOptions StringSplitOptions { get; set; }

        public ListTransform(StringSplitOptions stringSplitOptions = StringSplitOptions.None)
        {
            StringSplitOptions = stringSplitOptions;
        }

        public string Transform(string text)
        => TransformList(text.Split(new[] { Environment.NewLine }, StringSplitOptions));

        public abstract string TransformList(string[] lines);
    }
}