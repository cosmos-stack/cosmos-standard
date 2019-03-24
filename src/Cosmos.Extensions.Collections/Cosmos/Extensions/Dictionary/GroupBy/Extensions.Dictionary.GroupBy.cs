using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class DictionaryExtensions
    {
        public static Dictionary<TKey, List<TItem>> GroupByAsDictionary<TItem, TKey>(this IEnumerable<TItem> list, Func<TItem, TKey> keyFunc)
        {
            return GroupByAsDictionary(list, keyFunc, x => x);
        }

        public static Dictionary<TKey, List<TValue>> GroupByAsDictionary<TItem, TKey, TValue>(this IEnumerable<TItem> list, Func<TItem, TKey> keyFunc, Func<TItem, TValue> valueFunc)
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

        public static Dictionary<TKey1, Dictionary<TKey2, List<TItem>>> GroupByAsDictionaryOfDictionaries<TItem, TKey1, TKey2>(this IEnumerable<TItem> list, Func<TItem, TKey1> keyFunc1, Func<TItem, TKey2> keyFunc2)
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

        public static Dictionary<TKey, HashSet<TValue>> GroupByAsDictionaryHash<TItem, TKey, TValue>(this IEnumerable<TItem> list, Func<TItem, TKey> keyFunc, Func<TItem, TValue> valueFunc)
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

    }
}
