using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cosmos.Conversions.StringDeterminers {
    /// <summary>
    /// Internal core conversion helper from string to DateTime
    /// </summary>
    public static class StringDateTimeDeterminer {
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
            Action<DateTime> dtAct = null) {

            if (string.IsNullOrWhiteSpace(str))
                return false;

            var result = DateTime.TryParse(str, formatProvider.SafeD(), style, out var dateTime);

            if (result) {
                dtAct?.Invoke(dateTime);
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
            IEnumerable<IConversionTry<string, DateTime>> tries,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            Action<DateTime> dtAct = null) {
            return _Helper.IsXXX(str, string.IsNullOrWhiteSpace,
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
        public static DateTime To(string str,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            DateTime defaultVal = default) =>
            DateTime.TryParse(str, formatProvider.SafeD(), style, out var dateTime)
                ? dateTime
                : defaultVal;

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static DateTime To(string str,
            IEnumerable<IConversionImpl<string, DateTime>> impls,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null) =>
            _Helper.ToXXX(str, (s, act) => Is(s, style, formatProvider.SafeD(), act), impls);

        /// <summary>
        /// Exact DateTime Determiner
        /// </summary>
        public static class Exact {
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
                Action<DateTime> dtAct = null) {

                if (string.IsNullOrWhiteSpace(str))
                    return false;

                var result = DateTime.TryParseExact(str, format, formatProvider.SafeD(), style, out var dateTime);

                if (result)
                    dtAct?.Invoke(dateTime);

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
                IEnumerable<IConversionTry<string, DateTime>> tries,
                DateTimeStyles style = DateTimeStyles.None,
                IFormatProvider formatProvider = null,
                Action<DateTime> dtAct = null) {
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
            public static DateTime To(string str,
                string format,
                DateTimeStyles style = DateTimeStyles.None,
                IFormatProvider formatProvider = null,
                DateTime defaultVal = default) =>
                DateTime.TryParseExact(str, format, formatProvider.SafeD(), style, out var dateTime) ? dateTime : defaultVal;

            /// <summary>
            /// To
            /// </summary>
            /// <param name="str"></param>
            /// <param name="format"></param>
            /// <param name="impls"></param>
            /// <param name="style"></param>
            /// <param name="formatProvider"></param>
            /// <returns></returns>
            public static DateTime To(string str,
                string format,
                IEnumerable<IConversionImpl<string, DateTime>> impls,
                DateTimeStyles style = DateTimeStyles.None,
                IFormatProvider formatProvider = null) =>
                _Helper.ToXXX(str, (s, act) => Is(s, format, style, formatProvider.SafeD(), act), impls);
        }

       
    }
}