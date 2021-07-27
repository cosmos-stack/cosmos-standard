using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Cosmos.Collections
{
    public static class CollJudge
    {
        #region IsNull

        /// <summary>
        /// To judge whether the collection is null or not.<br />
        /// 判断集合是否为空。
        /// </summary>
        /// <param name="coll"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty(IEnumerable coll)
        {
            return coll is null || !coll.Cast<object>().Any();
        }

        /// <summary>
        /// Determine whether the collection is empty or empty.<br />
        /// 判断集合是否为空。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="coll"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty<T>(IEnumerable<T> coll)
        {
            return coll is null || !coll.Any();
        }

        #endregion

        #region IsSameCount
        
        /// <summary>
        /// Check if the number of elements in the set is the same. <br />
        /// 检查两个集合是否拥有相等数量的成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool IsSameCount<T>(ICollection<T> source, ICollection<T> that)
        {
            if (source is null && that is null)
                return true;
            if (source is null || that is null)
                return false;
            return source.Count.Equals(that.Count);
        }

        /// <summary>
        /// Check if the number of elements in the set is the same. <br />
        /// 检查两个集合是否拥有相等数量的成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool IsSameCount<T>(IQueryable<T> source, IQueryable<T> that)
        {
            if (source is null && that is null)
                return true;
            if (source is null || that is null)
                return false;
            return source.Count().Equals(that.Count());
        }

        #endregion
    }

    public static class CollJudgeExtensions
    {
        /// <summary>
        /// Check if the number of elements in the set is the same. <br />
        /// 检查两个集合是否拥有相等数量的成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSameCount<T>(this ICollection<T> source, ICollection<T> that)
        {
            return CollJudge.IsSameCount(source, that);
        }

        /// <summary>
        /// Check if the number of elements in the set is the same. <br />
        /// 检查两个集合是否拥有相等数量的成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSameCount<T>(this IQueryable<T> source, IQueryable<T> that)
        {
            return CollJudge.IsSameCount(source, that);
        }
    }
}