using System;
using Cosmos.Collections;

namespace Cosmos.Text
{
    public static class StringLetterExtensions
    {
        #region Letters count

        /// <summary>
        /// Returns the number of letters contained in the string.<br />
        /// 返回字符串中所包含字母的数量。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int LettersCount(this string text)
        {
            return text.IsNullOrEmpty()
                ? 0
                : text.ToCharArray().FindAll(char.IsLetter).Length;
        }

        /// <summary>
        /// Returns the number of lowercase letters in the string.<br />
        /// 返回字符串中所包含小写字母的数量。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int LowerLettersCount(this string text)
        {
            return text.IsNullOrEmpty()
                ? 0
                : text.ToCharArray().FindAll(x => char.IsLetter(x) && char.IsLower(x)).Length;
        }

        /// <summary>
        /// Returns the number of uppercase letters in the string.<br />
        /// 返回字符串中所包含大写字母的数量。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int UpperLettersCount(this string text)
        {
            return text.IsNullOrEmpty()
                ? 0
                : text.ToCharArray().FindAll(x => char.IsLetter(x) && char.IsUpper(x)).Length;
        }

        #endregion

        #region Contains

        /// <summary>
        /// Returns whether it contains letters.<br />
        /// 返回是否包含字母。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ContainsLetters(this string text)
        {
            return StringLetters.Contains(text);
        }

        #endregion

        #region Contains at least

        /// <summary>
        /// Contain at least the specified number of letters.<br />
        /// 至少包含指定数量的字母。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="minCount"></param>
        /// <returns></returns>
        public static bool ContainsLettersAtLeast(this string text, int minCount)
        {
            return StringLetters.ContainsAtLeast(text, minCount);
        }

        #endregion
    }
}