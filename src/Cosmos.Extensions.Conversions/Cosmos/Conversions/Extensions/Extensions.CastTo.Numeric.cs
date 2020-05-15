using Cosmos.Conversions.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions {
    /// <summary>
    /// Extensions for CastTo opts
    /// </summary>
    public static partial class CastToExtensions {

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

    }
}