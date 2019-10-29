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
        /// Index of
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int? IndexOf<T>(this IEnumerable<T> source, T item) => source.IndexOf(item, EqualityComparer<T>.Default);

        /// <summary>
        /// Index of
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int? IndexOf<T>(this IEnumerable<T> source, T item, IEqualityComparer<T> equalityComparer)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (equalityComparer == null)
                throw new ArgumentNullException(nameof(equalityComparer));

            return source.Select((i, index) => new {Item = i, Index = index})
                .FirstOrDefault(p => equalityComparer.Equals(p.Item, item))
                ?.Index;
        }
    }
}