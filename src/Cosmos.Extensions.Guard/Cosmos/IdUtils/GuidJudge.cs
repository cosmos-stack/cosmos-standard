namespace Cosmos.IdUtils;

/// <summary>
/// Guid Judgement <br />
/// GUID 检查器
/// </summary>
public static class GuidJudge
{
    /// <summary>
    /// Determine whether the given nullable Guid is Null or Empty. <br />
    /// 判断给定的可空 Guid 是否为 Null 或 Empty。
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty(Guid? guid)
    {
        return guid is null || guid == Guid.Empty;
    }

    /// <summary>
    /// Determine whether the given Guid is Null or Empty. <br />
    /// 判断给定的 Guid 是否为 Null 或 Empty。
    /// </summary>
    /// <param name="guid"> 值 </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty(Guid guid)
    {
        return guid == Guid.Empty;
    }
}

/// <summary>
/// Guid Judgement Extensions <br />
/// GUID 检验器扩展
/// </summary>
public static class GuidJudgeExtensions
{
    /// <summary>
    /// Determine whether the given nullable Guid is Null or Empty. <br />
    /// 判断给定的可空 Guid 是否为 Null 或 Empty。
    /// </summary>
    /// <param name="guid"> 值 </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty(this Guid? guid)
    {
        return GuidJudge.IsNullOrEmpty(guid);
    }

    /// <summary>
    /// Determine whether the given Guid is Null or Empty. <br />
    /// 判断给定的 Guid 是否为 Null 或 Empty。
    /// </summary>
    /// <param name="guid"> 值 </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty(this Guid guid)
    {
        return GuidJudge.IsNullOrEmpty(guid);
    }
}