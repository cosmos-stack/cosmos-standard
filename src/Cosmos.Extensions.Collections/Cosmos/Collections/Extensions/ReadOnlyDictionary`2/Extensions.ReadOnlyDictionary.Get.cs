using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// ReadOnly dictionary extensions
    /// </summary>
    public static partial class ReadOnlyDictionaryExtensions {
        /// <summary>
        /// Get value or default
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue) {
            if (dictionary is null)
                throw new ArgumentNullException(nameof(dictionary));
            if (key is null)
                throw new ArgumentNullException(nameof(key));
            return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
        }

        /// <summary>
        /// Get value or default
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key) {
            if (dictionary is null)
                throw new ArgumentNullException(nameof(dictionary));
            if (key is null)
                throw new ArgumentNullException(nameof(key));
            return dictionary.GetValueOrDefault(key, default);
        }

        /// <summary>
        /// Get value or default cascading
        /// </summary>
        /// <param name="dictionaries"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue GetValueOrDefaultCascading<TKey, TValue>(this IEnumerable<IReadOnlyDictionary<TKey, TValue>> dictionaries, TKey key, TValue defaultValue) {
            if (dictionaries is null)
                throw new ArgumentNullException(nameof(dictionaries));
            return dictionaries.TryGetValueCascading(key, out TValue value) ? value : defaultValue;
        }

        /// <summary>
        /// Get value or default cascading
        /// </summary>
        /// <param name="dictionaries"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue GetValueOrDefaultCascading<TKey, TValue>(this IEnumerable<IReadOnlyDictionary<TKey, TValue>> dictionaries, TKey key)
            => dictionaries.GetValueOrDefaultCascading(key, default);

        /// <summary>
        /// Try get value
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue? TryGetValue<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key) where TValue : struct {
            if (dictionary is null)
                throw new ArgumentNullException(nameof(dictionary));
            return dictionary.TryGetValue(key, out TValue value) ? value : (TValue?) null;
        }

        /// <summary>
        /// Try get value cascading
        /// </summary>
        /// <param name="dictionaries"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool TryGetValueCascading<TKey, TValue>(this IEnumerable<IReadOnlyDictionary<TKey, TValue>> dictionaries, TKey key, out TValue value) {
            if (dictionaries is null)
                throw new ArgumentNullException(nameof(dictionaries));
            value = default;

            foreach (var dictionary in dictionaries)
                if (dictionary.TryGetValue(key, out value))
                    return true;
            return false;
        }

        /// <summary>
        /// Try get value cascading
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dictionaries"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static bool TryGetValueCascading<TKey, TValue>(TKey key, out TValue value, params IReadOnlyDictionary<TKey, TValue>[] dictionaries) =>
            dictionaries.TryGetValueCascading(key, out value);

        /// <summary>
        /// Try get value cascading
        /// </summary>
        /// <param name="dictionaries"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue? TryGetValueCascading<TKey, TValue>(this IEnumerable<IReadOnlyDictionary<TKey, TValue>> dictionaries, TKey key) where TValue : struct
            => dictionaries.TryGetValueCascading(key, out TValue value) ? value : (TValue?) null;

        /// <summary>
        /// Try get value cascading
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dictionaries"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue? TryGetValueCascading<TKey, TValue>(TKey key, params IReadOnlyDictionary<TKey, TValue>[] dictionaries) where TValue : struct
            => dictionaries.TryGetValueCascading(key);
    }
}