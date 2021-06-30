using System.Collections.Generic;

namespace Cosmos.Collections.Pagination
{
    /// <summary>
    /// Page interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPage<out T> : IEnumerable<IPageMember<T>>, IPage
    {
        /// <summary>
        /// Gets page member indexer
        /// </summary>
        /// <param name="index">Index</param>
        IPageMember<T> this[int index] { get; }

        /// <summary>
        /// Convert to original items
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> ToOriginalItems();
    }
}