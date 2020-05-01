using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cosmos.Conversions.StringDeterminers {
    /// <summary>
    /// Internal core conversion helper from string to double
    /// </summary>
    public static class StringDoubleDeterminer {
        private const NumberStyles NUMBER_STYLES = NumberStyles.AllowLeadingWhite
                                                 | NumberStyles.AllowTrailingWhite
                                                 | NumberStyles.AllowLeadingSign
                                                 | NumberStyles.AllowDecimalPoint
                                                 | NumberStyles.AllowThousands
                                                 | NumberStyles.AllowExponent;

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="doubleAct"></param>
        /// <returns></returns>
        public static bool Is(
            string str,
            NumberStyles style = NUMBER_STYLES,
            IFormatProvider formatProvider = null,
            Action<double> doubleAct = null) {

            if (string.IsNullOrWhiteSpace(str))
                return false;

            var result = double.TryParse(str, style, formatProvider.SafeN(), out var number);

            if (result) {
                doubleAct?.Invoke(number);
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
        /// <param name="doubleAct"></param>
        /// <returns></returns>
        public static bool Is(string str, IEnumerable<IConversionTry<string, double>> tries,
            NumberStyles style = NUMBER_STYLES, IFormatProvider formatProvider = null, Action<double> doubleAct = null) {
            return _Helper.IsXXX(str, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, style, formatProvider.SafeN(), act), tries, doubleAct);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static double To(string str, double defaultVal = default,
            NumberStyles style = NUMBER_STYLES, IFormatProvider formatProvider = null) =>
            double.TryParse(str, style, formatProvider.SafeN(), out var number) ? number : defaultVal;

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static double To(string str, IEnumerable<IConversionImpl<string, double>> impls,
            NumberStyles style = NUMBER_STYLES, IFormatProvider formatProvider = null) =>
            _Helper.ToXXX(str, (s, act) => Is(s, style, formatProvider.SafeN(), act), impls);
    }
}