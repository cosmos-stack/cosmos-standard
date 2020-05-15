using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.Conversions.Core;

namespace Cosmos.Conversions.Determiners {
    /// <summary>
    /// Internal core conversion helper from string to long
    /// </summary>
    internal static class StringLongDeterminer {
        // ReSharper disable once InconsistentNaming
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
        /// <param name="longAct"></param>
        /// <returns></returns>
        public static bool Is(string str, NumberStyles style = NUMBER_STYLES,
            IFormatProvider formatProvider = null, Action<long> longAct = null) {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            var result = long.TryParse(str, style, formatProvider.SafeNumber(), out var number);
            if (!result) 
                result = ValueDeterminer.IsXxxAgain<long>(str);
            if (result) 
                longAct?.Invoke(number);
            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tries"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="longAct"></param>
        /// <returns></returns>
        public static bool Is(string str, IEnumerable<IConversionTry<string, long>> tries,
            NumberStyles style = NUMBER_STYLES, IFormatProvider formatProvider = null, Action<long> longAct = null) {
            return ValueDeterminer.IsXXX(str, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, style, formatProvider.SafeNumber(), act), tries, longAct);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static long To(string str, long defaultVal = default,
            NumberStyles style = NUMBER_STYLES, IFormatProvider formatProvider = null) {
            if (long.TryParse(str, style, formatProvider.SafeNumber(), out var number))
                return number;
            try {
                return Convert.ToInt64(Convert.ToDecimal(str));
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
        public static long To(string str, IEnumerable<IConversionImpl<string, long>> impls,
            NumberStyles style = NUMBER_STYLES, IFormatProvider formatProvider = null) =>
            ValueConverter.ToXxx(str, (s, act) => Is(s, style, formatProvider.SafeNumber(), act), impls);
    }
}