using System.Collections;
using Cosmos.Collections.Pagination;

namespace CosmosStack.Collections.Pagination
{
    /// <summary>
    /// Page interface <br />
    /// 页接口
    /// </summary>
    public interface IPage : IEnumerable
    {
        /// <summary>
        /// Gets total page count <br />
        /// 获取总页数
        /// </summary>
        int TotalPageCount { get; }

        /// <summary>
        /// Gets total member count <br />
        /// 获取总项数
        /// </summary>
        int TotalMemberCount { get; }

        /// <summary>
        /// Gets current page number <br />
        /// 获取当前页码
        /// </summary>
        int CurrentPageNumber { get; }

        /// <summary>
        /// Gets page size <br />
        /// 获取页尺寸
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Gets current page size, may equal to or less than page size. <br />
        /// 获取当前页尺寸，将小于等于页尺寸
        /// </summary>
        int CurrentPageSize { get; }

        /// <summary>
        /// Has previous. If this page is the first page, then returns false. <br />
        /// 标记是否有上一页。如果本页为第一页，则返回 false。
        /// </summary>
        bool HasPrevious { get; }

        /// <summary>
        /// Has next. If this page is the last page, then returns false. <br />
        /// 标记是否有下一页。如果本页为最后一页，则返回 false。
        /// </summary>
        bool HasNext { get; }

        /// <summary>
        /// Get metadata of page <br />
        /// 获取页的元信息
        /// </summary>
        /// <returns></returns>
        PageMetadata GetMetadata();
    }
}