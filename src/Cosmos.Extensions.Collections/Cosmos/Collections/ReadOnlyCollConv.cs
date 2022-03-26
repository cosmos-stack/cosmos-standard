using System.Collections.ObjectModel;
using Cosmos.Collections.Internals;

namespace Cosmos.Collections;

/// <summary>
/// ReadOnly Collection Convertor <br />
/// 只读集合转换器
/// </summary>
public static class ReadOnlyCollConv
{
    #region AsList

    /// <summary>
    /// As list <br />
    /// 转换为列表
    /// </summary>
    /// <param name="list"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IList<T> AsList<T>(IReadOnlyList<T> list)
    {
        if (list is null)
            throw new ArgumentNullException(nameof(list));
        return new ReadOnlyListWrapper<T>(list);
    }

    #endregion
}

/// <summary>
/// ReadOnly Collection Convertor Extensions <br />
/// 只读集合转换器扩展
/// </summary>
public static class ReadOnlyCollConvExtensions
{
    #region AsReadOnly

    /// <summary>
    /// To readonly collection <br />
    /// 转换为只读集合
    /// </summary>
    /// <param name="src"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ReadOnlyCollection<T> AsReadOnly<T>(this IEnumerable<T> src)
    {
        if (src is null)
            throw new ArgumentNullException(nameof(src));
        return ReadOnlyCollsHelper.WrapInReadOnlyCollection(src.ToList());
    }

    #endregion

    #region AsList

    /// <summary>
    /// As list <br />
    /// 转换为列表
    /// </summary>
    /// <param name="list"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IList<T> AsList<T>(this IReadOnlyList<T> list)
    {
        return ReadOnlyCollConv.AsList(list);
    }

    #endregion
}