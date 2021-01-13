using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.Date;

namespace Cosmos.Conversions.StringDeterminers
{
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

            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            var result = DateTimeSpan.TryParse(text, formatProvider, out var dateTimeSpan);

            if (result)
            {
                matchedCallback?.Invoke(dateTimeSpan);
            }

            return result;
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
            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

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
            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            return StringDeterminingHelper.ToXXX(text, (s, act) => Is(s, formatProvider, act), impls);
        }
    }
}