using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class ListExtensions
    {
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
