using System;
using System.Linq;
using emanuel.Extensions;
using textr.Transforms;

namespace emanuel.Transforms
{
    public class RemoveBlankLinesTransform : ListTransform
    {
        public override string TransformList(string[] lines)
            => lines
                .Where(line => !string.IsNullOrEmpty(line))
                .AggregateToString(Environment.NewLine);

        public override string ToString()
            => "Remove blank lines";
    }
}