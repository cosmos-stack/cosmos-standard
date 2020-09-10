using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Cosmos.Collections
{
    public static class DictionaryExtensions
    {
        #region Get

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
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue) =>
            dictionary != null && dictionary.TryGetValue(key, out var value) ? value : defaultValue;

        /// <summary>
        /// Get value or default
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) =>
            dictionary != null && dictionary.TryGetValue(key, out var value) ? value : default;

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
            if (dictionaries is null)
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
            if (dictionary is null)
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
            if (dictionary is null)
                throw new ArgumentNullException(nameof(dictionary));

            if (dictionary.TryGetValue(key, out var res))
                return res;

            res = valueCalculator(key);
            return dictionary[key] = res;
        }

        #endregion

        #region GroupBy

        /// <summary>
        /// Group by as dictionary
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyFunc"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, List<TItem>> GroupByAsDictionary<TItem, TKey>(
            this IEnumerable<TItem> list,
            Func<TItem, TKey> keyFunc)
        {
            return GroupByAsDictionary(list, keyFunc, x => x);
        }

        /// <summary>
        /// Group by as dictionary
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyFunc"></param>
        /// <param name="valueFunc"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, List<TValue>> GroupByAsDictionary<TItem, TKey, TValue>(
            this IEnumerable<TItem> list,
            Func<TItem, TKey> keyFunc,
            Func<TItem, TValue> valueFunc)
        {
            var res = new Dictionary<TKey, List<TValue>>();

            foreach (var item in list)
            {
                var key = keyFunc(item);
                var value = valueFunc(item);

                if (!res.TryGetValue(key, out var valuesList))
                {
                    valuesList = new List<TValue>();
                    res.Add(key, valuesList);
                }

                valuesList.Add(value);
            }

            return res;
        }

        /// <summary>
        /// Group by dictionary of dictonaries
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyFunc1"></param>
        /// <param name="keyFunc2"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <typeparam name="TKey1"></typeparam>
        /// <typeparam name="TKey2"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey1, Dictionary<TKey2, List<TItem>>> GroupByAsDictionaryOfDictionaries<TItem, TKey1, TKey2>(
            this IEnumerable<TItem> list,
            Func<TItem, TKey1> keyFunc1,
            Func<TItem, TKey2> keyFunc2)
        {
            var res = new Dictionary<TKey1, Dictionary<TKey2, List<TItem>>>();

            foreach (var item in list)
            {
                var key1 = keyFunc1(item);
                var key2 = keyFunc2(item);

                if (!res.TryGetValue(key1, out var dictionary1))
                {
                    dictionary1 = new Dictionary<TKey2, List<TItem>>();
                    res.Add(key1, dictionary1);
                }

                if (!dictionary1.TryGetValue(key2, out var valuesList))
                {
                    valuesList = new List<TItem>();
                    dictionary1.Add(key2, valuesList);
                }

                valuesList.Add(item);
            }

            return res;
        }

        /// <summary>
        /// Group by as dictionary hash
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyFunc"></param>
        /// <param name="valueFunc"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, HashSet<TValue>> GroupByAsDictionaryHash<TItem, TKey, TValue>(
            this IEnumerable<TItem> list,
            Func<TItem, TKey> keyFunc,
            Func<TItem, TValue> valueFunc)
        {
            var res = new Dictionary<TKey, HashSet<TValue>>();

            foreach (var item in list)
            {
                var key = keyFunc(item);
                var value = valueFunc(item);

                if (!res.TryGetValue(key, out var valuesList))
                {
                    valuesList = new HashSet<TValue>();
                    res.Add(key, valuesList);
                }

                valuesList.Add(value);
            }

            return res;
        }

        #endregion

        #region ReadOnly

        /// <summary>
        /// Wrap in readonly dictionary
        /// </summary>
        /// <param name="dictionary"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> WrapInReadOnlyDictionary<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary is null)
                throw new ArgumentNullException(nameof(dictionary));

            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }

        #endregion

        #region Select

        /// <summary>
        /// Select distinct sorted
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="TObj"></typeparam>
        /// <returns></returns>
        public static List<TObj> SelectDistinctSorted<TObj>(this IList<TObj> list) where TObj : IComparable
        {
            var res = new SortedList<TObj, TObj>(list.Count);
            foreach (var item in list)
            {
                if (!res.ContainsKey(item))
                    res.Add(item, item);
            }

            return res.Values.ToList();
        }

        #endregion

        #region Set

        /// <summary>
        /// Set value
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        public static void Set<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);
        }

        #endregion
        
         #region To

        /// <summary>
        /// To dictionary ignore duplicate keys
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyFunc"></param>
        /// <param name="valueFunc"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> ToDictionaryIgnoringDuplicateKeys<TItem, TKey, TValue>(this IList<TItem> list, Func<TItem, TKey> keyFunc,
            Func<TItem, TValue> valueFunc)
        {
            var res = new Dictionary<TKey, TValue>(list.Count);

            foreach (var item in list)
            {
                var key = keyFunc(item);
                if (!res.ContainsKey(key))
                    res.Add(key, valueFunc(item));
            }

            return res;
        }

        /// <summary>
        /// To sorted array by value
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static List<KeyValuePair<TKey, int>> ToSortedArrayByValue<TKey>(this Dictionary<TKey, int> list)
        {
            var res = new List<KeyValuePair<TKey, int>>();

            foreach (var valor in list)
            {
                res.Add(valor);
            }

            res.Sort((x, y) => -x.Value.CompareTo(y.Value));

            return res;
        }

        /// <summary>
        /// To sorted array by key
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static List<KeyValuePair<TKey, TValue>> ToSortedArrayByKey<TKey, TValue>(this Dictionary<TKey, TValue> list) where TKey : IComparable<TKey>
        {
            var res = new List<KeyValuePair<TKey, TValue>>();

            foreach (var valor in list)
            {
                res.Add(valor);
            }

            res.Sort((x, y) => x.Key.CompareTo(y.Key));

            return res;
        }

        /// <summary>
        /// To tuple...
        /// </summary>
        /// <param name="me"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static List<Tuple<TKey, TValue>> ToTuple<TKey, TValue>(this Dictionary<TKey, TValue> me)
        {
            var res = new List<Tuple<TKey, TValue>>();
#if NETSTANDARD2_0
            foreach (var pair in me)
            {
                res.Add(Tuple.Create(pair.Key, pair.Value));
            }
#else
            foreach (var (key, value) in me)
            {
                res.Add(Tuple.Create(key, value));
            }
#endif
            return res;
        }

        #endregion
    }
}