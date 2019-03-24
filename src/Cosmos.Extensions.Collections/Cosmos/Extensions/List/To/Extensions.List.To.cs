using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class ListExtensions
    {
        public static TSource[] ToSortedArray<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparer)
        {
            var res = source.ToArray();
            Array.Sort(res, comparer);
            return res;
        }

        public static TSource[] ToSortedArray<TSource>(this IEnumerable<TSource> source) where TSource : IComparable<TSource>
        {
            var res = source.ToArray();
            Array.Sort(res);
            return res;
        }
    }
}
