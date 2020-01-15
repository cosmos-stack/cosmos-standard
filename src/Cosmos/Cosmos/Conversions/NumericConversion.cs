using System;

namespace Cosmos.Conversions {
    /// <summary>
    /// Numeric Conversion Utilities
    /// </summary>
    public static class NumericConversion {
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
                return Internals.StringShortHelper.To(str, defaultVal);

            str = obj.ToString();
            if (Internals.StringShortHelper.Is(str))
                return Internals.StringShortHelper.To(str, defaultVal);

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

            if (obj is string str && Internals.StringShortHelper.Is(str))
                return Internals.StringShortHelper.To(str);

            str = obj.ToString();
            if (Internals.StringShortHelper.Is(str))
                return Internals.StringShortHelper.To(str);

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
                return Internals.StringUShortHelper.To(str, defaultVal);

            str = obj.ToString();
            if (Internals.StringUShortHelper.Is(str))
                return Internals.StringUShortHelper.To(str, defaultVal);

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

            if (obj is string str && Internals.StringUShortHelper.Is(str))
                return Internals.StringUShortHelper.To(str);

            str = obj.ToString();
            if (Internals.StringUShortHelper.Is(str))
                return Internals.StringUShortHelper.To(str);

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
                return Internals.StringIntHelper.To(str);

            str = obj.ToString();
            if (Internals.StringIntHelper.Is(str))
                return Internals.StringIntHelper.To(str, defaultVal);

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

            if (obj is string str && Internals.StringIntHelper.Is(str))
                return Internals.StringIntHelper.To(str);

            str = obj.ToString();
            if (Internals.StringIntHelper.Is(str))
                return Internals.StringIntHelper.To(str);

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
                return Internals.StringUIntHelper.To(str);

            str = obj.ToString();
            if (Internals.StringUIntHelper.Is(str))
                return Internals.StringUIntHelper.To(str, defaultVal);

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

            if (obj is string str && Internals.StringUIntHelper.Is(str))
                return Internals.StringUIntHelper.To(str);

            str = obj.ToString();
            if (Internals.StringUIntHelper.Is(str))
                return Internals.StringUIntHelper.To(str);

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
                return Internals.StringLongHelper.To(str);

            str = obj.ToString();
            if (Internals.StringLongHelper.Is(str))
                return Internals.StringLongHelper.To(str, defaultVal);

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

            if (obj is string str && Internals.StringLongHelper.Is(str))
                return Internals.StringLongHelper.To(str);

            str = obj.ToString();
            if (Internals.StringLongHelper.Is(str))
                return Internals.StringLongHelper.To(str);

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
                return Internals.StringULongHelper.To(str);

            str = obj.ToString();
            if (Internals.StringULongHelper.Is(str))
                return Internals.StringULongHelper.To(str, defaultVal);

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

            if (obj is string str && Internals.StringULongHelper.Is(str))
                return Internals.StringULongHelper.To(str);

            str = obj.ToString();
            if (Internals.StringULongHelper.Is(str))
                return Internals.StringULongHelper.To(str);

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
                return Internals.StringFloatHelper.To(str);

            str = obj.ToString();
            return Internals.StringFloatHelper.To(str, defaultVal);
        }

        /// <summary>
        /// To nullable float
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static float? ToNullableFloat(object obj) {
            if (obj is null)
                return null;

            if (obj is string str && Internals.StringFloatHelper.Is(str))
                return Internals.StringFloatHelper.To(str);

            str = obj.ToString();
            if (Internals.StringFloatHelper.Is(str))
                return Internals.StringFloatHelper.To(str);

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
                return Internals.StringDoubleHelper.To(str);

            str = obj.ToString();
            if (Internals.StringDoubleHelper.Is(str))
                return Internals.StringDoubleHelper.To(str, defaultVal);

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

            if (obj is string str && Internals.StringDoubleHelper.Is(str))
                return Internals.StringDoubleHelper.To(str);

            str = obj.ToString();
            if (Internals.StringDoubleHelper.Is(str))
                return Internals.StringDoubleHelper.To(str);

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
                return Internals.StringDecimalHelper.To(str);

            str = obj.ToString();
            if (Internals.StringDecimalHelper.Is(str))
                return Internals.StringDecimalHelper.To(str, defaultVal);

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

            if (obj is string str && Internals.StringDecimalHelper.Is(str))
                return Internals.StringDecimalHelper.To(str);

            str = obj.ToString();
            if (Internals.StringDecimalHelper.Is(str))
                return Internals.StringDecimalHelper.To(str);

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