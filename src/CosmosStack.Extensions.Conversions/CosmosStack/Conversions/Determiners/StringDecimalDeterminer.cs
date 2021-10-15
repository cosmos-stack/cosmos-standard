using System;
using System.Collections.Generic;
using System.Globalization;
using CosmosStack.Conversions.Common;
using CosmosStack.Conversions.Common.Core;
using CosmosStack.Exceptions;

namespace CosmosStack.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to decimal
    /// </summary>
    public static class StringDecimalDeterminer
    {
        // ReSharper disable once InconsistentNaming
        internal static bool IS(string str) => Is(str);

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            NumberStyles style = NumberStyles.Number,
            IFormatProvider formatProvider = null,
            Action<decimal> matchedCallback = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            return decimal.TryParse(text, style, formatProvider.SafeNumber(), out var number)
                          .IfFalseThenInvoke(ValueDeterminer.IsXxxAgain<decimal>, text)
                          .IfTrueThenInvoke(matchedCallback, number);
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tries"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            IEnumerable<IConversionTry<string, decimal>> tries,
            NumberStyles style = NumberStyles.Number,
            IFormatProvider formatProvider = null,
            Action<decimal> matchedCallback = null)
        {
            return ValueDeterminer.IsXXX(text, string.IsNullOrWhiteSpace,
                (s, act) => Is(s, style, formatProvider.SafeNumber(), act), tries, matchedCallback);
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static decimal To(
            string text,
            decimal defaultVal = default,
            NumberStyles style = NumberStyles.Number, 
            IFormatProvider formatProvider = null)
        {
            if (text is null)
                return defaultVal;

            if (decimal.TryParse(text, style, formatProvider.SafeNumber(), out var number))
                return number;

            return Try.Create(() => Convert.ToDecimal(text))
                      .Recover(_ => ValueConverter.ToXxxAgain(text, defaultVal))
                      .Value;
        }

        /// <summary>
        /// To
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static decimal To(
            string text,
            IEnumerable<IConversionImpl<string, decimal>> impls,
            NumberStyles style = NumberStyles.Number, 
            IFormatProvider formatProvider = null)
        {
            return ValueConverter.ToXxx(text, (s, act) => Is(s, style, formatProvider.SafeNumber(), act), impls);
        }
    }
}