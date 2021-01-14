using System;
using System.Collections.Generic;
using System.Globalization;
using Cosmos.Conversions.Common;
using Cosmos.Conversions.Common.Core;
using Cosmos.Exceptions;

namespace Cosmos.Conversions.Determiners
{
    /// <summary>
    /// Internal core conversion helper from string to float
    /// </summary>
    public static class StringFloatDeterminer
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
        /// <param name="text"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="matchedCallback"></param>
        /// <returns></returns>
        public static bool Is(
            string text,
            NumberStyles style = NUMBER_STYLES,
            IFormatProvider formatProvider = null,
             Action<float> matchedCallback = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            return float.TryParse(text, style, formatProvider.SafeNumber(), out var number)
                        .IfFalseThenInvoke(ValueDeterminer.IsXxxAgain<float>, text)
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
            IEnumerable<IConversionTry<string, float>> tries,
            NumberStyles style = NUMBER_STYLES, 
            IFormatProvider formatProvider = null, 
            Action<float> matchedCallback = null)
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
        public static float To(
            string text,
            float defaultVal = default,
            NumberStyles style = NUMBER_STYLES,
            IFormatProvider formatProvider = null)
        {
            if (text is null)
                return defaultVal;

            if (float.TryParse(text, style, formatProvider.SafeNumber(), out var number))
                return number;

            return Try.Create(() => Convert.ToSingle(Convert.ToDecimal(text)))
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
        public static float To(
            string text, 
            IEnumerable<IConversionImpl<string, float>> impls,
            NumberStyles style = NUMBER_STYLES, 
            IFormatProvider formatProvider = null)
        {
            return ValueConverter.ToXxx(text, (s, act) => Is(s, style, formatProvider.SafeNumber(), act), impls);
        }
    }
}