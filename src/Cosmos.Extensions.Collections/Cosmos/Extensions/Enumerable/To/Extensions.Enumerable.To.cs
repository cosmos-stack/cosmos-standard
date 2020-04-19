using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Enumerable extensions
    /// </summary>
    public static partial class EnumerableExtensions {
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
        
        /// <summary>
        /// To index sequence
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<KeyValuePair<int, T>> ToIndexedSequence<T>(this IEnumerable<T> src) {
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

        /// <summary>
        /// To readonly collection
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> src) {
            if (src == null)
                throw new ArgumentNullException(nameof(src));
            return src.ToList().WrapInReadOnlyCollection();
        }
    }
}