using System.Linq;

namespace Cosmos.Text
{
    public static class StringLetters
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
        /// Get only letters.<br />
        /// 只获取字母。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetOnlyLetter(this string text)
        {
            return StringFilters.FilterChars(text, char.IsLetter);
        }

        /// <summary>
        /// Returns whether it contains letters.<br />
        /// 返回是否包含字母。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool Contains(string text)
        {
            return ContainsAtLeast(text, 0);
        }

        /// <summary>
        /// Contain at least the specified number of letters.<br />
        /// 至少包含指定数量的字母。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minCount"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast(string text, int minCount)
        {
            return text.ToCharArray().Count(char.IsLetter) >= minCount;
        }
    }
}