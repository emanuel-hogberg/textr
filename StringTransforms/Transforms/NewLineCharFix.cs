using StringTransforms.Interfaces;
using System;

namespace StringTransforms.Transforms
{
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
}