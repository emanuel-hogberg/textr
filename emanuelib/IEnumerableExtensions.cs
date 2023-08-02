using System;
using System.Collections.Generic;
using System.Linq;

namespace emanuel.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> t, Func<IEnumerable<T>, IEnumerable<T>> filterFunction) { return filterFunction(t); }
        public static IEnumerable<T> Do<T>(this IEnumerable<T> t, Action<IEnumerable<T>> action) { action(t); return t; }
        public static IEnumerable<T> Do<T>(this IEnumerable<T> t, Action<T> action)
        {
            foreach (var e in t)
            {
                action(e);
            }
            return t;
        }
        public static string AggregateToString<T>(this IEnumerable<T> t, string separator)
            =>t.Any() ? t
                .Select(e => e == null ? "<null>" : e.ToString())
                .Aggregate((a, b) => string.Concat(a, separator, b))
            : string.Empty;

        public static IEnumerable<T> DoForEach<T>(this IEnumerable<T> t, Action<T> action) { foreach (T element in t) action(element); return t; }
    }
}
