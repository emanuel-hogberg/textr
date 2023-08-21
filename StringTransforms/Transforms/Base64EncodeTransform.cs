using emanuel.Extensions;
using StringTransforms.Extensions;
using System;
using System.Linq;

namespace StringTransforms.Transforms
{
    internal class Base64EncodeTransform : ListTransform
    {
        public override string TransformList(string[] lines)
            => lines
                .Select(line => line.ToBase64Encoded())
                .AggregateToString(Environment.NewLine);

        public override string ToString()
            => "Encode each line as base 64";
    }
    internal class Base64DecodeTransform : ListTransform
    {
        public override string TransformList(string[] lines)
            => lines
                .Select(line => line.FromBase64Encoded())
                .AggregateToString(Environment.NewLine);

        public override string ToString()
            => "Decode each line as base 64";
    }
}
