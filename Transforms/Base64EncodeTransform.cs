using emanuel.Extensions;
using System;
using System.Linq;
using emanuel.Extensions;
using emanuel.Transforms;
using textr.Extensions;

namespace textr.Transforms
{
    public class Base64EncodeTransform : ListTransform
    {
        public override string TransformList(string[] lines)
            => lines
                .Select(line => line.ToBase64Encoded())
                .AggregateToString(Environment.NewLine);

        public override string ToString()
            => "Encode each line as base 64";
    }
    public class Base64DecodeTransform : ListTransform
    {
        public override string TransformList(string[] lines)
            => lines
                .Select(line => line.FromBase64Encoded())
                .AggregateToString(Environment.NewLine);

        public override string ToString()
            => "Decode each line as base 64";
    }
}
