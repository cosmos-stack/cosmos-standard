using Cosmos.Conversions;
using Cosmos.Conversions.StringDeterminers;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// Conversion extensions
    /// </summary>
    public static partial class ConversionExtensions {

        private static TTo CastStringToNumericProxy<TFrom, TTo>(TFrom from, TTo defaultVal) {
            var safeString = from.ToString();
            var safeDefVal = defaultVal.ToString();
            object result;

            var toType = typeof(TTo);
            if (toType == typeof(short))
                result = safeString.CastToInt16(safeDefVal.CastToInt16());
            else if (toType == typeof(ushort))
                result = safeString.CastToUInt16(safeDefVal.CastToUInt16());
            else if (toType == typeof(int))
                result = safeString.CastToInt32(safeDefVal.CastToInt32());
            else if (toType == typeof(uint))
                result = safeString.CastToUInt32(safeDefVal.CastToUInt32());
            else if (toType == typeof(long))
                result = safeString.CastToInt64(safeDefVal.CastToInt64());
            else if (toType == typeof(ulong))
                result = safeString.CastToUInt64(safeDefVal.CastToUInt64());
            else if (toType == typeof(float))
                result = safeString.CastToFloat(safeDefVal.CastToFloat());
            else if (toType == typeof(double))
                result = safeString.CastToDouble(safeDefVal.CastToDouble());
            else
                result = safeString.CastToDecimal(safeDefVal.CastToDecimal());

            return (TTo) result;
        }

        /// <summary>
        /// To short
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static short CastToShort(this string str, short defaultVal = default)
            => StringShortDeterminer.To(str, defaultVal);

        /// <summary>
        /// To short
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static short CastToShort(this string str, params IConversionImpl<string, short>[] impls)
            => StringShortDeterminer.To(str, impls);

        /// <summary>
        /// To ushort
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ushort CastToUShort(this string str, ushort defaultVal = default)
            => StringUShortDeterminer.To(str, defaultVal);

        /// <summary>
        /// To ushort
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static ushort CastToUShort(this string str, params IConversionImpl<string, ushort>[] impls)
            => StringUShortDeterminer.To(str, impls);

        /// <summary>
        /// To int32
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int CastToInt(this string str, int defaultVal = default)
            => StringIntDeterminer.To(str, defaultVal);

        /// <summary>
        /// To int32
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static int CastToInt(this string str, params IConversionImpl<string, int>[] impls)
            => StringIntDeterminer.To(str, impls);

        /// <summary>
        /// To uint32
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static uint CastToUInt(this string str, uint defaultVal = default)
            => StringUIntDeterminer.To(str, defaultVal);

        /// <summary>
        /// To uint32
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static uint CastToUInt(this string str, params IConversionImpl<string, uint>[] impls)
            => StringUIntDeterminer.To(str, impls);

        /// <summary>
        /// To long
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static long CastToLong(this string str, long defaultVal = default)
            => StringLongDeterminer.To(str, defaultVal);

        /// <summary>
        /// To long
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static long CastToLong(this string str, params IConversionImpl<string, long>[] impls)
            => StringLongDeterminer.To(str, impls);

        /// <summary>
        /// To ulong
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ulong CastToULong(this string str, ulong defaultVal = default)
            => StringULongDeterminer.To(str, defaultVal);

        /// <summary>
        /// To ulong
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static ulong CastToULong(this string str, params IConversionImpl<string, ulong>[] impls)
            => StringULongDeterminer.To(str, impls);

        /// <summary>
        /// To float
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static float CastToFloat(this string str, float defaultVal = default)
            => StringFloatDeterminer.To(str, defaultVal);

        /// <summary>
        /// To float
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static float CastToFloat(this string str, params IConversionImpl<string, float>[] impls)
            => StringFloatDeterminer.To(str, impls);

        /// <summary>
        /// To float
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static double CastToDouble(this string str, double defaultVal = default)
            => StringDoubleDeterminer.To(str, defaultVal);

        /// <summary>
        /// To float
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static double CastToDouble(this string str, params IConversionImpl<string, double>[] impls)
            => StringDoubleDeterminer.To(str, impls);

        /// <summary>
        /// To decimal
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static decimal CastToDecimal(this string str, decimal defaultVal = default)
            => StringDecimalDeterminer.To(str, defaultVal);

        /// <summary>
        /// To decimal
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static decimal CastToDecimal(this string str, params IConversionImpl<string, decimal>[] impls)
            => StringDecimalDeterminer.To(str, impls);

        /// <summary>
        /// To int16
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static short CastToInt16(this string str, short defaultVal = default) => str.CastToShort(defaultVal);

        /// <summary>
        /// To int16
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static short CastToInt16(this string str, params IConversionImpl<string, short>[] impls) => str.CastToShort(impls);

        /// <summary>
        /// To uint16
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ushort CastToUInt16(this string str, ushort defaultVal = default) => str.CastToUShort(defaultVal);

        /// <summary>
        /// To uint16
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static ushort CastToUInt16(this string str, params IConversionImpl<string, ushort>[] impls) => str.CastToUShort(impls);

        /// <summary>
        /// To int32
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int CastToInt32(this string str, int defaultVal = default) => str.CastToInt(defaultVal);

        /// <summary>
        /// To int32
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static int CastToInt32(this string str, params IConversionImpl<string, int>[] impls) => str.CastToInt(impls);

        /// <summary>
        /// To uint32
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static uint CastToUInt32(this string str, uint defaultVal = default) => str.CastToUInt(defaultVal);

        /// <summary>
        /// To uint32
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static uint CastToUInt32(this string str, params IConversionImpl<string, uint>[] impls) => str.CastToUInt(impls);

        /// <summary>
        /// To int64
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static long CastToInt64(this string str, long defaultVal = default) => str.CastToLong(defaultVal);

        /// <summary>
        /// To int64
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static long CastToInt64(this string str, params IConversionImpl<string, long>[] impls) => str.CastToLong(impls);

        /// <summary>
        /// To uint64
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ulong CastToUInt64(this string str, ulong defaultVal = default) => str.CastToULong(defaultVal);

        /// <summary>
        /// To uint64
        /// </summary>
        /// <param name="str"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        public static ulong CastToUInt64(this string str, params IConversionImpl<string, ulong>[] impls) => str.CastToULong(impls);
    }
}