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
        /// Append
        /// </summary>
        /// <param name="source"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, params T[] items)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return items == null ? source : source.Concat(items);
        }
    }
}