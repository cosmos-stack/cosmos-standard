using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// Enumerable extensions
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// First based on...
        /// </summary>
        /// <param name="list"></param>
        /// <param name="order"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public static TItem FirstBasedOn<TItem>(this IList<TItem> list, Func<TItem, IComparable> order) where TItem : class
        {
            if (!list.Any()) return default;
            var first = default(TItem);
            IComparable valueFirst = null;

            foreach (var item in list)
            {
                var actual = order(item);
                if (valueFirst == null || actual.CompareTo(valueFirst) < 0)
                {
                    valueFirst = actual;
                    first = item;
                }
            }

            return first;
        }

        /// <summary>
        /// Last based on...
        /// </summary>
        /// <param name="list"></param>
        /// <param name="order"></param>
        /// <typeparam name="TItem"></typeparam>
        /// <returns></returns>
        public static TItem LastBasedOn<TItem>(this List<TItem> list, Func<TItem, IComparable> order)
        {
            if (!list.Any()) return default;
            var last = default(TItem);
            IComparable valueLast = null;

            foreach (var item in list)
            {
                var actual = order(item);
                if (valueLast == null || actual.CompareTo(valueLast) >= 0)
                {
                    valueLast = actual;
                    last = item;
                }
            }

            return last;
        }
    }
}