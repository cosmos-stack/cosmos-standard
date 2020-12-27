using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Cosmos.Collections
{
    public static class ReadOnlyDictConv
    {
        #region To Dictionary

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            IEnumerable<KeyValuePair<TKey, TValue>> src)
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
        public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            IEnumerable<KeyValuePair<TKey, TValue>> src, IEqualityComparer<TKey> comparer)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new ReadOnlyDictionary<TKey, TValue>(src.ToDictionary(p => p.Key, p => p.Value, comparer));
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
        public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            IEnumerable<TValue> source, Func<TValue, TKey> keySelector)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            return ReadOnlyDictsHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector));
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
        public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            IEnumerable<TValue> source, Func<TValue, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return ReadOnlyDictsHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector, comparer));
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
        public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TSource, TKey, TValue>(
            IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector, IEqualityComparer<TKey> comparer)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector is null)
                throw new ArgumentNullException(nameof(elementSelector));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return ReadOnlyDictsHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector, elementSelector, comparer));
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
        public static IReadOnlyDictionary<TKey, TValue> ToDictionary<TSource, TKey, TValue>(
            IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector is null)
                throw new ArgumentNullException(nameof(elementSelector));

            return ReadOnlyDictsHelper.WrapInReadOnlyDictionary(source.ToDictionary(keySelector, elementSelector));
        }

        #endregion
    }

    public static class ReadOnlyDictConvExtensions
    {
        #region To Dictionary

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
            return ReadOnlyDictConv.ToDictionary(src);
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
            return ReadOnlyDictConv.ToDictionary(src, comparer);
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
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<TValue> src, Func<TValue, TKey> keySelector)
        {
            return ReadOnlyDictConv.ToDictionary(src, keySelector);
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
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<TValue> src, Func<TValue, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return ReadOnlyDictConv.ToDictionary(src, keySelector, comparer);
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
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> src, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return ReadOnlyDictConv.ToDictionary(src, keySelector, elementSelector, comparer);
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
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> src, Func<TSource, TKey> keySelector, Func<TSource, TValue> elementSelector)
        {
            return ReadOnlyDictConv.ToDictionary(src, keySelector, elementSelector);
        }

        #endregion
    }
}