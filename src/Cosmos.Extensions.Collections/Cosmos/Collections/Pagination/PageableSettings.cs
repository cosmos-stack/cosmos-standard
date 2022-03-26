using Cosmos.Collections.Pagination.Internals;

namespace Cosmos.Collections.Pagination;

/// <summary>
/// Pageable settings <br />
/// 分页配置
/// </summary>
public class PageableSettings
{
    /// <summary>
    /// Gets or sets default page size <br />
    /// 获取或设置默认的页尺寸
    /// </summary>
    public int DefaultPageSize { get; set; } = PageableConstants.DEFAULT_PAGE_SIZE;

    /// <summary>
    /// Gets or sets max member items <br />
    /// 获取或设置最大页成员项数
    /// </summary>
    public long MaxMemberItems { get; set; } = PageableConstants.MAX_MEMBER_ITEMS_SUPPORT;
}