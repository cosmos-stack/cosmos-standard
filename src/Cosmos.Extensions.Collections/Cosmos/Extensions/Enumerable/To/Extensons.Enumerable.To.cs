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
        /// To dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> source) =>
            source.ToDictionary(EqualityComparer<TKey>.Default);

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> equalityComparer) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (equalityComparer == null)
                throw new ArgumentNullException(nameof(equalityComparer));
            return source.ToDictionary(p => p.Key, p => p.Value, equalityComparer);
        }

        /// <summary>
        /// To index sequence
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<KeyValuePair<int, T>> ToIndexedSequence<T>(this IEnumerable<T> source) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return source.Select((t, i) => new KeyValuePair<int, T>(i, t));
        }

        /// <summary>
        /// To safe array
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static TElement[] ToSafeArray<TElement>(this IEnumerable<TElement> source) => source as TElement[] ?? source.ToArray();

        /// <summary>
        /// To readonly collection
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> source) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return source.ToList().WrapInReadOnlyCollection();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<TValue> source, Func<TValue, TKey> keySelector) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            return source.ToDictionary(keySelector).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<TValue> source, Func<TValue, TKey> keySelector, IEqualityComparer<TKey> comparer) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return source.ToDictionary(keySelector, comparer).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector,
            Func<TSource, TValue> elementSelector,
            IEqualityComparer<TKey> comparer) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return source.ToDictionary(keySelector, elementSelector, comparer).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector,
            Func<TSource, TValue> elementSelector) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));

            return source.ToDictionary(keySelector, elementSelector).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> source) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new ReadOnlyDictionary<TKey, TValue>(source.ToDictionary(p => p.Key, p => p.Value, EqualityComparer<TKey>.Default));
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> comparer) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            return new ReadOnlyDictionary<TKey, TValue>(source.ToDictionary(p => p.Key, p => p.Value, comparer));
        }
    }
}