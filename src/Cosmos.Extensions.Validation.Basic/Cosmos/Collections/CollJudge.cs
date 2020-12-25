using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Collections
{
    public static class CollJudge
    {
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
        public static bool IsSameCount<T>(this IQueryable<T> source, IQueryable<T> that)
        {
            if (source is null && that is null)
                return true;
            if (source is null || that is null)
                return false;
            return source.Count().Equals(that.Count());
        }
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
        public static bool IsSameCount<T>(this IQueryable<T> source, IQueryable<T> that)
        {
            return CollJudge.IsSameCount(source, that);
        }
    }
}