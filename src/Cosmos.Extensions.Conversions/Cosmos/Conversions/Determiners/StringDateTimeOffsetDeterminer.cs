using Cosmos.Conversions.Common;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Conversions.Determiners;

/// <summary>
/// Internal core conversion helper from string to DateTimeOffset
/// </summary>
public static partial class StringDateTimeOffsetDeterminer
{
    // ReSharper disable once InconsistentNaming
    internal static bool IS(string str) => Is(str);

    /// <summary>
    /// Is
    /// </summary>
    /// <param name="text"></param>
    /// <param name="style"></param>
    /// <param name="formatProvider"></param>
    /// <param name="matchedCallback"></param>
    /// <returns></returns>
    public static bool Is(
        string text,
        DateTimeStyles style = DateTimeStyles.None,
        IFormatProvider formatProvider = null,
        Action<DateTimeOffset> matchedCallback = null)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        return DateTimeOffset.TryParse(text, formatProvider.SafeDateTime(), style, out var dateTimeOffset)
                             .IfFalseThenInvoke(ValueDeterminer.IsXxxAgain<DateTimeOffset>, text)
                             .IfTrueThenInvoke(matchedCallback, dateTimeOffset);
    }

    /// <summary>
    /// Is
    /// </summary>
    /// <param name="text"></param>
    /// <param name="tries"></param>
    /// <param name="style"></param>
    /// <param name="formatProvider"></param>
    /// <param name="matchedCallback"></param>
    /// <returns></returns>
    public static bool Is(
        string text,
        IEnumerable<IConversionTry<string, DateTimeOffset>> tries,
        DateTimeStyles style = DateTimeStyles.None,
        IFormatProvider formatProvider = null,
        Action<DateTimeOffset> matchedCallback = null)
    {
        return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace,
            (s, act) => Is(s, style, formatProvider, act), tries, matchedCallback);
    }

    /// <summary>
    /// To
    /// </summary>
    /// <param name="text"></param>
    /// <param name="style"></param>
    /// <param name="formatProvider"></param>
    /// <param name="defaultVal"></param>
    /// <returns></returns>
    public static DateTimeOffset To(
        string text,
        DateTimeStyles style = DateTimeStyles.None,
        IFormatProvider formatProvider = null,
        DateTimeOffset defaultVal = default)
    {
        if (text is null)
            return defaultVal;

        return DateTimeOffset.TryParse(text, formatProvider.SafeDateTime(), style, out var offset)
            ? offset
            : defaultVal;
    }

    /// <summary>
    /// To
    /// </summary>
    /// <param name="text"></param>
    /// <param name="impls"></param>
    /// <param name="style"></param>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    public static DateTimeOffset To(
        string text,
        IEnumerable<IConversionImpl<string, DateTimeOffset>> impls,
        DateTimeStyles style = DateTimeStyles.None,
        IFormatProvider formatProvider = null)
    {
        return ValueConverter.ToXxx(text, (s, act) => Is(s, style, formatProvider.SafeDateTime(), act), impls);
    }
}