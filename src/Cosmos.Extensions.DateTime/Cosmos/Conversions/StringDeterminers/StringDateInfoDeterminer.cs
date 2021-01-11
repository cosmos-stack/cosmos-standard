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
        /// <param name="str"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dtAct"></param>
        /// <returns></returns>
        public static bool Is(string str,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            Action<DateInfo> dtAct = null)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            var result = DateInfo.TryParse(str, formatProvider, style, out var dateInfo);

            if (result)
            {
                dtAct?.Invoke(dateInfo);
            }

            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tries"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dtAct"></param>
        /// <returns></returns>
        public static bool Is(string str,
            IEnumerable<IConversionTry<string, DateInfo>> tries,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            Action<DateInfo> dtAct = null)
        {
            return StringDeterminingHelper.IsXXX(str, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, style, formatProvider, act), tries, dtAct);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateInfo To(string str,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            DateInfo defaultVal = default)
        {
            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            return  DateInfo.TryParse(str, formatProvider, style, out var result) 
                ? result
                : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static DateInfo To(string str,
            IEnumerable<IConversionImpl<string, DateInfo>> impls,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null)
        {
            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            return StringDeterminingHelper.ToXXX(str, (s, act) => Is(s, style, formatProvider, act), impls);
        }
    }
}