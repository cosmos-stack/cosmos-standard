using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        /// To index sequence
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<KeyValuePair<int, T>> ToIndexedSequence<T>(this IEnumerable<T> src)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            return src.Select((t, i) => new KeyValuePair<int, T>(i, t));
        }

        /// <summary>
        /// To safe array
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static TElement[] ToSafeArray<TElement>(this IEnumerable<TElement> src) => src as TElement[] ?? src.ToArray();
    }
}