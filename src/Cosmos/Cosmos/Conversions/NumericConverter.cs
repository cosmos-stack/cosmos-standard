using System;
using Cosmos.Conversions.StringDeterminers;

namespace Cosmos.Conversions {
    /// <summary>
    /// Numeric Conversion Utilities
    /// </summary>
    public static class NumericConverter {
        /// <summary>
        /// To int16
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static short ToInt16(object obj, short defaultVal = default) {
            if (obj is null)
                return defaultVal;

            if (obj is string str)
                return StringShortDeterminer.To(str, defaultVal);

            str = obj.ToString();
            if (StringShortDeterminer.Is(str))
                return StringShortDeterminer.To(str, defaultVal);

            try {
                return Convert.ToInt16(ToDecimal(obj, defaultVal));
            } catch {
                return defaultVal;
            }
        }

        /// <summary>
        /// To nullable int16
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static short? ToNullableInt16(object obj) {
            if (obj is null)
                return null;

            if (obj is string str && StringShortDeterminer.Is(str))
                return StringShortDeterminer.To(str);

            str = obj.ToString();
            if (StringShortDeterminer.Is(str))
                return StringShortDeterminer.To(str);

            if (short.TryParse(obj.ToString(), out var ret))
                return ret;

            return null;
        }

        /// <summary>
        /// To uint16
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ushort ToUInt16(object obj, ushort defaultVal = default) {
            if (obj is null)
                return defaultVal;

            if (obj is string str)
                return StringUShortDeterminer.To(str, defaultVal);

            str = obj.ToString();
            if (StringUShortDeterminer.Is(str))
                return StringUShortDeterminer.To(str, defaultVal);

            try {
                return Convert.ToUInt16(ToDecimal(obj, defaultVal));
            } catch {
                return defaultVal;
            }
        }

        /// <summary>
        /// To nullable uint16
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ushort? ToNullableUInt16(object obj) {
            if (obj is null)
                return null;

            if (obj is string str && StringUShortDeterminer.Is(str))
                return StringUShortDeterminer.To(str);

            str = obj.ToString();
            if (StringUShortDeterminer.Is(str))
                return StringUShortDeterminer.To(str);

            if (ushort.TryParse(obj.ToString(), out var ret))
                return ret;

            return null;
        }

        /// <summary>
        /// To int32
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int ToInt32(object obj, int defaultVal = 0) {
            if (obj is null)
                return defaultVal;

            if (obj is string str)
                return StringIntDeterminer.To(str);

            str = obj.ToString();
            if (StringIntDeterminer.Is(str))
                return StringIntDeterminer.To(str, defaultVal);

            try {
                return Convert.ToInt32(ToDecimal(obj, defaultVal));
            } catch {
                return defaultVal;
            }
        }

        /// <summary>
        /// To nullable int32
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int? ToNullableInt32(object obj) {
            if (obj is null)
                return null;

            if (obj is string str && StringIntDeterminer.Is(str))
                return StringIntDeterminer.To(str);

            str = obj.ToString();
            if (StringIntDeterminer.Is(str))
                return StringIntDeterminer.To(str);

            if (int.TryParse(obj.ToString(), out var ret))
                return ret;

            return null;
        }

        /// <summary>
        /// To uint32
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static uint ToUInt32(object obj, uint defaultVal = 0) {
            if (obj is null)
                return defaultVal;

            if (obj is string str)
                return StringUIntDeterminer.To(str);

            str = obj.ToString();
            if (StringUIntDeterminer.Is(str))
                return StringUIntDeterminer.To(str, defaultVal);

            try {
                return Convert.ToUInt32(ToDecimal(obj, defaultVal));
            } catch {
                return defaultVal;
            }
        }

        /// <summary>
        /// To nullable uint32
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static uint? ToNullableUInt32(object obj) {
            if (obj is null)
                return null;

            if (obj is string str && StringUIntDeterminer.Is(str))
                return StringUIntDeterminer.To(str);

            str = obj.ToString();
            if (StringUIntDeterminer.Is(str))
                return StringUIntDeterminer.To(str);

            if (uint.TryParse(obj.ToString(), out var ret))
                return ret;

            return null;
        }

        /// <summary>
        /// To int64
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static long ToInt64(object obj, long defaultVal = 0) {
            if (obj is null)
                return defaultVal;

            if (obj is string str)
                return StringLongDeterminer.To(str);

            str = obj.ToString();
            if (StringLongDeterminer.Is(str))
                return StringLongDeterminer.To(str, defaultVal);

            try {
                return Convert.ToInt64(ToDecimal(obj, defaultVal));
            } catch {
                return defaultVal;
            }
        }

        /// <summary>
        /// To nullable int64
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static long? ToNullableInt64(object obj) {
            if (obj is null)
                return null;

            if (obj is string str && StringLongDeterminer.Is(str))
                return StringLongDeterminer.To(str);

            str = obj.ToString();
            if (StringLongDeterminer.Is(str))
                return StringLongDeterminer.To(str);

            if (long.TryParse(obj.ToString(), out var ret))
                return ret;

            return null;
        }

        /// <summary>
        /// To int64
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static ulong ToUInt64(object obj, ulong defaultVal = 0) {
            if (obj is null)
                return defaultVal;

            if (obj is string str)
                return StringULongDeterminer.To(str);

            str = obj.ToString();
            if (StringULongDeterminer.Is(str))
                return StringULongDeterminer.To(str, defaultVal);

            try {
                return Convert.ToUInt64(ToDecimal(obj, defaultVal));
            } catch {
                return defaultVal;
            }
        }

        /// <summary>
        /// To nullable uint64
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ulong? ToNullableUInt64(object obj) {
            if (obj is null)
                return null;

            if (obj is string str && StringULongDeterminer.Is(str))
                return StringULongDeterminer.To(str);

            str = obj.ToString();
            if (StringULongDeterminer.Is(str))
                return StringULongDeterminer.To(str);

            if (ulong.TryParse(obj.ToString(), out var ret))
                return ret;

            return null;
        }

        /// <summary>
        /// To float
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static float ToFloat(object obj, float defaultVal = 0F) {
            if (obj is null)
                return defaultVal;

            if (obj is string str)
                return StringFloatDeterminer.To(str);

            str = obj.ToString();
            return StringFloatDeterminer.To(str, defaultVal);
        }

        /// <summary>
        /// To nullable float
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float? ToNullableFloat(object obj) {
            if (obj is null)
                return null;

            if (obj is string str && StringFloatDeterminer.Is(str))
                return StringFloatDeterminer.To(str);

            str = obj.ToString();
            if (StringFloatDeterminer.Is(str))
                return StringFloatDeterminer.To(str);

            return null;
        }

        /// <summary>
        /// To double
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static double ToDouble(object obj, double defaultVal = 0D) {
            if (obj is null)
                return defaultVal;

            if (obj is string str)
                return StringDoubleDeterminer.To(str);

            str = obj.ToString();
            if (StringDoubleDeterminer.Is(str))
                return StringDoubleDeterminer.To(str, defaultVal);

            try {
                return Convert.ToDouble(ToDecimal(obj));
            } catch {
                return defaultVal;
            }
        }

        /// <summary>
        /// To nullable double
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static double? ToNullableDouble(object obj) {
            if (obj is null)
                return null;

            if (obj is string str && StringDoubleDeterminer.Is(str))
                return StringDoubleDeterminer.To(str);

            str = obj.ToString();
            if (StringDoubleDeterminer.Is(str))
                return StringDoubleDeterminer.To(str);

            if (double.TryParse(obj.ToString(), out var ret))
                return ret;

            return null;
        }

        /// <summary>
        /// To double with specified precision.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <param name="defaultRet"></param>
        /// <returns></returns>
        public static double ToRoundDouble(object obj, int digits, double defaultRet = 0D) {
            return Math.Round(ToDouble(obj, defaultRet), digits);
        }

        /// <summary>
        /// To nullable double with specified precision.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static double? ToRoundNullableDouble(object obj, int digits) {
            var ret = ToNullableDouble(obj);
            if (ret is null) {
                return null;
            }

            return Math.Round(ret.Value, digits);
        }

        /// <summary>
        /// To decimal
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object obj, decimal defaultVal = 0M) {
            if (obj is null)
                return defaultVal;

            if (obj is string str)
                return StringDecimalDeterminer.To(str);

            str = obj.ToString();
            if (StringDecimalDeterminer.Is(str))
                return StringDecimalDeterminer.To(str, defaultVal);

            try {
                return Convert.ToDecimal(obj);
            } catch {
                return defaultVal;
            }
        }

        /// <summary>
        /// To nullable decimal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal? ToNullableDecimal(object obj) {
            if (obj is null)
                return null;

            if (obj is string str && StringDecimalDeterminer.Is(str))
                return StringDecimalDeterminer.To(str);

            str = obj.ToString();
            if (StringDecimalDeterminer.Is(str))
                return StringDecimalDeterminer.To(str);

            if (decimal.TryParse(str, out var ret))
                return ret;

            return null;
        }

        /// <summary>
        /// To decimal with specified precision.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static decimal ToRoundDecimal(object obj, int digits, decimal defaultVal = 0M) {
            return Math.Round(ToDecimal(obj, defaultVal), digits);
        }


        /// <summary>
        /// To nullable decimal with specified precision.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static decimal? ToRoundNullableDecimal(object obj, int digits) {
            var ret = ToNullableDecimal(obj);
            if (ret is null) {
                return null;
            }

            return Math.Round(ret.Value, digits);
        }
    }
}