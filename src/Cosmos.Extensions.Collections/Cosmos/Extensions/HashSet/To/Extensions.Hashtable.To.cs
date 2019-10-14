using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// Extensions for hshtable 
    /// </summary>
    public static class HashtableExtensions
    {
        /// <summary>
        /// To HashSet ignore duplicates
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public static HashSet<TItem> ToHashSetIgnoringDuplicates<TItem>(this IList<TItem> list) where TItem : IComparable<TItem>
        {
            var res = new HashSet<TItem>();
            foreach (var item in list)
            {
                if (!res.Contains(item))
                    res.Add(item);
            }

            return res;
        }

        /// <summary>
        /// To HashSet
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public static HashSet<TItem> ToHashSet<TItem>(this IEnumerable<TItem> list) where TItem : IComparable<TItem>
        {
            var res = new HashSet<TItem>();

            foreach (var item in list)
            {
                res.Add(item);
            }

            return res;
        }

        /// <summary>
        /// To HashSet
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ignoreDup"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public static HashSet<TItem> ToHashSet<TItem>(this IEnumerable<TItem> list, bool ignoreDup) where TItem : IComparable<TItem>
        {
            var res = new HashSet<TItem>();

            foreach (var item in list)
            {
                if (ignoreDup && res.Contains(item))
                    continue;

                res.Add(item);
            }

            return res;
        }

        /// <summary>
        /// To HashSet
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyFunc"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static HashSet<TKey> ToHashSet<TItem, TKey>(this IEnumerable<TItem> list, Func<TItem, TKey> keyFunc) where TKey : IComparable<TKey>
        {
            var res = new HashSet<TKey>();

            foreach (var item in list)
            {
                res.Add(keyFunc(item));
            }

            return res;
        }
    }
}