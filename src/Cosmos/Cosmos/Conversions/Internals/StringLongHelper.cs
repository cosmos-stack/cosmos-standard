using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cosmos.Conversions.Internals {
    /// <summary>
    /// Internal core conversion helper from string to long
    /// </summary>
    public static class StringLongHelper {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="longAct"></param>
        /// <returns></returns>
        public static bool Is(
            string str,
            NumberStyles style = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint |
                                 NumberStyles.AllowThousands | NumberStyles.AllowExponent,
            IFormatProvider formatProvider = null,
            Action<long> longAct = null) {

            if (string.IsNullOrWhiteSpace(str))
                return false;

            if (formatProvider is null)
                formatProvider = NumberFormatInfo.CurrentInfo;

            var result = long.TryParse(str, style, formatProvider, out var number);

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
        public static bool Is(
            string str,
            IEnumerable<IConversionTry<string, long>> tries,
            NumberStyles style = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint |
                                 NumberStyles.AllowThousands | NumberStyles.AllowExponent,
            IFormatProvider formatProvider = null,
            Action<long> longAct = null) {

            if (formatProvider is null)
                formatProvider = NumberFormatInfo.CurrentInfo;

            return _Helper.IsXXX(str, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, style, formatProvider, act), tries, longAct);
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
            NumberStyles style = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint |
                                 NumberStyles.AllowThousands | NumberStyles.AllowExponent,
            IFormatProvider formatProvider = null) {

            if (formatProvider is null)
                formatProvider = NumberFormatInfo.CurrentInfo;

            return long.TryParse(str, style, formatProvider, out var number) ? number : defaultVal;
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
            NumberStyles style = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint |
                                 NumberStyles.AllowThousands | NumberStyles.AllowExponent,
            IFormatProvider formatProvider = null) {

            if (formatProvider is null)
                formatProvider = NumberFormatInfo.CurrentInfo;

            return _Helper.ToXXX(str, (s, act) => Is(s, style, formatProvider, act), impls);
        }
    }
}