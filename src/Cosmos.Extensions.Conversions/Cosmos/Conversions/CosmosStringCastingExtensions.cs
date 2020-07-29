using System;
using System.Text;
using Cosmos.Conversions.Core;
using Cosmos.Conversions.Scale;

namespace Cosmos.Conversions
{
    /// <summary>
    /// Cosmos <see cref="string"/> casting extensions.
    /// </summary>
    public static class CosmosStringCastingExtensions
    {
        #region Cast Object to String

        /// <summary>
        /// Cast <see cref="object"/> to <see cref="string"/>. <br />
        /// 将对象 <see cref="object"/> 转换为字符串。
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        public static string CastToString(this object that) => StringConv.ObjectSafeToString(that);

        #endregion

        #region Cast Numeric to String

        /// <summary>
        /// Cast <see cref="short"/> to <see cref="string"/>. <br />
        /// 将 <see cref="short"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this short number, string defaultVal = "") => StringConv.Int16ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="short"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="short"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this short? number, string defaultVal = "") => StringConv.Int16ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="ushort"/> to <see cref="string"/>. <br />
        /// 将 <see cref="ushort"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ushort number, string defaultVal = "") => StringConv.UInt16ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="ushort"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="ushort"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ushort? number, string defaultVal = "") => StringConv.UInt16ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="int"/> to <see cref="string"/>. <br />
        /// 将 <see cref="int"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this int number, string defaultVal = "") => StringConv.Int32ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="int"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="int"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this int? number, string defaultVal = "") => StringConv.Int32ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="uint"/> to <see cref="string"/>. <br />
        /// 将 <see cref="uint"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this uint number, string defaultVal = "") => StringConv.UInt32ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="uint"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="uint"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this uint? number, string defaultVal = "") => StringConv.UInt32ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="long"/> to <see cref="string"/>. <br />
        /// 将 <see cref="long"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this long number, string defaultVal = "") => StringConv.Int64ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="long"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="long"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this long? number, string defaultVal = "") => StringConv.Int64ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="ulong"/> to <see cref="string"/>. <br />
        /// 将 <see cref="ulong"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ulong number, string defaultVal = "") => StringConv.UInt64ToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="ulong"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="ulong"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this ulong? number, string defaultVal = "") => StringConv.UInt64ToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="float"/> to <see cref="string"/>. <br />
        /// 将 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string CastToString(this float number) => StringConv.FloatToString(number);

        /// <summary>
        /// Cast <see cref="float"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string CastToString(this float number, int digits) => StringConv.FloatToString(number, digits);

        /// <summary>
        /// Cast nullable <see cref="float"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string CastToString(this float? number) => StringConv.FloatToString(number);

        /// <summary>
        /// Cast nullable <see cref="float"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string CastToString(this float? number, int digits) => StringConv.FloatToString(number, digits);

        /// <summary>
        /// Cast <see cref="double"/> to <see cref="string"/>. <br />
        /// 将 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string CastToString(this double number) => StringConv.DoubleToString(number);

        /// <summary>
        /// Cast <see cref="double"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string CastToString(this double number, int digits) => StringConv.DoubleToString(number, digits);

        /// <summary>
        /// Cast nullable <see cref="double"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string CastToString(this double? number) => StringConv.DoubleToString(number);

        /// <summary>
        /// Cast nullable <see cref="double"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string CastToString(this double? number, int digits) => StringConv.DoubleToString(number, digits);

        /// <summary>
        /// Cast <see cref="decimal"/> to <see cref="string"/>. <br />
        /// 将 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this decimal number, string defaultVal = "") => StringConv.DecimalToString(number, defaultVal);

        /// <summary>
        /// Cast <see cref="decimal"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this decimal number, int digits, string defaultVal = "") => StringConv.DecimalToString(number, digits, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="decimal"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this decimal? number, string defaultVal = "") => StringConv.DecimalToString(number, defaultVal);

        /// <summary>
        /// Cast nullable <see cref="decimal"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string CastToString(this decimal? number, int digits, string defaultVal = "") => StringConv.DecimalToString(number, digits, defaultVal);

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
                ScaleStyles.Hexadecimal => HexadecimalConverter.ToString(originalStr, encoding),
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
        public static TEnum CastToEnum<TEnum>(this string str) where TEnum : struct, Enum => EnumConv.StringToEnum<TEnum>(str);

        /// <summary>
        /// Convert the given string to an enumerated type. <br />
        /// 将给定的字符串转换为枚举类型。
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str">     </param>
        /// <param name="ignoreCase"> 是否区分大小写 </param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string str, bool ignoreCase) where TEnum : struct, Enum => EnumConv.StringToEnum<TEnum>(str, ignoreCase);

        /// <summary>
        /// Convert the given string to an enumerated type. <br />
        /// 将给定的字符串转换为枚举类型。
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string str, TEnum defaultVal) where TEnum : struct, Enum => EnumConv.StringToEnum(str, defaultVal);

        /// <summary>
        /// Convert the given string to an enumerated type. <br />
        /// 将给定的字符串转换为枚举类型。
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="str"></param>
        /// <param name="ignoreCase">是否区分大小写</param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string str, bool ignoreCase, TEnum defaultVal) where TEnum : struct, Enum => EnumConv.StringToEnum(str, defaultVal, ignoreCase);

        #endregion

        #region Cast String to Guid

        /// <summary>
        /// To GUID <br />
        /// 将字符串转换为 Guid。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid CastToGuid(this string str) => GuidConv.StringToGuid(str);

        /// <summary>
        /// To GUID <br />
        /// 将字符串转换为 Guid。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid CastToGuid(this string str, Guid defaultVal) => GuidConv.StringToGuid(str, defaultVal);

        /// <summary>
        /// To nullable GUID. <br />
        /// 将字符串转换为可空 Guid。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid? CastToNullableGuid(this string str) => GuidConv.StringToNullableGuid(str);

        #endregion

        #region Cast String to Numeric

        #region Int16/short

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="short"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static short CastToShort(this string str, short defaultVal = default) => NumericConv.StringToInt16(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="short"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static short CastToShort(this string str, params IConversionImpl<string, short>[] impls) => NumericConv.StringToInt16(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="short"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static short CastToShort<TEnum>(this TEnum @enum, short defaultVal = default) where TEnum : struct => NumericConv.EnumToInt16(@enum, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="short"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static short CastToInt16(this string str, short defaultVal = default) => NumericConv.StringToInt16(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="short"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static short CastToInt16(this string str, params IConversionImpl<string, short>[] impls) => NumericConv.StringToInt16(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="short"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static short CastToInt16<TEnum>(this TEnum @enum, short defaultVal = default) where TEnum : struct => NumericConv.EnumToInt16(@enum, defaultVal);

        #endregion

        #region UInt16/ushort

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ushort"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ushort CastToUShort(this string str, ushort defaultVal = default) => NumericConv.StringToUInt16(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ushort"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static ushort CastToUShort(this string str, params IConversionImpl<string, ushort>[] impls) => NumericConv.StringToUInt16(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="ushort"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static ushort CastToUShort<TEnum>(this TEnum @enum, ushort defaultVal = default) where TEnum : struct => NumericConv.EnumToUInt16(@enum, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ushort"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ushort CastToUInt16(this string str, ushort defaultVal = default) => NumericConv.StringToUInt16(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ushort"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static ushort CastToUInt16(this string str, params IConversionImpl<string, ushort>[] impls) => NumericConv.StringToUInt16(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="ushort"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static ushort CastToUInt16<TEnum>(this TEnum @enum, ushort defaultVal = default) where TEnum : struct => NumericConv.EnumToUInt16(@enum, defaultVal);

        #endregion

        #region Int32/int

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="int"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int CastToInt(this string str, int defaultVal = default) => NumericConv.StringToInt32(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="int"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static int CastToInt(this string str, params IConversionImpl<string, int>[] impls) => NumericConv.StringToInt32(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="int"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static int CastToInt<TEnum>(this TEnum @enum, int defaultVal = default) where TEnum : struct => NumericConv.EnumToInt32(@enum, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="int"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int CastToInt32(this string str, int defaultVal = default) => NumericConv.StringToInt32(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="int"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static int CastToInt32(this string str, params IConversionImpl<string, int>[] impls) => NumericConv.StringToInt32(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="int"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static int CastToInt32<TEnum>(this TEnum @enum, int defaultVal = default) where TEnum : struct => NumericConv.EnumToInt32(@enum, defaultVal);

        #endregion

        #region UInt32/uint

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="uint"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static uint CastToUInt(this string str, uint defaultVal = default) => NumericConv.StringToUInt32(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="uint"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static uint CastToUInt(this string str, params IConversionImpl<string, uint>[] impls) => NumericConv.StringToUInt32(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="uint"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static uint CastToUInt<TEnum>(this TEnum @enum, uint defaultVal = default) where TEnum : struct => NumericConv.EnumToUInt32(@enum, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="uint"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static uint CastToUInt32(this string str, uint defaultVal = default) => NumericConv.StringToUInt32(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="uint"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static uint CastToUInt32(this string str, params IConversionImpl<string, uint>[] impls) => NumericConv.StringToUInt32(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="uint"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static uint CastToUInt32<TEnum>(this TEnum @enum, uint defaultVal = default) where TEnum : struct => NumericConv.EnumToUInt32(@enum, defaultVal);

        #endregion

        #region Int64/long

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="long"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static long CastToLong(this string str, long defaultVal = default) => NumericConv.StringToInt64(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="long"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static long CastToLong(this string str, params IConversionImpl<string, long>[] impls) => NumericConv.StringToInt64(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="long"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static long CastToLong<TEnum>(this TEnum @enum, long defaultVal = default) where TEnum : struct => NumericConv.EnumToInt64(@enum, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="long"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static long CastToInt64(this string str, long defaultVal = default) => NumericConv.StringToInt64(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="long"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static long CastToInt64(this string str, params IConversionImpl<string, long>[] impls) => NumericConv.StringToInt64(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="long"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static long CastToInt64<TEnum>(this TEnum @enum, long defaultVal = default) where TEnum : struct => NumericConv.EnumToInt64(@enum, defaultVal);

        #endregion

        #region UInt64/ulong

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ulong"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ulong CastToULong(this string str, ulong defaultVal = default) => NumericConv.StringToUInt64(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ulong"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static ulong CastToULong(this string str, params IConversionImpl<string, ulong>[] impls) => NumericConv.StringToUInt64(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="ulong"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static ulong CastToULong<TEnum>(this TEnum @enum, ulong defaultVal = default) where TEnum : struct => NumericConv.EnumToUInt64(@enum, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ulong"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ulong CastToUInt64(this string str, ulong defaultVal = default) => NumericConv.StringToUInt64(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ulong"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static ulong CastToUInt64(this string str, params IConversionImpl<string, ulong>[] impls) => NumericConv.StringToUInt64(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="ulong"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static ulong CastToUInt64<TEnum>(this TEnum @enum, ulong defaultVal = default) where TEnum : struct => NumericConv.EnumToUInt64(@enum, defaultVal);

        #endregion

        #region Float32/float

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="float"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static float CastToFloat(this string str, float defaultVal = default) => NumericConv.StringToFloat(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="float"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static float CastToFloat(this string str, params IConversionImpl<string, float>[] impls) => NumericConv.StringToFloat(str, impls);

        #endregion

        #region Float64/double

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="double"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static double CastToDouble(this string str, double defaultVal = default) => NumericConv.StringToDouble(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="double"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static double CastToDouble(this string str, params IConversionImpl<string, double>[] impls) => NumericConv.StringToDouble(str, impls);

        #endregion

        #region Decimal/decimal

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="decimal"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static decimal CastToDecimal(this string str, decimal defaultVal = default) => NumericConv.StringToDecimal(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="decimal"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static decimal CastToDecimal(this string str, params IConversionImpl<string, decimal>[] impls) => NumericConv.StringToDecimal(str, impls);

        #endregion

        #endregion

        #region Cast String to DateTime

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="DateTime"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTime CastToDateTime(this string str, DateTime defaultVal = default) => DateTimeConv.StringToDateTime(str, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="DateTime"/>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? CastToNullableDateTime(this string str) => DateTimeConv.StringToNullableDateTime(str);

        #endregion

        #region Cast String to DateTimeOffset

        /// <summary>
        /// To DateTimeOffset
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeOffset CastToDateTimeOffset(this string str, DateTimeOffset defaultVal = default) => DateTimeConv.StringToDateTimeOffset(str, defaultVal);

        /// <summary>
        /// To nullable DateTimeOffset
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTimeOffset? CastToNullableDateTimeOffset(this string str) => DateTimeConv.StringToNullableDateTimeOffset(str);

        #endregion

        #region Cast String to TimeSpan

        /// <summary>
        /// To TimeSpan
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TimeSpan CastToTimeSpan(this string str, TimeSpan defaultVal = default) => DateTimeConv.StringToTimeSpan(str, defaultVal);

        /// <summary>
        /// To nullable TimeSpan
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static TimeSpan? CastToNullableTimeSpan(this string str) => DateTimeConv.StringToNullableTimeSpan(str);

        #endregion
    }
}