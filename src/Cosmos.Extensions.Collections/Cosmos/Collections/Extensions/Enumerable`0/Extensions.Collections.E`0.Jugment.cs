using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Judgments;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// Extensions of collection
    /// </summary>
    public static class CollectionJudgmentExtensions
    {
        /// <summary>
        /// 判断集合是否为空
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNull(this IEnumerable source) => CollectionJudgment.IsNull(source);

        /// <summary>
        /// 判断集合是否为空
        /// </summary>
        /// <param name="source">要处理的集合</param>
        /// <returns>为空返回 True，不为空返回 False</returns>
        public static bool IsNullOrEmpty(this IEnumerable source) =>
            CollectionJudgment.IsNullOrEmpty(source);

        /// <summary>
        /// 判断集合是否为空
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source">要处理的集合</param>
        /// <returns>为空返回 True，不为空返回 False</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
            => CollectionJudgment.IsNullOrEmpty(source);
    }
}