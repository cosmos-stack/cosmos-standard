using Cosmos.Conversions.Common;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Conversions.Determiners;

/// <summary>
/// Internal core conversion helper from string to TimeSpan
/// </summary>
public static partial class StringTimeSpanDeterminer
{
    /// <summary>
    /// Exact TimeSpan Determiner
    /// </summary>
    public static class Exact
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            string format,
            IFormatProvider formatProvider = null,
            Action<TimeSpan> matchedCallback = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            return TimeSpan.TryParseExact(text, format, formatProvider.SafeDateTime(), out var timeSpan)
                           .IfTrueThenInvoke(matchedCallback, timeSpan);
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="format"></param>
        /// <param name="tries"></param>
        /// <param name="formatProvider"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            string format,
            IEnumerable<IConversionTry<string, TimeSpan>> tries,
            IFormatProvider formatProvider = null,
            Action<TimeSpan> matchedCallback = null)
        {
            return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, format, formatProvider, act), tries, matchedCallback);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TimeSpan To(
            string text,
            string format,
            IFormatProvider formatProvider = null,
            TimeSpan defaultVal = default)
        {
            if (text is null)
                return defaultVal;

            return TimeSpan.TryParseExact(text, format, formatProvider.SafeDateTime(), out var timeSpan) ? timeSpan : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="format"></param>
        /// <param name="impls"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static TimeSpan To(
            string text,
            string format,
            IEnumerable<IConversionImpl<string, TimeSpan>> impls,
            IFormatProvider formatProvider = null)
        {
            return ValueConverter.ToXxx(text, (s, act) => Is(s, format, formatProvider.SafeDateTime(), act), impls);
        }
    }
}