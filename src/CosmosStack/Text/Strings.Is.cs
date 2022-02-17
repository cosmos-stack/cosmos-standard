using System.Runtime.CompilerServices;

namespace Cosmos.Text;

/// <summary>
/// String Utils<br />
/// 字符串工具
/// </summary>
public static partial class Strings
{
    /// <summary>
    /// Is upper <br />
    /// 判断是否为大写
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUpper( string text)
    {
        return FilterForLetters(text).All(char.IsUpper);
    }

    /// <summary>
    /// Is lower <br />
    /// 判断是否为小写
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLower( string text)
    {
        return FilterForLetters(text).All(char.IsLower);
    }
}

/// <summary>
/// String extensions. <br />
/// 字符串扩展
/// </summary>
public static partial class StringsExtensions
{
    /// <summary>
    /// Is upper <br />
    /// 判断是否为大写
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUpper(this string text)
    {
        return Strings.IsUpper(text);
    }

    /// <summary>
    /// Is lower <br />
    /// 判断是否为小写
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLower(this string text)
    {
        return Strings.IsLower(text);
    }
}

/// <summary>
/// String Shortcut Extensions <br />
/// 字符串捷径扩展
/// </summary>
public static partial class StringsShortcutExtensions
{
    #region Is

    /// <summary>
    /// Check whether the string is null or system.string.empty string <br />
    /// 检查字符串是 null 还是 System.String.Empty 字符串
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty(this string text)
    {
        return string.IsNullOrEmpty(text);
    }

    /// <summary>
    /// Check whether the string is null or system.string.empty string <br />
    /// 检查字符串不是 null 或 System.String.Empty 字符串
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNotNullNorEmpty(this string text)
    {
        return !text.IsNullOrEmpty();
    }

    /// <summary>
    /// Check whether the string is null, empty, or just composed of white space characters <br />
    /// 检查字符串是 null、空还是仅由空白字符组成
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrWhiteSpace(this string text)
    {
        return string.IsNullOrWhiteSpace(text);
    }

    /// <summary>
    /// Check whether the string is null, empty, or just composed of white space characters <br />
    /// 检查字符串不是 null、空或由空白字符串组成
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNotNullNorWhiteSpace(this string text)
    {
        return !text.IsNullOrWhiteSpace();
    }

    #endregion
}