namespace Cosmos.Collections.Pagination;

/// <summary>
/// Page member wrapper interface <br />
/// 页成员包装接口
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IPageMember<out T>
{
    /// <summary>
    /// Gets value of current member <br />
    /// 获取当前项的值
    /// </summary>
    T Value { get; }

    /// <summary>
    /// Gets offset of current member <br />
    /// 获取当前项的偏移量
    /// </summary>
    int Offset { get; }

    /// <summary>
    /// Gets item number of current member <br />
    /// 获取当前项的序号
    /// </summary>
    int ItemNumber { get; }
}