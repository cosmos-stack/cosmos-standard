using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// Enumerable extensions
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Do action for each item
        /// </summary>
        /// <param name="src"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ForEach<T>(this IEnumerable<T> src, Action<T> action)
        {
            if (src is null) throw new ArgumentNullException(nameof(src));
            if (action is null) return;
            foreach (var i in src) action(i);
        }

        /// <summary>
        /// Do action for each item, and returns the result.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> ForEachItem<T>(this IEnumerable<T> src, Action<T> action)
        {
            if (src is null) throw new ArgumentNullException(nameof(src));
            if (action is null) return src;

            return src.Select(i =>
            {
                action(i);
                return i;
            });
        }
    }
}