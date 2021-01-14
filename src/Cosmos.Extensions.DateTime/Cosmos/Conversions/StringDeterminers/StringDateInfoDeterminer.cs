using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.Date;

namespace Cosmos.Conversions.StringDeterminers
{
    /// <summary>
    /// Internal core conversion helper from string to DateInfo
    /// </summary>
    public static class StringDateInfoDeterminer
    {
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
            Action<DateInfo> matchedCallback = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            return DateInfo.TryParse(text, formatProvider, style, out var dateInfo)
                           .IfTrueThenInvoke(matchedCallback, dateInfo);
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
            IEnumerable<IConversionTry<string, DateInfo>> tries,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            Action<DateInfo> matchedCallback = null)
        {
            return StringDeterminingHelper.IsXXX(text, string.IsNullOrWhiteSpace,
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
        public static DateInfo To(
            string text,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            DateInfo defaultVal = default)
        {
            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            return  DateInfo.TryParse(text, formatProvider, style, out var result) 
                ? result
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
        public static DateInfo To(
            string text,
            IEnumerable<IConversionImpl<string, DateInfo>> impls,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null)
        {
            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            return StringDeterminingHelper.ToXXX(text, (s, act) => Is(s, style, formatProvider, act), impls);
        }
    }
}