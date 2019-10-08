using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// Extensions of list
    /// </summary>
    public static partial class ListExtensions
    {
        /// <summary>
        /// Remove deplicates
        /// </summary>
        /// <param name="values"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static List<TSource> RemoveDuplicates<TSource>(this IList<TSource> values)
        {
            var res = new List<TSource>(values.Count);
            var duplicateCheck = new HashSet<TSource>();

            foreach (var value in values)
            {
                if (duplicateCheck.Contains(value))
                    continue;

                duplicateCheck.Add(value);
                res.Add(value);
            }

            return res;
        }

        /// <summary>
        /// Remove buplicates
        /// </summary>
        /// <param name="values"></param>
        /// <param name="dupliCheck"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCheck"></typeparam>
        /// <returns></returns>
        public static List<TSource> RemoveDuplicates<TSource, TCheck>(this IList<TSource> values, Func<TSource, TCheck> dupliCheck)
        {
            var duplicateCheck = new HashSet<TCheck>();
            var res = new List<TSource>(values.Count);

            foreach (var value in values)
            {
                var val = dupliCheck(value);

                if (duplicateCheck.Contains(val))
                    continue;

                duplicateCheck.Add(val);
                res.Add(value);
            }

            return res;
        }

        /// <summary>
        /// Remove duplicates ignore case
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static List<string> RemoveDuplicatesIgnoreCase(this IList<string> values)
        {
            var duplicateCheck = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var res = new List<string>(values.Count);
            foreach (var value in values)
            {
                if (duplicateCheck.Contains(value))
                {
                    continue;
                }

                duplicateCheck.Add(value);
                res.Add(value);
            }

            return res;
        }
    }
}