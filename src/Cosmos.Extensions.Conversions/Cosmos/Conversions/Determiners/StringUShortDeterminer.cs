using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.Conversions.Common;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to ushort
    /// </summary>
    public static class StringUShortDeterminer
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="shortAct"></param>
        /// <returns></returns>
        public static bool Is(string str, NumberStyles style = NumberStyles.Integer,
            IFormatProvider formatProvider = null, Action<ushort> shortAct = null)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            var result = ushort.TryParse(str, style, formatProvider.SafeNumber(), out var number);
            if (!result)
                result = ValueDeterminer.IsXxxAgain<ushort>(str);
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
        public static bool Is(
            string str,
            IEnumerable<IConversionTry<string, ushort>> tries,
            NumberStyles style = NumberStyles.Integer,
            IFormatProvider formatProvider = null,
            Action<ushort> shortAct = null)
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
        public static ushort To(string str, ushort defaultVal = default,
            NumberStyles style = NumberStyles.Integer, IFormatProvider formatProvider = null)
        {
            if (ushort.TryParse(str, style, formatProvider.SafeNumber(), out var number))
                return number;
            try
            {
                return Convert.ToUInt16(Convert.ToDecimal(str));
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
        public static ushort To(string str, IEnumerable<IConversionImpl<string, ushort>> impls,
            NumberStyles style = NumberStyles.Integer, IFormatProvider formatProvider = null) =>
            ValueConverter.ToXxx(str, (s, act) => Is(s, style, formatProvider.SafeNumber(), act), impls);
    }
}