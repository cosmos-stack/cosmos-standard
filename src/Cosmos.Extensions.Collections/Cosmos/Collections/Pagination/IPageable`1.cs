using System.Collections.Generic;

namespace Cosmos.Collections.Pagination
{
    /// <summary>
    /// Pageable interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPageable<T> : IEnumerable<IPage<T>>, IPageable
    {
        /// <summary>
        /// Get page
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <returns></returns>
        IPage<T> GetPage(int pageNumber);
    }
}