using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Collection extensions
    /// </summary>
    public static partial class CollectionExtensions {
        /// <summary>
        /// Select distinct sorted
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="valCalculator"></param>
        /// <typeparam name="TObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static IList<TResult> SelectDistinctSorted<TObj, TResult>(this IEnumerable<TObj> collection, Func<TObj, TResult> valCalculator) {
            var list = collection as TObj[] ?? collection.ToArray();
            var res = new SortedList<TResult, TResult>(list.Length);
            return SelectDistinctSortedInternal(list, res, valCalculator);
        }

        /// <summary>
        /// Select distinct sorted ignore case
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static IList<string> SelectDistinctSortedIgnoreCase(this IEnumerable<string> collection) {
            var list = collection as string[] ?? collection.ToArray();
            var res = new SortedList<string, string>(list.Length, StringComparer.OrdinalIgnoreCase);
            return SelectDistinctSortedInternal(list, res, str => str);
        }

        /// <summary>
        /// Select distinct sorted ignore case
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="valCalculator"></param>
        /// <returns></returns>
        public static IList<string> SelectDistinctSortedIgnoreCase(this IEnumerable<string> collection, Func<string, string> valCalculator) {
            var list = collection as string[] ?? collection.ToArray();
            var res = new SortedList<string, string>(list.Length, StringComparer.OrdinalIgnoreCase);
            return SelectDistinctSortedInternal(list, res, valCalculator);
        }

        private static IList<TResult> SelectDistinctSortedInternal<TObj, TResult>(IEnumerable<TObj> collection, SortedList<TResult, TResult> check,
            Func<TObj, TResult> valCalculator) {
            foreach (var item in collection) {
                var result = valCalculator(item);
                if (!check.ContainsKey(result))
                    check.Add(result, result);
            }

            return check.Values.ToList();
        }

        /// <summary>
        /// Select distinct un-sorted
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="valCalculator"></param>
        /// <typeparam name="TObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static IList<TResult> SelectDistinctUnsorted<TObj, TResult>(this IEnumerable<TObj> collection, Func<TObj, TResult> valCalculator) {
            var res = new List<TResult>();
            var check = new HashSet<TResult>();
            foreach (var item in collection) {
                var result = valCalculator(item);
                if (!check.Contains(result)) {
                    check.Add(result);
                    res.Add(result);
                }
            }

            return res;
        }
    }
}