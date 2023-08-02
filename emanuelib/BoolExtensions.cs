using System;

namespace emanuel.Extensions
{
    public static class BoolExtensions
    {
        public static bool? AsNullable(this bool b)
            => (bool?)b;
        public static bool NotNullNorFalse(this bool? b)
            => b.HasValue && b.Value;
        public static bool OrForceEvaluation(this bool b, params Func<bool>[] bs)
        {
            bool r = false;
            for (int i = 0; i < bs.Length; i++)
            {
                r = bs[i]() || r;
            }
            return r || b;
        }
        public static bool AndForceEvaluation(this bool b, params Func<bool>[] bs)
        {
            bool r = true;
            for (int i = 0; i < bs.Length; i++)
            {
                r = bs[i]() && r;
            }
            return r && b;
        }
    }
}
