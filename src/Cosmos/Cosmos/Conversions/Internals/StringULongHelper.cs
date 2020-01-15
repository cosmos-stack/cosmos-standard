using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cosmos.Conversions.Internals {
    /// <summary>
    /// Internal core conversion helper from string to ulong
    /// </summary>
    public static class StringULongHelper {
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
            Action<ulong> longAct = null) {

            if (string.IsNullOrWhiteSpace(str))
                return false;

            if (formatProvider is null)
                formatProvider = NumberFormatInfo.CurrentInfo;

            var result = ulong.TryParse(str, style, formatProvider, out var number);

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
            IEnumerable<IConversionTry<string, ulong>> tries,
            NumberStyles style = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint |
                                 NumberStyles.AllowThousands | NumberStyles.AllowExponent,
            IFormatProvider formatProvider = null,
            Action<ulong> longAct = null) {

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
        public static ulong To(string str, ulong defaultVal = default,
            NumberStyles style = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint |
                                 NumberStyles.AllowThousands | NumberStyles.AllowExponent,
            IFormatProvider formatProvider = null) {

            if (formatProvider is null)
                formatProvider = NumberFormatInfo.CurrentInfo;

            return ulong.TryParse(str, style, formatProvider, out var number) ? number : defaultVal;
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
            NumberStyles style = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint |
                                 NumberStyles.AllowThousands | NumberStyles.AllowExponent,
            IFormatProvider formatProvider = null) {

            if (formatProvider is null)
                formatProvider = NumberFormatInfo.CurrentInfo;

            return _Helper.ToXXX(str, (s, act) => Is(s, style, formatProvider, act), impls);
        }
    }
}