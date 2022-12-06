using System.Text.RegularExpressions;

namespace Cosmos.Text;

/// <summary>
/// String Utils<br />
/// 字符串工具
/// </summary>
public static partial class Strings
{
    /// <summary>
    /// Gets the captured substring from the input string. <br />
    /// 从输入字符串中获取捕获的子字符串。
    /// </summary>
    /// <param name="match"></param>
    /// <param name="group"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static string GetGroupedValue(Match match, string group)
    {
        ArgumentNullException.ThrowIfNull(match);
        ArgumentNullException.ThrowIfNull(group);

        var g = match.Groups[group];

        if (!match.Success || !g.Success)
            throw new InvalidOperationException($"The group ({group}) was not successfully matched on the match.");

        return g.Value;
    }
}

public static partial class StringsExtensions
{
    /// <summary>
    /// Gets the captured substring from the input string. <br />
    /// 从输入字符串中获取捕获的子字符串。
    /// </summary>
    /// <param name="match"></param>
    /// <param name="group"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetGroupedValue(this Match match, string group)
    {
        return Strings.GetGroupedValue(match, group);
    }
}