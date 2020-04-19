using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Extensions of list
    /// </summary>
    public static partial class ListExtensions {
        /// <summary>
        /// Remove deplicates
        /// </summary>
        /// <param name="values"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> RemoveDuplicates<TSource>(this IList<TSource> values) {
            var duplicateCheck = new HashSet<TSource>();

            return values.RemoveWhere(item => {
                if (duplicateCheck.Contains(item))
                    return true;

                duplicateCheck.Add(item);
                return false;
            });
        }

        /// <summary>
        /// Remove buplicates
        /// </summary>
        /// <param name="values"></param>
        /// <param name="duplicatePredicate"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCheck"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> RemoveDuplicates<TSource, TCheck>(this IList<TSource> values, Func<TSource, TCheck> duplicatePredicate) {
            if (duplicatePredicate is null)
                throw new ArgumentNullException(nameof(duplicatePredicate));

            var duplicateCheck = new HashSet<TCheck>();

            return values.RemoveWhere(item => {
                var val = duplicatePredicate(item);

                if (duplicateCheck.Contains(val))
                    return true;

                duplicateCheck.Add(val);
                return false;
            });
        }

        /// <summary>
        /// Remove duplicates ignore case
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<string> RemoveDuplicatesIgnoreCase(this IList<string> values) {
            var duplicateCheck = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            return values.RemoveWhere(item => {
                if (duplicateCheck.Contains(item))
                    return true;

                duplicateCheck.Add(item);
                return false;
            });
        }

        /// <summary>
        /// Remove where...
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> RemoveWhere<T>(this IList<T> source, Func<T, bool> predicate) {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            for (var i = source.Count - 1; i >= 0; --i) {
                var item = source[i];

                if (!predicate.Invoke(item))
                    continue;

                source.RemoveAt(i);

                yield return item;
            }
        }

        /// <summary>
        /// Safe remove range
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> SafeRemoveRange<T>(this List<T> source, int index, int count) {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (index < 0 || count < 0)
                return source;

            if (index >= source.Count)
                return source;

            count = Math.Min(count, source.Count) - index;

            source.RemoveRange(index, count);

            return source;
        }
    }
}