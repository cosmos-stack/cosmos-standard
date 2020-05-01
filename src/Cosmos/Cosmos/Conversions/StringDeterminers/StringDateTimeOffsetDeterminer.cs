using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cosmos.Conversions.StringDeterminers {
    /// <summary>
    /// Internal core conversion helper from string to DateTimeOffset
    /// </summary>
    public static class StringDateTimeOffsetDeterminer {
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
            Action<DateTimeOffset> dtAct = null) {

            if (string.IsNullOrWhiteSpace(str))
                return false;

            var result = DateTimeOffset.TryParse(str, formatProvider.SafeD(), style, out var dateTimeOffset);

            if (result) {
                dtAct?.Invoke(dateTimeOffset);
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
            IEnumerable<IConversionTry<string, DateTimeOffset>> tries,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            Action<DateTimeOffset> dtAct = null) {
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
        public static DateTimeOffset To(string str,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null,
            DateTimeOffset defaultVal = default) =>
            DateTimeOffset.TryParse(str, formatProvider.SafeD(), style, out var offset) ? offset : defaultVal;

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static DateTimeOffset To(string str,
            IEnumerable<IConversionImpl<string, DateTimeOffset>> impls,
            DateTimeStyles style = DateTimeStyles.None,
            IFormatProvider formatProvider = null) =>
            _Helper.ToXXX(str, (s, act) => Is(s, style, formatProvider.SafeD(), act), impls);

        /// <summary>
        /// Exact DateTimeOffset Determiner
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
                Action<DateTimeOffset> dtAct = null) {

                if (string.IsNullOrWhiteSpace(str))
                    return false;

                var result = DateTimeOffset.TryParseExact(str, format, formatProvider.SafeD(), style, out var dateTimeOffset);

                if (result) {
                    dtAct?.Invoke(dateTimeOffset);
                }

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
                DateTimeOffset defaultVal = default) =>
                DateTimeOffset.TryParseExact(str, format, formatProvider.SafeD(), style, out var offset) ? offset : defaultVal;

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
                IFormatProvider formatProvider = null) =>
                _Helper.ToXXX(str, (s, act) => Is(s, format, style, formatProvider.SafeD(), act), impls);
        }
    }
}