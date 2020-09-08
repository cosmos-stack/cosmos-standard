using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.Conversions.Common;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to uint
    /// </summary>
    public static class StringUIntDeterminer
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="intAct"></param>
        /// <returns></returns>
        public static bool Is(string str, NumberStyles style = NumberStyles.Integer,
            IFormatProvider formatProvider = null, Action<uint> intAct = null)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            var result = uint.TryParse(str, style, formatProvider.SafeNumber(), out var number);
            if (!result)
                result = ValueDeterminer.IsXxxAgain<uint>(str);
            if (result)
                intAct?.Invoke(number);
            return result;
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tries"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="intAct"></param>
        /// <returns></returns>
        public static bool Is(string str, IEnumerable<IConversionTry<string, uint>> tries,
            NumberStyles style = NumberStyles.Integer, IFormatProvider formatProvider = null, Action<uint> intAct = null)
        {
            return ValueDeterminer.IsXXX(str, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, style, formatProvider.SafeNumber(), act), tries, intAct);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static uint To(string str, uint defaultVal = default,
            NumberStyles style = NumberStyles.Integer, IFormatProvider formatProvider = null)
        {
            if (uint.TryParse(str, style, formatProvider.SafeNumber(), out var number))
                return number;
            try
            {
                return Convert.ToUInt32(Convert.ToDecimal(str));
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
        public static uint To(string str, IEnumerable<IConversionImpl<string, uint>> impls,
            NumberStyles style = NumberStyles.Integer, IFormatProvider formatProvider = null) =>
            ValueConverter.ToXxx(str, (s, act) => Is(s, style, formatProvider.SafeNumber(), act), impls);
    }
}