using Cosmos.Collections.Pagination.Internals;

namespace Cosmos.Collections.Pagination
{
    /// <summary>
    /// Pageable settings
    /// </summary>
    public class PageableSettings
    {
        /// <summary>
        /// Gets or sets default page size
        /// </summary>
        public int DefaultPageSize { get; set; } = PageableConstants.DEFAULT_PAGE_SIZE;

        /// <summary>
        /// Gets or sets max member items
        /// </summary>
        public long MaxMemberItems { get; set; } = PageableConstants.MAX_MEMBER_ITEMS_SUPPORT;
    }
}