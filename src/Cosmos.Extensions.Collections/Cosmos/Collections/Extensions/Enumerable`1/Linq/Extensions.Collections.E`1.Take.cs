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
        /// Take last
        /// </summary>
        /// <param name="src"></param>
        /// <param name="count"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> src, int count) {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), count, $"The {nameof(count)} parameter must be a non-negative number.");

            // If the count is zero, return empty.
            if (count == 0)
                return Enumerable.Empty<T>();

            // Start sniffing.
            // Read-only collection.
            if (src is IReadOnlyCollection<T> ro)
                return ro.ReadOnlyCollectionTakeLast(count);

            // Collection.
            if (src is ICollection<T> c)
                return c.CollectionTakeLast(count);

            // Default.
            return src.EnumerableTakeLast(count);
        }

        private static IEnumerable<T> EnumerableTakeLast<T>(this IEnumerable<T> src, int count) {
            var window = new Queue<T>(count);

            foreach (T item in src) {
                window.Enqueue(item);
                if (window.Count > count)
                    window.Dequeue();
            }

            return window;
        }

        private static IEnumerable<T> CollectionTakeLast<T>(this ICollection<T> src, int count) {
            count = Math.Min(src.Count, count);

            if (count == 0)
                return Enumerable.Empty<T>();

            if (count == src.Count)
                return src;

            return src.Skip(src.Count - count);
        }

        private static IEnumerable<T> ReadOnlyCollectionTakeLast<T>(this IReadOnlyCollection<T> src, int count) {
            count = Math.Min(src.Count, count);

            if (count == 0)
                return Enumerable.Empty<T>();

            if (count == src.Count)
                return src;

            return src.Skip(src.Count - count);
        }
    }
}