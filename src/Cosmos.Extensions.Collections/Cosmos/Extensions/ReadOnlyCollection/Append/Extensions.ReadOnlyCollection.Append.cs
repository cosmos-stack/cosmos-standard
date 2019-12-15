using System;
using System.Collections.Generic;
using Cosmos.Collections.Internals;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// ReadOnly collection extensions
    /// </summary>
    public static partial class ReadOnlyCollectionExtensions {
        /// <summary>
        /// Append
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyCollection<T> Append<T>(this IReadOnlyCollection<T> source, T item) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return new AppendedReadOnlyCollection<T>(source, item);
        }
    }
}