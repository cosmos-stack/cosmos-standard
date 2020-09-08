using Cosmos.Conversions;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Text
{
    /// <summary>
    /// Cosmos <see cref="string"/> casting extensions.
    /// </summary>
    public static partial class StringCastingExtensions
    {
        #region Cast String to Numeric

        #region Int16/short

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="short"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static short CastToShort(this string str, short defaultVal = default) => NumConvX.StringToInt16(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="short"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static short CastToShort(this string str, params IConversionImpl<string, short>[] impls) => NumConvX.StringToInt16(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="short"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static short CastToShort<TEnum>(this TEnum @enum, short defaultVal = default) where TEnum : struct => NumConvX.EnumToInt16(@enum, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="short"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static short CastToInt16(this string str, short defaultVal = default) => NumConvX.StringToInt16(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="short"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static short CastToInt16(this string str, params IConversionImpl<string, short>[] impls) => NumConvX.StringToInt16(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="short"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static short CastToInt16<TEnum>(this TEnum @enum, short defaultVal = default) where TEnum : struct => NumConvX.EnumToInt16(@enum, defaultVal);

        #endregion

        #region UInt16/ushort

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ushort"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ushort CastToUShort(this string str, ushort defaultVal = default) => NumConvX.StringToUInt16(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ushort"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static ushort CastToUShort(this string str, params IConversionImpl<string, ushort>[] impls) => NumConvX.StringToUInt16(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="ushort"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static ushort CastToUShort<TEnum>(this TEnum @enum, ushort defaultVal = default) where TEnum : struct => NumConvX.EnumToUInt16(@enum, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ushort"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ushort CastToUInt16(this string str, ushort defaultVal = default) => NumConvX.StringToUInt16(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ushort"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static ushort CastToUInt16(this string str, params IConversionImpl<string, ushort>[] impls) => NumConvX.StringToUInt16(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="ushort"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static ushort CastToUInt16<TEnum>(this TEnum @enum, ushort defaultVal = default) where TEnum : struct => NumConvX.EnumToUInt16(@enum, defaultVal);

        #endregion

        #region Int32/int

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="int"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int CastToInt(this string str, int defaultVal = default) => NumConvX.StringToInt32(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="int"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static int CastToInt(this string str, params IConversionImpl<string, int>[] impls) => NumConvX.StringToInt32(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="int"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static int CastToInt<TEnum>(this TEnum @enum, int defaultVal = default) where TEnum : struct => NumConvX.EnumToInt32(@enum, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="int"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int CastToInt32(this string str, int defaultVal = default) => NumConvX.StringToInt32(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="int"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static int CastToInt32(this string str, params IConversionImpl<string, int>[] impls) => NumConvX.StringToInt32(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="int"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static int CastToInt32<TEnum>(this TEnum @enum, int defaultVal = default) where TEnum : struct => NumConvX.EnumToInt32(@enum, defaultVal);

        #endregion

        #region UInt32/uint

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="uint"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static uint CastToUInt(this string str, uint defaultVal = default) => NumConvX.StringToUInt32(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="uint"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static uint CastToUInt(this string str, params IConversionImpl<string, uint>[] impls) => NumConvX.StringToUInt32(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="uint"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static uint CastToUInt<TEnum>(this TEnum @enum, uint defaultVal = default) where TEnum : struct => NumConvX.EnumToUInt32(@enum, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="uint"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static uint CastToUInt32(this string str, uint defaultVal = default) => NumConvX.StringToUInt32(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="uint"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static uint CastToUInt32(this string str, params IConversionImpl<string, uint>[] impls) => NumConvX.StringToUInt32(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="uint"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static uint CastToUInt32<TEnum>(this TEnum @enum, uint defaultVal = default) where TEnum : struct => NumConvX.EnumToUInt32(@enum, defaultVal);

        #endregion

        #region Int64/long

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="long"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static long CastToLong(this string str, long defaultVal = default) => NumConvX.StringToInt64(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="long"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static long CastToLong(this string str, params IConversionImpl<string, long>[] impls) => NumConvX.StringToInt64(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="long"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static long CastToLong<TEnum>(this TEnum @enum, long defaultVal = default) where TEnum : struct => NumConvX.EnumToInt64(@enum, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="long"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static long CastToInt64(this string str, long defaultVal = default) => NumConvX.StringToInt64(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="long"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static long CastToInt64(this string str, params IConversionImpl<string, long>[] impls) => NumConvX.StringToInt64(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="long"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static long CastToInt64<TEnum>(this TEnum @enum, long defaultVal = default) where TEnum : struct => NumConvX.EnumToInt64(@enum, defaultVal);

        #endregion

        #region UInt64/ulong

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ulong"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ulong CastToULong(this string str, ulong defaultVal = default) => NumConvX.StringToUInt64(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ulong"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static ulong CastToULong(this string str, params IConversionImpl<string, ulong>[] impls) => NumConvX.StringToUInt64(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="ulong"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static ulong CastToULong<TEnum>(this TEnum @enum, ulong defaultVal = default) where TEnum : struct => NumConvX.EnumToUInt64(@enum, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ulong"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ulong CastToUInt64(this string str, ulong defaultVal = default) => NumConvX.StringToUInt64(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ulong"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static ulong CastToUInt64(this string str, params IConversionImpl<string, ulong>[] impls) => NumConvX.StringToUInt64(str, impls);

        /// <summary>
        /// Cast TEnum to <see cref="ulong"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static ulong CastToUInt64<TEnum>(this TEnum @enum, ulong defaultVal = default) where TEnum : struct => NumConvX.EnumToUInt64(@enum, defaultVal);

        #endregion

        #region Float32/float

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="float"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static float CastToFloat(this string str, float defaultVal = default) => NumConvX.StringToFloat(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="float"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static float CastToFloat(this string str, params IConversionImpl<string, float>[] impls) => NumConvX.StringToFloat(str, impls);

        #endregion

        #region Float64/double

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="double"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static double CastToDouble(this string str, double defaultVal = default) => NumConvX.StringToDouble(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="double"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static double CastToDouble(this string str, params IConversionImpl<string, double>[] impls) => NumConvX.StringToDouble(str, impls);

        #endregion

        #region Decimal/decimal

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="decimal"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static decimal CastToDecimal(this string str, decimal defaultVal = default) => NumConvX.StringToDecimal(str, defaultVal);

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="decimal"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static decimal CastToDecimal(this string str, params IConversionImpl<string, decimal>[] impls) => NumConvX.StringToDecimal(str, impls);

        #endregion

        #endregion
    }
}