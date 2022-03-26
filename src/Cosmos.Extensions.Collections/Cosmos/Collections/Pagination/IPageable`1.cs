namespace Cosmos.Collections.Pagination;

/// <summary>
/// Pageable interface <br />
/// 分页接口
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IPageable<T> : IEnumerable<IPage<T>>, IPageable
{
    /// <summary>
    /// Get page <br />
    /// 获取指定页码的页
    /// </summary>
    /// <param name="pageNumber">Page number</param>
    /// <returns></returns>
    IPage<T> GetPage(int pageNumber);
}