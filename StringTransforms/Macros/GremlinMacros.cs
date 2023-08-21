using StringTransforms.Interfaces;
using StringTransforms.Transforms;
using System.Collections.Generic;

namespace StringTransforms.Macros
{
    internal static class GremlinMacros
    {
        public static List<ITransform> CreateGremlinFormat()
        => new Macros()
            .AddTransform(new NewLineAfterXOccurencesOfY(1, ".has", caseSensitive: false, before: true))
            .AddTransform(new NewLineAfterXOccurencesOfY(1, ".in(", caseSensitive: false, before: true))
            .AddTransform(new NewLineAfterXOccurencesOfY(1, ".out", caseSensitive: false, before: true))
            .AddTransform(new NewLineAfterXOccurencesOfY(1, ".project(", caseSensitive: false, before: true))
            .AddTransform(new NewLineAfterXOccurencesOfY(1, ".by(", caseSensitive: false, before: true))
            .ToList();
    }
}
