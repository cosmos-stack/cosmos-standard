using System.Linq;

namespace Cosmos.Text
{
    public static class StringDigits
    {
        /// <summary>
        /// Get only letters and numbers.<br />
        /// 只获取字母和数字。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetOnlyLetterOrDigit(this string text)
        {
            return StringFilters.FilterChars(text, char.IsLetterOrDigit);
        }

        /// <summary>
        /// Get only numbers.<br />
        /// 只获取数字。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetOnlyDigit(this string text)
        {
            return StringFilters.FilterChars(text, char.IsDigit);
        }
        
        /// <summary>
        /// Returns whether it contains digit.<br />
        /// 返回是否包含数字。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool Contains(string text)
        {
            return ContainsAtLeast(text, 0);
        }

        /// <summary>
        /// Contain at least the specified number of digit.<br />
        /// 至少包含指定数量的数字。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minCount"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast(string text, int minCount)
        {
            return text.ToCharArray().Count(char.IsDigit) >= minCount;
        }
    }
}