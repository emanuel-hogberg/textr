﻿using StringTransforms.Interfaces;
using System;

namespace StringTransforms.Transforms
{
    internal class RemoveNewLineTransform : ITransform
    {
        public string Transform(string text)
            => text.Replace(Environment.NewLine, " ");

        public override string ToString()
            => "Remove newlines";
    }
}