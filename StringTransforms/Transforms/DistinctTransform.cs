using emanuel.Extensions;
using System;
using System.Linq;

namespace StringTransforms.Transforms
{
    internal class DistinctTransform : ListTransform
    {
        override public string TransformList(string[] lines)
            => lines
                .Distinct()
                .AggregateToString(Environment.NewLine);

        public override string ToString()
            => "Distinct";
    }
}