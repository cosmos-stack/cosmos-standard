using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// Collection extensions
    /// </summary>
    public static partial class CollectionExtensions
    {
        /// <summary>
        /// In
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool In<T>(this T item, params T[] items) => item.In((IEnumerable<T>) items);

        /// <summary>
        /// In
        /// </summary>
        /// <param name="item"></param>
        /// <param name="equalityComparer"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool In<T>(this T item, IEqualityComparer<T> equalityComparer, params T[] items) => item.In(items, equalityComparer);

        /// <summary>
        /// In
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool In<T>(this T item, IEnumerable<T> items) => item.In(items, EqualityComparer<T>.Default);

        /// <summary>
        /// In
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool In<T>(this T item, IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));
            if (equalityComparer is null)
                throw new ArgumentNullException(nameof(equalityComparer));

            return items.Contains(item, equalityComparer);
        }
    }
}