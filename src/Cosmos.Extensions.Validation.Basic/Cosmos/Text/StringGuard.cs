using System;
using Cosmos.Validation.Internals;

namespace Cosmos.Text
{
    public static class StringGuard
    {
        /// <summary>
        /// Check if the string is null, empty or blank. <br />
        /// If the string is null, empty or blank, an exception is thrown. <br />
        /// 检查字符串是否为空或空白。 <br />
        /// 如果字符串为空或空白，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void NotNull(string argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentNullException>(
                !string.IsNullOrWhiteSpace(argument),
                argumentName, message ?? $"{nameof(argument)} can not be null or white space.");
        }

        /// <summary>
        /// Check if the string is empty or blank. <br />
        /// If the string is empty or blank, an exception is thrown. <br />
        /// 检查字符串是否为空或空白。 <br />
        /// 如果字符串为空或空白，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void NotEmpty(string argument, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentNullException>(
                !string.IsNullOrEmpty((argument ?? string.Empty).Trim()),
                argumentName, message ?? $"{nameof(argument)} can not be blank.");
        }

        /// <summary>
        /// Check if the string is empty or blank. <br />
        /// If the string is empty or blank, an exception is thrown. <br />
        /// 检查字符串是否为空或空白。 <br />
        /// 如果字符串为空或空白，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void NotBlank(string argument, string argumentName, string message = null)
        {
            NotEmpty(argument, argumentName, message);
        }

        /// <summary>
        /// Check whether the string exceeds the specified length.
        /// If the string exceeds the specified length, an exception is thrown.
        /// 检查字符串是否超过指定长度。
        /// 如果字符串超过指定长度，则抛出异常。
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="length"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void NotOutOfLength(string argument, int length, string argumentName, string message = null)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
                argument.Trim().Length <= length,
                argumentName, argument.Trim().Length, message ?? $"{nameof(argument)}'s length can not be greater than {length}.");
        }
    }

    public static class StringGuardExtensions
    {
        /// <summary>
        /// 检查字符串是否为 null、String.Empty 或 Blank
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNull(this string argument, string argumentName, string message = null)
        {
            StringGuard.NotNull(argument, argumentName, message);
        }

        /// <summary>
        /// 检查字符串是否为 String.Empty 或 Blank
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckBlank(this string argument, string argumentName, string message = null)
        {
            StringGuard.NotEmpty(argument, argumentName, message);
        }

        ///  <summary>
        /// 检查字符串长度是否超界
        ///  </summary>
        ///  <param name="argument"></param>
        ///  <param name="length"></param>
        ///  <param name="argumentName"></param>
        ///  <param name="message"></param>
        public static void RequireMaxLength(this string argument, int length, string argumentName, string message = null)
        {
            StringGuard.NotOutOfLength(argument, length, argumentName, message);
        }
    }
}