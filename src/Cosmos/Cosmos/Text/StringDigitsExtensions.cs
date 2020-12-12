using System;

namespace Cosmos.Text
{
    public static class StringDigitsExtensions
    {
        #region Digits count
        
        /// <summary>
        /// Total digits
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int DigitsCount(this string text)
        {
            return text.IsNullOrEmpty()
                ? 0
                : Array.FindAll(text.ToCharArray(),char.IsDigit).Length;
        }
        
        #endregion

        #region Contains

        /// <summary>
        /// Returns whether it contains digits.<br />
        /// 返回是否包含数字。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ContainsDigits(this string text)
        {
            return StringDigits.Contains(text);
        }

        #endregion

        #region Contains at least

        /// <summary>
        /// Contain at least the specified number of digits.<br />
        /// 至少包含指定数量的数字。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minCount"></param>
        /// <returns></returns>
        public static bool ContainsDigitsAtLeast(this string text, int minCount)
        {
            return StringDigits.ContainsAtLeast(text, minCount);
        }

        #endregion
    }
}