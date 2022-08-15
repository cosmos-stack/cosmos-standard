namespace Cosmos.Text;

/// <summary>
/// Char Utilities <br />
/// 字符工具集
/// </summary>
public static class Chars
{
    #region BeContainedIn

    /// <summary>
    /// Determine whether the character is included in the given character set. <br />
    /// 判断字符是否包含于给定的字符集合中
    /// </summary>
    /// <param name="char"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool BeContainedIn(char @char, params char[] values)
    {
        return Array.IndexOf(values, @char) >= 0;
    }

    /// <summary>
    /// Determine whether the character is included in the given character set. <br />
    /// 判断字符是否包含于给定的字符集合中
    /// </summary>
    /// <param name="char"></param>
    /// <param name="case"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool BeContainedIn(char @char, char[] values, IgnoreCase @case)
    {
        if (values is null || values.Length == 0)
            return false;
        if (@case == IgnoreCase.FALSE)
            return BeContainedIn(@char, values);
        return BeContainedIn(@char, IgnoreCaseHelper.FillChars(values));
    }

    /// <summary>
    /// Determine whether the character is not included in the given character set. <br />
    /// 判断字符是否不包含于给定的字符集合中
    /// </summary>
    /// <param name="char"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool BeNotContainedIn(char @char, params char[] values)
    {
        return Array.IndexOf(values, @char) < 0;
    }

    /// <summary>
    /// Determine whether the character is not included in the given character set. <br />
    /// 判断字符是否不包含于给定的字符集合中
    /// </summary>
    /// <param name="char"></param>
    /// <param name="case"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static bool BeNotContainedIn(char @char, char[] values, IgnoreCase @case)
    {
        if (values is null || values.Length == 0)
            return true;
        if (@case == IgnoreCase.FALSE)
            return BeNotContainedIn(@char, values);
        return BeNotContainedIn(@char, IgnoreCaseHelper.FillChars(values));
    }

    #endregion

    #region Between

    /// <summary>
    /// Determine whether the given character is included in the range <br />
    /// 判断给定的字符是否包含在范围内
    /// </summary>
    /// <param name="char"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBetween(char @char, char min, char max)
    {
        var (xiao, da) = Fix(min, max);
        return @char >= xiao && @char <= da;
    }

    private static (char min, char max) Fix(char min, char max) => min >= max ? (max, min) : (min, max);

    #endregion

    #region Range

    /// <summary>
    /// According to the given two characters, generate a set of continuous character sequence <br />
    /// 根据给定的两个字符，生成一组连续的字符序列
    /// </summary>
    /// <param name="char"></param>
    /// <param name="toCharacter"></param>
    /// <returns></returns>
    public static IEnumerable<char> Range(char @char, char toCharacter)
    {
        var reverseRequired = @char > toCharacter;

        var first = reverseRequired ? toCharacter : @char;
        var last = reverseRequired ? @char : toCharacter;

        var result = Enumerable.Range(first, last - first + 1).Select(charCode => (char)charCode);

        if (reverseRequired)
        {
            result = result.Reverse();
        }

        return result;
    }

    #endregion

    #region Repeat

    /// <summary>
    /// Generate a set of character sequences according to the given characters and the number of repetitions <br />
    /// 重复指定次数的字符
    /// </summary>
    /// <param name="char"></param>
    /// <param name="repeatTimes"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Repeat(char @char, int repeatTimes)
    {
        return repeatTimes <= 0 ? string.Empty : new string(@char, repeatTimes);
    }

    #endregion
}

/// <summary>
/// Chars extensions <br />
/// 字符扩展
/// </summary>
public static class CharsExtensions
{
    #region BeContainedIn

    /// <summary>
    /// Determine whether the character is included in the given character set. <br />
    /// 判断字符是否包含于给定的字符集合中
    /// </summary>
    /// <param name="char"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool BeContainedIn(this char @char, params char[] values) => Chars.BeContainedIn(@char, values);

    /// <summary>
    /// Determine whether the character is included in the given character set. <br />
    /// 判断字符是否包含于给定的字符集合中
    /// </summary>
    /// <param name="char"></param>
    /// <param name="case"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool BeContainedIn(this char @char, char[] values, IgnoreCase @case) => Chars.BeContainedIn(@char, values, @case);

    /// <summary>
    /// Determine whether the character is not included in the given character set. <br />
    /// 判断字符是否不包含于给定的字符集合中
    /// </summary>
    /// <param name="char"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool BeNotContainedIn(this char @char, params char[] values) => Chars.BeNotContainedIn(@char, values);

    /// <summary>
    /// Determine whether the character is not included in the given character set. <br />
    /// 判断字符是否不包含于给定的字符集合中
    /// </summary>
    /// <param name="char"></param>
    /// <param name="case"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool BeNotContainedIn(this char @char, char[] values, IgnoreCase @case) => Chars.BeNotContainedIn(@char, values, @case);

    #endregion

    #region Between

    /// <summary>
    /// Determine whether the given character is included in the range <br />
    /// 判断给定的字符是否包含在范围内
    /// </summary>
    /// <param name="char"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBetween(this char @char, char min, char max) => Chars.IsBetween(@char, min, max);

    #endregion

    #region Repeat

    /// <summary>
    /// Generate a set of character sequences according to the given characters and the number of repetitions <br />
    /// 重复指定次数的字符
    /// </summary>
    /// <param name="char"></param>
    /// <param name="repeatTimes"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Repeat(this char @char, int repeatTimes) => Chars.Repeat(@char, repeatTimes);

    #endregion
}

/// <summary>
/// Chars shortcut extensions <br />
/// 字符捷径扩展
/// </summary>
public static class CharsShortcutExtensions
{
    #region Case

    /// <summary>
    /// To Lower <br />
    /// 转为小写
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToLower(this char @char) => char.ToLower(@char);

    /// <summary>
    /// To Lower <br />
    /// 转为小写
    /// </summary>
    /// <param name="char"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToLower(this char @char, CultureInfo culture) => char.ToLower(@char, culture);

    /// <summary>
    /// To Lower invariant <br />
    /// 转为小写
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToLowerInvariant(this char @char) => char.ToLowerInvariant(@char);

    /// <summary>
    /// Is Upper <br />
    /// 转为大写
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsUpper(this char @char) => char.IsUpper(@char);

    /// <summary>
    /// To Upper <br />
    /// 转为大写
    /// </summary>
    /// <param name="char"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToUpper(this char @char, CultureInfo culture) => char.ToUpper(@char, culture);

    /// <summary>
    /// To Upper invariant <br />
    /// 转为大写
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static char ToUpperInvariant(this char @char) => char.ToUpperInvariant(@char);

    #endregion

    #region Equals with IgnoreCase

    /// <summary>
    /// Equals <br />
    /// 判断是否相等
    /// </summary>
    /// <param name="char"></param>
    /// <param name="toCheck"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Equals(this char @char, char toCheck, IgnoreCase @case) =>
        @case.X()
            ? EqualsIgnoreCase(@char, toCheck)
            : @char == toCheck;

    /// <summary>
    /// Equals <br />
    /// 判断是否相等
    /// </summary>
    /// <param name="char"></param>
    /// <param name="toCheck"></param>
    /// <param name="case"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Equals(this char? @char, char toCheck, IgnoreCase @case)
    {
        if (@char is null)
            return false;
        return @case.X()
            ? EqualsIgnoreCase(@char.Value, toCheck)
            : @char.Value == toCheck;
    }

    /// <summary>
    /// Equals ignore case <br />
    /// 判断是否相等
    /// </summary>
    /// <param name="char"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsIgnoreCase(this char @char, char toCheck) => char.ToUpper(@char) == char.ToUpper(toCheck);

    /// <summary>
    /// Equals ignore case <br />
    /// 判断是否相等
    /// </summary>
    /// <param name="char"></param>
    /// <param name="toCheck"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsIgnoreCase(this char? @char, char toCheck) => @char is not null && EqualsIgnoreCase(@char.Value, toCheck);

    #endregion

    #region Is

    /// <summary>
    /// Indicates whether the specified Unicode character is categorized as white space. <br />
    /// 指示指定的 Unicode 字符是否归类为空格。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWhiteSpace(this char @char) => char.IsWhiteSpace(@char);

    /// <summary>
    /// Indicates whether the specified Unicode character is categorized as a control character. <br />
    /// 指示指定的 Unicode 字符是否归类为控制字符。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsControl(this char @char) => char.IsControl(@char);

    /// <summary>
    /// Indicates whether the specified Unicode character is categorized as a decimal digit. <br />
    /// 指示指定的 Unicode 字符是否归类为十进制数字。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDigit(this char @char) => char.IsDigit(@char);

    /// <summary>
    /// Indicates whether the specified Unicode character is categorized as a Unicode letter. <br />
    /// 指示指定的 Unicode 字符是否归类为 Unicode 字母。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLetter(this char @char) => char.IsLetter(@char);

    /// <summary>
    /// Indicates whether the specified Unicode character is categorized as a letter or a decimal digit. <br />
    /// 指示指定的 Unicode 字符属于字母还是十进制数字。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLetterOrDigit(this char @char) => char.IsLetterOrDigit(@char);

    /// <summary>
    /// Indicates whether the specified Unicode character is categorized as a lowercase letter. <br />
    /// 指示指定的 Unicode 字符是否归类为小写字母。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLower(this char @char) => char.IsLower(@char);

    /// <summary>
    /// Indicates whether the specified Unicode character is categorized as a number. <br />
    /// 指示指定的 Unicode 字符是否归类为数字。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNumber(this char @char) => char.IsNumber(@char);

    /// <summary>
    /// Indicates whether the specified Unicode character is categorized as a punctuation mark. <br />
    /// 指示指定的 Unicode 字符是否归类为标点符号。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPunctuation(this char @char) => char.IsPunctuation(@char);

    /// <summary>
    /// Indicates whether the specified Unicode character is categorized as a separator character. <br />
    /// 指示指定的 Unicode 字符是否归类为分隔符。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSeparator(this char @char) => char.IsSeparator(@char);

    /// <summary>
    /// Indicates whether the specified Unicode character is categorized as a symbol character. <br />
    /// 指示指定的 Unicode 字符是否归类为符号字符。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSymbol(this char @char) => char.IsSymbol(@char);

    #endregion

    #region Is Surrogate

    /// <summary>
    /// Indicates whether the specified character has a surrogate code unit. <br />
    /// 指示指定的字符是否具有代理代码单元。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSurrogate(this char @char) => char.IsSurrogate(@char);

    /// <summary>
    /// Indicates whether the two specified Char objects form a surrogate pair. <br />
    /// 指示两个指定的 Char 对象是否形成代理对。
    /// </summary>
    /// <param name="highSurrogate"></param>
    /// <param name="lowSurrogate"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSurrogatePair(this char highSurrogate, char lowSurrogate) => char.IsSurrogatePair(highSurrogate, lowSurrogate);

    /// <summary>
    /// Indicates whether the specified Char object is a high surrogate. <br />
    /// 指示指定的 Char 对象是否为高代理。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsHighSurrogate(this char @char) => char.IsHighSurrogate(@char);

    /// <summary>
    /// Indicates whether the specified Char object is a low surrogate. <br />
    /// 指示指定的 Char 对象是否为低代理。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLowSurrogate(this char @char) => char.IsLowSurrogate(@char);

    #endregion

    #region Numeric

    /// <summary>
    /// Converts the specified numeric Unicode character to a double-precision floating point number. <br />
    /// 将指定的数字 Unicode 字符转换为双精度浮点数。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double GetNumericValue(this char @char) => char.GetNumericValue(@char);

    #endregion

    #region To

    /// <summary>
    /// Converts the specified Unicode character to its equivalent string representation. <br />
    /// 将指定的 Unicode 字符转换为其等效的字符串表示形式。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToString(this char @char) => char.ToString(@char);

    #endregion

    #region Utf32

    /// <summary>
    /// Converts the value of a UTF-16 encoded surrogate pair into a Unicode code point. <br />
    /// 将 UTF-16 编码的代理对的值转换为 Unicode 代码点。
    /// </summary>
    /// <param name="highSurrogate"></param>
    /// <param name="lowSurrogate"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ConvertToUtf32(this char highSurrogate, char lowSurrogate) => char.ConvertToUtf32(highSurrogate, lowSurrogate);

    #endregion

    #region UnicodeCategory

    /// <summary>
    /// Categorizes a specified Unicode character into a group identified by one of the UnicodeCategory values. <br />
    /// 将指定的 Unicode 字符分类到由 UnicodeCategory 值之一标识的组中。
    /// </summary>
    /// <param name="char"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static UnicodeCategory GetUnicodeCategory(this char @char) => char.GetUnicodeCategory(@char);

    #endregion
}