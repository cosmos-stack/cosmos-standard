using System;
using System.Collections.Generic;

namespace Cosmos.Collections
{
    /// <summary>
    /// Cosmos Dictionary extensions
    /// </summary>
    public static partial class CosmosDictionaryExtensions
    {
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