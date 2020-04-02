using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Extensions of list
    /// </summary>
    public static partial class ListExtensions {
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

        /// <summary>
        /// Add range
        /// </summary>
        /// <param name="source"></param>
        /// <param name="resource"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<T> AddRange<T>(this IList<T> source, IList<T> resource) {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (resource is null)
                throw new ArgumentNullException(nameof(resource));
            foreach (var item in resource) {
                source.Add(item);
            }

            return source;
        }
    }
}