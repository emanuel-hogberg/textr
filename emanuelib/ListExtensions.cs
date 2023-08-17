using System.Collections.Generic;
using System.Linq;

namespace emanuel.Extensions
{
    public static class ListExtensions
    {
        public static bool AnyAndNotNull<T>(this List<T> t)
        => t != null ? t.Any() : false;
    }
}
