using System;
using System.Linq;

namespace emanuel.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceCaseInsensitive(this string t, string find, string replace)
        {
            string r = string.Empty;
            while (t.IndexOf(find, StringComparison.InvariantCultureIgnoreCase).AssignForwardIf(i => i >= 0, out int index))
            {
                r = string.Concat(r,
                    t.Substring(0, index),
                    replace);
                t = t.Substring(index + find.Length);
            }
            return r + t;
        }

        public static (bool Found, string Head, string Tail) Crunch(this string t, string sought)
        => t.IndexOf(sought).Forward(i => i < 0 ? (false, t, string.Empty) :
            (true, t.Substring(0, i), t.Substring(i + sought.Length, t.Length - i - sought.Length)));

        public static string Cutoff(this string t, int n, string addTail = "") => string.Concat(t.Take(n).AggregateToString(string.Empty), t.Length > n ? addTail : string.Empty);
    }
}
