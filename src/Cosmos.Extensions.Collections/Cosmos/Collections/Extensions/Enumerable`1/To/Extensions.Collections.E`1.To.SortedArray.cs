using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    public static partial class CollectionExtensions
    {
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
    }
}