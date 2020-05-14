using System.Collections.Generic;
using Cosmos.Collections.Internals;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Enumerable extensions
    /// </summary>
    public static partial class EnumerableExtensions {
        /// <summary>
        /// Null if empty
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> NullIfEmpty<T>(this IEnumerable<T> source) {
            // Get the enumerator in a releasable disposable.
            using (var disposable = new InternalReleasableDisposable<IEnumerator<T>>(source.GetEnumerator())) {
                // Get the enumerator.
                IEnumerator<T> enumerator = disposable.Disposable;

                // Move to the next item.  If there are no elements, then return null.
                if (!enumerator.MoveNext()) return null;

                // Release the disposable.
                disposable.Release();

                // Create an enumerator that skips the first move next.
                var wrapper = new InternalNullIfEmptySkipFirstMoveNextEnumeratorWrapper<T>(enumerator);

                // Wrap in a single use enumerator, return that.
                return new InternalSingleUseEnumerable<T>(wrapper);
            }
        }
    }
}