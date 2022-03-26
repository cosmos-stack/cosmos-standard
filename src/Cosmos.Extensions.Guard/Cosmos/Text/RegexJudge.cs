using System.Text.RegularExpressions;

namespace Cosmos.Text;

/// <summary>
/// Regex Judgement Utilities <br />
/// 正则检查器
/// </summary>
public static class RegexJudge
{
    /// <summary>
    /// Indicates whether the regular expression specified in the Regex constructor
    /// finds a match in a specified input string.<br />
    /// 指示在Regex构造函数中指定的正则表达式是否在指定的输入字符串中找到匹配项。
    /// </summary>
    /// <param name="str"></param>
    /// <param name="pattern"></param>
    /// <param name="options">regex options, default is RegexOptions.IgnoreCase</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsMatch(string str, string pattern, RegexOptions options = RegexOptions.IgnoreCase) =>
        Regex.IsMatch(str, pattern, options);
}