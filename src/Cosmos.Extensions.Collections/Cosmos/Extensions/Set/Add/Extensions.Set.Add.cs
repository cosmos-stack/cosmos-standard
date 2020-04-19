using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Collections;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Set extensions
    /// </summary>
    public static partial class SetExtensions {
        /// <summary>
        /// Add range
        /// </summary>
        /// <param name="set"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyCollection<SetAddRangeResult<T>> AddRange<T>(this ISet<T> set, IEnumerable<T> items) {
            if (set is null)
                throw new ArgumentNullException(nameof(set));
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            var added = new List<SetAddRangeResult<T>>(items is ICollection<T> collection ? collection.Count : 1);

            added.AddRange(items.Select(i => new SetAddRangeResult<T>(i, set.Add(i))));

            return added.WrapInReadOnlyCollection();
        }
    }
}