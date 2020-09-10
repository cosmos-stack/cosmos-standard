using System.Linq;

namespace Cosmos.Collections
{
    /// <summary>
    /// Cosmos collection extensions
    /// </summary>
    public static partial class CollectionExtensions
    {
        #region Contains

        /// <summary>
        /// 检查一个集合是否拥有指定数量的成员
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(this IQueryable<T> source, int count)
        {
            if (source is null)
                return false;

            return (from t in source.Take(count) select t).Count() >= count;
        }

        /// <summary>
        /// 检查两个集合是否拥有相等数量的成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool ContainsEqualCount<T>(this IQueryable<T> source, IQueryable<T> that)
        {
            if (source is null && that is null)
                return true;

            if (source is null || that is null)
                return false;

            return source.Count().Equals(that.Count());
        }

        #endregion
    }
}