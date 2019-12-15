using System.Collections.ObjectModel;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// ReadOnly collection extensions
    /// </summary>
    public static partial class ReadOnlyCollectionExtensions {
        /// <summary>
        /// Gets empty readonly collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ReadOnlyCollection<T> Empty<T>() => EmptyReadOnlyCollectionSingleton<T>.Instance;

        private static class EmptyReadOnlyCollectionSingleton<T> {
            internal static readonly ReadOnlyCollection<T> Instance = new ReadOnlyCollection<T>(new T[0]);
        }
    }
}