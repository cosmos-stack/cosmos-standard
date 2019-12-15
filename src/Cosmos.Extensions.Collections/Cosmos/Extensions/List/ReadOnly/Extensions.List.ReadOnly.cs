using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Extensions of list
    /// </summary>
    public static partial class ListExtensions {
        /// <summary>
        /// Wrap in readonly connection
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyCollection<T> WrapInReadOnlyCollection<T>(this IList<T> source) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return new ReadOnlyCollection<T>(source);
        }
    }
}