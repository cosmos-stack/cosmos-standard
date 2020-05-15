using System.Text;
using Cosmos.Conversions.Core;
using Cosmos.Conversions.Scale;

// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions {
    /// <summary>
    /// Extensions for CastTo opts
    /// </summary>
    public static partial class CastToExtensions {

        #region Object

        /// <summary>
        /// Cast <see cref="object"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string CastToString(this object obj) => StringConv.ObjectSafeToString(obj);

        #endregion

        #region Numeric

        /// <summary>
        /// Cast <see cref="short"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this short number, string defaultVal = "") => StringConv.Int16ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="short"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this short? number, string defaultVal = "") => StringConv.Int16ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="short"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ushort number, string defaultVal = "") => StringConv.UInt16ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="short"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ushort? number, string defaultVal = "") => StringConv.UInt16ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="int"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this int number, string defaultVal = "") => StringConv.Int32ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="int"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this int? number, string defaultVal = "") => StringConv.Int32ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="uint"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this uint number, string defaultVal = "") => StringConv.UInt32ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="uint"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this uint? number, string defaultVal = "") => StringConv.UInt32ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="long"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this long number, string defaultVal = "") => StringConv.Int64ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="long"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this long? number, string defaultVal = "") => StringConv.Int64ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="ulong"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ulong number, string defaultVal = "") => StringConv.UInt64ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="ulong"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ulong? number, string defaultVal = "") => StringConv.UInt64ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="float"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string CastToString(this float number) => StringConv.FloatToString(number);

        /// <summary>
        /// Cast <see cref="float"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string CastToString(this float number, int digits) => StringConv.FloatToString(number, digits);

        /// <summary>
        /// Cast nullable <see cref="float"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string CastToString(this float? number) => StringConv.FloatToString(number);

        /// <summary>
        /// Cast nullable <see cref="float"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string CastToString(this float? number, int digits) => StringConv.FloatToString(number, digits);

        /// <summary>
        /// Cast <see cref="double"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string CastToString(this double number) => StringConv.DoubleToString(number);

        /// <summary>
        /// Cast <see cref="double"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string CastToString(this double number, int digits) => StringConv.DoubleToString(number, digits);

        /// <summary>
        /// Cast nullable <see cref="double"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string CastToString(this double? number) => StringConv.DoubleToString(number);

        /// <summary>
        /// Cast nullable <see cref="double"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string CastToString(this double? number, int digits) => StringConv.DoubleToString(number, digits);

        /// <summary>
        /// Cast <see cref="decimal"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this decimal number, string defaultVal = "") => StringConv.DecimalToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="decimal"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this decimal number, int digits, string defaultVal = "") => StringConv.DecimalToString(number, digits, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="decimal"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this decimal? number, string defaultVal = "") => StringConv.DecimalToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="decimal"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this decimal? number, int digits, string defaultVal = "") => StringConv.DecimalToString(number, digits, defaultVal);

        #endregion

        #region Hexadecimal

        /// <summary>
        /// To string
        /// </summary>
        /// <param name="originalStr"></param>
        /// <param name="fromStyle"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string CastToString(this string originalStr, ScaleStyles fromStyle = ScaleStyles.String, Encoding encoding = null) {
            return fromStyle switch {
                ScaleStyles.Hexadecimal => HexadecimalConverter.ToString(originalStr, encoding),
                _                       => originalStr
            };
        }

        #endregion

    }
}