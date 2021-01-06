using System.Linq;

namespace Cosmos.Text
{
    /// <summary>
    /// String Utils<br />
    /// 字符串工具
    /// </summary>
    public static partial class Strings
    {
        /// <summary>
        /// Is upper
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsUpper( string text)
        {
            return FilterForLetters(text).All(char.IsUpper);
        }

        /// <summary>
        /// Is lower
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsLower( string text)
        {
            return FilterForLetters(text).All(char.IsLower);
        }
    }

    public static partial class StringsExtensions
    {
        /// <summary>
        /// Is upper
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsUpper(this string text)
        {
            return Strings.IsUpper(text);
        }

        /// <summary>
        /// Is lower
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsLower(this string text)
        {
            return Strings.IsLower(text);
        }
    }

    public static partial class StringsShortcutExtensions
    {
        #region Is

        /// <summary>
        /// 检查字符串是 null 还是 System.String.Empty 字符串
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        /// <summary>
        /// 检查字符串不是 null 或 System.String.Empty 字符串
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNotNullNorEmpty(this string text)
        {
            return !text.IsNullOrEmpty();
        }

        /// <summary>
        /// 检查字符串是 null、空还是仅由空白字符组成
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        /// <summary>
        /// 检查字符串不是 null、空或由空白字符串组成
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsNotNullNorWhiteSpace(this string text)
        {
            return !text.IsNullOrWhiteSpace();
        }

        #endregion
    }
}