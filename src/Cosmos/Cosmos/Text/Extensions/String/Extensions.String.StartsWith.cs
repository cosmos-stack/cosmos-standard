using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Judgments;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// 确定此字符串实例的开头是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="string"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWith(this string @string, params string[] values)
            => StringJudgment.StartWithThese(@string, values);

        /// <summary>
        /// 确定此字符串实例的开头是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="string"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWith(this string @string, ICollection<string> values)
            => StringJudgment.StartWithThese(@string, values);

        /// <summary>
        /// Starts with ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool StartsWithIgnoreCase(this string text, string toCheck)
        {
            if (toCheck.IsNullOrEmpty())
                return true;
            return text.IsNullOrEmpty() ? toCheck.IsNullOrEmpty() : text.StartsWith(toCheck, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Starts with any ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool StartsWithAnyIgnoreCase(this string text, params string[] toCheck)
            => StartsWithAnyIgnoreCase(text, (IEnumerable<string>) toCheck);

        /// <summary>
        /// Starts with any ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool StartsWithAnyIgnoreCase(this string text, IEnumerable<string> toCheck)
            => !text.IsNullOrEmpty() && toCheck.Any(check => text.StartsWith(check, StringComparison.OrdinalIgnoreCase));
    }
}