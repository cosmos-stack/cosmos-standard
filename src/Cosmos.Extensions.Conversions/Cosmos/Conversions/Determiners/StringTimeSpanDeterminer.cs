using Cosmos.Conversions.Common;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Conversions.Determiners;

/// <summary>
/// Internal core conversion helper from string to TimeSpan
/// </summary>
public static partial class StringTimeSpanDeterminer
{
    // ReSharper disable once InconsistentNaming
    internal static bool IS(string str) => Is(str);

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
        Action<TimeSpan> matchedCallback = null)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        return TimeSpan.TryParse(text, formatProvider.SafeDateTime(), out var timeSpan)
                       .IfTrueThenInvoke(matchedCallback, timeSpan);
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
        IEnumerable<IConversionTry<string, TimeSpan>> tries,
        IFormatProvider formatProvider = null,
        Action<TimeSpan> matchedCallback = null)
    {
        return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace,
            (s, act) => Is(s, formatProvider, act), tries, matchedCallback);
    }

    /// <summary>
    /// To
    /// </summary>
    /// <param name="text"></param>
    /// <param name="formatProvider"></param>
    /// <param name="defaultVal"></param>
    /// <returns></returns>
    public static TimeSpan To(
        string text,
        IFormatProvider formatProvider = null,
        TimeSpan defaultVal = default)
    {
        if (text is null)
            return defaultVal;

        return TimeSpan.TryParse(text, formatProvider.SafeDateTime(), out var timeSpan) ? timeSpan : defaultVal;
    }

    /// <summary>
    /// To
    /// </summary>
    /// <param name="text"></param>
    /// <param name="impls"></param>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    public static TimeSpan To(
        string text,
        IEnumerable<IConversionImpl<string, TimeSpan>> impls,
        IFormatProvider formatProvider = null)
    {
        return ValueConverter.ToXxx(text, (s, act) => Is(s, formatProvider.SafeDateTime(), act), impls);
    }
}