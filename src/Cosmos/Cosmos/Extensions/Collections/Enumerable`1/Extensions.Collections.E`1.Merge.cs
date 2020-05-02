using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    public static partial class CollectionExtensions {
        /// <summary>
        /// Merge<br />
        /// 合并集合
        /// </summary>
        /// <param name="source"></param>
        /// <param name="collection"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> source, IEnumerable<T> collection) {
            if (source is null) throw new ArgumentNullException(nameof(source));
            foreach (var item in source)
                yield return item;
            if (collection is null)
                yield break;
            foreach (var item in collection)
                yield return item;
        }

        /// <summary>
        /// Merge<br />
        /// 合并集合
        /// </summary>
        /// <param name="source"></param>
        /// <param name="collection"></param>
        /// <param name="limit"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> source, IEnumerable<T> collection, int limit) {
            if (source is null) throw new ArgumentNullException(nameof(source));
            foreach (var item in source)
                yield return item;
            if (collection is null)
                yield break;
            if (limit <= 0) {
                foreach (var item in collection)
                    yield return item;
            } else {
                var counter = 0;
                foreach (var item in collection) {
                    if (counter++ >= limit)
                        yield break;
                    yield return item;
                }
            }
        }
    }
}