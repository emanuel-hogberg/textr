using System;

namespace StringTransforms.Transforms
{
    public static class TruncateEdit
    {
        public static Type Properties => typeof(TruncateProperties);

        public static Type Transform => typeof(TruncateTransform);
    }
}