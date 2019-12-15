using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Extensions for dictionary
    /// </summary>
    public static partial class DictionaryExtensions {
        /// <summary>
        /// Wrap in readonly dictionary
        /// </summary>
        /// <param name="dictionary"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> WrapInReadOnlyDictionary<TKey, TValue>(this IDictionary<TKey, TValue> dictionary) {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));

            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }
    }
}