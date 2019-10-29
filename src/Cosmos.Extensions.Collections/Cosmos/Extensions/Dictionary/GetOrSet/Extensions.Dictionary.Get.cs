using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// Extensions for dictionary
    /// </summary>
    public static partial class DictionaryExtensions
    {
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
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            return dictionary != null && dictionary.TryGetValue(key, out var value) ? value : defaultValue;
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
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary != null && dictionary.TryGetValue(key, out var value) ? value : default;
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
        public static TValue GetValueOrDefaultCascading<TKey, TValue>(this IEnumerable<IDictionary<TKey, TValue>> dictionaries, TKey key, TValue defaultValue)
        {
            if (dictionaries == null)
                throw new ArgumentNullException(nameof(dictionaries));

            return dictionaries.TryGetValueCascading(key, out var value) ? value : defaultValue;
        }

        /// <summary>
        /// Get value or default cascading
        /// </summary>
        /// <param name="dictionaries"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue GetValueOrDefaultCascading<TKey, TValue>(this IEnumerable<IDictionary<TKey, TValue>> dictionaries, TKey key)
            => dictionaries.GetValueOrDefaultCascading(key, default);

        /// <summary>
        /// Add or override
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddOrOverride<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            dictionary[key] = value;
        }

        /// <summary>
        /// Try get value
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue? TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : struct
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));

            return dictionary.TryGetValue(key, out var value) ? value : (TValue?) null;
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
        public static bool TryGetValueCascading<TKey, TValue>(this IEnumerable<IDictionary<TKey, TValue>> dictionaries, TKey key, out TValue value)
        {
            if (dictionaries == null)
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
        public static bool TryGetValueCascading<TKey, TValue>(TKey key, out TValue value, params IDictionary<TKey, TValue>[] dictionaries)
            => dictionaries.TryGetValueCascading(key, out value);

        /// <summary>
        /// Try get value cascading
        /// </summary>
        /// <param name="dictionaries"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue? TryGetValueCascading<TKey, TValue>(this IEnumerable<IDictionary<TKey, TValue>> dictionaries, TKey key) where TValue : struct
            => dictionaries.TryGetValueCascading(key, out TValue value) ? value : (TValue?) null;

        /// <summary>
        /// Try get value cascading
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dictionaries"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue? TryGetValueCascading<TKey, TValue>(TKey key, params IDictionary<TKey, TValue>[] dictionaries) where TValue : struct
            => dictionaries.TryGetValueCascading(key);

        /// <summary>
        /// Get or add
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.TryGetValue(key, out var res))
                return res;

            return dictionary[key] = value;
        }

        /// <summary>
        /// Get or add
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="newValueCreator"></param>
        /// <returns></returns>
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> newValueCreator)
        {
            if (dictionary.TryGetValue(key, out var res))
                return res;

            res = newValueCreator(key);
            return dictionary[key] = res;
        }
        
        /// <summary>
        /// Get or add new default instance
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetOrAddNewInstance<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) where TValue : new()
        {
            if (dictionary.TryGetValue(key, out var res))
                return res;

            res = new TValue();
            dictionary.Add(key, res);
            return res;
        }

        /// <summary>
        /// Get value
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="valueCalculator"></param>
        /// <returns></returns>
        public static TValue GetOrCalculate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueCalculator)
        {
            if (dictionary != null && dictionary.TryGetValue(key, out var res))
                return res;

            return valueCalculator(key);
        }

        /// <summary>
        /// Get value
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="valueCalculator"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue GetOrAddCalculatedInstance<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueCalculator)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));

            if (dictionary.TryGetValue(key, out var res))
                return res;

            res = valueCalculator(key);
            return dictionary[key] = res;
        }
    }
}