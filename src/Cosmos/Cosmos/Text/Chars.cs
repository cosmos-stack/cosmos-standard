using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Cosmos.Text
{
    public static class Chars
    {
        #region BeContainedIn

        /// <summary>
        /// In
        /// </summary>
        /// <param name="char"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool BeContainedIn(char @char, params char[] values)
        {
            return Array.IndexOf(values, @char) >= 0;
        }

        /// <summary>
        /// In
        /// </summary>
        /// <param name="char"></param>
        /// <param name="case"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool BeContainedIn(char @char, IgnoreCase @case, params char[] values)
        {
            if (values is null || values.Length == 0)
                return false;
            if (@case == IgnoreCase.FALSE)
                return BeContainedIn(@char, values);
            return BeContainedIn(@char, IgnoreCaseHelper.FillChars(values));
        }

        /// <summary>
        /// Not In
        /// </summary>
        /// <param name="char"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool BeNotContainedIn(char @char, params char[] values)
        {
            return Array.IndexOf(values, @char) < 0;
        }

        /// <summary>
        /// Not In
        /// </summary>
        /// <param name="char"></param>
        /// <param name="case"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool BeNotContainedIn(char @char, IgnoreCase @case, params char[] values)
        {
            if (values is null || values.Length == 0)
                return true;
            if (@case == IgnoreCase.FALSE)
                return BeNotContainedIn(@char, values);
            return BeNotContainedIn(@char, IgnoreCaseHelper.FillChars(values));
        }

        #endregion

        #region Between

        /// <summary>
        /// Is special char between min and max
        /// </summary>
        /// <param name="char"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsBetween(char @char, char min, char max)
        {
            var (xiao, da) = Fix(min, max);
            return @char >= xiao && @char <= da;
        }

        private static (char min, char max) Fix(char min, char max) => min >= max ? (max, min) : (min, max);

        #endregion

        #region Range

        /// <summary>
        /// To create a range from one to another
        /// </summary>
        /// <param name="char"></param>
        /// <param name="toCharacter"></param>
        /// <returns></returns>
        public static IEnumerable<char> Range(char @char, char toCharacter)
        {
            var reverseRequired = @char > toCharacter;

            var first = reverseRequired ? toCharacter : @char;
            var last = reverseRequired ? @char : toCharacter;

            var result = Enumerable.Range(first, last - first + 1).Select(charCode => (char) charCode);

            if (reverseRequired)
            {
                result = result.Reverse();
            }

            return result;
        }

        #endregion

        #region Repeat

        /// <summary>
        /// Repeat<br />
        /// 重复指定次数的字符
        /// </summary>
        /// <param name="char"></param>
        /// <param name="repeatTimes"></param>
        /// <returns></returns>
        public static string Repeat(char @char, int repeatTimes)
        {
            return repeatTimes <= 0 ? string.Empty : new string(@char, repeatTimes);
        }

        #endregion
    }

    public static class CharsExtensions
    {
        #region BeContainedIn

        /// <summary>
        /// In
        /// </summary>
        /// <param name="char"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool BeContainedIn(this char @char, params char[] values)
        {
            return Chars.BeContainedIn(@char, values);
        }

        /// <summary>
        /// In
        /// </summary>
        /// <param name="char"></param>
        /// <param name="case"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool BeContainedIn(this char @char, IgnoreCase @case, params char[] values)
        {
            return Chars.BeContainedIn(@char, @case, values);
        }

        /// <summary>
        /// Not In
        /// </summary>
        /// <param name="char"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool BeNotContainedIn(this char @char, params char[] values)
        {
            return Chars.BeNotContainedIn(@char, values);
        }

        /// <summary>
        /// Not In
        /// </summary>
        /// <param name="char"></param>
        /// <param name="case"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool BeNotContainedIn(this char @char, IgnoreCase @case, params char[] values)
        {
            return Chars.BeNotContainedIn(@char, @case, values);
        }

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
            return Chars.IsBetween(@char, min, max);
        }

        #endregion

        #region Repeat

        /// <summary>
        /// Repeat<br />
        /// 重复指定次数的字符
        /// </summary>
        /// <param name="char"></param>
        /// <param name="repeatTimes"></param>
        /// <returns></returns>
        public static string Repeat(this char @char, int repeatTimes)
        {
            return Chars.Repeat(@char, repeatTimes);
        }

        #endregion
    }

    public static class CharsShortcutExtensions
    {
        #region Case

        /// <summary>
        /// To Lower
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static char ToLower(this char @char)
        {
            return char.ToLower(@char);
        }

        /// <summary>
        /// To Lower
        /// </summary>
        /// <param name="char"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static char ToLower(this char @char, CultureInfo culture)
        {
            return char.ToLower(@char, culture);
        }

        /// <summary>
        /// To Lower invariant
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static char ToLowerInvariant(this char @char)
        {
            return char.ToLowerInvariant(@char);
        }

        /// <summary>
        /// Is Upper
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static bool IsUpper(this char @char)
        {
            return char.IsUpper(@char);
        }

        /// <summary>
        /// To Upper
        /// </summary>
        /// <param name="char"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static char ToUpper(this char @char, CultureInfo culture)
        {
            return char.ToUpper(@char, culture);
        }

        /// <summary>
        /// To Upper invariant
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static char ToUpperInvariant(this char @char)
        {
            return char.ToUpperInvariant(@char);
        }

        #endregion

        #region Equals with IgnoreCase

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="char"></param>
        /// <param name="toCheck"></param>
        /// <param name="case"></param>
        /// <returns></returns>
        public static bool Equals(this char @char, char toCheck,IgnoreCase @case)
        {
            return @case.X()
                ? EqualsIgnoreCase(@char, toCheck)
                : @char == toCheck;
        }
        
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="char"></param>
        /// <param name="toCheck"></param>
        /// <param name="case"></param>
        /// <returns></returns>
        public static bool Equals(this char? @char, char toCheck,IgnoreCase @case)
        {
            if (@char is null)
                return false;
            return @case.X()
                ? EqualsIgnoreCase(@char.Value, toCheck)
                : @char.Value == toCheck;
        }

        /// <summary>
        /// Equals ignore case
        /// </summary>
        /// <param name="char"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this char @char, char toCheck)
        {
            return char.ToUpper(@char) == char.ToUpper(toCheck);
        }

        /// <summary>
        /// Equals ignore case
        /// </summary>
        /// <param name="char"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this char? @char, char toCheck)
        {
            return @char is not null && EqualsIgnoreCase(@char.Value, toCheck);
        }

        #endregion

        #region Is

        /// <summary>
        /// Is WhiteSpace
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static bool IsWhiteSpace(this char @char)
        {
            return char.IsWhiteSpace(@char);
        }

        /// <summary>
        /// Is Control
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static bool IsControl(this char @char)
        {
            return char.IsControl(@char);
        }

        /// <summary>
        /// Is Digit
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static bool IsDigit(this char @char)
        {
            return char.IsDigit(@char);
        }

        /// <summary>
        /// Is Letter
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static bool IsLetter(this char @char)
        {
            return char.IsLetter(@char);
        }

        /// <summary>
        /// Is Letter or Digit
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static bool IsLetterOrDigit(this char @char)
        {
            return char.IsLetterOrDigit(@char);
        }

        /// <summary>
        /// Is Lower
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static bool IsLower(this char @char)
        {
            return char.IsLower(@char);
        }

        /// <summary>
        /// Is Number
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static bool IsNumber(this char @char)
        {
            return char.IsNumber(@char);
        }

        /// <summary>
        /// Is Punctuation
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static bool IsPunctuation(this char @char)
        {
            return char.IsPunctuation(@char);
        }

        /// <summary>
        /// Is Separator
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static bool IsSeparator(this char @char)
        {
            return char.IsSeparator(@char);
        }

        /// <summary>
        /// Is Symbol
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static bool IsSymbol(this char @char)
        {
            return char.IsSymbol(@char);
        }

        #endregion

        #region Is Surrogate

        /// <summary>
        /// Is Surrogate
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static bool IsSurrogate(this char @char)
        {
            return char.IsSurrogate(@char);
        }

        /// <summary>
        /// Is Surrogate Pair
        /// </summary>
        /// <param name="highSurrogate"></param>
        /// <param name="lowSurrogate"></param>
        /// <returns></returns>
        public static bool IsSurrogatePair(this char highSurrogate, char lowSurrogate)
        {
            return char.IsSurrogatePair(highSurrogate, lowSurrogate);
        }

        /// <summary>
        /// Is High Surrogate
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static bool IsHighSurrogate(this char @char)
        {
            return char.IsHighSurrogate(@char);
        }

        /// <summary>
        /// Is Low Surrogate
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static bool IsLowSurrogate(this char @char)
        {
            return char.IsLowSurrogate(@char);
        }

        #endregion

        #region Numeric

        /// <summary>
        /// Get numeric value
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static double GetNumericValue(this char @char)
        {
            return char.GetNumericValue(@char);
        }

        #endregion

        #region To

        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static string ToString(this char @char)
        {
            return char.ToString(@char);
        }

        #endregion

        #region Utf32

        /// <summary>
        /// Convert to utf32
        /// </summary>
        /// <param name="highSurrogate"></param>
        /// <param name="lowSurrogate"></param>
        /// <returns></returns>
        public static int ConvertToUtf32(this char highSurrogate, char lowSurrogate)
        {
            return char.ConvertToUtf32(highSurrogate, lowSurrogate);
        }

        #endregion

        #region UnicodeCategory

        /// <summary>
        /// Get unicode category
        /// </summary>
        /// <param name="char"></param>
        /// <returns></returns>
        public static UnicodeCategory GetUnicodeCategory(this char @char)
        {
            return char.GetUnicodeCategory(@char);
        }

        #endregion
    }
}