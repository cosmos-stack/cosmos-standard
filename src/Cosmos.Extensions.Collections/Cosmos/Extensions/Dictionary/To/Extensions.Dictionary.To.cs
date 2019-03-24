using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class DictionaryExtensions
    {
        public static Dictionary<TKey, TItem> ToDictionary<TKey, TItem>(this IList<TItem> list, Func<TItem, TKey> keyFunc)
        {
            return ToDictionary(list, keyFunc, x => x);
        }

        public static Dictionary<TKey, TValue> ToDictionary<TItem, TKey, TValue>(this IList<TItem> list, Func<TItem, TKey> keyFunc, Func<TItem, TValue> valueFunc)
        {
            var res = new Dictionary<TKey, TValue>(list.Count);
            foreach (var item in list)
            {
                res.Add(keyFunc(item), valueFunc(item));
            }

            return res;
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Hashtable hash)
        {
            var res = new Dictionary<TKey, TValue>(hash.Count);
            foreach (var item in hash.Keys)
            {
                res.Add((TKey)item, (TValue)hash[item]);
            }

            return res;
        }

        public static Dictionary<TKey, TValue> ToDictionaryIgnoringDuplicateKeys<TItem, TKey, TValue>(this IList<TItem> list, Func<TItem, TKey> keyFunc, Func<TItem, TValue> valueFunc)
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

        public static List<Tuple<TKey, TValue>> ToTuple<TKey, TValue>(this Dictionary<TKey, TValue> me)
        {
            var res = new List<Tuple<TKey, TValue>>();

            foreach (var val in me)
            {
                res.Add(Tuple.Create(val.Key, val.Value));
            }

            return res;
        }
    }
}
