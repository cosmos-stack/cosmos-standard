using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cosmos.Conversions.Internals {
    /// <summary>
    /// Internal core conversion helper from string to DateTime Extra
    /// </summary>
    public static class StringDateTimeOffsetExactHelper {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dtAct"></param>
        /// <returns></returns>
        public static bool Is(string str,
            string format,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            Action<DateTimeOffset> dtAct = null) {

            if (string.IsNullOrWhiteSpace(str))
                return false;

            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            var result = DateTimeOffset.TryParseExact(str, format, formatProvider, style, out var dateTimeOffset);

            if (result)
                dtAct?.Invoke(dateTimeOffset);

            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <param name="tries"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="dtAct"></param>
        /// <returns></returns>
        public static bool Is(string str,
            string format,
            IEnumerable<IConversionTry<string, DateTimeOffset>> tries,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            Action<DateTimeOffset> dtAct = null) {
            return _Helper.IsXXX(str, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, format, style, formatProvider, act), tries, dtAct);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeOffset To(string str,
            string format,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            DateTimeOffset defaultVal = default) {

            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            return DateTimeOffset.TryParseExact(str, format, formatProvider, style, out var offset) ? offset : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <param name="impls"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static DateTimeOffset To(string str,
            string format,
            IEnumerable<IConversionImpl<string, DateTimeOffset>> impls,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null) {

            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            return _Helper.ToXXX(str, (s, act) => Is(s, format, style, formatProvider, act), impls);
        }
    }
}