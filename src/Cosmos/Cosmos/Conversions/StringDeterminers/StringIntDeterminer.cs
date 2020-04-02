using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cosmos.Conversions.StringDeterminers {
    /// <summary>
    /// Internal core conversion helper from string to int32
    /// </summary>
    public static class StringIntDeterminer {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="intAct"></param>
        /// <returns></returns>
        public static bool Is(
            string str,
            NumberStyles style = NumberStyles.Integer,
            IFormatProvider formatProvider = null,
            Action<int> intAct = null) {

            if (string.IsNullOrWhiteSpace(str))
                return false;

            if (formatProvider is null)
                formatProvider = NumberFormatInfo.CurrentInfo;

            var result = int.TryParse(str, style, formatProvider, out var number);

            if (result)
                intAct?.Invoke(number);

            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tries"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="intAct"></param>
        /// <returns></returns>
        public static bool Is(
            string str,
            IEnumerable<IConversionTry<string, int>> tries,
            NumberStyles style = NumberStyles.Integer,
            IFormatProvider formatProvider = null,
            Action<int> intAct = null) {

            if (formatProvider is null)
                formatProvider = NumberFormatInfo.CurrentInfo;

            return _Helper.IsXXX(str, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, style, formatProvider, act), tries, intAct);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static int To(string str, int defaultVal = default,
            NumberStyles style = NumberStyles.Integer, IFormatProvider formatProvider = null) {

            if (formatProvider is null)
                formatProvider = NumberFormatInfo.CurrentInfo;

            return int.TryParse(str, style, formatProvider, out var number) ? number : defaultVal;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static int To(string str, IEnumerable<IConversionImpl<string, int>> impls,
            NumberStyles style = NumberStyles.Integer, IFormatProvider formatProvider = null) {

            if (formatProvider is null)
                formatProvider = NumberFormatInfo.CurrentInfo;

            return _Helper.ToXXX(str, (s, act) => Is(s, style, formatProvider, act), impls);
        }
    }
}