using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Collections
{
    public static class CollectionJudge
    {
        #region IsNull

        /// <summary>
        /// To judge whether the collection is null or not.<br />
        /// 判断集合是否为空。
        /// </summary>
        /// <param name="coll"></param>
        /// <returns></returns>
        public static bool IsNull(IEnumerable coll)
        {
            return coll is null;
        }

        #endregion

        #region IsNullOrEmpty

        /// <summary>
        /// Determine whether the collection is empty or empty.<br />
        /// 判断集合是否为空。
        /// </summary>
        /// <param name="coll"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(IEnumerable coll)
        {
            if (coll is null)
                return true;

            return !coll.Cast<object>().Any();
        }

        /// <summary>
        /// Determine whether the collection is empty or empty.<br />
        /// 判断集合是否为空。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="coll"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(IEnumerable<T> coll)
        {
            return coll is null || !coll.Any();
        }

        #endregion

        #region Contains

        /// <summary>
        /// Determine whether a queryable set contains at least a specified number of elements.<br />
        /// 判断一个可查询集合是否至少包含指定数量的元素。
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="coll"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(ICollection<T> coll, int count)
        {
            return coll?.Count >= count;
        }

        /// <summary>
        /// Determine whether the two collections contain the same number of elements.<br />
        /// 判断这两个集合是否包含相同数量的元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftColl"></param>
        /// <param name="rightColl"></param>
        /// <returns></returns>
        public static bool ContainsSameNumberOfElements<T>(ICollection<T> leftColl, ICollection<T> rightColl)
        {
            if (leftColl is null && rightColl is null)
                return true;

            if (leftColl is null || rightColl is null)
                return false;

            return leftColl.Count.Equals(rightColl.Count);
        }

        #endregion
    }
}