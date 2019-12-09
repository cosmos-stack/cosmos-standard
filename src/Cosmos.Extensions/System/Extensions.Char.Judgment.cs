namespace System {
    /// <summary>
    /// Base Type Extensions
    /// </summary>
    public static partial class BaseTypeExtensions {
        /// <summary>
        /// In
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool In(this char @this, params char[] values) {
            return Array.IndexOf(values, @this) != -1;
        }

        /// <summary>
        /// Not In
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool NotIn(this char @this, params char[] values) {
            return Array.IndexOf(values, @this) == -1;
        }

        /// <summary>
        /// Is WhiteSpace
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsWhiteSpace(this char c) {
            return char.IsWhiteSpace(c);
        }

        /// <summary>
        /// Is Control
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsControl(this char c) {
            return char.IsControl(c);
        }

        /// <summary>
        /// Is Digit
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsDigit(this char c) {
            return char.IsDigit(c);
        }

        /// <summary>
        /// Is Letter
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsLetter(this char c) {
            return char.IsLetter(c);
        }

        /// <summary>
        /// Is Letter or Digit
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsLetterOrDigit(this char c) {
            return char.IsLetterOrDigit(c);
        }

        /// <summary>
        /// Is Lower
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsLower(this char c) {
            return char.IsLower(c);
        }

        /// <summary>
        /// Is Number
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsNumber(this char c) {
            return char.IsNumber(c);
        }

        /// <summary>
        /// Is Punctuation
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsPunctuation(this char c) {
            return char.IsPunctuation(c);
        }

        /// <summary>
        /// Is Separator
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsSeparator(this char c) {
            return char.IsSeparator(c);
        }

        /// <summary>
        /// Is Symbol
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsSymbol(this char c) {
            return char.IsSymbol(c);
        }

    }
}