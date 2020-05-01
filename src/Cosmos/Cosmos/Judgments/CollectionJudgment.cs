using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Judgments {
    /// <summary>
    /// Collection Judgment Utilities
    /// </summary>
    public static class CollectionJudgment {
        /// <summary>
        /// To judge whether the collection is null or not.
        /// </summary>
        /// <param name="coll"></param>
        /// <returns></returns>
        public static bool IsNull(IEnumerable coll) => coll is null;

        /// <summary>
        /// To judge whether the collection is null or empty.
        /// </summary>
        /// <param name="coll"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(IEnumerable coll) {
            if (coll is null)
                return true;

            return !coll.Cast<object>().Any();
        }

        /// <summary>
        /// To judge whether the collection is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="coll"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(IEnumerable<T> coll) => coll is null || !coll.Any();

        /// <summary>
        /// To judge whether one collection contains specified count of elements at least.
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="coll"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(ICollection<T> coll, int count) => coll?.Count >= count;

        /// <summary>
        /// To judge whether these two collections contain same count of elements.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftColl"></param>
        /// <param name="rightColl"></param>
        /// <returns></returns>
        public static bool ContainsEqualCount<T>(ICollection<T> leftColl, ICollection<T> rightColl) {
            if (leftColl is null && rightColl is null)
                return true;

            if (leftColl is null || rightColl is null)
                return false;

            return leftColl.Count.Equals(rightColl.Count);
        }
    }
}