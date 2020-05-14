using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Enumerable extensions
    /// </summary>
    public static partial class EnumerableExtensions {
        /// <summary>
        /// 将集合转换为只读集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static ReadOnlyCollection<T> AsReadOnly<T>(this IEnumerable<T> enumerable) {
            return new ReadOnlyCollection<T>(new List<T>(enumerable));
        }

        /// <summary>
        /// As enumerable proxy
        /// </summary>
        /// <param name="enumerable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EnumerableProxy<T> AsEnumerableProxy<T>(this IEnumerable<T> enumerable) {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));
            return new EnumerableProxy<T>(enumerable);
        }

        /// <summary>
        /// As Nullables
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T?> AsNullables<T>(this IEnumerable<T> source) where T : struct {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return source.Cast<T?>();
        }
    }
}