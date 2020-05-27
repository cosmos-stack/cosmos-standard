using System.Collections.Generic;
using Cosmos.Judgments;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    public static partial class CollectionExtensions
    {
        /// <summary>
        /// 检查一个集合是否拥有指定数量的成员
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="enumeration"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(this ICollection<T> enumeration, int count)
            => CollectionJudgment.ContainsAtLeast(enumeration, count);

        /// <summary>
        /// 检查两个集合是否拥有相等数量的成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool ContainsEqualCount<T>(this ICollection<T> @this, ICollection<T> @that)
            => CollectionJudgment.ContainsEqualCount(@this, @that);
    }
}