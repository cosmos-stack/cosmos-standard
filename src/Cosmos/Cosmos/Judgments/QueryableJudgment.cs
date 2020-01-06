using System.Linq;

namespace Cosmos.Judgments {
    /// <summary>
    /// Queryable Judgment Utilities
    /// </summary>
    public static class QueryableJudgment {
        /// <summary>
        /// To judge whether one queryable collection contains specified count of elements at least.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(IQueryable<T> query, int count) {
            if (query is null)
                return false;

            return (from t in query.Take(count) select t).Count() >= count;
        }

        /// <summary>
        /// To judge whether these two queryable collections contain same count of elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="targetQuery"></param>
        /// <returns></returns>
        public static bool ContainsEqualCount<T>(IQueryable<T> query, IQueryable<T> targetQuery) {
            if (query is null && targetQuery is null)
                return true;

            if (query is null || targetQuery is null)
                return false;

            return query.Count().Equals(targetQuery.Count());
        }
    }
}