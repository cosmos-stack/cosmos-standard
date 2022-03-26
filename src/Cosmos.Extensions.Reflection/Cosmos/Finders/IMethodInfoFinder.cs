﻿namespace Cosmos.Finders;

/// <summary>
/// A finder for MethodInfo <br />
/// MethodInfo 查找器接口
/// </summary>
public interface IMethodInfoFinder
{
    /// <summary>
    /// 查找指定条件的项
    /// </summary>
    /// <param name="type">要查找的类型</param>
    /// <param name="predicate">筛选条件</param>
    /// <returns></returns>
    MethodInfo[] Find(Type type, Func<MethodInfo, bool> predicate);

    /// <summary>
    /// 查找所有项
    /// </summary>
    /// <param name="type">要查找的类型</param>
    /// <returns></returns>
    MethodInfo[] FindAll(Type type);
}