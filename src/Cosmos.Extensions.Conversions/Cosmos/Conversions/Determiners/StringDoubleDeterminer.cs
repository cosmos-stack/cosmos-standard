using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.Conversions.Core;

namespace Cosmos.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to double
    /// </summary>
    internal static class StringDoubleDeterminer
    {
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
        /// <param name="doubleAct"></param>
        /// <returns></returns>
        public static bool Is(
            string str,
            NumberStyles style = NUMBER_STYLES,
            IFormatProvider formatProvider = null,
            Action<double> doubleAct = null)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            var result = double.TryParse(str, style, formatProvider.SafeNumber(), out var number);
            if (!result)
                result = ValueDeterminer.IsXxxAgain<double>(str);
            if (result)
                doubleAct?.Invoke(number);
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
            NumberStyles style = NUMBER_STYLES, IFormatProvider formatProvider = null, Action<double> doubleAct = null)
        {
            return ValueDeterminer.IsXXX(str, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, style, formatProvider.SafeNumber(), act), tries, doubleAct);
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
            NumberStyles style = NUMBER_STYLES, IFormatProvider formatProvider = null)
        {
            if (double.TryParse(str, style, formatProvider.SafeNumber(), out var number))
                return number;
            try
            {
                return Convert.ToDouble(Convert.ToDecimal(str));
            }
            catch
            {
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
        public static double To(string str, IEnumerable<IConversionImpl<string, double>> impls,
            NumberStyles style = NUMBER_STYLES, IFormatProvider formatProvider = null)
        {
            return ValueConverter.ToXxx(str, (s, act) => Is(s, style, formatProvider.SafeNumber(), act), impls);
        }
    }
}