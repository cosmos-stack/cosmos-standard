using Cosmos.Conversions.Determiners;
using Cosmos.Judgments;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    /// <summary>
    /// String determiner extensions
    /// </summary>
    public static partial class StringDeterminerExtensions
    {
        /// <summary>
        /// Is char
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsChar(this string str) => StringCharDeterminer.Is(str);

        /// <summary>
        /// Is boolean
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBoolean(this string str) => StringBooleanDeterminer.Is(str);

        /// <summary>
        /// Is encoding
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEncoding(this string str) => StringEncodingDeterminer.Is(str);

        /// <summary>
        /// 判断是否为 Url 路径
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsWebUrl(this string target) => StringJudgment.IsWebUrl(target);

        /// <summary>
        /// 判断是否为 Email 地址
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsEmail(this string target) => StringJudgment.IsEmail(target);

        /// <summary>
        /// Is version
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsVersion(this string str) => StringVersionDeterminer.Is(str);

        /// <summary>
        /// Is IpAddress
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsIpAddress(this string str) => StringIpAddressDeterminer.Is(str);
    }
}