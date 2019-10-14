using System.Collections.Generic;

namespace Cosmos
{
    /// <summary>
    /// Enumerable factory
    /// </summary>
    public static class EnumerableFactory
    {
        /// <summary>
        /// Create list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> CreateList<T>() => new List<T>();

        /// <summary>
        /// Create list
        /// </summary>
        /// <param name="listParams"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> CreateList<T>(params IEnumerable<T>[] listParams)
        {
            var ret = CreateList<T>();
            if (listParams != null)
            {
                foreach (var list in listParams)
                {
                    ret.AddRange(list);
                }
            }

            return ret;
        }

        /// <summary>
        /// Create readonly list
        /// </summary>
        /// <param name="listParams"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IReadOnlyList<T> CreateReadOnlyList<T>(params IEnumerable<T>[] listParams) => CreateList(listParams);
    }
}