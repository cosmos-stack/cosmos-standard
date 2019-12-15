using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Enumerable extensions
    /// </summary>
    public static partial class EnumerableExtensions {
        /// <summary>
        /// Take last
        /// </summary>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int count) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), count, $"The {nameof(count)} parameter must be a non-negative number.");

            // If the count is zero, return empty.
            if (count == 0)
                return Enumerable.Empty<T>();

            // Start sniffing.
            // Read-only collection.
            if (source is IReadOnlyCollection<T> ro)
                return ro.ReadOnlyCollectionTakeLast(count);

            // Collection.
            if (source is ICollection<T> c)
                return c.CollectionTakeLast(count);

            // Default.
            return source.EnumerableTakeLast(count);
        }

        private static IEnumerable<T> EnumerableTakeLast<T>(this IEnumerable<T> source, int count) {
            var window = new Queue<T>(count);

            foreach (T item in source) {
                window.Enqueue(item);
                if (window.Count > count)
                    window.Dequeue();
            }

            return window;
        }

        private static IEnumerable<T> CollectionTakeLast<T>(this ICollection<T> source, int count) {
            count = Math.Min(source.Count, count);

            if (count == 0)
                return Enumerable.Empty<T>();

            if (count == source.Count)
                return source;

            return source.Skip(source.Count - count);
        }

        private static IEnumerable<T> ReadOnlyCollectionTakeLast<T>(this IReadOnlyCollection<T> source, int count) {
            count = Math.Min(source.Count, count);

            if (count == 0)
                return Enumerable.Empty<T>();

            if (count == source.Count)
                return source;

            return source.Skip(source.Count - count);
        }
    }
}