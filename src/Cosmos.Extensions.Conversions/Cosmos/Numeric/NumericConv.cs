using Cosmos.Conversions.Common.Core;

namespace Cosmos.Numeric
{
    /// <summary>
    /// Numeric Conversion Utilities
    /// </summary>
    public static class NumericConv
    {
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
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static short ToInt16(string str, short defaultVal = default) => NumConvX.StringToInt16(str, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="short"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static short? ToNullableInt16(object obj) => NumConvX.ObjectToNullableInt16(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="short"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static short? ToNullableInt16(string str) => NumConvX.StringToNullableInt16(str);

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
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ushort ToUInt16(string str, ushort defaultVal = default) => NumConvX.StringToUInt16(str, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ushort? ToNullableUInt16(object obj) => NumConvX.ObjectToNullableUInt16(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static ushort? ToNullableUInt16(string str) => NumConvX.StringToNullableUInt16(str);

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
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int ToInt32(string str, int defaultVal = default) => NumConvX.StringToInt32(str, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="int"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int? ToNullableInt32(object obj) => NumConvX.ObjectToNullableInt32(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="int"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int? ToNullableInt32(string str) => NumConvX.StringToNullableInt32(str);

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
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static uint ToUInt32(string str, uint defaultVal = default) => NumConvX.StringToUInt32(str, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static uint? ToNullableUInt32(object obj) => NumConvX.ObjectToNullableUInt32(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static uint? ToNullableUInt32(string str) => NumConvX.StringToNullableUInt32(str);

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
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static long ToInt64(string str, long defaultVal = default) => NumConvX.StringToInt64(str, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="long"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long? ToNullableInt64(object obj) => NumConvX.ObjectToNullableInt64(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="long"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long? ToNullableInt64(string str) => NumConvX.StringToNullableInt64(str);

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
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ulong ToUInt64(string str, ulong defaultVal = default) => NumConvX.StringToUInt64(str, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ulong? ToNullableUInt64(object obj) => NumConvX.ObjectToNullableUInt64(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static ulong? ToNullableUInt64(string str) => NumConvX.StringToNullableUInt64(str);

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
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static float ToFloat(string str, float defaultVal = 0F) => NumConvX.StringToFloat(str, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="float"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float? ToNullableFloat(object obj) => NumConvX.ObjectToNullableFloat(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="float"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static float? ToNullableFloat(string str) => NumConvX.StringToNullableFloat(str);

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
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static double ToDouble(string str, double defaultVal = 0D) => NumConvX.StringToDouble(str, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="double"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double? ToNullableDouble(object obj) => NumConvX.ObjectToNullableDouble(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="double"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double? ToNullableDouble(string str) => NumConvX.StringToNullableDouble(str);

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
        /// <param name="str"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static double ToRoundDouble(string str, int digits, double defaultVal = 0D) => NumConvX.StringToRoundDouble(str, digits, defaultVal);

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
        /// <param name="str"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static double? ToRoundNullableDouble(string str, int digits) => NumConvX.StringToNullableRoundDouble(str, digits);

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
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static decimal ToDecimal(string str, decimal defaultVal = 0M) => NumConvX.StringToDecimal(str, defaultVal);

        /// <summary>
        /// Convert <see cref="object"/> to nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal? ToNullableDecimal(object obj) => NumConvX.ObjectToNullableDecimal(obj);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal? ToNullableDecimal(string str) => NumConvX.StringToNullableDecimal(str);

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
        /// <param name="str"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static decimal ToRoundDecimal(string str, int digits, decimal defaultVal = 0M) => NumConvX.StringToRoundDecimal(str, digits, defaultVal);

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
        /// <param name="str"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static decimal? ToRoundNullableDecimal(string str, int digits) => NumConvX.StringToNullableRoundDecimal(str, digits);

        #endregion
    }
}