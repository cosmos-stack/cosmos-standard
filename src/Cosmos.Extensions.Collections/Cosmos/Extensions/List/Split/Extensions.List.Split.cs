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
        /// Split in groups
        /// </summary>
        /// <param name="values"></param>
        /// <param name="groupSize"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IEnumerable<List<TSource>> SplitInGroups<TSource>(this IEnumerable<TSource> values, int groupSize)
        {
            if (values is List<TSource> asList && asList.Count <= groupSize)
            {
                yield return asList;
                yield break;
            }

            var currentList = new List<TSource>(groupSize);

            foreach (var value in values)
            {
                if (currentList.Count >= groupSize)
                {
                    yield return currentList;
                    currentList = new List<TSource>(groupSize);
                }
                currentList.Add(value);
            }

            if (currentList.Count > 0)
                yield return currentList;
        }

        /// <summary>
        /// Split in groups remove duplicates
        /// </summary>
        /// <param name="values"></param>
        /// <param name="groupSize"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static List<List<TSource>> SplitInGroupsRemovingDuplicates<TSource>(this IEnumerable<TSource> values, int groupSize)
        {
            var res = new List<List<TSource>>();

            var duplicateCheck = new HashSet<TSource>();
            var currentList = new List<TSource>(groupSize);

            foreach (var value in values)
            {
                if (duplicateCheck.Contains(value))
                    continue;

                duplicateCheck.Add(value);

                if (currentList.Count >= groupSize)
                {
                    res.Add(currentList);
                    currentList = new List<TSource>(groupSize);
                }
                currentList.Add(value);
            }

            if (currentList.Count > 0)
                res.Add(currentList);

            return res;
        }
    }
}
