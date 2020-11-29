using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cosmos.Text
{
    public static class StringJudge
    {
        #region StartsWith/EndsWith

        /// <summary>
        /// Determine whether the string starts with the specified string.<br />
        /// 判断字符串是否以指定的字符串开头。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWithThese(string str, params string[] values) => str.StartsWith(values);

        /// <summary>
        /// Determine whether the string starts with the specified string.<br />
        /// 判断字符串是否以指定的字符串开头。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWithThese(string str, ICollection<string> values) => str.StartsWith(values);

        /// <summary>
        /// Determine whether the string ends with the specified string.<br />
        /// 判断字符串是否以指定的字符串结尾。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndsWithThese(string str, params string[] values) => str.EndsWith(values);

        /// <summary>
        /// Determine whether the string ends with the specified string.<br />
        /// 判断字符串是否以指定的字符串结尾。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndsWithThese(string str, ICollection<string> values) => str.EndsWith(values);

        #endregion

        #region Contains

        /// <summary>
        /// Determine whether the string contains Chinese characters.<br />
        /// 判断字符串是否包含汉字。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ContainsChineseCharacters(string str)
        {
            return !string.IsNullOrWhiteSpace(str) && RegexJudge.IsMatch(str, "[\u4e00-\u9fa5]+");
        }

        /// <summary>
        /// Determine whether the string contains numbers.<br />
        /// 判断字符串是否包含数字。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ContainsNumber(string str)
        {
            return !string.IsNullOrWhiteSpace(str) && RegexJudge.IsMatch(str, "[0-9]+");
        }

        #endregion

        #region Is

        private const RegexOptions InternalSchema = RegexOptions.Singleline | RegexOptions.Compiled;

        private static readonly Regex WebUrlExpressionSchema = new Regex(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", InternalSchema);

        /// <summary>
        /// Determine whether the string is a Web Url address.<br />
        /// 判断字符串是否为 Web Url 地址。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsWebUrl(string str)
        {
            return !string.IsNullOrWhiteSpace(str) && WebUrlExpressionSchema.IsMatch(str);
        }

        private static readonly Regex EemailExpressionSchema = new Regex(@"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$", InternalSchema);

        /// <summary>
        /// Determine whether the string is an email.<br />
        /// 判断字符串是否为电子邮件。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmail(string str)
        {
            return !string.IsNullOrWhiteSpace(str) && EemailExpressionSchema.IsMatch(str);
        }

        #endregion
    }
}