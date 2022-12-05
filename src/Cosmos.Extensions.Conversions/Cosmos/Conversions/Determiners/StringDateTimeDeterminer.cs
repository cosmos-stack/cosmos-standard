using Cosmos.Conversions.Common;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Conversions.Determiners;

/// <summary>
/// Internal core conversion helper from string to DateTime
/// </summary>
public static partial class StringDateTimeDeterminer
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
        Action<DateTime> matchedCallback = null)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        return DateTime.TryParse(text, formatProvider.SafeDateTime(), style, out var dateTime)
                       .IfFalseThenInvoke(ValueDeterminer.IsXxxAgain<DateTime>, text)
                       .IfTrueThenInvoke(matchedCallback, dateTime);
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
        IEnumerable<IConversionTry<string, DateTime>> tries,
        DateTimeStyles style = DateTimeStyles.None,
        IFormatProvider formatProvider = null,
        Action<DateTime> matchedCallback = null)
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
    public static DateTime To(
        string text,
        DateTimeStyles style = DateTimeStyles.None,
        IFormatProvider formatProvider = null,
        DateTime defaultVal = default)
    {
        if (text is null)
            return defaultVal;

        return DateTime.TryParse(text, formatProvider?.SafeDateTime(), style, out var dateTime)
            ? dateTime
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
    public static DateTime To(
        string text,
        IEnumerable<IConversionImpl<string, DateTime>> impls,
        DateTimeStyles style = DateTimeStyles.None,
        IFormatProvider formatProvider = null)
    {
        return ValueConverter.ToXxx(text, (s, act) => Is(s, style, formatProvider?.SafeDateTime(), act), impls);
    }
}