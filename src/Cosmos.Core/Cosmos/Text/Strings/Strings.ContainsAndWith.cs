// ReSharper disable PossibleMultipleEnumeration

namespace Cosmos.Text;

/// <summary>
/// String Utils<br />
/// 字符串工具
/// </summary>
public static partial class Strings
{
    #region Contains

    /// <summary>
    /// Contains <br />
    /// 在字符串中是否包含任意一个给定的子字符串
    /// </summary>
    /// <param name="text"></param>
    /// <param name="value"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool Contains(string text, string value, params string[] values)
    {
        return YieldReturnStrings().Any(text.Contains);

        IEnumerable<string> YieldReturnStrings()
        {
            yield return value;
            if (value is null)
                yield break;
            foreach (var val in values)
                yield return val;
        }
    }

    /// <summary>
    /// Contains <br />
    /// 在字符串中是否包含给定的字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="character"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(string text, char character)
    {
        return text.Any(c => c == character);
    }

    /// <summary>
    /// Contains <br />
    /// 在字符串中是否包含任意一个给定的字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="character"></param>
    /// <param name="characters"></param>
    /// <returns></returns>
    public static bool Contains(string text, char character, params char[] characters)
    {
        return YieldReturnCharacters().Any(text.Contains);

        IEnumerable<char> YieldReturnCharacters()
        {
            yield return character;
            if (characters is null)
                yield break;
            foreach (var @char in characters)
                yield return @char;
        }
    }

    /// <summary>
    /// Contains ignore case <br />
    /// 在字符串中是否包含任意一个给定的子字符串，忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="value"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool ContainsIgnoreCase(string text, string value, params string[] values)
    {
#if NETFRAMEWORK || NETSTANDARD2_0
        return YieldReturnStrings().Any(val => string.Equals(text, val, StringComparison.OrdinalIgnoreCase));
#else
        return YieldReturnStrings().Any(v => text.Contains(v, StringComparison.OrdinalIgnoreCase));
#endif
        IEnumerable<string> YieldReturnStrings()
        {
            yield return value;
            if (value is null)
                yield break;
            foreach (var val in values)
                yield return val;
        }
    }

    /// <summary>
    /// Contains ignore case <br />
    /// 在字符串中是否包含给定的字符，忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="character"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsIgnoreCase(string text, char character)
    {
        return text.Any(c => c == char.ToUpperInvariant(character) || c == char.ToLowerInvariant(character));
    }

    /// <summary>
    /// Contains ignore case <br />
    /// 在字符串中是否包含任意一个给定的子字符串，忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="character"></param>
    /// <param name="characters"></param>
    /// <returns></returns>
    public static bool ContainsIgnoreCase(string text, char character, params char[] characters)
    {
#if NETFRAMEWORK || NETSTANDARD2_0
        foreach (var val in YieldReturnCharacters())
            for (var i = 0; i < text.Length; i++)
                if (text[i].EqualsIgnoreCase(val))
                    return true;

        return false;
#else
        return YieldReturnCharacters().Any(v => text.Contains(v, StringComparison.OrdinalIgnoreCase));
#endif

        IEnumerable<char> YieldReturnCharacters()
        {
            yield return character;
            if (characters is null)
                yield break;
            foreach (var @char in characters)
                yield return @char;
        }
    }

    /// <summary>
    /// Contains with ignore case options <br />
    /// 在字符串中是否包含任意一个给定的子字符串，根据给定的 IgnoreCase 选项
    /// </summary>
    /// <param name="text"></param>
    /// <param name="values"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(string text, string[] values, IgnoreCase @case)
    {
        return @case.X()
#if NETFRAMEWORK || NETSTANDARD2_0
            ? values.Any(val => string.Equals(text, val, StringComparison.OrdinalIgnoreCase))
#else
            ? values.Any(v => text.Contains(v, StringComparison.OrdinalIgnoreCase))
#endif
            : values.Any(text.Contains);
    }

    /// <summary>
    /// Contains with ignore case options <br />
    /// 在字符串中是否包含给定的字符，根据给定的 IgnoreCase 选项
    /// </summary>
    /// <param name="text"></param>
    /// <param name="character"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(string text, char character, IgnoreCase @case)
    {
        return @case.X()
            ? text.Any(c => c == char.ToUpperInvariant(character) || c == char.ToLowerInvariant(character))
            : text.Any(c => c == character);
    }

    /// <summary>
    /// Contains with ignore case options <br />
    /// 在字符串中是否包含任意一个给定的字符，根据给定的 IgnoreCase 选项
    /// </summary>
    /// <param name="text"></param>
    /// <param name="characters"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(string text, char[] characters, IgnoreCase @case)
    {
        if (@case.X())
        {
#if NETFRAMEWORK || NETSTANDARD2_0
            foreach (var val in characters)
                for (var i = 0; i < text.Length; i++)
                    if (text[i].EqualsIgnoreCase(val))
                        return true;

            return false;
#else
            return characters.Any(v => text.Contains(v, StringComparison.OrdinalIgnoreCase));
#endif
        }

        return characters.Any(text.Contains);
    }

    #endregion
}

/// <summary>
/// String extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringsExtensions
{
    #region Contains

    /// <summary>
    /// Contains <br />
    /// 在字符串中是否包含任意一个给定的子字符串
    /// </summary>
    /// <param name="text"></param>
    /// <param name="value"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this string text, string value, params string[] values) => Strings.Contains(text, value, values);

    /// <summary>
    /// Contains <br />
    /// 在字符串中是否包含给定的字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="character"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this string text, char character) => Strings.Contains(text, character);

    /// <summary>
    /// Contains <br />
    /// 在字符串中是否包含任意一个给定的字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="character"></param>
    /// <param name="characters"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this string text, char character, params char[] characters) => Strings.Contains(text, character, characters);

    /// <summary>
    /// Contains ignore case <br />
    /// 在字符串中是否包含任意一个给定的子字符串，忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="value"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsIgnoreCase(this string text, string value, params string[] values) => Strings.ContainsIgnoreCase(text, value, values);

    /// <summary>
    /// Contains ignore case <br />
    /// 在字符串中是否包含给定的字符，忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="character"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsIgnoreCase(this string text, char character) => Strings.ContainsIgnoreCase(text, character);

    /// <summary>
    /// Contains ignore case <br />
    /// 在字符串中是否包含任意一个给定的子字符串，忽略大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="character"></param>
    /// <param name="characters"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsIgnoreCase(this string text, char character, params char[] characters) => Strings.ContainsIgnoreCase(text, character, characters);

    /// <summary>
    /// Contains with ignore case options <br />
    /// 在字符串中是否包含任意一个给定的子字符串，根据给定的 IgnoreCase 选项
    /// </summary>
    /// <param name="text"></param>
    /// <param name="values"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this string text, string[] values, IgnoreCase @case) => Strings.Contains(text, values, @case);

    /// <summary>
    /// Contains with ignore case options <br />
    /// 在字符串中是否包含给定的字符，根据给定的 IgnoreCase 选项
    /// </summary>
    /// <param name="text"></param>
    /// <param name="character"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this string text, char character, IgnoreCase @case) => Strings.Contains(text, character, @case);

    /// <summary>
    /// Contains with ignore case options <br />
    /// 在字符串中是否包含任意一个给定的字符，根据给定的 IgnoreCase 选项
    /// </summary>
    /// <param name="text"></param>
    /// <param name="characters"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Contains(this string text, char[] characters, IgnoreCase @case) => Strings.Contains(text, characters, @case);

    #endregion
}

/// <summary>
/// String shortcut extensions <br />
/// 字符串捷径扩展
/// </summary>
public static partial class StringsShortcutExtensions
{
    #region EndsWith

    /// <summary>
    /// Ends with <br />
    /// 确定此字符串实例的结尾是否与指定的字符串数组中的某一个成员匹配。
    /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
    /// </summary>
    /// <param name="text"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool EndsWith(this string text, params string[] values)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        if (values is null || values.Length == 0 || values.Any(string.IsNullOrWhiteSpace))
            return true;

        return values.Any(text.EndsWith);
    }

    /// <summary>
    /// Ends with <br />
    /// 确定此字符串实例的结尾是否与指定的字符串数组中的某一个成员匹配。
    /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
    /// </summary>
    /// <param name="text"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool EndsWith(this string text, IEnumerable<string> values)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        if (values is null || !values.Any())
            return true;

        return EndsWith(text, values.ToArray());
    }

    /// <summary>
    /// Ends with ignore case <br />
    /// 确定此字符串实例的结尾是否与指定的字符串匹配，忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool EndsWithIgnoreCase(this string text, string values)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        if (values.IsNullOrEmpty())
            return true;

        return text.EndsWith(values, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Ends with any ignore case <br />
    /// 确定此字符串实例的结尾是否与指定的字符串数组中的某一个成员匹配。
    /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
    /// </summary>
    /// <param name="text"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool EndsWithIgnoreCase(this string text, params string[] values)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        if (values is null || values.Length == 0 || values.Any(string.IsNullOrWhiteSpace))
            return true;

        return EndsWithIgnoreCase(text, (IEnumerable<string>)values);
    }

    /// <summary>
    /// Ends with any ignore case <br />
    /// 确定此字符串实例的结尾是否与指定的字符串数组中的某一个成员匹配，忽略大小写。
    /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
    /// </summary>
    /// <param name="text"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool EndsWithIgnoreCase(this string text, IEnumerable<string> values)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        if (values is null || !values.Any())
            return true;

        return values.Any(check => text.EndsWith(check, StringComparison.OrdinalIgnoreCase));
    }

    #endregion

    #region StartsWith

    /// <summary>
    /// Start withs <br />
    /// 确定此字符串实例的开头是否与指定的字符串数组中的某一个成员匹配。
    /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
    /// </summary>
    /// <param name="text"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool StartsWith(this string text, params string[] values)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        if (values is null || values.Length == 0 || values.Any(string.IsNullOrWhiteSpace))
            return true;

        return values.Any(text.StartsWith);
    }

    /// <summary>
    /// Start withs <br />
    /// 确定此字符串实例的开头是否与指定的字符串数组中的某一个成员匹配。
    /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
    /// </summary>
    /// <param name="text"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool StartsWith(this string text, IEnumerable<string> values)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        if (values is null || !values.Any())
            return true;

        return StartsWith(text, values.ToArray());
    }

    /// <summary>
    /// Starts with ignore case <br />
    /// 确定此字符串实例的开头是否与指定的字符串匹配，忽略大小写。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool StartsWithIgnoreCase(this string text, string values)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        if (values.IsNullOrEmpty())
            return true;

        return text.StartsWith(values, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Starts with any ignore case <br />
    /// 确定此字符串实例的开头是否与指定的字符串数组中的某一个成员匹配。
    /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
    /// </summary>
    /// <param name="text"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool StartsWithIgnoreCase(this string text, params string[] values)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        if (values is null || values.Length == 0 || values.Any(string.IsNullOrWhiteSpace))
            return true;

        return StartsWithIgnoreCase(text, (IEnumerable<string>)values);
    }

    /// <summary>
    /// Starts with any ignore case <br />
    /// 确定此字符串实例的开头是否与指定的字符串数组中的某一个成员匹配，忽略大小写。
    /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
    /// </summary>
    /// <param name="text"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool StartsWithIgnoreCase(this string text, IEnumerable<string> values)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        if (values is null || !values.Any())
            return true;

        return values.Any(check => text.StartsWith(check, StringComparison.OrdinalIgnoreCase));
    }

    #endregion
}