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
    }
}