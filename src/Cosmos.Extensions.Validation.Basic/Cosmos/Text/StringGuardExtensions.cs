namespace Cosmos.Text
{
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