using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static partial class Extensions
    {
        public static bool Contains<T>(this IEnumerable<T> me, Predicate<T> condition) => me.Any(val => condition(val));
    }
}
