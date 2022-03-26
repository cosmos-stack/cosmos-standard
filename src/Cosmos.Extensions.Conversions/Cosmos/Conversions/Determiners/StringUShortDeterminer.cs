using Cosmos.Conversions.Common;
using Cosmos.Conversions.Common.Core;
using Cosmos.Exceptions;

namespace Cosmos.Conversions.Determiners;

/// <summary>
/// Internal core conversion helper from string to ushort
/// </summary>
public static class StringUShortDeterminer
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
        NumberStyles style = NumberStyles.Integer,
        IFormatProvider formatProvider = null,
        Action<ushort> matchedCallback = null)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        return ushort.TryParse(text, style, formatProvider.SafeNumber(), out var number)
                     .IfFalseThenInvoke(ValueDeterminer.IsXxxAgain<ushort>, text)
                     .IfTrueThenInvoke(matchedCallback, number);
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
        IEnumerable<IConversionTry<string, ushort>> tries,
        NumberStyles style = NumberStyles.Integer,
        IFormatProvider formatProvider = null,
        Action<ushort> matchedCallback = null)
    {
        return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace,
            (s, act) => Is(s, style, formatProvider.SafeNumber(), act), tries, matchedCallback);
    }

    /// <summary>
    /// To
    /// </summary>
    /// <param name="text"></param>
    /// <param name="defaultVal"></param>
    /// <param name="style"></param>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    public static ushort To(
        string text,
        ushort defaultVal = default,
        NumberStyles style = NumberStyles.Integer,
        IFormatProvider formatProvider = null)
    {
        if (text is null)
            return defaultVal;

        if (ushort.TryParse(text, style, formatProvider.SafeNumber(), out var number))
            return number;

        return Try.Create(() => Convert.ToUInt16(Convert.ToDecimal(text)))
                  .Recover(_ => ValueConverter.ToXxxAgain(text, defaultVal))
                  .Value;
    }

    /// <summary>
    /// To
    /// </summary>
    /// <param name="text"></param>
    /// <param name="impls"></param>
    /// <param name="style"></param>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    public static ushort To(
        string text,
        IEnumerable<IConversionImpl<string, ushort>> impls,
        NumberStyles style = NumberStyles.Integer,
        IFormatProvider formatProvider = null)
    {
        return ValueConverter.ToXxx(text, (s, act) => Is(s, style, formatProvider.SafeNumber(), act), impls);
    }
}