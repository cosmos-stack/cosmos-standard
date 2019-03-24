using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmos.Extensions
{
    public static partial class Extensions
    {
        /// <summary>
        /// 添加或覆盖一个值
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
        /// 从字典中获取数据。若不存在，则向字典中添加一个 <see cref="TValue"/> 新实例并返回该实例。
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
        /// 从字典中获取数据。若不存在，则通过 <see cref="newValueCreator"/> 获得新值插入字典并返回该值。
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
            dictionary.Add(key, res);
            return res;
        }

        /// <summary>
        /// 从字典中获取数据。若不存在，则通过 <see cref="valueCalculator"/> 获得新值并返回，新值不会更新到字典内。
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
        /// 从字典中获取数据。若不存在，则返回 <see cref="TValue"/> 的默认值，该默认值不会写入字典。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) where TValue : class
        {
            if (dictionary != null && dictionary.TryGetValue(key, out var res))
                return res;

            return default;
        }

        public static void AddDictionary<TKey, TVal>(this Dictionary<TKey, TVal> me, Dictionary<TKey, TVal> other)
        {
            foreach (var src in other)
            {
                me.Add(src.Key, src.Value);
            }
        }

        public static void Set<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {

            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);
        }
    }
}