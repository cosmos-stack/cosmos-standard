namespace Cosmos.Conversions.StringDeterminers;

/// <summary>
/// Internal core conversion helper from string to DateTimeSpan
/// </summary>
public static class StringDateTimeSpanDeterminer
{
    /// <summary>
    /// Is
    /// </summary>
    /// <param name="text"></param>
    /// <param name="formatProvider"></param>
    /// <param name="matchedCallback"></param>
    /// <returns></returns>
    public static bool Is(
        string text,
        IFormatProvider formatProvider = null,
        Action<DateTimeSpan> matchedCallback = null)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        formatProvider ??= DateTimeFormatInfo.CurrentInfo;
        return DateTimeSpan.TryParse(text, formatProvider, out var dateTimeSpan)
                           .IfTrueThenInvoke(matchedCallback, dateTimeSpan);
    }

    /// <summary>
    /// Is
    /// </summary>
    /// <param name="text"></param>
    /// <param name="tries"></param>
    /// <param name="formatProvider"></param>
    /// <param name="matchedCallback"></param>
    /// <returns></returns>
    public static bool Is(
        string text,
        IEnumerable<IConversionTry<string, DateTimeSpan>> tries,
        IFormatProvider formatProvider = null,
        Action<DateTimeSpan> matchedCallback = null)
    {
        formatProvider ??= DateTimeFormatInfo.CurrentInfo;
        return StringDeterminingHelper.IsXXX(text, string.IsNullOrWhiteSpace,
            (s, act) => Is(s, formatProvider, act), tries, matchedCallback);
    }

    /// <summary>
    /// To
    /// </summary>
    /// <param name="text"></param>
    /// <param name="formatProvider"></param>
    /// <param name="defaultVal"></param>
    /// <returns></returns>
    public static DateTimeSpan To(
        string text,
        IFormatProvider formatProvider = null,
        DateTimeSpan defaultVal = default)
    {
        formatProvider ??= DateTimeFormatInfo.CurrentInfo;
        return DateTimeSpan.TryParse(text, formatProvider, out var dateTimeSpan)
            ? dateTimeSpan
            : defaultVal;
    }

    /// <summary>
    /// To
    /// </summary>
    /// <param name="text"></param>
    /// <param name="impls"></param>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    public static DateTimeSpan To(
        string text,
        IEnumerable<IConversionImpl<string, DateTimeSpan>> impls,
        IFormatProvider formatProvider = null)
    {
        formatProvider ??= DateTimeFormatInfo.CurrentInfo;
        return StringDeterminingHelper.ToXXX(text, (s, act) => Is(s, formatProvider, act), impls);
    }
}