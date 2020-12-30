using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable InconsistentNaming

namespace Cosmos.Text
{
    internal static class AuxiliaryStringHelper
    {
        public static string StringVal(this IEnumerable<char> chars) => chars.ToString();

        public static IEnumerable<T> M<T>(T t, IEnumerable<T> ts)
        {
            yield return t;
            if (ts is not null)
                foreach (var t0 in ts)
                    yield return t0;
        }
    }

    /// <summary>
    /// String Utils<br />
    /// 字符串工具
    /// </summary>
    public static partial class Strings
    {
        #region Empty

        /// <summary>
        /// Avoid null, so convert null to empty.<br />
        /// 将 null 转换为 Empty
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string AvoidNull(string text) => text ?? string.Empty;

        /// <summary>
        /// Convert null to empty.<br />
        /// 将 null 转换为 Empty
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string NullToEmpty(string text) => AvoidNull(text);

        /// <summary>
        /// Convert empty to null.<br />
        /// 将 Empty 转换为 null
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string EmptyToNull(string text) => string.IsNullOrEmpty(text) ? null : text;

        #endregion

        #region Filter

        /// <summary>
        /// Filter by char
        /// </summary>
        /// <param name="text"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<char> FilterByChar(string text, Func<char, bool> predicate)
        {
            return text.ToCharArray().Where(predicate);
        }

        #endregion

        #region Merge

        public static string Merge(IEnumerable<char> chars)
        {
            var builder = new StringBuilder();
            if (chars is not null)
                foreach (var val in chars)
                    builder.Append(val);
            return builder.ToString();
        }

        public static string Merge(string text, params string[] strings)
        {
            var builder = new StringBuilder();
            builder.Append(text);
            if (strings is not null)
                for (var i = 0; i < strings.Length; i++)
                    builder.Append(strings[i]);
            return builder.ToString();
        }

        public static string Merge(string text, string @string, params string[] strings)
        {
            var builder = new StringBuilder();
            builder.Append(text);
            foreach (var val in AuxiliaryStringHelper.M(@string, strings))
                builder.Append(val);
            return builder.ToString();
        }

        public static string Merge(string text, char @char, params char[] chars)
        {
            var builder = new StringBuilder();
            builder.Append(text);
            foreach (var val in AuxiliaryStringHelper.M(@char, chars))
                builder.Append(val);
            return builder.ToString();
        }

        #endregion


        #region Repeat

        /// <summary>
        /// Repeat<br />
        /// 重复指定次数的字符
        /// </summary>
        /// <param name="source"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public static string Repeat(string source, int times) => source.Repeat(times);

        /// <summary>
        /// Repeat<br />
        /// 重复指定次数的字符
        /// </summary>
        /// <param name="source"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public static string Repeat(char source, int times) => source.Repeat(times);

        #endregion

        #region Pad

        /// <summary>
        /// Padding left
        /// </summary>
        /// <param name="source"></param>
        /// <param name="width"></param>
        /// <param name="appendChar"></param>
        /// <returns></returns>
        public static string PadStart(string source, int width, char appendChar) => source.PadLeft(width, appendChar);

        /// <summary>
        /// Padding right
        /// </summary>
        /// <param name="source"></param>
        /// <param name="width"></param>
        /// <param name="appendChar"></param>
        /// <returns></returns>
        public static string PadEnd(string source, int width, char appendChar) => source.PadRight(width, appendChar);

        #endregion

        #region Prefix / Suffix

        /// <summary>
        /// Returns the common prefix.<br />
        /// 从左到右，返回共有的字符，直至遇到第一个不同的字符。
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static string CommonPrefix(string left, string right)
        {
            if (string.IsNullOrWhiteSpace(left) || string.IsNullOrWhiteSpace(right))
                return string.Empty;

            var sb = new StringBuilder();
            var rangeTimes = left.Length < right.Length ? left.Length : right.Length;
            for (var i = 0; i < rangeTimes; i++)
            {
                if (left[i] != right[i])
                    break;

                sb.Append(left[i]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns the common suffix.<br />
        /// 从右到左，返回共有的字符，直至遇到第一个不同的字符。
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static string CommonSuffix(string left, string right)
        {
            if (string.IsNullOrWhiteSpace(left) || string.IsNullOrWhiteSpace(right))
                return string.Empty;

            var sb = new StringBuilder();
            var rangeTimes = left.Length < right.Length ? left.Length : right.Length;
            int leftPointer = left.Length - 1, rightPointer = right.Length - 1;
            for (var i = 0; i < rangeTimes; i++, leftPointer--, rightPointer--)
            {
                if (left[leftPointer] != right[rightPointer])
                    break;
                sb.Append(left[leftPointer]);
            }

            return sb.ReverseAndToString();
        }

        #endregion
    }

    public static partial class StringsExtensions
    {
        #region Equals

        /// <summary>
        /// Equals ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="targetText"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string text, string targetText) =>
            string.Equals(text, targetText, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Equals to any ignore case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="targetTexts"></param>
        /// <returns></returns>
        public static bool EqualsToAnyIgnoreCase(this string text, params string[] targetTexts) =>
            targetTexts != null &&
            targetTexts.Any(t => string.Equals(text, t, StringComparison.OrdinalIgnoreCase));

        #endregion

        #region Filter

        public static IEnumerable<char> Where(this string text, Func<char, bool> predicate)
        {
            return Strings.FilterByChar(text, predicate);
        }

        #endregion
    }
}