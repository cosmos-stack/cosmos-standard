using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Cosmos.Collections.Internals;
using Cosmos.Judgments;

namespace Cosmos.Collections
{
    /// <summary>
    /// Collection extensions
    /// </summary>
    public static class CosmosCollectionExtensions
    {
        #region Collections

        #region Contains

        /// <summary>
        /// 检查一个集合是否拥有指定数量的成员
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="enumeration"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(this ICollection<T> enumeration, int count)
            => CollectionJudgment.ContainsAtLeast(enumeration, count);

        /// <summary>
        /// 检查两个集合是否拥有相等数量的成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool ContainsEqualCount<T>(this ICollection<T> @this, ICollection<T> @that)
            => CollectionJudgment.ContainsEqualCount(@this, @that);

        #endregion

        #endregion

        #region Dictionary`2

        #region Add

        /// <summary>
        /// Add dictionary into another dictionary
        /// </summary>
        /// <param name="me"></param>
        /// <param name="other"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TVal"></typeparam>
        public static void AddDictionary<TKey, TVal>(this Dictionary<TKey, TVal> me, Dictionary<TKey, TVal> other)
        {
            foreach (var (key, value) in other)
            {
                me.Add(key, value);
            }
        }

        #endregion

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
        /// To dictionary
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyFunc"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, TItem> ToDictionary<TKey, TItem>(this IList<TItem> list, Func<TItem, TKey> keyFunc)
        {
            return ToDictionary(list, keyFunc, x => x);
        }

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyFunc"></param>
        /// <param name="valueFunc"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> ToDictionary<TItem, TKey, TValue>(this IList<TItem> list, Func<TItem, TKey> keyFunc, Func<TItem, TValue> valueFunc)
        {
            var res = new Dictionary<TKey, TValue>(list.Count);
            foreach (var item in list)
            {
                res.Add(keyFunc(item), valueFunc(item));
            }

            return res;
        }

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="hash"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Hashtable hash)
        {
            var res = new Dictionary<TKey, TValue>(hash.Count);
            foreach (var item in hash.Keys)
            {
                res.Add((TKey) item, (TValue) hash[item]);
            }

            return res;
        }

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

            foreach (var (key, value) in me)
            {
                res.Add(Tuple.Create(key, value));
            }

            return res;
        }

        #endregion

        #region ToString

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="linker"></param>
        /// <param name="separator"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static string ToString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, string linker, string separator)
        {
            if (dictionary is null) return string.Empty;
            var sb = new StringBuilder();
            foreach (var (key, value) in dictionary)
            {
                sb.Append($"{key}{linker}{value}{separator}");
            }

            return sb.ToString();
        }

        #endregion

        #endregion

        #region Enumerable`0

        #region Flatten

        /// <summary>
        /// 将多层的集合展开并整理为单层集合
        /// </summary>
        /// <param name="src"></param>
        /// <param name="enumerate"></param>
        /// <returns></returns>
        // ReSharper disable once FunctionRecursiveOnAllPaths
        public static IEnumerable Flatten(this IEnumerable src, Func<object, IEnumerable> enumerate) =>
            Flatten(src.Cast<object>(), o => (enumerate(o) ?? new object[0]).Cast<object>());

        #endregion

        #region Judgement

        /// <summary>
        /// 判断集合是否为空
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNull(this IEnumerable source) => CollectionJudgment.IsNull(source);

        /// <summary>
        /// 判断集合是否为空
        /// </summary>
        /// <param name="source">要处理的集合</param>
        /// <returns>为空返回 True，不为空返回 False</returns>
        public static bool IsNullOrEmpty(this IEnumerable source) =>
            CollectionJudgment.IsNullOrEmpty(source);

        /// <summary>
        /// 判断集合是否为空
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">要处理的集合</param>
        /// <returns>为空返回 True，不为空返回 False</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
            => CollectionJudgment.IsNullOrEmpty(source);

        #endregion

        #endregion

        #region Enumerable`1

        #region Append

        /// <summary>
        /// Append
        /// </summary>
        /// <param name="source"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, params T[] items)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return items is null ? source : source.Concat(items);
        }

        #endregion

        #region As

        /// <summary>
        /// 将集合转换为只读集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static ReadOnlyCollection<T> AsReadOnly<T>(this IEnumerable<T> enumerable)
        {
            return new ReadOnlyCollection<T>(new List<T>(enumerable));
        }

        /// <summary>
        /// As enumerable proxy
        /// </summary>
        /// <param name="enumerable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EnumerableProxy<T> AsEnumerableProxy<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable is null)
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
        public static IEnumerable<T?> AsNullables<T>(this IEnumerable<T> source) where T : struct
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return source.Cast<T?>();
        }

        #endregion

        #region Chunk

        /// <summary>
        /// Chunk
        /// </summary>
        /// <param name="source"></param>
        /// <param name="size"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int size)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size), size, $"The {nameof(size)} parameter must be a positive value.");

            using (var enumerator = source.GetEnumerator())
            {
                do
                {
                    if (!enumerator.MoveNext())
                        yield break;

                    yield return ChunkSequence(enumerator, size);
                } while (true);
            }
        }

        private static IEnumerable<T> ChunkSequence<T>(IEnumerator<T> enumerator, int size)
        {
            if (enumerator is null)
                throw new ArgumentNullException(nameof(enumerator));

            var count = 0;

            do
            {
                yield return enumerator.Current;
            } while (++count < size && enumerator.MoveNext());
        }

        #endregion

        #region Count

        /// <summary>
        /// Count distinct
        /// </summary>
        /// <param name="list"></param>
        /// <param name="valCalculator"></param>
        /// <typeparam name="TObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static int CountDistinct<TObj, TResult>(this IList<TObj> list, Func<TObj, TResult> valCalculator)
        {
            var check = new HashSet<TResult>();

            foreach (var item in list)
            {
                var result = valCalculator(item);
                if (!check.Contains(result))
                    check.Add(result);
            }

            return check.Count;
        }

        #endregion

        #region Flatten

        /// <summary>
        /// 将多层的集合展开并整理为单层集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src">   </param>
        /// <param name="enumerate"></param>
        /// <returns></returns>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> src, Func<T, IEnumerable<T>> enumerate)
        {
            if (src != null)
            {
                var stack = new Stack<T>(src);

                while (stack.Count > 0)
                {
                    var current = stack.Pop();

                    if (current is null)
                        continue;
                    yield return current;

                    var enumerable = enumerate?.Invoke(current);

                    if (enumerable is null)
                        continue;
                    foreach (var child in enumerable)
                        stack.Push(child);
                }
            }
        }

        #endregion

        #region ForEach

        /// <summary>
        /// Do action for each item
        /// </summary>
        /// <param name="src"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ForEach<T>(this IEnumerable<T> src, Action<T> action)
        {
            if (src is null) throw new ArgumentNullException(nameof(src));
            if (action is null) return;
            foreach (var i in src) action(i);
        }

        /// <summary>
        /// Do action for each item, and returns the result.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> ForEachItem<T>(this IEnumerable<T> src, Action<T> action)
        {
            if (src is null) throw new ArgumentNullException(nameof(src));
            if (action is null) return src;

            return src.Select(i =>
            {
                action(i);
                return i;
            });
        }

        #endregion

        #region Get

        /// <summary>
        /// Null if empty
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> NullIfEmpty<T>(this IEnumerable<T> source)
        {
            // Get the enumerator in a releasable disposable.
            using var disposable = new InternalReleasableDisposable<IEnumerator<T>>(source.GetEnumerator());
            // Get the enumerator.
            var enumerator = disposable.Disposable;

            // Move to the next item.  If there are no elements, then return null.
            if (!enumerator.MoveNext()) return null;

            // Release the disposable.
            disposable.Release();

            // Create an enumerator that skips the first move next.
            var wrapper = new InternalNullIfEmptySkipFirstMoveNextEnumeratorWrapper<T>(enumerator);

            // Wrap in a single use enumerator, return that.
            return new InternalSingleUseEnumerable<T>(wrapper);
        }

        #endregion

        #region Harvest

        /// <summary>
        /// Harvest
        /// </summary>
        /// <param name="source"></param>
        /// <param name="harvester"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Harvest<T>(this IEnumerable<T> source, ICollection<T> harvester)
            => source.Harvest(null, harvester);

        /// <summary>
        /// Harvest
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="harvester"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Harvest<T>(this IEnumerable<T> source, Func<T, bool> predicate, ICollection<T> harvester)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (harvester is null)
                throw new ArgumentNullException(nameof(harvester));
            if (predicate is null)
                predicate = t => true;

            foreach (var item in source)
            {
                if (!predicate(item))
                    continue;

                harvester.Add(item);
                yield return item;
            }
        }

        #endregion

        #region BasedOn

        /// <summary>
        /// First based on...
        /// </summary>
        /// <param name="list"></param>
        /// <param name="order"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public static TItem FirstBasedOn<TItem>(this IList<TItem> list, Func<TItem, IComparable> order) where TItem : class
        {
            if (!list.Any()) return default;
            var first = default(TItem);
            IComparable valueFirst = null;

            foreach (var item in list)
            {
                var actual = order(item);
                if (valueFirst is null || actual.CompareTo(valueFirst) < 0)
                {
                    valueFirst = actual;
                    first = item;
                }
            }

            return first;
        }

        /// <summary>
        /// Last based on...
        /// </summary>
        /// <param name="list"></param>
        /// <param name="order"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public static TItem LastBasedOn<TItem>(this List<TItem> list, Func<TItem, IComparable> order)
        {
            if (!list.Any()) return default;
            var last = default(TItem);
            IComparable valueLast = null;

            foreach (var item in list)
            {
                var actual = order(item);
                if (valueLast is null || actual.CompareTo(valueLast) >= 0)
                {
                    valueLast = actual;
                    last = item;
                }
            }

            return last;
        }

        #endregion

        #region Index

        /// <summary>
        /// Index of
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int? IndexOf<T>(this IEnumerable<T> source, T item) => source.IndexOf(item, EqualityComparer<T>.Default);

        /// <summary>
        /// Index of
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int? IndexOf<T>(this IEnumerable<T> source, T item, IEqualityComparer<T> equalityComparer)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (equalityComparer is null)
                throw new ArgumentNullException(nameof(equalityComparer));

            return source.Select((i, index) => new {Item = i, Index = index})
                .FirstOrDefault(p => equalityComparer.Equals(p.Item, item))
                ?.Index;
        }

        #endregion

        #region Intercept

        /// <summary>
        /// Intercept
        /// </summary>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Intercept<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (action is null)
                throw new ArgumentNullException(nameof(action));

            return source.Select(t =>
            {
                action(t);
                return t;
            });
        }

        #endregion

        #region Contains

        /// <summary>
        /// Contains<br />
        /// 包含
        /// </summary>
        /// <param name="me"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Contains<T>(this IEnumerable<T> me, Predicate<T> condition) =>
            me.Any(val => condition(val));

        #endregion

        #region In

        /// <summary>
        /// In
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool In<T>(this T item, params T[] items) => item.In((IEnumerable<T>) items);

        /// <summary>
        /// In
        /// </summary>
        /// <param name="item"></param>
        /// <param name="equalityComparer"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool In<T>(this T item, IEqualityComparer<T> equalityComparer, params T[] items) => item.In(items, equalityComparer);

        /// <summary>
        /// In
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool In<T>(this T item, IEnumerable<T> items) => item.In(items, EqualityComparer<T>.Default);

        /// <summary>
        /// In
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool In<T>(this T item, IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));
            if (equalityComparer is null)
                throw new ArgumentNullException(nameof(equalityComparer));

            return items.Contains(item, equalityComparer);
        }

        #endregion

        #region Linq-Select

        /// <summary>
        /// Select distinct sorted
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="valCalculator"></param>
        /// <typeparam name="TObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static IList<TResult> SelectDistinctSorted<TObj, TResult>(this IEnumerable<TObj> collection, Func<TObj, TResult> valCalculator)
        {
            var list = collection as TObj[] ?? collection.ToArray();
            var res = new SortedList<TResult, TResult>(list.Length);
            return SelectDistinctSortedInternal(list, res, valCalculator);
        }

        /// <summary>
        /// Select distinct sorted ignore case
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static IList<string> SelectDistinctSortedIgnoreCase(this IEnumerable<string> collection)
        {
            var list = collection as string[] ?? collection.ToArray();
            var res = new SortedList<string, string>(list.Length, StringComparer.OrdinalIgnoreCase);
            return SelectDistinctSortedInternal(list, res, str => str);
        }

        /// <summary>
        /// Select distinct sorted ignore case
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="valCalculator"></param>
        /// <returns></returns>
        public static IList<string> SelectDistinctSortedIgnoreCase(this IEnumerable<string> collection, Func<string, string> valCalculator)
        {
            var list = collection as string[] ?? collection.ToArray();
            var res = new SortedList<string, string>(list.Length, StringComparer.OrdinalIgnoreCase);
            return SelectDistinctSortedInternal(list, res, valCalculator);
        }

        private static IList<TResult> SelectDistinctSortedInternal<TObj, TResult>(IEnumerable<TObj> collection, SortedList<TResult, TResult> check,
            Func<TObj, TResult> valCalculator)
        {
            foreach (var item in collection)
            {
                var result = valCalculator(item);
                if (!check.ContainsKey(result))
                    check.Add(result, result);
            }

            return check.Values.ToList();
        }

        /// <summary>
        /// Select distinct un-sorted
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="valCalculator"></param>
        /// <typeparam name="TObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static IList<TResult> SelectDistinctUnsorted<TObj, TResult>(this IEnumerable<TObj> collection, Func<TObj, TResult> valCalculator)
        {
            var res = new List<TResult>();
            var check = new HashSet<TResult>();
            foreach (var item in collection)
            {
                var result = valCalculator(item);
                if (!check.Contains(result))
                {
                    check.Add(result);
                    res.Add(result);
                }
            }

            return res;
        }

        #endregion

        #region Linq-Take

        /// <summary>
        /// Take last
        /// </summary>
        /// <param name="src"></param>
        /// <param name="count"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> src, int count)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), count, $"The {nameof(count)} parameter must be a non-negative number.");

            // If the count is zero, return empty.
            if (count == 0)
                return Enumerable.Empty<T>();

            // Start sniffing.
            // Read-only collection.
            if (src is IReadOnlyCollection<T> ro)
                return ro.ReadOnlyCollectionTakeLast(count);

            // Collection.
            if (src is ICollection<T> c)
                return c.CollectionTakeLast(count);

            // Default.
            return src.EnumerableTakeLast(count);
        }

        private static IEnumerable<T> EnumerableTakeLast<T>(this IEnumerable<T> src, int count)
        {
            var window = new Queue<T>(count);

            foreach (T item in src)
            {
                window.Enqueue(item);
                if (window.Count > count)
                    window.Dequeue();
            }

            return window;
        }

        private static IEnumerable<T> CollectionTakeLast<T>(this ICollection<T> src, int count)
        {
            count = Math.Min(src.Count, count);

            if (count == 0)
                return Enumerable.Empty<T>();

            if (count == src.Count)
                return src;

            return src.Skip(src.Count - count);
        }

        private static IEnumerable<T> ReadOnlyCollectionTakeLast<T>(this IReadOnlyCollection<T> src, int count)
        {
            count = Math.Min(src.Count, count);

            if (count == 0)
                return Enumerable.Empty<T>();

            if (count == src.Count)
                return src;

            return src.Skip(src.Count - count);
        }

        #endregion

        #region Merge

        /// <summary>
        /// Merge<br />
        /// 合并集合
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> left, IEnumerable<T> right)
        {
            if (left is null) throw new ArgumentNullException(nameof(left));
            foreach (var item in left)
                yield return item;
            if (right is null)
                yield break;
            foreach (var item in right)
                yield return item;
        }

        /// <summary>
        /// Merge<br />
        /// 合并集合
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="limit"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> left, IEnumerable<T> right, int limit)
        {
            if (left is null) throw new ArgumentNullException(nameof(left));
            foreach (var item in left)
                yield return item;
            if (right is null)
                yield break;
            if (limit <= 0)
            {
                foreach (var item in right)
                    yield return item;
            }
            else
            {
                var counter = 0;
                foreach (var item in right)
                {
                    if (counter++ >= limit)
                        yield break;
                    yield return item;
                }
            }
        }

        #endregion

        #region ReadOnly

        /// <summary>
        /// To readonly collection
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> src)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            return src.ToList().WrapInReadOnlyCollection();
        }

        #endregion

        #region Sort

        /// <summary>
        /// Make the collection random order<br />
        /// 打乱一个集合的顺序
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> RandomOrder<TSource>(this IEnumerable<TSource> source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return source.OrderBy(o => Guid.NewGuid());
        }

        #endregion

        #region Split

        /// <summary>
        /// Split in groups
        /// </summary>
        /// <param name="values"></param>
        /// <param name="groupSize"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IEnumerable<List<TSource>> SplitInGroups<TSource>(this IEnumerable<TSource> values, int groupSize)
        {
            if (values is List<TSource> asList && asList.Count <= groupSize)
            {
                yield return asList;
                yield break;
            }

            var currentList = new List<TSource>(groupSize);

            foreach (var value in values)
            {
                if (currentList.Count >= groupSize)
                {
                    yield return currentList;
                    currentList = new List<TSource>(groupSize);
                }

                currentList.Add(value);
            }

            if (currentList.Count > 0)
                yield return currentList;
        }

        /// <summary>
        /// Split in groups remove duplicates
        /// </summary>
        /// <param name="values"></param>
        /// <param name="groupSize"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static List<List<TSource>> SplitInGroupsAndRemoveDuplicate<TSource>(this IEnumerable<TSource> values, int groupSize)
        {
            var res = new List<List<TSource>>();

            var duplicateCheck = new HashSet<TSource>();
            var currentList = new List<TSource>(groupSize);

            foreach (var value in values)
            {
                if (duplicateCheck.Contains(value))
                    continue;

                duplicateCheck.Add(value);

                if (currentList.Count >= groupSize)
                {
                    res.Add(currentList);
                    currentList = new List<TSource>(groupSize);
                }

                currentList.Add(value);
            }

            if (currentList.Count > 0)
                res.Add(currentList);

            return res;
        }

        #endregion

        #region To

        /// <summary>
        /// To index sequence
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<KeyValuePair<int, T>> ToIndexedSequence<T>(this IEnumerable<T> src)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            return src.Select((t, i) => new KeyValuePair<int, T>(i, t));
        }

        /// <summary>
        /// To safe array
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static TElement[] ToSafeArray<TElement>(this IEnumerable<TElement> src) =>
            src as TElement[] ?? src.ToArray();

        #endregion

        #region To Dictionary

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> src) =>
            src.ToDictionary(EqualityComparer<TKey>.Default);

        /// <summary>
        /// To dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="equalityComparer"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> src, IEqualityComparer<TKey> equalityComparer)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (equalityComparer is null)
                throw new ArgumentNullException(nameof(equalityComparer));
            return src.ToDictionary(p => p.Key, p => p.Value, equalityComparer);
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="keySelector"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<TValue> src, Func<TValue, TKey> keySelector)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            return src.ToDictionary(keySelector).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="keySelector"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<TValue> src, Func<TValue, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return src.ToDictionary(keySelector, comparer).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> src, Func<TSource, TKey> keySelector,
            Func<TSource, TValue> elementSelector,
            IEqualityComparer<TKey> comparer)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector is null)
                throw new ArgumentNullException(nameof(elementSelector));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return src.ToDictionary(keySelector, elementSelector, comparer).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> src, Func<TSource, TKey> keySelector,
            Func<TSource, TValue> elementSelector)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector is null)
                throw new ArgumentNullException(nameof(elementSelector));

            return src.ToDictionary(keySelector, elementSelector).WrapInReadOnlyDictionary();
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> src)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));

            return new ReadOnlyDictionary<TKey, TValue>(src.ToDictionary(p => p.Key, p => p.Value, EqualityComparer<TKey>.Default));
        }

        /// <summary>
        /// To readonly dictionary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyDictionary<TKey, TValue> ToReadOnlyDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> src, IEqualityComparer<TKey> comparer)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new ReadOnlyDictionary<TKey, TValue>(src.ToDictionary(p => p.Key, p => p.Value, comparer));
        }

        #endregion

        #region To HashSet

        /// <summary>
        /// To hashset
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> src) where T : IComparable<T> =>
            src.ToHashSet(EqualityComparer<T>.Default);

        /// <summary>
        /// To hashset
        /// </summary>
        /// <param name="src"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> src, IEqualityComparer<T> comparer)
            where T : IComparable<T>
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));
            return new HashSet<T>(src, comparer);
        }

        /// <summary>
        /// To HashSet
        /// </summary>
        /// <param name="src"></param>
        /// <param name="ignoreDup"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> src, bool ignoreDup) where T : IComparable<T> =>
            ignoreDup
                ? src.Distinct().ToHashSet(EqualityComparer<T>.Default)
                : src.ToHashSet(EqualityComparer<T>.Default);

        /// <summary>
        /// To HashSet
        /// </summary>
        /// <param name="src"></param>
        /// <param name="keyFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static HashSet<TKey> ToHashSet<T, TKey>(this IEnumerable<T> src, Func<T, TKey> keyFunc)
            where TKey : IComparable<TKey>
        {
            if (keyFunc is null) throw new ArgumentNullException(nameof(keyFunc));
            return src.Select(keyFunc).ToHashSet(EqualityComparer<TKey>.Default);
        }

        /// <summary>
        /// To HashSet ignore duplicates
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static HashSet<T> ToHashSetIgnoringDuplicates<T>(this IEnumerable<T> src) where T : IComparable<T> =>
            src.ToHashSet(true);

        #endregion

        #region To List
        
        /// <summary>
        /// To string list
        /// </summary>
        /// <param name="me"></param>
        /// <param name="stringConverter"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<string> ToList<T>(this IEnumerable<T> me, Func<T, string> stringConverter)
            => me.Select(stringConverter).ToList();

        /// <summary>
        /// To list
        /// </summary>
        /// <param name="src"></param>
        /// <param name="func"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<T> ToList<T>(this IEnumerable<T> src, Func<T, bool> func)
        {
            if (src is null) throw new ArgumentNullException(nameof(src));
            return func is null ? src.ToList() : src.Where(func).ToList();
        }

        #endregion

        #region To SortedArray
        
        /// <summary>
        /// To sorted array
        /// </summary>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static TSource[] ToSortedArray<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparer)
        {
            var res = source.ToArray();
            Array.Sort(res, comparer);
            return res;
        }

        /// <summary>
        /// To sorted array
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static TSource[] ToSortedArray<TSource>(this IEnumerable<TSource> source) where TSource : IComparable<TSource>
        {
            var res = source.ToArray();
            Array.Sort(res);
            return res;
        }

        #endregion

        #endregion

        #region Enumerator`1

        #region Merge

        /// <summary>
        /// 将两个具有相同种类的元素的集合合并
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="left"> </param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static IEnumerable<T> Merge<T>(this IEnumerator<T> left, IEnumerator<T> right)
        {
            while (left.MoveNext()) yield return left.Current;
            while (right.MoveNext()) yield return right.Current;
        }

        /// <summary>
        /// 将一个元素添加到一个具有相同种类的元素的集合内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="left"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public static IEnumerable<T> Merge<T>(this IEnumerator<T> left, T last)
        {
            while (left.MoveNext()) yield return left.Current;
            yield return last;
        }

        #endregion

        #region To

        /// <summary>
        /// To Enumerable
        /// </summary>
        /// <param name="enumerator"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> enumerator)
        {
            if (enumerator is null)
                throw new ArgumentNullException(nameof(enumerator));

            IEnumerable<T> Implementation()
            {
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
        public static IEnumerable<T> ToEnumerableAfter<T>(this IEnumerator<T> enumerator)
        {
            if (enumerator is null)
                throw new ArgumentNullException(nameof(enumerator));

            IEnumerable<T> Implementation()
            {
                do
                {
                    yield return enumerator.Current;
                } while (enumerator.MoveNext());
            }

            return Implementation();
        }

        #endregion

        #endregion

        #region List`1

        #region Add

        /// <summary>
        /// Add range
        /// </summary>
        /// <param name="source"></param>
        /// <param name="collection"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<T> AddRange<T>(this IList<T> source, IList<T> collection)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            foreach (var item in collection)
                source.Add(item);
            return source;
        }

        /// <summary>
        /// Add range
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="collection"></param>
        /// <param name="limit"></param>
        public static void AddRange<T>(this List<T> source, IEnumerable<T> collection, int limit)
        {
            if (limit <= 0)
            {
                source.AddRange(collection);
                return;
            }

            var counter = 0;
            source.AddRange(collection.TakeWhile(item => counter++ < limit));
        }

        /// <summary>
        /// Add into
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<T> AddRangeInto<T>(this IList<T> source, IList<T> target)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (target is null)
                throw new ArgumentNullException(nameof(target));
            target.AddRange(source);
            return target;
        }

        #endregion

        #region Find

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(this IList<T> list, T value) =>
            list.BinarySearch(t => t, value);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<TSource, TValue>(this IList<TSource> list, Func<TSource, TValue> map, TValue value) =>
            list.BinarySearch(map, value, Comparer<TValue>.Default);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(this IList<T> list, int index, int length, T value) =>
            list.BinarySearch(index, length, t => t, value);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<TSource, TValue>(this IList<TSource> list, int index, int length, Func<TSource, TValue> map, TValue value) =>
            list.BinarySearch(index, length, map, value, Comparer<TValue>.Default);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(this IList<T> list, T value, IComparer<T> comparer) =>
            list.BinarySearch(0, list.Count, t => t, value, comparer);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<TSource, TValue>(this IList<TSource> list, Func<TSource, TValue> map, TValue value, IComparer<TValue> comparer) =>
            list.BinarySearch(0, list.Count, map, value, comparer);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(this IList<T> list, int index, int length, T value, IComparer<T> comparer) =>
            list.BinarySearch(index, length, t => t, value, comparer);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static int BinarySearch<TSource, TValue>(this IList<TSource> list, int index, int length, Func<TSource, TValue> map, TValue value, IComparer<TValue> comparer)
        {
            if (list is null)
                throw new ArgumentNullException(nameof(list));
            if (map is null)
                throw new ArgumentNullException(nameof(map));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), index, $"The {nameof(index)} parameter must be a non-negative value.");
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), length, $"The {nameof(length)} parmeter must be a non-negative value.");
            if (index + length > list.Count)
                throw new InvalidOperationException(
                    $"The value of {nameof(index)} plus {nameof(length)} must be less than or equal to the value of the number of items in the {nameof(list)}.");

            // Do work.
            // Taken from https://github.com/dotnet/coreclr/blob/cdff8b0babe5d82737058ccdae8b14d8ae90160d/src/mscorlib/src/System/Collections/Generic/ArraySortHelper.cs#L156
            // The lo and high bounds.
            var low = index;
            var high = index + length - 1;

            // While low < high.
            while (low <= high)
            {
                // The midpoint.
                var midpoint = low + ((high - low) >> 1);

                // Compare.
                var order = comparer.Compare(map(list[midpoint]), value);

                // If they are equal, return.
                if (order == 0) return midpoint;

                // If less than zero, reset low, otherwise, reset high.
                if (order < 0)
                    low = midpoint + 1;
                else
                    high = midpoint - 1;
            }

            // Nothing matched, return inverse of the low bound.
            return ~low;
        }

        #endregion

        #region Move

        /// <summary>
        /// Move to first
        /// </summary>
        /// <param name="source"></param>
        /// <param name="element"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static List<TSource> MoveToFirst<TSource>(this List<TSource> source, TSource element)
        {
            if (!source.Contains(element))
                return source;

            source.Remove(element);
            source.Insert(0, element);
            return source;
        }

        #endregion

        #region ReadOnly

        /// <summary>
        /// Wrap in readonly connection
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyCollection<T> WrapInReadOnlyCollection<T>(this IList<T> source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return new ReadOnlyCollection<T>(source);
        }

        #endregion

        #region Remove

        /// <summary>
        /// Remove deplicates
        /// </summary>
        /// <param name="values"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> RemoveDuplicates<TSource>(this IList<TSource> values)
        {
            var duplicateCheck = new HashSet<TSource>();

            return values.RemoveWhere(item =>
            {
                if (duplicateCheck.Contains(item))
                    return true;

                duplicateCheck.Add(item);
                return false;
            });
        }

        /// <summary>
        /// Remove buplicates
        /// </summary>
        /// <param name="values"></param>
        /// <param name="duplicatePredicate"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCheck"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> RemoveDuplicates<TSource, TCheck>(this IList<TSource> values, Func<TSource, TCheck> duplicatePredicate)
        {
            if (duplicatePredicate is null)
                throw new ArgumentNullException(nameof(duplicatePredicate));

            var duplicateCheck = new HashSet<TCheck>();

            return values.RemoveWhere(item =>
            {
                var val = duplicatePredicate(item);

                if (duplicateCheck.Contains(val))
                    return true;

                duplicateCheck.Add(val);
                return false;
            });
        }

        /// <summary>
        /// Remove duplicates ignore case
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<string> RemoveDuplicatesIgnoreCase(this IList<string> values)
        {
            var duplicateCheck = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            return values.RemoveWhere(item =>
            {
                if (duplicateCheck.Contains(item))
                    return true;

                duplicateCheck.Add(item);
                return false;
            });
        }

        #endregion

        #region Remove Safty

        /// <summary>
        /// Safe remove range<br />
        /// 安全地移除指定范围内的成员
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> SafeRemoveRange<T>(this List<T> source, int index, int count)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (index < 0 || count < 0)
                return source;

            if (index >= source.Count)
                return source;

            count = Math.Min(count, source.Count) - index;

            source.RemoveRange(index, count);

            return source;
        }

        #endregion

        #region Remove Where

        /// <summary>
        /// Remove where...<br />
        /// 移除满足条件的成员，并最终返回筛选后的结果
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> RemoveWhere<T>(this IList<T> source, Func<T, bool> predicate)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            for (var i = source.Count - 1; i >= 0; --i)
            {
                var item = source[i];

                if (!predicate.Invoke(item))
                    continue;

                source.RemoveAt(i);

                yield return item;
            }
        }

        #endregion

        #region Shuffle

        /// <summary>
        /// Shuffle in place
        /// </summary>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        public static void ShuffleInPlace<T>(this IList<T> items) => ShuffleInPlace(items, 4);

        /// <summary>
        /// Shuffle in place
        /// </summary>
        /// <param name="items"></param>
        /// <param name="times"></param>
        /// <typeparam name="T"></typeparam>
        public static void ShuffleInPlace<T>(this IList<T> items, int times)
        {
            for (var j = 0; j < times; j++)
            {
                var rnd = new Random((int) (DateTime.Now.Ticks % int.MaxValue) - j);

                for (var i = 0; i < items.Count; i++)
                {
                    var index = rnd.Next(items.Count - 1);
                    var temp = items[index];
                    items[index] = items[i];
                    items[i] = temp;
                }
            }
        }

        /// <summary>
        /// Shuffle to new list
        /// </summary>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> ShuffleToNewList<T>(this IList<T> items) => ShuffleToNewList(items, 4);

        /// <summary>
        /// Shuffle to new list
        /// </summary>
        /// <param name="items"></param>
        /// <param name="times"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> ShuffleToNewList<T>(this IList<T> items, int times)
        {
            var res = new List<T>(items);
            res.ShuffleInPlace(times);
            return res;
        }

        #endregion

        #endregion

        #region Queryable`1

        #region Contains

        /// <summary>
        /// 检查一个集合是否拥有指定数量的成员
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="enumeration"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(this IQueryable<T> enumeration, int count)
            => QueryableJudgment.ContainsAtLeast(enumeration, count);

        /// <summary>
        /// 检查两个集合是否拥有相等数量的成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool ContainsEqualCount<T>(this IQueryable<T> @this, IQueryable<T> that)
            => QueryableJudgment.ContainsEqualCount(@this, that);

        #endregion

        #endregion

        #region ReadOnlyCollection`1

        #region Append

        /// <summary>
        /// Append
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyCollection<T> Append<T>(this IReadOnlyCollection<T> source, T item)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return new AppendedReadOnlyCollection<T>(source, item);
        }

        #endregion

        #endregion

        #region ReadOnlyDictionary`2

        #region Cast

        /// <summary>
        /// Cast
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TFromKey"></typeparam>
        /// <typeparam name="TFromValue"></typeparam>
        /// <typeparam name="TToKey"></typeparam>
        /// <typeparam name="TToValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyDictionary<TToKey, TToValue> Cast<TFromKey, TFromValue, TToKey, TToValue>(
            this IReadOnlyDictionary<TFromKey, TFromValue> source)
            where TFromKey : TToKey
            where TFromValue : TToValue
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return new CastingReadOnlyDictionaryWrapper<TFromKey, TFromValue, TToKey, TToValue>(source);
        }

        #endregion

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
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
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
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)
        {
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
        public static TValue GetValueOrDefaultCascading<TKey, TValue>(this IEnumerable<IReadOnlyDictionary<TKey, TValue>> dictionaries, TKey key, TValue defaultValue)
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
        public static TValue? TryGetValue<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key) where TValue : struct
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
        public static bool TryGetValueCascading<TKey, TValue>(this IEnumerable<IReadOnlyDictionary<TKey, TValue>> dictionaries, TKey key, out TValue value)
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
            => dictionaries.TryGetValueCascading(key, out var value) ? value : (TValue?) null;

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

        #endregion

        #endregion

        #region ReadOnlyList`1

        #region As

        /// <summary>
        /// As list
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<T> AsList<T>(this IReadOnlyList<T> list)
        {
            // Validate parameters.
            if (list is null) throw new ArgumentNullException(nameof(list));

            // Wrap and return.
            return new ReadOnlyListWrapper<T>(list);
        }

        #endregion

        #region Search

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(this IReadOnlyList<T> list, T value) => list.BinarySearch(t => t, value);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<TSource, TValue>(this IReadOnlyList<TSource> list, Func<TSource, TValue> map, TValue value) =>
            list.BinarySearch(map, value, Comparer<TValue>.Default);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(this IReadOnlyList<T> list, int index, int length, T value) =>
            list.BinarySearch(index, length, t => t, value);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<TSource, TValue>(this IReadOnlyList<TSource> list, int index, int length, Func<TSource, TValue> map, TValue value) =>
            list.BinarySearch(index, length, map, value, Comparer<TValue>.Default);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(this IReadOnlyList<T> list, T value, IComparer<T> comparer) =>
            list.BinarySearch(0, list.Count, t => t, value, comparer);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<TSource, TValue>(this IReadOnlyList<TSource> list, Func<TSource, TValue> map, TValue value, IComparer<TValue> comparer) =>
            list.BinarySearch(0, list.Count, map, value, comparer);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int BinarySearch<T>(this IReadOnlyList<T> list, int index, int length, T value, IComparer<T> comparer) =>
            list.BinarySearch(index, length, t => t, value, comparer);

        /// <summary>
        /// Binary search
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="map"></param>
        /// <param name="value"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static int BinarySearch<TSource, TValue>(this IReadOnlyList<TSource> list, int index, int length, Func<TSource, TValue> map, TValue value,
            IComparer<TValue> comparer)
        {
            if (list is null)
                throw new ArgumentNullException(nameof(list));
            if (map is null)
                throw new ArgumentNullException(nameof(map));
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), index, $"The {nameof(index)} parameter must be a non-negative value.");
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), length, $"The {nameof(length)} parameter must be a non-negative value.");
            if (index + length > list.Count)
                throw new InvalidOperationException(
                    $"The value of {nameof(index)} plus {nameof(length)} must be less than or equal to the value of the number of items in the {nameof(list)}.");

            // Do work.
            // Taken from https://github.com/dotnet/coreclr/blob/cdff8b0babe5d82737058ccdae8b14d8ae90160d/src/mscorlib/src/System/Collections/Generic/ArraySortHelper.cs#L156
            // The lo and high bounds.
            int low = index;
            int high = index + length - 1;

            // While low < high.
            while (low <= high)
            {
                // The midpoint.
                int midpoint = low + ((high - low) >> 1);

                // Compare.
                int order = comparer.Compare(map(list[midpoint]), value);

                // If they are equal, return.
                if (order == 0) return midpoint;

                // If less than zero, reset low, otherwise, reset high.
                if (order < 0)
                    low = midpoint + 1;
                else
                    high = midpoint - 1;
            }

            // Nothing matched, return inverse of the low bound.
            return ~low;
        }

        #endregion

        #endregion

        #region Set

        #region Add

        /// <summary>
        /// Add range
        /// </summary>
        /// <param name="set"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyCollection<SetAddRangeResult<T>> AddRange<T>(this ISet<T> set, IEnumerable<T> items)
        {
            if (set is null)
                throw new ArgumentNullException(nameof(set));
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            var added = new List<SetAddRangeResult<T>>(items is ICollection<T> collection ? collection.Count : 1);

            added.AddRange(items.Select(i => new SetAddRangeResult<T>(i, set.Add(i))));

            return added.WrapInReadOnlyCollection();
        }

        #endregion

        #endregion
    }
}