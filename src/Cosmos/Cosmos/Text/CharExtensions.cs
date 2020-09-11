using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Text
{
    /// <summary>
    /// Char extensions
    /// </summary>
    public static class CharExtensions
    {
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

        #region Range

        /// <summary>
        /// To create a range from one to another
        /// </summary>
        /// <param name="this"></param>
        /// <param name="toCharacter"></param>
        /// <returns></returns>
        public static IEnumerable<char> Range(this char @this, char toCharacter)
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
        
        #endregion
        
    }
}