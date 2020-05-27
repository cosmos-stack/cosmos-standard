using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    public static partial class CollectionExtensions
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
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return items is null ? source : source.Concat(items);
        }
    }
}