using System.Runtime.CompilerServices;

namespace Cosmos;

/// <summary>
/// Interlocked Util <br />
/// Interlocked 工具
/// </summary>
public static class InterlockedUtil
{
    /// <summary>
    /// Read <br />
    /// 读取
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Read(ref int value) => Interlocked.CompareExchange(ref value, 0, 0);

    /// <summary>
    /// Read <br />
    /// 读取
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Read<T>(ref T value) where T : class => Interlocked.CompareExchange(ref value!, null, null);
}