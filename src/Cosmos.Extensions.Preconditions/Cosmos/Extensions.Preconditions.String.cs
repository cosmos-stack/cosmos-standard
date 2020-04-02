using System;
using Cosmos.Judgments;

namespace Cosmos {
    /// <summary>
    /// String arguments checking extensions
    /// </summary>
    public static partial class PreconditionsExtensions {
        /// <summary>
        /// 检查字符串是否为 null、String.Empty 或 Blank
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckNull(this string argument, string argumentName, string message = null) {
            AssertionJudgment.Require2Validation<ArgumentNullException>(
                !string.IsNullOrWhiteSpace(argument),
                argumentName, message ?? $"{nameof(argument)} can not be null or white space.");
        }

        /// <summary>
        /// 检查字符串是否为 String.Empty 或 Blank
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <param name="message"></param>
        public static void CheckBlank(this string argument, string argumentName, string message = null)
            => Preconditions.IsNotEmpty(argument, argumentName, message);

        ///  <summary>
        /// 检查字符串长度是否超界
        ///  </summary>
        ///  <param name="argument"></param>
        ///  <param name="length"></param>
        ///  <param name="argumentName"></param>
        ///  <param name="message"></param>
        public static void CheckOutOfLength(this string argument, int length, string argumentName, string message = null)
            => Preconditions.IsNotOutOfLength(argument, length, argumentName, message);
    }
}