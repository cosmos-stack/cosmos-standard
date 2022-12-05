// ReSharper disable MemberHidesStaticFromOuterClass

namespace Cosmos.Collections;

/// <summary>
/// Collections Utilities <br />
/// 集合工具
/// </summary>
public static partial class Colls
{
    /// <summary>
    /// Create a list instance of the specified type T. <br />
    /// 创建一个指定类型 T 的列表实例。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<T> OfList<T>() => new();

    /// <summary>
    /// Create a list instance of the specified type T. <br />
    /// 创建一个指定类型 T 的列表实例。
    /// </summary>
    /// <param name="params"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static List<T> OfList<T>(params T[] @params) => new(@params);

    /// <summary>
    /// Create a list instance of the specified type T. <br />
    /// 创建一个指定类型 T 的列表实例。
    /// </summary>
    /// <param name="listParams"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static List<T> OfList<T>(IEnumerable<T>[] listParams)
    {
        var ret = new List<T>();

        if (listParams is not null)
        {
            foreach (var list in listParams)
            {
                ret.AddRange(list);
            }
        }

        return ret;
    }

    /// <summary>
    /// Create a list instance of the specified type T. <br />
    /// 创建一个指定类型 T 的列表实例。
    /// </summary>
    /// <param name="list"></param>
    /// <param name="listParams"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static List<T> OfList<T>(IEnumerable<T> list, params IEnumerable<T>[] listParams)
    {
        var ret = new List<T>(list);

        if (listParams is not null)
        {
            foreach (var @params in listParams)
            {
                ret.AddRange(@params);
            }
        }

        return ret;
    }


}