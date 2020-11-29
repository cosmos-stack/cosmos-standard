using System.Linq;

namespace Cosmos.Collections
{
    public static class QueryableJudge
    {
        #region Contains

        /// <summary>
        /// Determine whether a queryable set contains at least a specified number of elements.<br />
        /// 判断一个可查询集合是否至少包含指定数量的元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(IQueryable<T> query, int count)
        {
            if (query is null)
                return false;

            return (from t in query.Take(count) select t).Count() >= count;
        }

        /// <summary>
        /// Determine whether the two queryable sets contain the same number of elements.<br />
        /// 判断这两个可查询集合是否包含相同数量的元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="targetQuery"></param>
        /// <returns></returns>
        public static bool ContainsSameNumberOfElements<T>(IQueryable<T> query, IQueryable<T> targetQuery)
        {
            if (query is null && targetQuery is null)
                return true;

            if (query is null || targetQuery is null)
                return false;

            return query.Count().Equals(targetQuery.Count());
        }

        #endregion
    }
}