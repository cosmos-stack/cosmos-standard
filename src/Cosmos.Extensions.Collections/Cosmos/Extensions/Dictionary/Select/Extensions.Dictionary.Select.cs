using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Extensions for dictionary
    /// </summary>
    public static partial class DictionaryExtensions {
        /// <summary>
        /// Select distinct sorted
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="TObj"></typeparam>
        /// <returns></returns>
        public static List<TObj> SelectDistinctSorted<TObj>(this IList<TObj> list) where TObj : IComparable {
            var res = new SortedList<TObj, TObj>(list.Count);
            foreach (var item in list) {
                if (!res.ContainsKey(item))
                    res.Add(item, item);
            }

            return res.Values.ToList();
        }
    }
}