using emanuel.Extensions;
using System;
using System.Linq;
using textr.Transforms;

namespace emanuel.Transforms
{
    public class DistinctTransform : ListTransform
    {
        override public string TransformList(string[] lines)
            => lines
                .Distinct()
                .AggregateToString(Environment.NewLine);

        public override string ToString()
            => "Distinct";
    }
}