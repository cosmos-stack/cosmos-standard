using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Collection extensions
    /// </summary>
    public static partial class CollectionExtensions {
        /// <summary>
        /// Move to first
        /// </summary>
        /// <param name="source"></param>
        /// <param name="element"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static List<TSource> MoveToFirst<TSource>(this List<TSource> source, TSource element) {
            if (!source.Contains(element))
                return source;

            source.Remove(element);
            source.Insert(0, element);
            return source;
        }
    }
}