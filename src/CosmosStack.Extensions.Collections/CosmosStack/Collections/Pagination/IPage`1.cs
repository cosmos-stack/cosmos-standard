using System.Collections.Generic;
using Cosmos.Collections.Pagination;

namespace CosmosStack.Collections.Pagination
{
    /// <summary>
    /// Page interface <br />
    /// 页接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPage<out T> : IEnumerable<IPageMember<T>>, IPage
    {
        /// <summary>
        /// Gets page member indexer <br />
        /// 获取当前页的某一项
        /// </summary>
        /// <param name="index">Index</param>
        IPageMember<T> this[int index] { get; }

        /// <summary>
        /// Convert to original items <br />
        /// 转换为页内项的集合
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> ToOriginalItems();
    }
}