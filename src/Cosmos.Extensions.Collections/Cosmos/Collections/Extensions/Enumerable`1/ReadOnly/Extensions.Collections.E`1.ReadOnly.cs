using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Collection extensions
    /// </summary>
    public static partial class CollectionExtensions {
        /// <summary>
        /// To readonly collection
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> src) {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            return src.ToList().WrapInReadOnlyCollection();
        }
    }
}