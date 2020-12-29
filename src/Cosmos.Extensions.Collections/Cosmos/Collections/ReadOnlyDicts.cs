using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cosmos.Collections
{
    internal static class ReadOnlyDictsHelper
    {
        /// <summary>
        /// Wrap in readonly dictionary
        /// </summary>
        /// <param name="dictionary"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> WrapInReadOnlyDictionary<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary is null)
                throw new ArgumentNullException(nameof(dictionary));

            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }
    }
    
    public static class ReadOnlyDicts
    {
        #region Empty
        
        /// <summary>
        /// Gets empty readonly dictionary
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static ReadOnlyDictionary<TKey, TValue> Empty<TKey, TValue>()
        {
            return EmptyReadOnlyDictionarySingleton<TKey, TValue>.OneInstance;
        }

        private static class EmptyReadOnlyDictionarySingleton<TKey, TValue>
        {
            internal static readonly ReadOnlyDictionary<TKey, TValue> OneInstance = new(new Dictionary<TKey, TValue>());
        }

        #endregion

        #region Get or Default

        /// <summary>
        /// Get value or default
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="valueCalculator"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue GetValueOrDefault<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueCalculator)
        {
            if (dictionary is not null && dictionary.TryGetValue(key, out var value))
                return value;

            if (valueCalculator is null)
                return default;

            return valueCalculator.Invoke(key);
        }

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
        public static TValue GetValueOrDefault<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            return dictionary is not null &&
                   dictionary.TryGetValue(key, out var value)
                ? value
                : defaultValue;
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
        public static TValue GetValueOrDefault<TKey, TValue>(IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary is not null &&
                   dictionary.TryGetValue(key, out var value)
                ? value
                : default;
        }

        #endregion

        #region Get or Default Cascading

        /// <summary>
        /// Get value or default cascading
        /// </summary>
        /// <param name="dictionaryColl"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue GetValueOrDefaultCascading<TKey, TValue>(IEnumerable<IReadOnlyDictionary<TKey, TValue>> dictionaryColl, TKey key, TValue defaultValue)
        {
            if (dictionaryColl is null)
                throw new ArgumentNullException(nameof(dictionaryColl));
            return TryGetValueCascading(dictionaryColl, key, out var value) ? value : defaultValue;
        }

        /// <summary>
        /// Get value or default cascading
        /// </summary>
        /// <param name="dictionaryColl"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue GetValueOrDefaultCascading<TKey, TValue>(IEnumerable<IReadOnlyDictionary<TKey, TValue>> dictionaryColl, TKey key)
        {
            return GetValueOrDefaultCascading(dictionaryColl, key, default);
        }

        /// <summary>
        /// Try get value cascading
        /// </summary>
        /// <param name="dictionaryColl"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool TryGetValueCascading<TKey, TValue>(IEnumerable<IReadOnlyDictionary<TKey, TValue>> dictionaryColl, TKey key, out TValue value)
        {
            if (dictionaryColl is null)
                throw new ArgumentNullException(nameof(dictionaryColl));
            value = default;
            foreach (var dictionary in dictionaryColl)
                if (dictionary.TryGetValue(key, out value))
                    return true;
            return false;
        }

        #endregion
    }
}