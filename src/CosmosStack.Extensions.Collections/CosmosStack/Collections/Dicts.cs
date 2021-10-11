using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CosmosStack.Collections
{
    /// <summary>
    /// Dictionary Utilities <br />
    /// 字典工具
    /// </summary>
    public static class Dicts
    {
        #region Add

        /// <summary>
        /// Add or override <br />
        /// 添加或覆盖
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddValueOrOverride<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            dictionary[key] = value;
        }

        /// <summary>
        /// Add or update <br />
        /// 添加或更新
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="insertFunc"></param>
        /// <param name="updateFunc"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        public static void AddValueOrUpdate<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> insertFunc, Func<TKey, TValue, TValue> updateFunc)
        {
            if (insertFunc is null)
                throw new ArgumentNullException(nameof(insertFunc));

            if (updateFunc is null)
                throw new ArgumentNullException(nameof(updateFunc));

            var newVal = dictionary.ContainsKey(key)
                ? updateFunc(key, dictionary[key])
                : insertFunc(key);

            AddValueOrOverride(dictionary, key, newVal);
        }

        /// <summary>
        /// Add or update <br />
        /// 添加或更新
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="insertFunc"></param>
        /// <param name="doAct"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddValueOrDo<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> insertFunc, Action<TKey, TValue> doAct)
        {
            if (insertFunc is null)
                throw new ArgumentNullException(nameof(insertFunc));

            if (doAct is null)
                throw new ArgumentNullException(nameof(doAct));

            if (dictionary.ContainsKey(key))
            {
                doAct(key, dictionary[key]);
            }
            else
            {
                AddValueOrOverride(dictionary, key, insertFunc(key));
            }
        }

        /// <summary>
        /// Add if not exist <br />
        /// 如果不存在则添加
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddValueIfNotExist<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key)) return;
            dictionary[key] = value;
        }
        
        /// <summary>
        /// Merge the second dictionary into the first one <br />
        /// 合并字典到第一个
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dict"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TVal"></typeparam>
        public static void Add<TKey, TVal>(Dictionary<TKey, TVal> source, Dictionary<TKey, TVal> dict)
        {
            foreach (var pair in dict)
                source.Add(pair.Key, pair.Value);
        }

        #endregion

        #region Get or Default

        /// <summary>
        /// Get value or default <br />
        /// 获取值或默认值
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="valueCalculator"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue GetValueOrDefault<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueCalculator)
        {
            if (dictionary is not null && dictionary.TryGetValue(key, out var value))
                return value;

            if (valueCalculator is null)
                return default;

            return valueCalculator.Invoke(key);
        }

        /// <summary>
        /// Get value or default <br />
        /// 获取值或默认值
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue GetValueOrDefault<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            return dictionary is not null &&
                   dictionary.TryGetValue(key, out var value)
                ? value
                : defaultValue;
        }

        /// <summary>
        /// Get value or default <br />
        /// 获取值或默认值
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue GetValueOrDefault<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary is not null &&
                   dictionary.TryGetValue(key, out var value)
                ? value
                : default;
        }

        #endregion

        #region Get or Default Cascading

        /// <summary>
        /// Get value or default cascading <br />
        /// 级联地尝试获取一个值或默认值，该值为值类型的
        /// </summary>
        /// <param name="dictionaryColl"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TValue GetValueOrDefaultCascading<TKey, TValue>(IEnumerable<IDictionary<TKey, TValue>> dictionaryColl, TKey key, TValue defaultValue)
        {
            if (dictionaryColl is null)
                throw new ArgumentNullException(nameof(dictionaryColl));
            return TryGetValueCascading(dictionaryColl, key, out var value) ? value : defaultValue;
        }

        /// <summary>
        /// Get value or default cascading <br />
        /// 级联地尝试获取一个值或默认值，该值为值类型的
        /// </summary>
        /// <param name="dictionaryColl"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue GetValueOrDefaultCascading<TKey, TValue>(IEnumerable<IDictionary<TKey, TValue>> dictionaryColl, TKey key)
        {
            return GetValueOrDefaultCascading(dictionaryColl, key, default);
        }

        /// <summary>
        /// Try get value cascading <br />
        /// 级联地尝试获取一个可选地值，该值为值类型的
        /// </summary>
        /// <param name="dictionaryColl"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool TryGetValueCascading<TKey, TValue>(IEnumerable<IDictionary<TKey, TValue>> dictionaryColl, TKey key, out TValue value)
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

        #region Get or Add

        /// <summary>
        /// Get or add <br />
        /// 获取或添加
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TValue GetValueOrAdd<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.TryGetValue(key, out var res))
                return res;

            return dictionary[key] = value;
        }

        /// <summary>
        /// Get or add <br />
        /// 获取或添加
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="newValueCreator"></param>
        /// <returns></returns>
        public static TValue GetValueOrAdd<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> newValueCreator)
        {
            if (newValueCreator is null)
                throw new ArgumentNullException(nameof(newValueCreator));

            if (dictionary.TryGetValue(key, out var res))
                return res;

            return dictionary[key] = newValueCreator(key);
        }

        /// <summary>
        /// Get or add new default instance <br />
        /// 获取或添加一个默认新实例
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetValueOrAddNewInstance<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key) where TValue : new()
        {
            return GetValueOrAdd(dictionary, key, _ => new TValue());
        }

        #endregion

        #region GroupBy

        /// <summary>
        /// Group by as dictionary <br />
        /// 分组为字典
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyFunc"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, List<TItem>> GroupByAsDictionary<TItem, TKey>(
            IEnumerable<TItem> list, Func<TItem, TKey> keyFunc)
        {
            return GroupByAsDictionary(list, keyFunc, x => x);
        }

        /// <summary>
        /// Group by as dictionary <br />
        /// 分组为字典
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyFunc"></param>
        /// <param name="valueFunc"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, List<TValue>> GroupByAsDictionary<TItem, TKey, TValue>(
            IEnumerable<TItem> list, Func<TItem, TKey> keyFunc, Func<TItem, TValue> valueFunc)
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

        #endregion

        #region Set Value

        /// <summary>
        /// Set value <br />
        /// 设置值
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        public static void SetValue<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);
        }

        #endregion
    }

    /// <summary>
    /// Dictionary Utilities Extensions<br />
    /// 字典工具扩展
    /// </summary>
    public static class DictsExtensions
    {
        #region Add

        /// <summary>
        /// Add one dictionary into another one. <br />
        /// 将一个字典添加到另一个
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dict"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TVal"></typeparam>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add<TKey, TVal>(this Dictionary<TKey, TVal> source, Dictionary<TKey, TVal> dict)
        {
            Dicts.Add(source, dict);
        }

        /// <summary>
        /// Add one key-value-pair into the given dictionary. <br />
        /// 添加一组键值对到给定字典
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pair"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TVal"></typeparam>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add<TKey, TVal>(this Dictionary<TKey, TVal> source, KeyValuePair<TKey, TVal> pair)
        {
            source.Add(pair.Key, pair.Value);
        }

        /// <summary>
        /// Add or override <br />
        /// 添加或覆盖
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddValueOrOverride<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            Dicts.AddValueOrOverride(dictionary, key, value);
        }

        /// <summary>
        /// Add or update <br />
        /// 添加或更新
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="insertFunc"></param>
        /// <param name="updateFunc"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddValueOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> insertFunc, Func<TKey, TValue, TValue> updateFunc)
        {
            Dicts.AddValueOrUpdate(dictionary, key, insertFunc, updateFunc);
        }

        /// <summary>
        /// Add or update <br />
        /// 添加或更新
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="insertFunc"></param>
        /// <param name="doAct"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddValueOrDo<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> insertFunc, Action<TKey, TValue> doAct)
        {
            Dicts.AddValueOrDo(dictionary, key, insertFunc, doAct);
        }

        /// <summary>
        /// Add if not exist <br />
        /// 如果不存在则添加
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddValueIfNotExist<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            Dicts.AddValueIfNotExist(dictionary, key, value);
        }

        #endregion

        #region Get or Default

        /// <summary>
        /// Get value or default <br />
        /// 获取值或默认值
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="valueCalculator"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueCalculator)
        {
            return Dicts.GetValueOrDefault(dictionary, key, valueCalculator);
        }

#if NETFRAMEWORK || NETSTANDARD2_0
        /// <summary>
        /// Get value or default <br />
        /// 获取值或默认值
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
         [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            return Dicts.GetValueOrDefault(dictionary, key, defaultValue);
        }
        
        /// <summary>
        /// Get value or default <br />
        /// 获取值或默认值
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
         [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return Dicts.GetValueOrDefault(dictionary, key);
        }
#endif
        
        #endregion

        #region Get or Default Cascading

        /// <summary>
        /// Get value or default cascading <br />
        /// 级联地尝试获取一个值或默认值，该值为值类型的
        /// </summary>
        /// <param name="dictionaryColl"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue GetValueOrDefaultCascading<TKey, TValue>(this IEnumerable<IDictionary<TKey, TValue>> dictionaryColl, TKey key, TValue defaultValue)
        {
            return Dicts.GetValueOrDefaultCascading(dictionaryColl, key, defaultValue);
        }

        /// <summary>
        /// Get value or default cascading <br />
        /// 级联地尝试获取一个值或默认值，该值为值类型的
        /// </summary>
        /// <param name="dictionaryColl"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue GetValueOrDefaultCascading<TKey, TValue>(this IEnumerable<IDictionary<TKey, TValue>> dictionaryColl, TKey key)
        {
            return Dicts.GetValueOrDefaultCascading(dictionaryColl, key, default);
        }

        /// <summary>
        /// Try get value cascading <br />
        /// 级联地尝试获取一个可选地值，该值为值类型的
        /// </summary>
        /// <param name="dictionaryColl"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetValueCascading<TKey, TValue>(this IEnumerable<IDictionary<TKey, TValue>> dictionaryColl, TKey key, out TValue value)
        {
            return Dicts.TryGetValueCascading(dictionaryColl, key, out value);
        }

        #endregion
        
        #region Get or Add

        /// <summary>
        /// Get or add <br />
        /// 获取或添加
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue GetValueOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            return Dicts.GetValueOrAdd(dictionary, key, value);
        }

        /// <summary>
        /// Get or add <br />
        /// 获取或添加
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="newValueCreator"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue GetValueOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> newValueCreator)
        {
            return Dicts.GetValueOrAdd(dictionary, key, newValueCreator);
        }

        /// <summary>
        /// Get or add new default instance <br />
        /// 获取或添加一个新的默认实例
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue GetValueOrAddNewInstance<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) where TValue : new()
        {
            return Dicts.GetValueOrAddNewInstance(dictionary, key);
        }

        #endregion

        #region Set Value

        /// <summary>
        /// Set value <br />
        /// 设置值
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            Dicts.SetValue(dictionary, key, value);
        }

        #endregion
    }
}