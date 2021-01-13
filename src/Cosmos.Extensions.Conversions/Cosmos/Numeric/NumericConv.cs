using Cosmos.Conversions.Common.Core;

namespace Cosmos.Numeric
{
    /// <summary>
    /// Numeric Conversion Utilities
    /// </summary>
    public static class NumericConv
    {
        #region Byte

        /// <summary>
        /// Convert <see cref="object"/> to <see cref="byte"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static byte ToByte(object obj, byte defaultVal = default) => NumConvX.ObjectToByte(obj, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="byte"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static byte ToByte(string text, byte defaultVal = default) => NumConvX.StringToByte(text, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="byte"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte? ToNullableByte(object obj) => NumConvX.ObjectToNullableByte(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="byte"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static byte? ToNullableByte(string text) => NumConvX.StringToNullableByte(text);

        #endregion
        
        #region SByte

        /// <summary>
        /// Convert <see cref="object"/> to <see cref="sbyte"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static sbyte ToSByte(object obj, sbyte defaultVal = default) => NumConvX.ObjectToSByte(obj, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="sbyte"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static sbyte ToSByte(string text, sbyte defaultVal = default) => NumConvX.StringToSByte(text, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="sbyte"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static sbyte? ToNullableSByte(object obj) => NumConvX.ObjectToNullableSByte(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="sbyte"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static sbyte? ToNullableSByte(string text) => NumConvX.StringToNullableSByte(text);

        #endregion
        
        #region Int16/short

        /// <summary>
        /// Convert <see cref="object"/> to <see cref="short"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static short ToInt16(object obj, short defaultVal = default) => NumConvX.ObjectToInt16(obj, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="short"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static short ToInt16(string text, short defaultVal = default) => NumConvX.StringToInt16(text, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="short"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static short? ToNullableInt16(object obj) => NumConvX.ObjectToNullableInt16(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="short"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static short? ToNullableInt16(string text) => NumConvX.StringToNullableInt16(text);

        #endregion

        #region UInt16/ushort

        /// <summary>
        /// Convert <see cref="object"/> to <see cref="ushort"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ushort ToUInt16(object obj, ushort defaultVal = default) => NumConvX.ObjectToUInt16(obj, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="ushort"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ushort ToUInt16(string text, ushort defaultVal = default) => NumConvX.StringToUInt16(text, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ushort? ToNullableUInt16(object obj) => NumConvX.ObjectToNullableUInt16(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static ushort? ToNullableUInt16(string text) => NumConvX.StringToNullableUInt16(text);

        #endregion

        #region Int32/int

        /// <summary>
        /// Convert <see cref="object"/> to <see cref="int"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int ToInt32(object obj, int defaultVal = default) => NumConvX.ObjectToInt32(obj, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="int"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int ToInt32(string text, int defaultVal = default) => NumConvX.StringToInt32(text, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="int"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int? ToNullableInt32(object obj) => NumConvX.ObjectToNullableInt32(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="int"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int? ToNullableInt32(string text) => NumConvX.StringToNullableInt32(text);

        #endregion

        #region UInt32/uint

        /// <summary>
        /// Convert <see cref="object"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static uint ToUInt32(object obj, uint defaultVal = default) => NumConvX.ObjectToUInt32(obj, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static uint ToUInt32(string text, uint defaultVal = default) => NumConvX.StringToUInt32(text, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static uint? ToNullableUInt32(object obj) => NumConvX.ObjectToNullableUInt32(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static uint? ToNullableUInt32(string text) => NumConvX.StringToNullableUInt32(text);

        #endregion

        #region Int64/long

        /// <summary>
        /// Convert <see cref="object"/> to <see cref="long"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static long ToInt64(object obj, long defaultVal = default) => NumConvX.ObjectToInt64(obj, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="long"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static long ToInt64(string text, long defaultVal = default) => NumConvX.StringToInt64(text, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="long"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long? ToNullableInt64(object obj) => NumConvX.ObjectToNullableInt64(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="long"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static long? ToNullableInt64(string text) => NumConvX.StringToNullableInt64(text);

        #endregion

        #region UInt64/ulong

        /// <summary>
        /// Convert <see cref="object"/> to <see cref="ulong"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ulong ToUInt64(object obj, ulong defaultVal = default) => NumConvX.ObjectToUInt64(obj, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="ulong"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ulong ToUInt64(string text, ulong defaultVal = default) => NumConvX.StringToUInt64(text, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ulong? ToNullableUInt64(object obj) => NumConvX.ObjectToNullableUInt64(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static ulong? ToNullableUInt64(string text) => NumConvX.StringToNullableUInt64(text);

        #endregion

        #region Float32/float

        /// <summary>
        /// Convert <see cref="object"/> to <see cref="float"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static float ToFloat(object obj, float defaultVal = 0F) => NumConvX.ObjectToFloat(obj, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="float"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static float ToFloat(string text, float defaultVal = 0F) => NumConvX.StringToFloat(text, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="float"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float? ToNullableFloat(object obj) => NumConvX.ObjectToNullableFloat(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="float"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static float? ToNullableFloat(string text) => NumConvX.StringToNullableFloat(text);

        #endregion

        #region Float64/double

        /// <summary>
        /// Convert <see cref="object"/> to <see cref="double"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static double ToDouble(object obj, double defaultVal = 0D) => NumConvX.ObjectToDouble(obj, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="double"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static double ToDouble(string text, double defaultVal = 0D) => NumConvX.StringToDouble(text, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="double"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double? ToNullableDouble(object obj) => NumConvX.ObjectToNullableDouble(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="double"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static double? ToNullableDouble(string text) => NumConvX.StringToNullableDouble(text);

        /// <summary>
        /// Convert <see cref="object"/> to <see cref="double"/> with specified precision.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static double ToRoundDouble(object obj, int digits, double defaultVal = 0D) => NumConvX.ObjectToRoundDouble(obj, digits, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="double"/> with specified precision.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static double ToRoundDouble(string text, int digits, double defaultVal = 0D) => NumConvX.StringToRoundDouble(text, digits, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="double"/> with specified precision.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static double? ToRoundNullableDouble(object obj, int digits) => NumConvX.ObjectToNullableRoundDouble(obj, digits);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="double"/> with specified precision.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static double? ToRoundNullableDouble(string text, int digits) => NumConvX.StringToNullableRoundDouble(text, digits);

        #endregion

        #region Decimal/decimal

        /// <summary>
        /// Convert <see cref="object"/> to <see cref="decimal"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object obj, decimal defaultVal = 0M) => NumConvX.ObjectToDecimal(obj, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="decimal"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static decimal ToDecimal(string text, decimal defaultVal = 0M) => NumConvX.StringToDecimal(text, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal? ToNullableDecimal(object obj) => NumConvX.ObjectToNullableDecimal(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static decimal? ToNullableDecimal(string text) => NumConvX.StringToNullableDecimal(text);

        /// <summary>
        /// Convert <see cref="object"/> to <see cref="decimal"/> with specified precision.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static decimal ToRoundDecimal(object obj, int digits, decimal defaultVal = 0M) => NumConvX.ObjectToRoundDecimal(obj, digits, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="decimal"/> with specified precision.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static decimal ToRoundDecimal(string text, int digits, decimal defaultVal = 0M) => NumConvX.StringToRoundDecimal(text, digits, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="decimal"/> with specified precision.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static decimal? ToRoundNullableDecimal(object obj, int digits) => NumConvX.ObjectToNullableRoundDecimal(obj, digits);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="decimal"/> with specified precision.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static decimal? ToRoundNullableDecimal(string text, int digits) => NumConvX.StringToNullableRoundDecimal(text, digits);

        #endregion
    }
}