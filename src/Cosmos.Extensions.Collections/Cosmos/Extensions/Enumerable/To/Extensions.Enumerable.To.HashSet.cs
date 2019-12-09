using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Enumerable extensions
    /// </summary>
    public static partial class EnumerableExtensions {
        /// <summary>
        /// To hashset
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source) where T : IComparable<T> =>
            source.ToHashSet(EqualityComparer<T>.Default);

        /// <summary>
        /// To hashset
        /// </summary>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
            where T : IComparable<T> {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));
            return new HashSet<T>(source, comparer);
        }

        /// <summary>
        /// To HashSet
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ignoreDup"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source, bool ignoreDup) where T : IComparable<T> =>
            ignoreDup
                ? source.Distinct().ToHashSet(EqualityComparer<T>.Default)
                : source.ToHashSet(EqualityComparer<T>.Default);

        /// <summary>
        /// To HashSet
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keyFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static HashSet<TKey> ToHashSet<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keyFunc) where TKey : IComparable<TKey> {
            if (keyFunc is null) throw new ArgumentNullException(nameof(keyFunc));
            return source.Select(i => keyFunc(i)).ToHashSet(EqualityComparer<TKey>.Default);
        }

        /// <summary>
        /// To HashSet ignore duplicates
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static HashSet<T> ToHashSetIgnoringDuplicates<T>(this IEnumerable<T> source) where T : IComparable<T> => source.ToHashSet(true);

    }
}