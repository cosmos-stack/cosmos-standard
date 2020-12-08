using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.Conversions.Common;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to short
    /// </summary>
    public static class StringShortDeterminer
    {
        // ReSharper disable once InconsistentNaming
        internal static bool IS(string str) => Is(str);
        
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="shortAct"></param>
        /// <returns></returns>
        public static bool Is(string str, NumberStyles style = NumberStyles.Integer,
            IFormatProvider formatProvider = null, Action<short> shortAct = null)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            var result = short.TryParse(str, style, formatProvider.SafeNumber(), out var number);
            if (!result)
                result = ValueDeterminer.IsXxxAgain<short>(str);
            if (result)
                shortAct?.Invoke(number);
            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tries"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="shortAct"></param>
        /// <returns></returns>
        public static bool Is(string str, IEnumerable<IConversionTry<string, short>> tries,
            NumberStyles style = NumberStyles.Integer, IFormatProvider formatProvider = null, Action<short> shortAct = null)
        {
            return ValueDeterminer.IsXXX(str, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, style, formatProvider.SafeNumber(), act), tries, shortAct);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static short To(string str, short defaultVal = default,
            NumberStyles style = NumberStyles.Integer, IFormatProvider formatProvider = null)
        {
            if (short.TryParse(str, style, formatProvider.SafeNumber(), out var number))
                return number;
            try
            {
                return Convert.ToInt16(Convert.ToDecimal(str));
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
        public static short To(string str, IEnumerable<IConversionImpl<string, short>> impls,
            NumberStyles style = NumberStyles.Integer, IFormatProvider formatProvider = null) =>
            ValueConverter.ToXxx(str, (s, act) => Is(s, style, formatProvider.SafeNumber(), act), impls);
    }
}