namespace Cosmos.Text;

/// <summary>
/// String Utils<br />
/// 字符串工具
/// </summary>
public static partial class Strings
{
    /// <summary>
    /// Replace ignore case <br />
    /// 替换，无视大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceIgnoreCase(string text, string oldValue, string newValue)
    {
        return Replace(text, oldValue, newValue, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Replace only whole phrase <br />
    /// 只替换完整单词
    /// </summary>
    /// <param name="text"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    public static string ReplaceOnlyWholePhrase(string text, string oldValue, string newValue)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        if (string.IsNullOrEmpty(oldValue))
            return text;

        var index = text.IndexOfWholePhrase(oldValue);
        var lastIndex = 0;

        var buffer = new StringBuilder(text.Length);

        while (index >= 0)
        {
            buffer.Append(text, startIndex: lastIndex, count: index - lastIndex);
            buffer.Append(newValue);

            lastIndex = index + oldValue.Length;

            index = text.IndexOfWholePhrase(oldValue, startIndex: index + 1);
        }

        buffer.Append(text, lastIndex, text.Length - lastIndex);

        return buffer.ToString();
    }

    /// <summary>
    /// Replace first occurrence <br />
    /// 只替换首个命中的值
    /// </summary>
    /// <param name="text"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    public static string ReplaceFirstOccurrence(string text, string oldValue, string newValue)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        if (string.IsNullOrEmpty(oldValue))
            return text;

        var index = text.IndexOfIgnoreCase(oldValue);

        return index switch
        {
            < 0 => text,
            0 => $"{newValue}{text[oldValue.Length..]}",
            _ => $"{text[..index]}{newValue}{text[(index + oldValue.Length)..]}"
        };
    }

    /// <summary>
    /// Replace last occurrence <br />
    /// 只替换最后一个命中的值
    /// </summary>
    /// <param name="text"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    public static string ReplaceLastOccurrence(string text, string oldValue, string newValue)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        if (string.IsNullOrEmpty(oldValue))
            return text;

        var index = text.LastIndexOfIgnoreCase(oldValue);

        return index switch
        {
            < 0 => text,
            0 => $"{newValue}{text[oldValue.Length..]}",
            _ => $"{text[..index]}{newValue}{text[(index + oldValue.Length)..]}"
        };
    }

    /// <summary>
    /// Replace only at end ignore case <br />
    /// 只替换结尾命中的结果，并无视大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    public static string ReplaceOnlyAtEndIgnoreCase(string text, string oldValue, string newValue)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        if (string.IsNullOrEmpty(oldValue))
            return text;

        if (text.EndsWithIgnoreCase(oldValue))
            return $"{text[..^oldValue.Length]}{newValue}";

        return text;
    }

    /// <summary>
    /// Replace <br />
    /// 替换
    /// </summary>
    /// <param name="text"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <param name="comparisionType"></param>
    /// <returns></returns>
    public static string Replace(string text, string oldValue, string newValue, StringComparison comparisionType)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        if (string.IsNullOrEmpty(oldValue))
            return text;

        int index = -1, lastIndex = 0;

        var buffer = new StringBuilder(text.Length);

        while ((index = text.IndexOf(oldValue, index + 1, comparisionType)) >= 0)
        {
            buffer.Append(text, lastIndex, index - lastIndex);
            buffer.Append(newValue);

            lastIndex = index + oldValue.Length;
        }

        buffer.Append(text, lastIndex, text.Length - lastIndex);

        return buffer.ToString();
    }

    /// <summary>
    /// Replace recursive <br />
    /// 递归替换
    /// </summary>
    /// <param name="text"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    public static string ReplaceRecursive(string text, string oldValue, string newValue)
    {
        const int maxTries = 1000;

        string temp, ret;

        ret = text.Replace(oldValue, newValue);

        var i = 0;
        do
        {
            i++;
            temp = ret;
            ret = temp.Replace(oldValue, newValue);
        } while (temp != ret || i > maxTries);

        return ret;
    }

    /// <summary>
    /// Replace chars with space <br />
    /// 用空格来替换所有命中的字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toReplace"></param>
    /// <returns></returns>
    public static string ReplaceCharsWithWhiteSpace(string text, params char[] toReplace)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        if (toReplace is null || toReplace.Length == 0)
            return text;

        var holder = new char[text.Length];

        for (var i = 0; i < text.Length; i++)
        {
            var @char = text[i];
            var matched = false;
            for (var j = 0; j < toReplace.Length; j++)
            {
                if (@char == toReplace[j])
                {
                    holder[i] = ' ';
                    matched = true;
                    break;
                }
            }

            if (!matched)
            {
                holder[i] = @char;
            }
        }

        return new string(holder);
    }

    /// <summary>
    /// Replace numbers with... <br />
    /// 用给定的字符来替换数字
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toReplace"></param>
    /// <returns></returns>
    public static string ReplaceNumbersWith(string text, char toReplace)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        var holder = new char[text.Length];

        for (var i = 0; i < text.Length; i++)
        {
            var @char = text[i];
            if (@char >= '0' && @char <= '9')
                holder[i] = toReplace;
            else
                holder[i] = @char;
        }

        return new string(holder);
    }
}

/// <summary>
/// String extensions <br />
/// 字符串扩展
/// </summary>
public static partial class StringsExtensions
{
     /// <summary>
    /// Replace ignore case <br />
    /// 替换，无视大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceIgnoreCase(this string text, string oldValue, string newValue)
         => Strings.ReplaceIgnoreCase(text, oldValue, newValue);

     /// <summary>
    /// Replace only whole phrase <br />
    /// 只替换完整单词
    /// </summary>
    /// <param name="text"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceOnlyWholePhrase(this string text, string oldValue, string newValue)
        => Strings.ReplaceOnlyWholePhrase(text, oldValue, newValue);

    /// <summary>
    /// Replace first occurrence <br />
    /// 只替换首个命中的值
    /// </summary>
    /// <param name="text"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceFirstOccurrence(this string text, string oldValue, string newValue)
        => Strings.ReplaceFirstOccurrence(text, oldValue, newValue);

    /// <summary>
    /// Replace last occurrence <br />
    /// 只替换最后一个命中的值
    /// </summary>
    /// <param name="text"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceLastOccurrence(this string text, string oldValue, string newValue)
        => Strings.ReplaceLastOccurrence(text, oldValue, newValue);

    /// <summary>
    /// Replace only at end ignore case <br />
    /// 只替换结尾命中的结果，并无视大小写
    /// </summary>
    /// <param name="text"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceOnlyAtEndIgnoreCase(this string text, string oldValue, string newValue)
        => Strings.ReplaceOnlyAtEndIgnoreCase(text, oldValue, newValue);

    /// <summary>
    /// Replace <br />
    /// 替换
    /// </summary>
    /// <param name="text"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <param name="comparisionType"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Replace(this string text, string oldValue, string newValue, StringComparison comparisionType)
        => Strings.Replace(text, oldValue, newValue, comparisionType);

    /// <summary>
    /// Replace recursive <br />
    /// 递归替换
    /// </summary>
    /// <param name="text"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceRecursive(this string text, string oldValue, string newValue)
        => Strings.ReplaceRecursive(text, oldValue, newValue);

    /// <summary>
    /// Replace chars with space <br />
    /// 用空格来替换所有命中的字符
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toReplace"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceCharsWithWhiteSpace(this string text, params char[] toReplace)
        => Strings.ReplaceCharsWithWhiteSpace(text, toReplace);

    /// <summary>
    /// Replace numbers with... <br />
    /// 用给定的字符来替换数字
    /// </summary>
    /// <param name="text"></param>
    /// <param name="toReplace"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ReplaceNumbersWith(this string text, char toReplace)
        => Strings.ReplaceNumbersWith(text, toReplace);
}