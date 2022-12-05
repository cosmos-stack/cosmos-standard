using Cosmos.Conversions.Common;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Conversions.Determiners;

/// <summary>
/// Internal core conversion helper from string to DateTimeOffset
/// </summary>
public static partial class StringDateTimeOffsetDeterminer
{
    /// <summary>
    /// Exact DateTimeOffset Determiner
    /// </summary>
    public static class Exact
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="format"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            string format,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            Action<DateTimeOffset> matchedCallback = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            return DateTimeOffset.TryParseExact(text, format, formatProvider.SafeDateTime(), style, out var dateTimeOffset)
                                 .IfTrueThenInvoke(matchedCallback, dateTimeOffset);
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="format"></param>
        /// <param name="tries"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            string format,
            IEnumerable<IConversionTry<string, DateTimeOffset>> tries,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            Action<DateTimeOffset> matchedCallback = null)
        {
            return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, format, style, formatProvider, act), tries, matchedCallback);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="format"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeOffset To(
            string text,
            string format,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            DateTimeOffset defaultVal = default)
        {
            if (text is null)
                return defaultVal;

            return DateTimeOffset.TryParseExact(text, format, formatProvider.SafeDateTime(), style, out var offset)
                ? offset
                : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="format"></param>
        /// <param name="impls"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static DateTimeOffset To(
            string text,
            string format,
            IEnumerable<IConversionImpl<string, DateTimeOffset>> impls,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null)
        {
            return ValueConverter.ToXxx(text, (s, act) => Is(s, format, style, formatProvider.SafeDateTime(), act), impls);
        }
    }
}