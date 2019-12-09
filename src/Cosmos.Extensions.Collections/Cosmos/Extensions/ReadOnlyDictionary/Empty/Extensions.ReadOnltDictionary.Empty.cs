using System.Collections.Generic;
using System.Collections.ObjectModel;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// ReadOnly dictionary extensions
    /// </summary>
    public static partial class ReadOnlyDictionaryExtensions {
        /// <summary>
        /// Gets empty readonly dictionary
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static ReadOnlyDictionary<TKey, TValue> Empty<TKey, TValue>() => EmptyReadOnlyDictionarySingleton<TKey, TValue>.Instance;

        private static class EmptyReadOnlyDictionarySingleton<TKey, TValue> {
            internal static readonly ReadOnlyDictionary<TKey, TValue> Instance = new ReadOnlyDictionary<TKey, TValue>(new Dictionary<TKey, TValue>());
        }
    }
}