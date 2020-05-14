using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Enumerable extensions
    /// </summary>
    public static partial class EnumerableExtensions {
        /// <summary>
        /// Count distinct
        /// </summary>
        /// <param name="list"></param>
        /// <param name="valCalculator"></param>
        /// <typeparam name="TObj"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static int CountDistinct<TObj, TResult>(this IList<TObj> list, Func<TObj, TResult> valCalculator) {
            var check = new HashSet<TResult>();

            foreach (var item in list) {
                var result = valCalculator(item);
                if (!check.Contains(result))
                    check.Add(result);
            }

            return check.Count;
        }
    }
}