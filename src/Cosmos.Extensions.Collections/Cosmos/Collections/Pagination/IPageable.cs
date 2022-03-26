namespace Cosmos.Collections.Pagination;

/// <summary>
/// Pageable interface <br />
/// 分页接口
/// </summary>
public interface IPageable : IEnumerable
{
    /// <summary>
    /// Gets page size <br />
    /// 获取页尺寸
    /// </summary>
    int PageSize { get; }

    /// <summary>
    /// Gets member count <br />
    /// 获取成员项数
    /// </summary>
    int MemberCount { get; }
}