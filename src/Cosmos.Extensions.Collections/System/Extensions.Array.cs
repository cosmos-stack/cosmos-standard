using System.Collections.Generic;
using System.Linq;

namespace System {
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="me"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Contains<T>(this IEnumerable<T> me, Predicate<T> condition) => me.Any(val => condition(val));
    }
}