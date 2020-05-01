using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cosmos.Conversions.StringDeterminers {
    /// <summary>
    /// Internal core conversion helper from string to decimal
    /// </summary>
    public static class StringDecimalDeterminer {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="decimalAct"></param>
        /// <returns></returns>
        public static bool Is(
            string str,
            NumberStyles style = NumberStyles.Number,
            IFormatProvider formatProvider = null,
            Action<decimal> decimalAct = null) {

            if (string.IsNullOrWhiteSpace(str))
                return false;

            var result = decimal.TryParse(str, style, formatProvider.SafeN(), out var number);

            if (result) {
                decimalAct?.Invoke(number);
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
        /// <param name="decimalAct"></param>
        /// <returns></returns>
        public static bool Is(
            string str,
            IEnumerable<IConversionTry<string, decimal>> tries,
            NumberStyles style = NumberStyles.Number,
            IFormatProvider formatProvider = null,
            Action<decimal> decimalAct = null) {
            return _Helper.IsXXX(str, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, style, formatProvider.SafeN(), act), tries, decimalAct);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static decimal To(string str, decimal defaultVal = default,
            NumberStyles style = NumberStyles.Number, IFormatProvider formatProvider = null) =>
            decimal.TryParse(str, style, formatProvider.SafeN(), out var number) ? number : defaultVal;

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static decimal To(string str, IEnumerable<IConversionImpl<string, decimal>> impls,
            NumberStyles style = NumberStyles.Number, IFormatProvider formatProvider = null) =>
            _Helper.ToXXX(str, (s, act) => Is(s, style, formatProvider.SafeN(), act), impls);
    }
}