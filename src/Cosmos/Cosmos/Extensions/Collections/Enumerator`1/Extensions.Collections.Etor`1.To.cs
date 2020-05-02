using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Enumerator Extensions
    /// </summary>
    public static class EnumeratorExtensions {
        /// <summary>
        /// To Enumerable
        /// </summary>
        /// <param name="enumerator"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> enumerator) {
            if (enumerator is null)
                throw new ArgumentNullException(nameof(enumerator));

            IEnumerable<T> Implementation() {
                while (enumerator.MoveNext())
                    yield return enumerator.Current;
            }

            return Implementation();
        }

        /// <summary>
        /// To Enumerable After
        /// </summary>
        /// <param name="enumerator"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> ToEnumerableAfter<T>(this IEnumerator<T> enumerator) {
            if (enumerator is null)
                throw new ArgumentNullException(nameof(enumerator));

            IEnumerable<T> Implementation() {
                do {
                    yield return enumerator.Current;
                } while (enumerator.MoveNext());
            }

            return Implementation();
        }
    }
}