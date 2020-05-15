using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.Conversions.Core;

namespace Cosmos.Conversions.Determiners {
    /// <summary>
    /// Internal core conversion helper from string to ulong
    /// </summary>
    internal static class StringULongDeterminer {
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
            IFormatProvider formatProvider = null, Action<ulong> longAct = null) {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            var result = ulong.TryParse(str, style, formatProvider.SafeNumber(), out var number);
            if (!result) 
                result = ValueDeterminer.IsXxxAgain<ulong>(str);
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
        public static bool Is(string str, IEnumerable<IConversionTry<string, ulong>> tries,
            NumberStyles style = NUMBER_STYLES, IFormatProvider formatProvider = null, Action<ulong> longAct = null) {
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
        public static ulong To(string str, ulong defaultVal = default,
            NumberStyles style = NUMBER_STYLES, IFormatProvider formatProvider = null) {
            if (ulong.TryParse(str, style, formatProvider.SafeNumber(), out var number))
                return number;
            try {
                return Convert.ToUInt64(Convert.ToDecimal(str));
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
        public static ulong To(string str, IEnumerable<IConversionImpl<string, ulong>> impls,
            NumberStyles style = NUMBER_STYLES, IFormatProvider formatProvider = null) =>
            ValueConverter.ToXxx(str, (s, act) => Is(s, style, formatProvider.SafeNumber(), act), impls);
    }
}