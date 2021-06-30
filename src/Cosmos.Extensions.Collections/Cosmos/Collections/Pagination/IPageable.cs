using System.Collections;

namespace Cosmos.Collections.Pagination
{
    /// <summary>
    /// Pageable interface
    /// </summary>
    public interface IPageable : IEnumerable
    {
        /// <summary>
        /// Gets page size
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Gets member count
        /// </summary>
        int MemberCount { get; }
    }
}