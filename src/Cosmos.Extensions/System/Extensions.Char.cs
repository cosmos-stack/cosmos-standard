using System.Globalization;

namespace System {
    /// <summary>
    /// Base Type Extensions
    /// </summary>
    public static partial class BaseTypeExtensions {
        /// <summary>
        /// Get numeric value
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double GetNumericValue(this char c) {
            return char.GetNumericValue(c);
        }

        /// <summary>
        /// Get unicode category
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static UnicodeCategory GetUnicodeCategory(this char c) {
            return char.GetUnicodeCategory(c);
        }

        /// <summary>
        /// To Lower
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static char ToLower(this char c) {
            return char.ToLower(c);
        }

        /// <summary>
        /// To Lower
        /// </summary>
        /// <param name="c"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static char ToLower(this char c, CultureInfo culture) {
            return char.ToLower(c, culture);
        }

        /// <summary>
        /// To Lower invariant
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static char ToLowerInvariant(this char c) {
            return char.ToLowerInvariant(c);
        }

        /// <summary>
        /// Is Upper
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsUpper(this char c) {
            return char.IsUpper(c);
        }

        /// <summary>
        /// To Upper
        /// </summary>
        /// <param name="c"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static char ToUpper(this char c, CultureInfo culture) {
            return char.ToUpper(c, culture);
        }

        /// <summary>
        /// To Upper invariant
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static char ToUpperInvariant(this char c) {
            return char.ToUpperInvariant(c);
        }

        /// <summary>
        /// ToStrng
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string ToString(this char c) {
            return char.ToString(c);
        }

        /// <summary>
        /// Convert to utf32
        /// </summary>
        /// <param name="highSurrogate"></param>
        /// <param name="lowSurrogate"></param>
        /// <returns></returns>
        public static int ConvertToUtf32(this char highSurrogate, char lowSurrogate) {
            return char.ConvertToUtf32(highSurrogate, lowSurrogate);
        }

        /// <summary>
        /// Is Surrogate
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsSurrogate(this char c) {
            return char.IsSurrogate(c);
        }

        /// <summary>
        /// Is Surrogate Pair
        /// </summary>
        /// <param name="highSurrogate"></param>
        /// <param name="lowSurrogate"></param>
        /// <returns></returns>
        public static bool IsSurrogatePair(this char highSurrogate, char lowSurrogate) {
            return char.IsSurrogatePair(highSurrogate, lowSurrogate);
        }

        /// <summary>
        /// Is High Surrogate
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsHighSurrogate(this char c) {
            return char.IsHighSurrogate(c);
        }

        /// <summary>
        /// Is Low Surrogate
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsLowSurrogate(this char c) {
            return char.IsLowSurrogate(c);
        }

        /// <summary>
        /// Repeat
        /// </summary>
        /// <param name="this"></param>
        /// <param name="repeatCount"></param>
        /// <returns></returns>
        public static string Repeat(this char @this, int repeatCount) {
            return new string(@this, repeatCount);
        }
    }
}