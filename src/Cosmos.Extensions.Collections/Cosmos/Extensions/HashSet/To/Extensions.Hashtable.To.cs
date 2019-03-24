using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class HashtableExtensions
    {
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

        public static HashSet<TItem> ToHashSet<TItem>(this IEnumerable<TItem> list) where TItem : IComparable<TItem>
        {
            var res = new HashSet<TItem>();

            foreach (var item in list)
            {
                res.Add(item);
            }

            return res;
        }

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
