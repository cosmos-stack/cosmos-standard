using System;
using System.Text;
using Cosmos.Conversions;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Text
{
    /// <summary>
    /// Cosmos <see cref="string"/> casting extensions.
    /// </summary>
    public static partial class StringCastingExtensions
    {
        #region Cast Object to String

        /// <summary>
        /// Cast <see cref="object"/> to <see cref="string"/>. <br />
        /// 将对象 <see cref="object"/> 转换为字符串。
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        public static string CastToString(this object that) => StrConvX.ObjectSafeToString(that);

        #endregion

        #region Cast Numeric to String

        /// <summary>
        /// Cast <see cref="short"/> to <see cref="string"/>. <br />
        /// 将 <see cref="short"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this short number, string defaultVal = "") => StrConvX.Int16ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="short"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="short"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this short? number, string defaultVal = "") => StrConvX.Int16ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="ushort"/> to <see cref="string"/>. <br />
        /// 将 <see cref="ushort"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ushort number, string defaultVal = "") => StrConvX.UInt16ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="ushort"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="ushort"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ushort? number, string defaultVal = "") => StrConvX.UInt16ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="int"/> to <see cref="string"/>. <br />
        /// 将 <see cref="int"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this int number, string defaultVal = "") => StrConvX.Int32ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="int"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="int"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this int? number, string defaultVal = "") => StrConvX.Int32ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="uint"/> to <see cref="string"/>. <br />
        /// 将 <see cref="uint"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this uint number, string defaultVal = "") => StrConvX.UInt32ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="uint"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="uint"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this uint? number, string defaultVal = "") => StrConvX.UInt32ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="long"/> to <see cref="string"/>. <br />
        /// 将 <see cref="long"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this long number, string defaultVal = "") => StrConvX.Int64ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="long"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="long"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this long? number, string defaultVal = "") => StrConvX.Int64ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="ulong"/> to <see cref="string"/>. <br />
        /// 将 <see cref="ulong"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ulong number, string defaultVal = "") => StrConvX.UInt64ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="ulong"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="ulong"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ulong? number, string defaultVal = "") => StrConvX.UInt64ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="float"/> to <see cref="string"/>. <br />
        /// 将 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string CastToString(this float number) => StrConvX.FloatToString(number);

        /// <summary>
        /// Cast <see cref="float"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string CastToString(this float number, int digits) => StrConvX.FloatToString(number, digits);

        /// <summary>
        /// Cast nullable <see cref="float"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string CastToString(this float? number) => StrConvX.FloatToString(number);

        /// <summary>
        /// Cast nullable <see cref="float"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string CastToString(this float? number, int digits) => StrConvX.FloatToString(number, digits);

        /// <summary>
        /// Cast <see cref="double"/> to <see cref="string"/>. <br />
        /// 将 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string CastToString(this double number) => StrConvX.DoubleToString(number);

        /// <summary>
        /// Cast <see cref="double"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string CastToString(this double number, int digits) => StrConvX.DoubleToString(number, digits);

        /// <summary>
        /// Cast nullable <see cref="double"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string CastToString(this double? number) => StrConvX.DoubleToString(number);

        /// <summary>
        /// Cast nullable <see cref="double"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string CastToString(this double? number, int digits) => StrConvX.DoubleToString(number, digits);

        /// <summary>
        /// Cast <see cref="decimal"/> to <see cref="string"/>. <br />
        /// 将 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this decimal number, string defaultVal = "") => StrConvX.DecimalToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="decimal"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this decimal number, int digits, string defaultVal = "") => StrConvX.DecimalToString(number, digits, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="decimal"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this decimal? number, string defaultVal = "") => StrConvX.DecimalToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="decimal"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this decimal? number, int digits, string defaultVal = "") => StrConvX.DecimalToString(number, digits, defaultVal);

        #endregion

        #region Cast Hex to String

        /// <summary>
        /// Convert the given hexadecimal value (string type) to a normal string.<br />
        /// Currently only hexadecimal is supported.<br />
        /// 将给定进制值（字符串类型）转换为普通字符串。<br />
        /// 目前只支持十六进制。
        /// </summary>
        /// <param name="originalStr"></param>
        /// <param name="fromStyle"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string CastToString(this string originalStr, ScaleStyles fromStyle = ScaleStyles.String, Encoding encoding = null)
        {
            return fromStyle switch
            {
                ScaleStyles.Hexadecimal => HexadecimalConv.ToString(originalStr, encoding),
                _ => originalStr
            };
        }

        #endregion

        #region Cast String to Enum

        /// <summary>
        /// Convert the given string to an enumerated type. <br />
        /// 将给定的字符串转换为枚举类型。
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string str) where TEnum : struct, Enum => EnumConvX.StringToEnum<TEnum>(str);

        /// <summary>
        /// Convert the given string to an enumerated type. <br />
        /// 将给定的字符串转换为枚举类型。
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str">     </param>
        /// <param name="ignoreCase"> 是否区分大小写 </param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string str, bool ignoreCase) where TEnum : struct, Enum => EnumConvX.StringToEnum<TEnum>(str, ignoreCase);

        /// <summary>
        /// Convert the given string to an enumerated type. <br />
        /// 将给定的字符串转换为枚举类型。
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string str, TEnum defaultVal) where TEnum : struct, Enum => EnumConvX.StringToEnum(str, defaultVal);

        /// <summary>
        /// Convert the given string to an enumerated type. <br />
        /// 将给定的字符串转换为枚举类型。
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str"></param>
        /// <param name="ignoreCase">是否区分大小写</param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string str, bool ignoreCase, TEnum defaultVal) where TEnum : struct, Enum => EnumConvX.StringToEnum(str, defaultVal, ignoreCase);

        #endregion

        #region Cast String to Guid

        /// <summary>
        /// To GUID <br />
        /// 将字符串转换为 Guid。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid CastToGuid(this string str) => GuidConvX.StringToGuid(str);

        /// <summary>
        /// To GUID <br />
        /// 将字符串转换为 Guid。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid CastToGuid(this string str, Guid defaultVal) => GuidConvX.StringToGuid(str, defaultVal);

        /// <summary>
        /// To nullable GUID. <br />
        /// 将字符串转换为可空 Guid。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid? CastToNullableGuid(this string str) => GuidConvX.StringToNullableGuid(str);

        #endregion

    }
}