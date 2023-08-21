using System;

namespace StringTransforms.Transforms
{
    public static class FindReplaceEdit
    {
        public static Type Properties => typeof(FindReplaceProperties);

        public static Type Transform => typeof(FindReplaceTransform);
    }
}
