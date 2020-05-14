using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Collection extensions
    /// </summary>
    public static partial class CollectionExtensions {
        /// <summary>
        /// Add range
        /// </summary>
        /// <param name="source"></param>
        /// <param name="collection"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<T> AddRange<T>(this IList<T> source, IList<T> collection) {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            foreach (var item in collection)
                source.Add(item);
            return source;
        }

        /// <summary>
        /// Add range
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="collection"></param>
        /// <param name="limit"></param>
        public static void AddRange<T>(this List<T> source, IEnumerable<T> collection, int limit) {
            if (limit <= 0) {
                source.AddRange(collection);
                return;
            }

            var counter = 0;
            source.AddRange(collection.TakeWhile(item => counter++ < limit));
        }

        /// <summary>
        /// Add into
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<T> AddRangeInto<T>(this IList<T> source, IList<T> target) {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (target is null)
                throw new ArgumentNullException(nameof(target));
            target.AddRange(source);
            return target;
        }
    }
}