using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cosmos.Conversions.Internals {
    /// <summary>
    /// Internal core conversion helper from string to short
    /// </summary>
    public static class StringShortHelper {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="shortAct"></param>
        /// <returns></returns>
        public static bool Is(
            string str,
            NumberStyles style = NumberStyles.Integer,
            IFormatProvider formatProvider = null,
            Action<short> shortAct = null) {

            if (string.IsNullOrWhiteSpace(str))
                return false;

            if (formatProvider is null)
                formatProvider = NumberFormatInfo.CurrentInfo;

            var result = short.TryParse(str, style, formatProvider, out var number);

            if (result)
                shortAct?.Invoke(number);

            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tries"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="shortAct"></param>
        /// <returns></returns>
        public static bool Is(
            string str,
            IEnumerable<IConversionTry<string, short>> tries,
            NumberStyles style = NumberStyles.Integer,
            IFormatProvider formatProvider = null,
            Action<short> shortAct = null) {

            if (formatProvider is null)
                formatProvider = NumberFormatInfo.CurrentInfo;

            return _Helper.IsXXX(str, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, style, formatProvider, act), tries, shortAct);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static short To(string str, short defaultVal = default,
            NumberStyles style = NumberStyles.Integer, IFormatProvider formatProvider = null) {

            if (formatProvider is null)
                formatProvider = NumberFormatInfo.CurrentInfo;

            return short.TryParse(str, style, formatProvider, out var number) ? number : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static short To(string str, IEnumerable<IConversionImpl<string, short>> impls,
            NumberStyles style = NumberStyles.Integer, IFormatProvider formatProvider = null) {

            if (formatProvider is null)
                formatProvider = NumberFormatInfo.CurrentInfo;

            return _Helper.ToXXX(str, (s, act) => Is(s, style, formatProvider, act), impls);
        }
    }
}