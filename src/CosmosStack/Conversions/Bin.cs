using System.Runtime.CompilerServices;
using Cosmos.Conversions.Helpers;

namespace Cosmos.Conversions;

/// <summary>
/// Bin utilities. <br />
/// 二进制工具
/// </summary>
public static class Bin
{
    /// <summary>
    /// Reverse high and low positions. <br />
    /// 交换高低位
    /// </summary>
    /// <param name="bin"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Reverse(string bin)
    {
        return ScaleRevHelper.Reverse(bin, 8);
    }
}