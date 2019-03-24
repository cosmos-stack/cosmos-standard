using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class ListExtensions
    {
        public static List<TResult> SelectDistinctSorted<TObj, TResult>(this IList<TObj> list, Func<TObj, TResult> valCalculator)
        {
            var res = new SortedList<TResult, TResult>(list.Count);
            return SelectDistinctSortedInternal(list, res, valCalculator);
        }

        public static List<string> SelectDistinctSortedIgnoreCase(this IList<string> list)
        {
            var res = new SortedList<string, string>(list.Count, StringComparer.OrdinalIgnoreCase);
            return SelectDistinctSortedInternal(list, res, str => str);
        }

        public static List<string> SelectDistinctSortedIgnoreCase(this IList<string> list, Func<string, string> valCalculator)
        {
            var res = new SortedList<string, string>(list.Count, StringComparer.OrdinalIgnoreCase);
            return SelectDistinctSortedInternal(list, res, valCalculator);
        }

        private static List<TResult> SelectDistinctSortedInternal<TObj, TResult>(IList<TObj> list, SortedList<TResult, TResult> check, Func<TObj, TResult> valCalculator)
        {
            foreach (var item in list)
            {
                var result = valCalculator(item);
                if (!check.ContainsKey(result))
                    check.Add(result, result);
            }

            return check.Values.ToList();
        }

        public static List<TResult> SelectDistinctUnSorted<TObj, TResult>(this IList<TObj> list, Func<TObj, TResult> valCalculator)
        {
            var res = new List<TResult>();
            var check = new HashSet<TResult>();
            foreach (var item in list)
            {
                var result = valCalculator(item);
                if (!check.Contains(result))
                {
                    check.Add(result);
                    res.Add(result);
                }
            }

            return res;
        }
    }
}
