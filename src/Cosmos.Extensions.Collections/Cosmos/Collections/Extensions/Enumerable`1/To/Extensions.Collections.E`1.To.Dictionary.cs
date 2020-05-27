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
        /// To dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> src) =>
            src.ToDictionary(EqualityComparer<TKey>.Default);

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> src, IEqualityComparer<TKey> equalityComparer)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (equalityComparer is null)
                throw new ArgumentNullException(nameof(equalityComparer));
            return src.ToDictionary(p => p.Key, p => p.Value, equalityComparer);
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="keySelector"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<TValue> src, Func<TValue, TKey> keySelector)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            return src.ToDictionary(keySelector).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="keySelector"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<TValue> src, Func<TValue, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return src.ToDictionary(keySelector, comparer).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> src, Func<TSource, TKey> keySelector,
            Func<TSource, TValue> elementSelector,
            IEqualityComparer<TKey> comparer)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector is null)
                throw new ArgumentNullException(nameof(elementSelector));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return src.ToDictionary(keySelector, elementSelector, comparer).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> src, Func<TSource, TKey> keySelector,
            Func<TSource, TValue> elementSelector)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector is null)
                throw new ArgumentNullException(nameof(elementSelector));

            return src.ToDictionary(keySelector, elementSelector).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> src)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));

            return new ReadOnlyDictionary<TKey, TValue>(src.ToDictionary(p => p.Key, p => p.Value, EqualityComparer<TKey>.Default));
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> src, IEqualityComparer<TKey> comparer)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new ReadOnlyDictionary<TKey, TValue>(src.ToDictionary(p => p.Key, p => p.Value, comparer));
        }
    }
}