using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    public static partial class CollectionExtensions {
        /// <summary>
        /// To string list
        /// </summary>
        /// <param name="me"></param>
        /// <param name="stringConverter"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<string> ToList<T>(this IEnumerable<T> me, Func<T, string> stringConverter)
            => me.Select(stringConverter).ToList();

        /// <summary>
        /// To list
        /// </summary>
        /// <param name="src"></param>
        /// <param name="func"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<T> ToList<T>(this IEnumerable<T> src, Func<T, bool> func) {
            if (src is null) throw new ArgumentNullException(nameof(src));
            return func is null ? src.ToList() : src.Where(func).ToList();
        }
    }
}