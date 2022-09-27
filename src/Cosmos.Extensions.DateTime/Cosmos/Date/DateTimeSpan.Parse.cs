using Cosmos.Conversions.StringDeterminers;

namespace Cosmos.Date;

/// <summary>
/// DateTime span
/// </summary>
public partial struct DateTimeSpan
{
    /// <summary>
    /// Try to convert the string to DateTimeSpan <br />
    /// 尝试将字符串转换为 DateTimeSpan
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, out DateTimeSpan result)
        => DateTimeSpanParse.TryParse(s, null, out result);

    /// <summary>
    /// Try to convert the string to DateTimeSpan <br />
    /// 尝试将字符串转换为 DateTimeSpan
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParse(string s, IFormatProvider provider, out DateTimeSpan result)
        => DateTimeSpanParse.TryParse(s, provider, out result);

    /// <summary>
    /// Try to convert the string to DateTimeSpan <br />
    /// 尝试将字符串转换为 DateTimeSpan
    /// </summary>
    /// <param name="input"></param>
    /// <param name="format"></param>
    /// <param name="provider"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParseExact(string input, string format, IFormatProvider provider, out DateTimeSpan result)
        => DateTimeSpanParse.TryParseExact(input, format, provider, TimeSpanStyles.None, out result);

    /// <summary>
    /// Try to convert the string to DateTimeSpan <br />
    /// 尝试将字符串转换为 DateTimeSpan
    /// </summary>
    /// <param name="input"></param>
    /// <param name="formats"></param>
    /// <param name="provider"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParseExact(string input, string[] formats, IFormatProvider provider, out DateTimeSpan result)
        => DateTimeSpanParse.TryParseExactMultiple(input, formats, provider, TimeSpanStyles.None, out result);

    /// <summary>
    /// Try to convert the string to DateTimeSpan <br />
    /// 尝试将字符串转换为 DateTimeSpan
    /// </summary>
    /// <param name="input"></param>
    /// <param name="format"></param>
    /// <param name="provider"></param>
    /// <param name="styles"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParseExact(string input, string format, IFormatProvider provider, TimeSpanStyles styles, out DateTimeSpan result)
        => DateTimeSpanParse.TryParseExact(input, format, provider, styles, out result);

    /// <summary>
    /// Try to convert the string to DateTimeSpan <br />
    /// 尝试将字符串转换为 DateTimeSpan
    /// </summary>
    /// <param name="input"></param>
    /// <param name="formats"></param>
    /// <param name="provider"></param>
    /// <param name="styles"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool TryParseExact(string input, string[] formats, IFormatProvider provider, TimeSpanStyles styles, out DateTimeSpan result)
        => DateTimeSpanParse.TryParseExactMultiple(input, formats, provider, styles, out result);

    private static Func<object, bool> StringConvBeHandler
    {
        get
        {
            return obj =>
            {
                if (obj is string str)
                    return StringDateTimeSpanDeterminer.Is(str);
                return false;
            };
        }
    }

    private static Func<object, object> StringConvToHandler
    {
        get
        {
            return obj =>
            {
                if (obj is string str)
                    return StringDateTimeSpanDeterminer.To(str);
                return default(DateInfo);
            };
        }
    }
}

internal static class DateTimeSpanParse
{
    public static bool TryParse(string s, IFormatProvider provider, out DateTimeSpan result)
        => TryCreateDateTimeSpan(TimeSpan.TryParse(s, provider, out var timeSpan), timeSpan, out result);

    public static bool TryParseExact(string s, string format, IFormatProvider provider, TimeSpanStyles styles, out DateTimeSpan result)
        => TryCreateDateTimeSpan(TimeSpan.TryParseExact(s, format, provider, styles, out var timeSpan), timeSpan, out result);

    public static bool TryParseExactMultiple(string s, string[] formats, IFormatProvider provider, TimeSpanStyles styles, out DateTimeSpan result)
        => TryCreateDateTimeSpan(TimeSpan.TryParseExact(s, formats, provider, styles, out var timeSpan), timeSpan, out result);

    private static bool TryCreateDateTimeSpan(bool condition, TimeSpan timeSpan, out DateTimeSpan result)
    {
        result = default;
        if (!condition) return false;
        result = new DateTimeSpan { TimeSpan = timeSpan };
        return true;
    }
}