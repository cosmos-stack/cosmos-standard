namespace Cosmos.Text;

/// <summary>
/// String Utils<br />
/// 字符串工具
/// </summary>
public static partial class Strings
{
    #region Has Numbers

    /// <summary>
    /// Returns whether it contains digit.<br />
    /// 返回是否包含数字。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool HasNumbers(string text) => HasNumbersAtLeast(text, 1);

    /// <summary>
    /// Contain at least the specified number of digit.<br />
    /// 至少包含指定数量的数字。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="minCount"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool HasNumbersAtLeast(string text, int minCount)
    {
        minCount = minCount <= 0 ? 1 : minCount;
        return FilterForNumbers(text).Count() >= minCount;
    }

    #endregion

    #region Has Letters

    /// <summary>
    /// Returns whether it contains letters.<br />
    /// 返回是否包含字母。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool HasLetters(string text) => HasLettersAtLeast(text, 1);

    /// <summary>
    /// Contain at least the specified number of letters.<br />
    /// 至少包含指定数量的字母。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="minCount"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool HasLettersAtLeast(string text, int minCount)
    {
        minCount = minCount <= 0 ? 1 : minCount;
        return FilterForLetters(text).Count() >= minCount;
    }

    #endregion
}

/// <summary>
/// String extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringsExtensions
{
    #region Has Numbers

    /// <summary>
    /// Returns whether it contains digit.<br />
    /// 返回是否包含数字。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool HasNumbers(this string text) => Strings.HasNumbers(text);

    /// <summary>
    /// Contain at least the specified number of digit.<br />
    /// 至少包含指定数量的数字。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="minCount"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool HasNumbersAtLeast(this string text, int minCount) => Strings.HasNumbersAtLeast(text, minCount);

    #endregion

    #region Has Letters

    /// <summary>
    /// Returns whether it contains letters.<br />
    /// 返回是否包含字母。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsLetters(this string text) => Strings.HasLetters(text);

    /// <summary>
    /// Contain at least the specified number of letters.<br />
    /// 至少包含指定数量的字母。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="minCount"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsLettersAtLeast(this string text, int minCount) => Strings.HasLettersAtLeast(text, minCount);

    #endregion
}