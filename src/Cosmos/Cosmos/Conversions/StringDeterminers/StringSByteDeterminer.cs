using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cosmos.Conversions.StringDeterminers {
    /// <summary>
    /// Internal core conversion helper from string to sbyte
    /// </summary>
    public static class StringSByteDeterminer {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="byteAct"></param>
        /// <returns></returns>
        public static bool Is(string str, NumberStyles style = NumberStyles.Integer,
            IFormatProvider formatProvider = null, Action<sbyte> byteAct = null) {

            if (string.IsNullOrWhiteSpace(str))
                return false;

            var result = sbyte.TryParse(str, style, formatProvider.SafeN(), out var number);

            if (result) {
                byteAct?.Invoke(number);
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
        /// <param name="byteAct"></param>
        /// <returns></returns>
        public static bool Is(string str, IEnumerable<IConversionTry<string, sbyte>> tries,
            NumberStyles style = NumberStyles.Integer, IFormatProvider formatProvider = null, Action<sbyte> byteAct = null) {
            return _Helper.IsXXX(str, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, style, formatProvider.SafeN(), act), tries, byteAct);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static sbyte To(string str, sbyte defaultVal = default,
            NumberStyles style = NumberStyles.Integer, IFormatProvider formatProvider = null) {
            if (!sbyte.TryParse(str, style, formatProvider.SafeN(), out var number))
                number = defaultVal;
            return number;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static sbyte To(string str, IEnumerable<IConversionImpl<string, sbyte>> impls,
            NumberStyles style = NumberStyles.Integer, IFormatProvider formatProvider = null) =>
            _Helper.ToXXX(str, (s, act) => Is(s, style, formatProvider.SafeN(), act), impls);
    }
}