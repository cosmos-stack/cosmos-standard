using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// 判断指定字符串是否为 Guid
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsGuid(this string @string) => Judgements.GuidJudgement.IsValid(@string);

        /// <summary>
        /// 检查字符串是 null 还是 System.String.Empty 字符串
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string @string) => string.IsNullOrEmpty(@string);

        /// <summary>
        /// 检查字符串不是 null 或 System.String.Empty 字符串
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNotNullNorEmpty(this string @string) => !@string.IsNullOrEmpty();

        /// <summary>
        /// 检查字符串是 null、空还是仅由空白字符组成
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string @string) => string.IsNullOrWhiteSpace(@string);

        /// <summary>
        /// 检查字符串不是 null、空或由空白字符串组成
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNotNullNorWhiteSpace(this string @string) => !@string.IsNullOrWhiteSpace();

        /// <summary>
        /// 指示指定的字符串是否为 Int 类型
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsInt(this string @string) => Judgements.NumericJudgement.IsInt32(@string);

        /// <summary>
        /// 指示指定的字符串是否为数字
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNumberic(this string @string) => Judgements.NumericJudgement.IsNumeric(@string);

        /// <summary>
        /// 判断是否为 Url 路径
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsWebUrl(this string target) => Judgements.StringJudgement.IsWebUrl(target);

        /// <summary>
        /// 判断是否为 Email 地址
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsEmail(this string target) => Judgements.StringJudgement.IsEmail(target);
        
        public static bool OneAbsentChar(this string text, string toCheck)
        {
            if (text.Length > 1
                && toCheck.Length > 1
                && Math.Abs(text.Length - toCheck.Length) != 1) //las long deben diferir en 1, y ambas ser mayor que 1
                return false;

            var textWithChar = (text.Length > toCheck.Length ? text : toCheck);
            var textNoChar = (text.Length > toCheck.Length ? toCheck : text);

            //chequear si es el ultimo
            if (textWithChar[textWithChar.Length - 1] != textNoChar[textNoChar.Length - 1])
                return textWithChar.Substring(0, textWithChar.Length - 1).EqualsIgnoreCase(textNoChar);

            for (int i = 0; i < textNoChar.Length; i++)
            {
                if (textWithChar[i] != textNoChar[i])
                {
                    //a partir del car distinto, el resto debe coincidir
                    return textWithChar.Substring(i + 1).EqualsIgnoreCase(textNoChar.Substring(i));
                }
            }
            return false;
        }
    }
}