﻿// ReSharper disable InconsistentNaming

namespace Cosmos.Text;

internal static class AuxiliaryStringHelper
{
    public static IEnumerable<T> M<T>(T t, IEnumerable<T> ts)
    {
        yield return t;
        if (ts is not null)
            foreach (var t0 in ts)
                yield return t0;
    }
}

internal static class DiffStringHelper
{
    public static bool CheckLengthForParams(string text, string check, out int ret, out int times)
    {
        times = 0;
        ret = -1;
        if (text is null && check is null)
            return false;

        ret = 0;
        if (string.IsNullOrEmpty(text) && string.IsNullOrEmpty(check))
            return false;

        string safeText = Strings.NullToEmpty(text), safeCheck = Strings.NullToEmpty(check);

        ret = Math.Abs(safeText.Length - safeCheck.Length);

        if (string.IsNullOrEmpty(safeText) || string.IsNullOrEmpty(safeCheck))
            return false;

        times = safeText.Length > safeCheck.Length ? safeCheck.Length : safeText.Length;

        return ret > -1;
    }
}

/// <summary>
/// String Utils<br />
/// 字符串工具
/// </summary>
public static partial class Strings
{
    #region Count

    /// <summary>
    /// Returns the number of letters contained in the string.<br />
    /// 返回字符串中所包含字母的数量。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountForLetters(string text)
    {
        return string.IsNullOrEmpty(text) ? 0 : FilterForLetters(text).Count();
    }

    /// <summary>
    /// Returns the number of uppercase letters in the string.<br />
    /// 返回字符串中所包含大写字母的数量。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountForLettersUpperCase(string text)
    {
        return string.IsNullOrEmpty(text) ? 0 : FilterForLetters(text).Where(char.IsUpper).Count();
    }

    /// <summary>
    /// Returns the number of lowercase letters in the string.<br />
    /// 返回字符串中所包含小写字母的数量。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountForLettersLowerCase(string text)
    {
        return string.IsNullOrEmpty(text) ? 0 : FilterForLetters(text).Where(char.IsLower).Count();
    }

    /// <summary>
    /// Returns the number of digit contained in the string.<br />
    /// 返回字符串中所包含数字的数量。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountForNumbers(string text)
    {
        return string.IsNullOrEmpty(text) ? 0 : FilterForNumbers(text).Count();
    }

    /// <summary>
    /// Count Occurrences <br />
    /// 计算给定字符串中有多少个指定的字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountOccurrences(string text, char toCheck)
    {
        return CountOccurrences(text, toCheck.ToString());
    }

    /// <summary>
    /// Count Occurrences <br />
    /// 计算给定字符串中有多少个指定的子字符串
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static int CountOccurrences(string text, string toCheck)
    {
        if (toCheck.IsNullOrEmpty())
            return 0;

        int ret = 0, offset = 0;
        while ((offset = text.IndexOf(toCheck, offset, StringComparison.Ordinal)) != -1)
        {
            offset += toCheck.Length;
            ret++;
        }

        return ret;
    }

    /// <summary>
    /// Count Occurrences ignore case <br />
    /// 计算给定字符串中有多少个指定的字符，忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountOccurrencesIgnoreCase(string text, char toCheck)
    {
        return CountOccurrencesIgnoreCase(text, toCheck.ToString());
    }

    /// <summary>
    /// Count Occurrences ignore case <br />
    /// 计算给定字符串中有多少个指定的子字符串，忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static int CountOccurrencesIgnoreCase(string text, string toCheck)
    {
        if (toCheck.IsNullOrEmpty())
            return 0;

        int ret = 0, offset = 0;
        while ((offset = text.IndexOfIgnoreCase(toCheck, offset)) != -1)
        {
            offset += toCheck.Length;
            ret++;
        }

        return ret;
    }

    /// <summary>
    /// Count Occurrences with ignore case options <br />
    /// 计算给定字符串中有多少个指定的字符，根据 <see cref="IgnoreCase"/> 开关来决定是否忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountOccurrences(string text, char toCheck, IgnoreCase @case)
    {
        return @case switch
        {
            IgnoreCase.TRUE => CountOccurrencesIgnoreCase(text, toCheck),
            IgnoreCase.FALSE => CountOccurrences(text, toCheck),
            _ => CountOccurrences(text, toCheck)
        };
    }

    /// <summary>
    /// Count Occurrences with ignore case options <br />
    /// 计算给定字符串中有多少个指定的子字符串，根据 <see cref="IgnoreCase"/> 开关来决定是否忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountOccurrences(string text, string toCheck, IgnoreCase @case)
    {
        return @case switch
        {
            IgnoreCase.TRUE => CountOccurrencesIgnoreCase(text, toCheck),
            IgnoreCase.FALSE => CountOccurrences(text, toCheck),
            _ => CountOccurrences(text, toCheck)
        };
    }

    /// <summary>
    /// Compare strings to get the number of unequal characters. <br />
    /// 比较字符串，获取不相等字符的数量。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static int CountForDiffChars(string text, string toCheck)
    {
        if (!DiffStringHelper.CheckLengthForParams(text, toCheck, out var ret, out var times))
            return ret;

        for (var i = 0; i < times; i++)
            if (text[i] != toCheck[i])
                ret++;

        return ret;
    }

    /// <summary>
    /// Compare strings to get the number of unequal characters, ignore case. <br />
    /// 比较字符串，获取不相等字符的数量，忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static int CountForDiffCharsIgnoreCase(string text, string toCheck)
    {
        if (!DiffStringHelper.CheckLengthForParams(text, toCheck, out var ret, out var times))
            return ret;

        for (var i = 0; i < times; i++)
            if (!text[i].EqualsIgnoreCase(toCheck[i]))
                ret++;

        return ret;
    }

    /// <summary>
    /// Compare strings to get the number of unequal characters with IgnoreCase options. <br />
    /// 比较字符串，获取不相等字符的数量，根据给定的 IgnoreCase 选项。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountForDiffChars(string text, string toCheck, IgnoreCase @case)
    {
        return @case switch
        {
            IgnoreCase.TRUE => CountForDiffCharsIgnoreCase(text, toCheck),
            IgnoreCase.FALSE => CountForDiffChars(text, toCheck),
            _ => CountForDiffChars(text, toCheck)
        };
    }

    #endregion

    #region Empty

    /// <summary>
    /// Avoid null, so convert null to empty.<br />
    /// 将 null 转换为 Empty
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string AvoidNull(string text) => text ?? string.Empty;

    /// <summary>
    /// Convert null to empty.<br />
    /// 将 null 转换为 Empty
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string NullToEmpty(string text) => AvoidNull(text);

    /// <summary>
    /// Convert empty to null.<br />
    /// 将 Empty 转换为 null
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string EmptyToNull(string text) => string.IsNullOrEmpty(text) ? null : text;

    #endregion

    #region Filter

    /// <summary>
    /// Filter by char <br />
    /// 过滤为字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<char> FilterByChar(string text, Func<char, bool> predicate)
    {
        return text.ToCharArray().Where(predicate);
    }

    /// <summary>
    /// Filter for only letters and numbers.<br />
    /// 只获取字母和数字。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<char> FilterForNumbersAndLetters(string text)
    {
        return FilterByChar(text, __check);

        bool __check(char @char)
        {
            return @char is >= 'a' and <= 'z' or >= 'A' and <= 'Z' or >= '0' and <= '9';
        }
    }

    /// <summary>
    /// Filter for only digit.<br />
    /// 只获取字母。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<char> FilterForNumbers(string text)
    {
        return FilterByChar(text, __check);

        bool __check(char @char)
        {
            return @char is >= '0' and <= '9';
        }
    }

    /// <summary>
    /// Filter for only letters.<br />
    /// 只获取字母。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<char> FilterForLetters(string text)
    {
        return FilterByChar(text, __check);

        bool __check(char @char)
        {
            return @char is >= 'a' and <= 'z' or >= 'A' and <= 'Z';
        }
    }

    #endregion

    #region Format With

    /// <summary>
    /// Extension method to format string with passed arguments. Current thread's current culture is used
    /// </summary>
    /// <param name="format">string format</param>
    /// <param name="args">arguments</param>
    /// <returns></returns>
    public static string FormatWith(string format, params object[] args)
    {
        return string.Format(format, args);
    }

    /// <summary>
    /// Extension method to format string with passed arguments using specified format provider (i.e. CultureInfo)
    /// </summary>
    /// <param name="format">string format</param>
    /// <param name="provider">An object that supplies culture-specific formatting information</param>
    /// <param name="args">arguments</param>
    /// <returns></returns>
    public static string FormatWith(string format, IFormatProvider provider, params object[] args)
    {
        return string.Format(provider, format, args);
    }

    #endregion

    #region Get

    /// <summary>
    /// Get only letters and numbers.<br />
    /// 只获取字母和数字。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetNumbersAndLetters(string text)
    {
        return Merge(FilterForNumbersAndLetters(text));
    }

    /// <summary>
    /// Get only digit.<br />
    /// 只获取字母。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetNumbers(string text)
    {
        return Merge(FilterForNumbers(text));
    }

    /// <summary>
    /// Get only letters.<br />
    /// 只获取字母。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetLetters(string text)
    {
        return Merge(FilterForLetters(text));
    }

    #endregion

    #region Left and Right

    /// <summary>
    /// Cut off from right to left. <br />
    /// 从右向左截取字符串
    /// </summary>
    /// <param name="text"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string Right(string text, int length)
    {
        if (length < 0)
            throw new ArgumentException("Length > 0", nameof(length));

        if (length == 0 || text is null)
            return string.Empty;

        var strLength = text.Length;
        return length >= strLength ? text : text.Substring(strLength - length, length);
    }

    /// <summary>
    /// Cut off from left to right <br />
    /// 从左向右截取字符串
    /// </summary>
    /// <param name="text"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string Left(string text, int length)
    {
        if (length < 0)
            throw new ArgumentException("Length > 0", nameof(length));

        if (length == 0 || text is null)
            return string.Empty;

        return length >= text.Length ? text : text.Substring(0, length);
    }

    #endregion

    #region Merge

    /// <summary>
    /// Merge char coll to string. <br />
    /// 将字符集合合并为一个字符串
    /// </summary>
    /// <param name="chars"></param>
    /// <returns></returns>
    public static string Merge(IEnumerable<char> chars)
    {
        var builder = new StringBuilder();
        if (chars is not null)
            foreach (var val in chars)
                builder.Append(val);
        return builder.ToString();
    }

    /// <summary>
    /// Merge string coll to string. <br />
    /// 将字符串集合合并为一个字符串
    /// </summary>
    /// <param name="text"></param>
    /// <param name="strings"></param>
    /// <returns></returns>
    public static string Merge(string text, params string[] strings)
    {
        var builder = new StringBuilder();
        builder.Append(text);
        if (strings is not null)
            for (var i = 0; i < strings.Length; i++)
                builder.Append(strings[i]);
        return builder.ToString();
    }

    /// <summary>
    /// Merge string coll to string. <br />
    /// 将字符串集合合并为一个字符串
    /// </summary>
    /// <param name="text"></param>
    /// <param name="string"></param>
    /// <param name="strings"></param>
    /// <returns></returns>
    public static string Merge(string text, string @string, params string[] strings)
    {
        var builder = new StringBuilder();
        builder.Append(text);
        foreach (var val in AuxiliaryStringHelper.M(@string, strings))
            builder.Append(val);
        return builder.ToString();
    }

    /// <summary>
    /// Merge char coll to string. <br />
    /// 将字符集合合并为一个字符串
    /// </summary>
    /// <param name="text"></param>
    /// <param name="char"></param>
    /// <param name="chars"></param>
    /// <returns></returns>
    public static string Merge(string text, char @char, params char[] chars)
    {
        var builder = new StringBuilder();
        builder.Append(text);
        foreach (var val in AuxiliaryStringHelper.M(@char, chars))
            builder.Append(val);
        return builder.ToString();
    }

    #endregion

    #region Remove

    /// <summary>
    /// Remove <br />
    /// 从字符串中移除给定的子字符串，根据 IgnoreCase 选项来控制大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="removeText"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Remove(string text, string removeText, IgnoreCase @case = IgnoreCase.FALSE)
    {
        return @case.X()
            ? text.Replace(removeText, string.Empty, StringComparison.OrdinalIgnoreCase)
            : text.Replace(removeText, string.Empty);
    }

    /// <summary>
    /// Remove all specified characters. <br />
    /// 移除所有指定的字符。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toRemove"></param>
    /// <returns></returns>
    public static string RemoveChars(string text, params char[] toRemove)
    {
        var builder = new StringBuilder(text);
        foreach (var remove in toRemove)
            builder.Replace(remove, char.MinValue);
        builder.Replace(char.MinValue.ToString(), string.Empty);
        return builder.ToString();
    }

    /// <summary>
    /// Remove all spaces. <br />
    /// 移除所有空格。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RemoveWhiteSpace(string text)
    {
        return RemoveChars(text, ' ');
    }

    /// <summary>
    /// Remove duplicate space <br />
    /// 从字符串中移除所有重复的空格
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RemoveDuplicateWhiteSpaces(string text)
    {
        return RemoveDuplicateChar(text, ' ');
    }

    /// <summary>
    /// Remove duplicate char <br />
    /// 从字符串中移除所有重复的字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="charRemove"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    public static string RemoveDuplicateChar(string text, char charRemove, IgnoreCase @case = IgnoreCase.FALSE)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        var builder = new StringBuilder();

        int index = 0, offset, length = text.Length;

        Func<char, char, bool> equals = @case.X()
            ? (l, r) => l.EqualsIgnoreCase(r)
            : (l, r) => l == r;

        while (true)
        {
            if (index >= length) break;

            var @char = text[index];

            if (!equals(@char, charRemove))
            {
                builder.Append(@char);
                index++;
            }
            else
            {
                builder.Append(charRemove);
                UpdateOffset();
                index += offset;
            }
        }

        return builder.ToString();

        void UpdateOffset()
        {
            offset = 0;
            while (IsMatchedNextChar())
                ++offset;
        }

        bool IsMatchedNextChar()
        {
            if (index + offset >= length) return false;
            return text[index + offset] == charRemove;
        }
    }

    /// <summary>
    /// Remove since the given index <br />
    /// 从给定的位置开始移除所有字符，位置从 0 开始计算
    /// </summary>
    /// <param name="text"></param>
    /// <param name="indexOfStartToRemove"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RemoveSince(string text, int indexOfStartToRemove)
    {
        return indexOfStartToRemove <= 0 ? text : text[..indexOfStartToRemove];
    }

    /// <summary>
    /// Remove since the given text <br />
    /// 根据给定子字符串在字符串中的位置，移除该位置之后的所有字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="removeFromThis"></param>
    /// <returns></returns>
    public static string RemoveSince(string text, string removeFromThis)
    {
        if (string.IsNullOrEmpty(removeFromThis))
            return text;
        var index = text.IndexOf(removeFromThis, StringComparison.Ordinal);
        return RemoveSince(text, index);
    }

    /// <summary>
    /// Remove since the given text and ignore case <br />
    /// 根据给定子字符串在字符串中的位置，移除该位置之后的所有字符，并忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="removeFromThis"></param>
    /// <returns></returns>
    public static string RemoveSinceIgnoreCase(string text, string removeFromThis)
    {
        if (string.IsNullOrEmpty(removeFromThis))
            return text;
        var index = text.IndexOf(removeFromThis, StringComparison.OrdinalIgnoreCase);
        return RemoveSince(text, index);
    }

    /// <summary>
    /// Remove since the given text with ignore case options <br />
    /// 根据给定子字符串在字符串中的位置，移除该位置之后的所有字符，根据 IgnoreCase 选项决定是否忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="removeFromThis"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RemoveSince(string text, string removeFromThis, IgnoreCase @case)
    {
        return @case switch
        {
            IgnoreCase.TRUE => RemoveSinceIgnoreCase(text, removeFromThis),
            IgnoreCase.FALSE => RemoveSince(text, removeFromThis),
            _ => RemoveSince(text, removeFromThis)
        };
    }

    #endregion

    #region Repeat

    /// <summary>
    /// Repeat<br />
    /// 重复指定次数的字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="repeatTimes"></param>
    /// <returns></returns>
    public static string Repeat(string text, int repeatTimes)
    {
        if (repeatTimes < 0)
            return string.Empty;

        if (text.IsNullOrEmpty() || repeatTimes == 0)
            return string.Empty;

        if (text.Length == 1)
            return new string(text[0], repeatTimes);

        switch (repeatTimes)
        {
            case 1:
                return text;
            case 2:
                return string.Concat(text, text);
            case 3:
                return string.Concat(text, text, text);
            case 4:
                return string.Concat(text, text, text, text);
        }

        var res = new StringBuilder(text.Length * repeatTimes);
        for (var i = 0; i < repeatTimes; i++)
            res.Append(text);
        return res.ToString();
    }

    #endregion

    #region Prefix / Suffix

    /// <summary>
    /// Returns the common prefix.<br />
    /// 从左到右，返回共有的字符，直至遇到第一个不同的字符。
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string CommonPrefix(string left, string right)
    {
        return CommonPrefix(left, right, out _);
    }

    /// <summary>
    /// Returns the common prefix.<br />
    /// 从左到右，返回共有的字符，直至遇到第一个不同的字符。
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="len"></param>
    /// <returns></returns>
    public static string CommonPrefix(string left, string right, out int len)
    {
        len = 0;
        if (string.IsNullOrWhiteSpace(left) || string.IsNullOrWhiteSpace(right))
            return string.Empty;
        var rangeTimes = left.Length < right.Length ? left.Length : right.Length;
        for (var i = 0; i < rangeTimes; i++, len++)
            if (left[i] != right[i])
                break;
        return left.Left(len);
    }

    /// <summary>
    /// Returns the common suffix.<br />
    /// 从右到左，返回共有的字符，直至遇到第一个不同的字符。
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string CommonSuffix(string left, string right)
    {
        return CommonSuffix(left, right, out _);
    }

    /// <summary>
    /// Returns the common suffix.<br />
    /// 从右到左，返回共有的字符，直至遇到第一个不同的字符。
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="len"></param>
    /// <returns></returns>
    public static string CommonSuffix(string left, string right, out int len)
    {
        len = 0;
        if (string.IsNullOrWhiteSpace(left) || string.IsNullOrWhiteSpace(right))
            return string.Empty;
        var rangeTimes = left.Length < right.Length ? left.Length : right.Length;
        int leftPointer = left.Length - 1, rightPointer = right.Length - 1;
        for (var i = 0; i < rangeTimes; i++, len++, leftPointer--, rightPointer--)
            if (left[leftPointer] != right[rightPointer])
                break;
        return right.Right(len);
    }

    #endregion
}

/// <summary>
/// String extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringsExtensions
{
    #region Count

    /// <summary>
    /// Returns the number of letters contained in the string.<br />
    /// 返回字符串中所包含字母的数量。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountForLetters(this string text)
    {
        return Strings.CountForLetters(text);
    }

    /// <summary>
    /// Returns the number of uppercase letters in the string.<br />
    /// 返回字符串中所包含大写字母的数量。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountForLettersUpperCase(this string text)
    {
        return Strings.CountForLettersUpperCase(text);
    }

    /// <summary>
    /// Returns the number of lowercase letters in the string.<br />
    /// 返回字符串中所包含小写字母的数量。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountForLettersLowerCase(this string text)
    {
        return Strings.CountForLettersLowerCase(text);
    }

    /// <summary>
    /// Returns the number of digit contained in the string.<br />
    /// 返回字符串中所包含数字的数量。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountForNumbers(this string text)
    {
        return Strings.CountForNumbers(text);
    }

    /// <summary>
    /// Count Occurrences <br />
    /// 计算给定字符串中有多少个指定的字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountOccurrences(this string text, char toCheck)
    {
        return Strings.CountOccurrences(text, toCheck);
    }

    /// <summary>
    /// Count Occurrences <br />
    /// 计算给定字符串中有多少个指定的子字符串
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountOccurrences(this string text, string toCheck)
    {
        return Strings.CountOccurrences(text, toCheck);
    }

    /// <summary>
    /// Count Occurrences <br />
    /// 计算给定字符串中有多少个指定的字符，忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountOccurrencesIgnoreCase(this string text, char toCheck)
    {
        return Strings.CountOccurrencesIgnoreCase(text, toCheck);
    }

    /// <summary>
    /// Count Occurrences <br />
    /// 计算给定字符串中有多少个指定的子字符串，忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountOccurrencesIgnoreCase(this string text, string toCheck)
    {
        return Strings.CountOccurrencesIgnoreCase(text, toCheck);
    }

    /// <summary>
    /// Count Occurrences <br />
    /// 计算给定字符串中有多少个指定的字符，根据 <see cref="IgnoreCase"/> 开关来决定是否忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountOccurrences(this string text, char toCheck, IgnoreCase @case)
    {
        return Strings.CountOccurrences(text, toCheck, @case);
    }

    /// <summary>
    /// Count Occurrences <br />
    /// 计算给定字符串中有多少个指定的子字符串，根据 <see cref="IgnoreCase"/> 开关来决定是否忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountOccurrences(this string text, string toCheck, IgnoreCase @case)
    {
        return Strings.CountOccurrences(text, toCheck, @case);
    }

    /// <summary>
    /// Diff chars' count <br />
    /// 比较字符串，获取不相等字符的数量。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountForDiffChars(this string text, string toCheck)
    {
        return Strings.CountForDiffChars(text, toCheck);
    }

    /// <summary>
    /// Diff chars' count ignore case <br />
    /// 比较字符串，获取不相等字符的数量，忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CountForDiffCharsIgnoreCase(this string text, string toCheck)
    {
        return Strings.CountForDiffCharsIgnoreCase(text, toCheck);
    }

    #endregion

    #region Equals

    /// <summary>
    /// Equals ignore case <br />
    /// 相等判断，忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="targetText"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsIgnoreCase(this string text, string targetText) =>
        string.Equals(text, targetText, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Equals to any ignore case <br />
    /// 相等判断，只要给定的字符串与字符串集合中任意一个值相等，就返回 True，忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="targetTexts"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsToAnyIgnoreCase(this string text, params string[] targetTexts) =>
        targetTexts is not null && targetTexts.Any(t => string.Equals(text, t, StringComparison.OrdinalIgnoreCase));

    #endregion

    #region Filter

    /// <summary>
    /// Filter by char <br />
    /// 过滤为字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<char> Where(this string text, Func<char, bool> predicate)
    {
        return Strings.FilterByChar(text, predicate);
    }

    #endregion

    #region Format With

    /// <summary>
    /// Extension method to format string with passed arguments. Current thread's current culture is used
    /// </summary>
    /// <param name="format">string format</param>
    /// <param name="args">arguments</param>
    /// <returns></returns>
    public static string FormatWith(this string format, params object[] args)
    {
        return Strings.FormatWith(format, args);
    }

    /// <summary>
    /// Extension method to format string with passed arguments using specified format provider (i.e. CultureInfo)
    /// </summary>
    /// <param name="format">string format</param>
    /// <param name="provider">An object that supplies culture-specific formatting information</param>
    /// <param name="args">arguments</param>
    /// <returns></returns>
    public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
    {
        return Strings.FormatWith(format, provider, args);
    }

    #endregion

    #region Left and Right

    /// <summary>
    /// Cut off from right to left. <br />
    /// 从右向左截取字符串
    /// </summary>
    /// <param name="text"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Right(this string text, int length)
    {
        return Strings.Right(text, length);
    }

    /// <summary>
    /// Cut off from left to right <br />
    /// 从左向右截取字符串
    /// </summary>
    /// <param name="text"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Left(this string text, int length)
    {
        return Strings.Left(text, length);
    }

    #endregion

    #region Remove

    /// <summary>
    /// Remove <br />
    /// 从字符串中移除给定的子字符串，根据 IgnoreCase 选项来控制大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="removeText"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Remove(this string text, string removeText, IgnoreCase @case = IgnoreCase.FALSE)
    {
        return Strings.Remove(text, removeText, @case);
    }

    /// <summary>
    /// Remove all specified characters. <br />
    /// 移除所有指定的字符。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toRemove"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RemoveChars(this string text, params char[] toRemove)
    {
        return Strings.RemoveChars(text, toRemove);
    }

    /// <summary>
    /// Remove all spaces. <br />
    /// 移除所有空格。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RemoveWhiteSpace(this string text)
    {
        return Strings.RemoveWhiteSpace(text);
    }

    /// <summary>
    /// Remove duplicate space <br />
    /// 从字符串中移除所有重复的空格
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RemoveDuplicateWhiteSpaces(this string text)
    {
        return Strings.RemoveDuplicateWhiteSpaces(text);
    }

    /// <summary>
    /// Remove duplicate char <br />
    /// 从字符串中移除所有重复的字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="charRemove"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RemoveDuplicateChar(this string text, char charRemove, IgnoreCase @case = IgnoreCase.FALSE)
    {
        return Strings.RemoveDuplicateChar(text, charRemove, @case);
    }

    /// <summary>
    /// Remove since the given index <br />
    /// 从给定的位置开始移除所有字符，位置从 0 开始计算
    /// </summary>
    /// <param name="text"></param>
    /// <param name="indexOfStartToRemove"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RemoveSince(this string text, int indexOfStartToRemove)
    {
        return Strings.RemoveSince(text, indexOfStartToRemove);
    }

    /// <summary>
    /// Remove since the given text <br />
    /// 根据给定子字符串在字符串中的位置，移除该位置之后的所有字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="removeFromThis"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RemoveSince(this string text, string removeFromThis)
    {
        return Strings.RemoveSince(text, removeFromThis);
    }

    /// <summary>
    /// Remove since the given text and ignore case <br />
    /// 根据给定子字符串在字符串中的位置，移除该位置之后的所有字符，并忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="removeFromThis"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RemoveSinceIgnoreCase(this string text, string removeFromThis)
    {
        return Strings.RemoveSinceIgnoreCase(text, removeFromThis);
    }

    /// <summary>
    /// Remove since the given text with ignore case options <br />
    /// 根据给定子字符串在字符串中的位置，移除该位置之后的所有字符，根据 IgnoreCase 选项决定是否忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="removeFromThis"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string RemoveSince(this string text, string removeFromThis, IgnoreCase @case)
    {
        return Strings.RemoveSince(text, removeFromThis, @case);
    }

    #endregion

    #region Repeat

    /// <summary>
    /// Repeat<br />
    /// 重复指定次数的字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="repeatTimes"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Repeat(this string text, int repeatTimes)
    {
        return Strings.Repeat(text, repeatTimes);
    }

    #endregion

    #region Prefix / Suffix

    /// <summary>
    /// Returns the common prefix.<br />
    /// 从左到右，返回共有的字符，直至遇到第一个不同的字符。
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string CommonPrefix(this string left, string right)
    {
        return Strings.CommonPrefix(left, right);
    }

    /// <summary>
    /// Returns the common prefix.<br />
    /// 从左到右，返回共有的字符，直至遇到第一个不同的字符。
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="len"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string CommonPrefix(this string left, string right, out int len)
    {
        return Strings.CommonPrefix(left, right, out len);
    }

    /// <summary>
    /// Returns the common suffix.<br />
    /// 从右到左，返回共有的字符，直至遇到第一个不同的字符。
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string CommonSuffix(this string left, string right)
    {
        return Strings.CommonSuffix(left, right);
    }

    /// <summary>
    /// Returns the common suffix.<br />
    /// 从右到左，返回共有的字符，直至遇到第一个不同的字符。
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="len"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string CommonSuffix(this string left, string right, out int len)
    {
        return Strings.CommonSuffix(left, right, out len);
    }

    #endregion
}

/// <summary>
/// String shortcut extensions <br />
/// 字符串捷径扩展
/// </summary>
public static partial class StringsShortcutExtensions
{
    #region Encoding

    /// <summary>
    /// Convert string to byte array <br />
    /// 将字符串换换为字节数组
    /// </summary>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] ToBytes(this string value, Encoding encoding = null)
    {
        return value is null
            ? throw new ArgumentNullException(nameof(value))
            : (encoding ?? Encoding.UTF8).GetBytes(value);
    }

    /// <summary>
    /// Convert byte array to string <br />
    /// 将字节数组换换位字符串
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetString(this byte[] bytes, Encoding encoding = null)
    {
        return bytes is null
            ? throw new ArgumentNullException(nameof(bytes))
            : (encoding ?? Encoding.UTF8).GetString(bytes);
    }

    #endregion

    #region Index

    /// <summary>
    /// Index of ignore case <br />
    /// 查找给定子字符串位于字符串的位置，忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfIgnoreCase(this string text, string toCheck)
    {
        return text.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Index of ignore case <br />
    /// 查找给定子字符串位于字符串的位置，忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="startIndex"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOfIgnoreCase(this string text, string toCheck, int startIndex)
    {
        return text.IndexOf(toCheck, startIndex, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Last index of ignore case <br />
    /// 查找给定子字符串位于字符串的最后的位置，忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfIgnoreCase(this string text, string toCheck)
    {
        return text.LastIndexOf(toCheck, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Last index of ignore case <br />
    /// 查找给定子字符串位于字符串的最后的位置，忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <param name="startIndex"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int LastIndexOfIgnoreCase(this string text, string toCheck, int startIndex, int count)
    {
        return text.LastIndexOf(toCheck, startIndex, count, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Last index of any <br />
    /// 查找给定子字符串集合中，最靠结尾的那个字字符串的位置
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    public static int LastIndexOfAny(this string text, params string[] toCheck)
    {
        if (toCheck is null || toCheck.Length == 0)
            throw new ArgumentNullException(nameof(toCheck), $"The parameter '{nameof(toCheck)}' cannot be null or empty.");

        var res = -1;
        foreach (var checking in toCheck)
        {
            var index = text.LastIndexOf(checking, StringComparison.OrdinalIgnoreCase);
            if (index >= 0 && index > res)
                res = index;
        }

        return res;
    }

    /// <summary>
    /// Index whole phrase <br />
    /// 查找给定短语在字符串中的位置
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toCheck"></param>
    /// <param name="startIndex"></param>
    /// <returns></returns>
    public static int IndexOfWholePhrase(this string text, string toCheck, int startIndex = 0)
    {
        if (toCheck.IsNullOrEmpty())
            throw new ArgumentNullException($"The parameter '{nameof(toCheck)}' cannot be null or empty.", nameof(toCheck));

        //var length = toCheck.Length;
        while (startIndex <= text.Length)
        {
            var index = text.IndexOfIgnoreCase(toCheck, startIndex);
            if (index < 0)
                return -1;

            var indexPreviousCar = index - 1;
            var indexNextCar = index + toCheck.Length;
            if (
                (index == 0 || !char.IsLetter(text[indexPreviousCar]))
              &&
                (index + toCheck.Length == text.Length || !char.IsLetter(text[indexNextCar]))
            )
                return index;

            startIndex = index + toCheck.Length;
        }

        return -1;
    }

    #endregion

    #region Substring

    /// <summary>
    /// SubString from... <br />
    /// 根据给定的子字符串在字符串中的位置开始截取
    /// </summary>
    /// <param name="text"></param>
    /// <param name="from"></param>
    /// <returns></returns>
    public static string SubstringSince(this string text, string from)
    {
        if (text.IsNullOrEmpty())
            return string.Empty;

        var index = text.IndexOfIgnoreCase(from);
        return index < 0 ? string.Empty : text[index..];
    }

    /// <summary>
    /// SubString to... <br />
    /// 根据给定的子字符串在字符串中的位置，截取至该位置
    /// </summary>
    /// <param name="text"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public static string SubstringTo(this string text, string to)
    {
        if (text.IsNullOrEmpty())
            return string.Empty;

        var index = text.IndexOfIgnoreCase(to);
        return index < 0 ? string.Empty : text[..index];
    }

    #endregion

    #region Trim

    /// <summary>
    /// Remove all spaces. <br />
    /// 移除所有空格。
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string TrimInner(this string text)
    {
        return Strings.RemoveWhiteSpace(text);
    }

    /// <summary>
    /// Trim all <br />
    /// 对所有给定的字符串进行 Trim 操作
    /// </summary>
    /// <param name="texts"></param>
    public static void TrimAll(this IList<string> texts)
    {
        if (texts is null)
            return;

        for (var i = 0; i < texts.Count; i++)
            texts[i] = texts[i].Trim();
    }

    /// <summary>
    /// Trim phrase <br />
    /// 根据给定的短语，对字符串两端进行 Trim 操作。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="phrase"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string TrimPhrase(this string text, string phrase)
    {
        return text.TrimPhraseStart(phrase).TrimPhraseEnd(phrase);
    }

    /// <summary>
    /// Trim phrase start <br />
    /// 根据给定的短语，对字符串开始端进行 Trim 操作。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="phrase"></param>
    /// <returns></returns>
    public static string TrimPhraseStart(this string text, string phrase)
    {
        if (text.IsNullOrEmpty())
            return string.Empty;

        if (phrase.IsNullOrEmpty())
            return text;

        while (text.StartsWith(phrase))
        {
            text = text[phrase.Length..];
        }

        return text;
    }

    /// <summary>
    /// Trim phrase end <br />
    /// 根据给定的短语，对字符串结尾端进行 Trim 操作。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="phrase"></param>
    /// <returns></returns>
    public static string TrimPhraseEnd(this string text, string phrase)
    {
        if (text.IsNullOrEmpty())
            return string.Empty;

        if (phrase.IsNullOrEmpty())
            return text;

        while (text.EndsWithIgnoreCase(phrase))
        {
            text = text[..^phrase.Length];
        }

        return text;
    }

    #endregion
}