namespace Cosmos.Collections.Pagination;

/// <summary>
/// Query entry state interface <br />
/// 查询状态接口
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IQueryEntryState<out T>
{
    /// <summary>
    /// Gets all values <br />
    /// 获取所有值
    /// </summary>
    IEnumerable<T> AllValues { get; }
}