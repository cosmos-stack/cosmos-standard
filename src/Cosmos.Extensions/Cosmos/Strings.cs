using System;
using System.Text;

namespace Cosmos {
    /// <summary>
    /// String Utils<br />
    /// 字符串工具
    /// </summary>
    public static class Strings {
        /// <summary>
        /// Convert null to empty.<br />
        /// 将 null 转换为 Empty
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static string NullToEmpty(string @string) {
            return @string.AvoidNull();
        }

        /// <summary>
        /// Convert empty to null.<br />
        /// 将 Empty 转换为 null
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static string EmptyToNull(string @string) {
            if (@string.IsNullOrEmpty())
                return null;
            return @string;
        }

        /// <summary>
        /// Returns the common prefix.<br />
        /// 从左到右，返回共有的字符，直至遇到第一个不同的字符。
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static string CommonPrefix(string left, string right) {
            if (string.IsNullOrWhiteSpace(left) || string.IsNullOrWhiteSpace(right))
                return string.Empty;

            var sb = new StringBuilder();
            var rangeTimes = left.Length < right.Length ? left.Length : right.Length;
            for (var i = 0; i < rangeTimes; i++) {
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
        public static string CommonSuffix(string left, string right) {
            if (string.IsNullOrWhiteSpace(left) || string.IsNullOrWhiteSpace(right))
                return string.Empty;

            var sb = new StringBuilder();
            var rangeTimes = left.Length < right.Length ? left.Length : right.Length;
            int leftPointer = left.Length - 1, rightPointer = right.Length - 1;
            for (var i = 0; i < rangeTimes; i++, leftPointer--, rightPointer--) {
                if (left[leftPointer] != right[rightPointer])
                    break;
                sb.Append(left[leftPointer]);
            }

            return sb.ToReverseString();
        }

        /// <summary>
        /// Repeat<br />
        /// 重复指定次数的字符
        /// </summary>
        /// <param name="source"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public static string Repeat(string source, int times) {
            return source.Repeat(times);
        }

        /// <summary>
        /// Repeat<br />
        /// 重复指定次数的字符
        /// </summary>
        /// <param name="source"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public static string Repeat(char source, int times) {
            return source.Repeat(times);
        }

        /// <summary>
        /// Padding left
        /// </summary>
        /// <param name="source"></param>
        /// <param name="width"></param>
        /// <param name="appendChar"></param>
        /// <returns></returns>
        public static string PadStart(string source, int width, char appendChar) {
            return source.PadLeft(width, appendChar);
        }

        /// <summary>
        /// Padding right
        /// </summary>
        /// <param name="source"></param>
        /// <param name="width"></param>
        /// <param name="appendChar"></param>
        /// <returns></returns>
        public static string PadEnd(string source, int width, char appendChar) {
            return source.PadRight(width, appendChar);
        }
    }
}