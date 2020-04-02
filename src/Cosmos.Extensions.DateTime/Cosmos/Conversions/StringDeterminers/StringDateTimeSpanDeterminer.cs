using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.Date;

namespace Cosmos.Conversions.StringDeterminers {
    /// <summary>
    /// Internal core conversion helper from string to DateTimeSpan
    /// </summary>
    public static class StringDateTimeSpanDeterminer {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="formatProvider"></param>
        /// <param name="tsAct"></param>
        /// <returns></returns>
        public static bool Is(string str, IFormatProvider formatProvider = null, Action<DateTimeSpan> tsAct = null) {

            if (string.IsNullOrWhiteSpace(str))
                return false;

            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            var result = TimeSpan.TryParse(str, formatProvider, out var timeSpan);

            if (result) {
                var dateTimeSpan = new DateTimeSpan {TimeSpan = timeSpan};
                tsAct?.Invoke(dateTimeSpan);
            }

            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tries"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dtAct"></param>
        /// <returns></returns>
        public static bool Is(string str,
            IEnumerable<IConversionTry<string, DateTimeSpan>> tries,
            IFormatProvider formatProvider = null,
            Action<DateTimeSpan> dtAct = null) {
            return _Helper.IsXXX(str, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, formatProvider, act), tries, dtAct);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="formatProvider"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeSpan To(string str, IFormatProvider formatProvider = null, DateTimeSpan defaultVal = default) {

            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            return TimeSpan.TryParse(str, formatProvider, out var timeSpan)
                ? new DateTimeSpan {TimeSpan = timeSpan}
                : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static DateTimeSpan To(string str, IEnumerable<IConversionImpl<string, DateTimeSpan>> impls, IFormatProvider formatProvider = null) {

            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            return _Helper.ToXXX(str, (s, act) => Is(s, formatProvider, act), impls);
        }
    }
}