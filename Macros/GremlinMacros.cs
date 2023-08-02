using System;
using System.Collections.Generic;
using emanuel.Transforms;

namespace emanuel.Macros
{
    public static class GremlinMacros
    {
        public static List<ITransform> GremlinFormat()
        => new Macros()
            .AddTransform(new NewLineAfterXOccurencesOfY(1, ".has", caseSensitive: false, before: true))
            .AddTransform(new NewLineAfterXOccurencesOfY(1, ".in(", caseSensitive: false, before: true))
            .AddTransform(new NewLineAfterXOccurencesOfY(1, ".out", caseSensitive: false, before: true))
            .AddTransform(new NewLineAfterXOccurencesOfY(1, ".project(", caseSensitive: false, before: true))
            .AddTransform(new NewLineAfterXOccurencesOfY(1, ".by(", caseSensitive: false, before: true))
            .ToList();
    }
}
