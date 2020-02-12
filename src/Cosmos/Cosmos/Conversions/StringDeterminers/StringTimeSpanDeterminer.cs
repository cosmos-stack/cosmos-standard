using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cosmos.Conversions.StringDeterminers {
    /// <summary>
    /// Internal core conversion helper from string to TimeSpan
    /// </summary>
    public static class StringTimeSpanDeterminer {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="formatProvider"></param>
        /// <param name="tsAct"></param>
        /// <returns></returns>
        public static bool Is(string str, IFormatProvider formatProvider = null, Action<TimeSpan> tsAct = null) {

            if (string.IsNullOrWhiteSpace(str))
                return false;

            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            var result = TimeSpan.TryParse(str, formatProvider, out var timeSpan);

            if (result)
                tsAct?.Invoke(timeSpan);

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
            IEnumerable<IConversionTry<string, TimeSpan>> tries,
            IFormatProvider formatProvider = null,
            Action<TimeSpan> dtAct = null) {
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
        public static TimeSpan To(string str, IFormatProvider formatProvider = null, TimeSpan defaultVal = default) {

            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            return TimeSpan.TryParse(str, formatProvider, out var timeSpan) ? timeSpan : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static TimeSpan To(string str, IEnumerable<IConversionImpl<string, TimeSpan>> impls, IFormatProvider formatProvider = null) {

            if (formatProvider is null)
                formatProvider = DateTimeFormatInfo.CurrentInfo;

            return _Helper.ToXXX(str, (s, act) => Is(s, formatProvider, act), impls);
        }

        /// <summary>
        /// Exact TimeSpan Determiner
        /// </summary>
        public static class Exact {
            /// <summary>
            /// Is
            /// </summary>
            /// <param name="str"></param>
            /// <param name="format"></param>
            /// <param name="formatProvider"></param>
            /// <param name="tsAct"></param>
            /// <returns></returns>
            public static bool Is(string str, string format, IFormatProvider formatProvider = null, Action<TimeSpan> tsAct = null) {

                if (string.IsNullOrWhiteSpace(str))
                    return false;

                if (formatProvider is null)
                    formatProvider = DateTimeFormatInfo.CurrentInfo;

                var result = TimeSpan.TryParseExact(str, format, formatProvider, out var timeSpan);

                if (result)
                    tsAct?.Invoke(timeSpan);

                return result;
            }

            /// <summary>
            /// Is
            /// </summary>
            /// <param name="str"></param>
            /// <param name="format"></param>
            /// <param name="tries"></param>
            /// <param name="formatProvider"></param>
            /// <param name="dtAct"></param>
            /// <returns></returns>
            public static bool Is(string str,
                string format,
                IEnumerable<IConversionTry<string, TimeSpan>> tries,
                IFormatProvider formatProvider = null,
                Action<TimeSpan> dtAct = null) {
                return _Helper.IsXXX(str, string.IsNullOrWhiteSpace,
                    (s, act) => Is(s, format, formatProvider, act), tries, dtAct);
            }

            /// <summary>
            /// To
            /// </summary>
            /// <param name="str"></param>
            /// <param name="format"></param>
            /// <param name="formatProvider"></param>
            /// <param name="defaultVal"></param>
            /// <returns></returns>
            public static TimeSpan To(string str, string format, IFormatProvider formatProvider = null, TimeSpan defaultVal = default) {

                if (formatProvider is null)
                    formatProvider = DateTimeFormatInfo.CurrentInfo;

                return TimeSpan.TryParseExact(str, format, formatProvider, out var timeSpan) ? timeSpan : defaultVal;
            }

            /// <summary>
            /// To
            /// </summary>
            /// <param name="str"></param>
            /// <param name="format"></param>
            /// <param name="impls"></param>
            /// <param name="formatProvider"></param>
            /// <returns></returns>
            public static TimeSpan To(string str, string format, IEnumerable<IConversionImpl<string, TimeSpan>> impls, IFormatProvider formatProvider = null) {

                if (formatProvider is null)
                    formatProvider = DateTimeFormatInfo.CurrentInfo;

                return _Helper.ToXXX(str, (s, act) => Is(s, format, formatProvider, act), impls);
            }
        }
    }
}