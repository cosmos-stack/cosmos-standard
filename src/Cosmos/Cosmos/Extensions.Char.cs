using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// Char extensions
    /// </summary>
    public static class CharExtensions
    {
        #region Numeric

        /// <summary>
        /// Get numeric value
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double GetNumericValue(this char c) => char.GetNumericValue(c);

        #endregion

        #region Repeat

        /// <summary>
        /// Repeat
        /// </summary>
        /// <param name="this"></param>
        /// <param name="repeatCount"></param>
        /// <returns></returns>
        public static string Repeat(this char @this, int repeatCount) => new string(@this, repeatCount);

        #endregion

        #region Between

        /// <summary>
        /// Is special char between min and max
        /// </summary>
        /// <param name="char"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsBetween(this char @char, char min, char max)
        {
            var (xiao, da) = Fix(min, max);
            return @char >= xiao && @char <= da;
        }

        private static (char min, char max) Fix(char min, char max) => min >= max ? (max, min) : (min, max);

        #endregion

        #region In

        /// <summary>
        /// In
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool In(this char @this, params char[] values) => Array.IndexOf(values, @this) != -1;

        /// <summary>
        /// Not In
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool NotIn(this char @this, params char[] values) => Array.IndexOf(values, @this) == -1;

        #endregion

        #region Is

        /// <summary>
        /// Is WhiteSpace
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsWhiteSpace(this char c) => char.IsWhiteSpace(c);

        /// <summary>
        /// Is Control
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsControl(this char c) => char.IsControl(c);

        /// <summary>
        /// Is Digit
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsDigit(this char c) => char.IsDigit(c);

        /// <summary>
        /// Is Letter
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsLetter(this char c) => char.IsLetter(c);

        /// <summary>
        /// Is Letter or Digit
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsLetterOrDigit(this char c) => char.IsLetterOrDigit(c);

        /// <summary>
        /// Is Lower
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsLower(this char c) => char.IsLower(c);

        /// <summary>
        /// Is Number
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsNumber(this char c) => char.IsNumber(c);

        /// <summary>
        /// Is Punctuation
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsPunctuation(this char c) => char.IsPunctuation(c);

        /// <summary>
        /// Is Separator
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsSeparator(this char c) => char.IsSeparator(c);

        /// <summary>
        /// Is Symbol
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsSymbol(this char c) => char.IsSymbol(c);

        #endregion

        #region Is Surrogate

        /// <summary>
        /// Is Surrogate
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsSurrogate(this char c) => char.IsSurrogate(c);

        /// <summary>
        /// Is Surrogate Pair
        /// </summary>
        /// <param name="highSurrogate"></param>
        /// <param name="lowSurrogate"></param>
        /// <returns></returns>
        public static bool IsSurrogatePair(this char highSurrogate, char lowSurrogate) =>
            char.IsSurrogatePair(highSurrogate, lowSurrogate);

        /// <summary>
        /// Is High Surrogate
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsHighSurrogate(this char c) => char.IsHighSurrogate(c);

        /// <summary>
        /// Is Low Surrogate
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsLowSurrogate(this char c) => char.IsLowSurrogate(c);

        #endregion

        #region Case

        /// <summary>
        /// To Lower
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static char ToLower(this char c) => char.ToLower(c);

        /// <summary>
        /// To Lower
        /// </summary>
        /// <param name="c"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static char ToLower(this char c, CultureInfo culture) => char.ToLower(c, culture);

        /// <summary>
        /// To Lower invariant
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static char ToLowerInvariant(this char c) => char.ToLowerInvariant(c);

        /// <summary>
        /// Is Upper
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsUpper(this char c) => char.IsUpper(c);

        /// <summary>
        /// To Upper
        /// </summary>
        /// <param name="c"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static char ToUpper(this char c, CultureInfo culture) => char.ToUpper(c, culture);

        /// <summary>
        /// To Upper invariant
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static char ToUpperInvariant(this char c) => char.ToUpperInvariant(c);

        #endregion

        #region Equals with IgnoreCase

        /// <summary>
        /// Equals ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this char text, char toCheck) =>
            char.ToUpper(text) == char.ToUpper(toCheck);

        /// <summary>
        /// Equals ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this char? text, char toCheck) =>
            text != null && char.ToUpper(text.Value) == char.ToUpper(toCheck);

        #endregion

        #region To

        /// <summary>
        /// To create a range from one to another
        /// </summary>
        /// <param name="this"></param>
        /// <param name="toCharacter"></param>
        /// <returns></returns>
        public static IEnumerable<char> To(this char @this, char toCharacter)
        {
            var reverseRequired = @this > toCharacter;

            var first = reverseRequired ? toCharacter : @this;
            var last = reverseRequired ? @this : toCharacter;

            var result = Enumerable.Range(first, last - first + 1).Select(charCode => (char) charCode);

            if (reverseRequired)
            {
                result = result.Reverse();
            }

            return result;
        }

        /// <summary>
        /// ToStrng
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string ToString(this char c) => char.ToString(c);

        #endregion

        #region Utf32

        /// <summary>
        /// Convert to utf32
        /// </summary>
        /// <param name="highSurrogate"></param>
        /// <param name="lowSurrogate"></param>
        /// <returns></returns>
        public static int ConvertToUtf32(this char highSurrogate, char lowSurrogate) =>
            char.ConvertToUtf32(highSurrogate, lowSurrogate);

        /// <summary>
        /// Convert from utf32
        /// </summary>
        /// <param name="highSurrogate"></param>
        /// <param name="lowSurrogate"></param>
        /// <returns></returns>
        public static int ConvertFromUft32(this char highSurrogate, char lowSurrogate) =>
            char.ConvertToUtf32(highSurrogate, lowSurrogate);

        #endregion

        #region UnicodeCategory

        /// <summary>
        /// Get unicode category
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static UnicodeCategory GetUnicodeCategory(this char c) => char.GetUnicodeCategory(c);

        #endregion
    }
}