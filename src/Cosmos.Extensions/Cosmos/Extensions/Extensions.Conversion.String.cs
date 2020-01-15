using System.Text;
using Cosmos.Conversions;
using Cosmos.Conversions.Scale;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// Conversion extensions
    /// </summary>
    public static partial class ConversionExtensions {
        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this short number, string defaultVal = "") => number == 0 ? defaultVal : number.ToString();

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this short? number, string defaultVal = "") => CastToString(number.SafeValue(), defaultVal);

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ushort number, string defaultVal = "") => number == 0 ? defaultVal : number.ToString();

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ushort? number, string defaultVal = "") => CastToString(number.SafeValue(), defaultVal);

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this int number, string defaultVal = "") => number == 0 ? defaultVal : number.ToString();

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this int? number, string defaultVal = "") => CastToString(number.SafeValue(), defaultVal);

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this uint number, string defaultVal = "") => number == 0 ? defaultVal : number.ToString();

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this uint? number, string defaultVal = "") => CastToString(number.SafeValue(), defaultVal);

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this long number, string defaultVal = "") => number == 0 ? defaultVal : number.ToString();

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this long? number, string defaultVal = "") => CastToString(number.SafeValue(), defaultVal);

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ulong number, string defaultVal = "") => number == 0 ? defaultVal : number.ToString();

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ulong? number, string defaultVal = "") => CastToString(number.SafeValue(), defaultVal);

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this float number, string defaultVal = "") => $"{number:0.##}";

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this float? number, string defaultVal = "") => CastToString(number.SafeValue(), defaultVal);

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this double number, string defaultVal = "") => $"{number:0.##}";

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this double? number, string defaultVal = "") => CastToString(number.SafeValue(), defaultVal);

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this decimal number, string defaultVal = "") => number == 0 ? defaultVal : $"{number:0.##}";

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this decimal? number, string defaultVal = "") => CastToString(number.SafeValue(), defaultVal);

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="originalStr"></param>
        /// <param name="fromStyle"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string CastToString(this string originalStr, ScaleStyles fromStyle = ScaleStyles.String, Encoding encoding = null) {
            return fromStyle switch {
                ScaleStyles.Hexadecimal => HexadecimalConversion.ToString(originalStr, encoding),
                _                       => originalStr
            };
        }

        /// <summary>
        /// 用指定的字符串来指示其边界（输出为 String 结果）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="format"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string CastToString<T>(this T[] array, string format, string delimiter) {

            if (array is null || array.Length == 0)
                return string.Empty;

            if (string.IsNullOrEmpty(format)) format = "{0}";

            return Joiners.Joiner.On(delimiter).Join(array, arg => string.Format(format, arg));
        }

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string CastToString(this object obj) => ObjectConversion.ToString(obj);
    }
}