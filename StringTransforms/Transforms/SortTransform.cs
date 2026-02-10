using emanuel.Extensions;
using System;
using System.Linq;

namespace StringTransforms.Transforms
{
    internal class SortTransform : ListTransform
    {
        public override string TransformList(string[] lines)
            => lines
                .OrderBy(line => line)
                .AggregateToString(Environment.NewLine);

        public override string ToString()
            => "Sort";
    }
}
