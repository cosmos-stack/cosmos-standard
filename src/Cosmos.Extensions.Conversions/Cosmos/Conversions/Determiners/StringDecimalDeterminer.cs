using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.Conversions.Core;

namespace Cosmos.Conversions.Determiners {
    /// <summary>
    /// Internal core conversion helper from string to decimal
    /// </summary>
    internal static class StringDecimalDeterminer {
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
            var result = decimal.TryParse(str, style, formatProvider.SafeNumber(), out var number);
            if (!result)
                result = ValueDeterminer.IsXxxAgain<decimal>(str);
            if (result)
                decimalAct?.Invoke(number);
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
            return ValueDeterminer.IsXXX(str, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, style, formatProvider.SafeNumber(), act), tries, decimalAct);
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
            NumberStyles style = NumberStyles.Number, IFormatProvider formatProvider = null) {
            if (decimal.TryParse(str, style, formatProvider.SafeNumber(), out var number))
                return number;
            try {
                return Convert.ToDecimal(str);
            } catch {
                return ValueConverter.ToXxxAgain(str, defaultVal);
            }
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static decimal To(string str, IEnumerable<IConversionImpl<string, decimal>> impls,
            NumberStyles style = NumberStyles.Number, IFormatProvider formatProvider = null) {
            return ValueConverter.ToXxx(str, (s, act) => Is(s, style, formatProvider.SafeNumber(), act), impls);
        }
    }
}