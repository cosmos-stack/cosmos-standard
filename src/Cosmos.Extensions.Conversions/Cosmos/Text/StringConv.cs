using Cosmos.Conversions.Common.Core;

namespace Cosmos.Text
{
    /// <summary>
    /// Object converter
    /// </summary>
    public static class StringConv
    {
        #region Object

        /// <summary>
        /// Convert <see cref="object"/> to <see cref="string"/> safety.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(object obj, string defaultVal = default) => StrConvX.ObjectSafeToString(obj, defaultVal);

        #endregion

        #region Int16/short

        /// <summary>
        /// Convert <see cref="short"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(short num, string defaultVal = "0") => StrConvX.Int16ToString(num, defaultVal);

        /// <summary>
        /// Convert nullable <see cref="short"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(short? num, string defaultVal = "") => StrConvX.Int16ToString(num, defaultVal);

        /// <summary>
        /// Convert <see cref="ushort"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(ushort num, string defaultVal = "0") => StrConvX.UInt16ToString(num, defaultVal);

        /// <summary>
        /// Convert nullable <see cref="ushort"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(ushort? num, string defaultVal = "") => StrConvX.UInt16ToString(num, defaultVal);

        #endregion

        #region Int32/int

        /// <summary>
        /// Convert <see cref="int"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(int num, string defaultVal = "0") => StrConvX.Int32ToString(num, defaultVal);

        /// <summary>
        /// Convert nullable <see cref="int"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(int? num, string defaultVal = "") => StrConvX.Int32ToString(num, defaultVal);

        /// <summary>
        /// Convert <see cref="uint"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(uint num, string defaultVal = "0") => StrConvX.UInt32ToString(num, defaultVal);

        /// <summary>
        /// Convert nullable <see cref="uint"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(uint? num, string defaultVal = "") => StrConvX.UInt32ToString(num, defaultVal);

        #endregion

        #region Int64/long

        /// <summary>
        /// Convert <see cref="long"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(long num, string defaultVal = "0") => StrConvX.Int64ToString(num, defaultVal);

        /// <summary>
        /// Convert nullable <see cref="long"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(long? num, string defaultVal = "") => StrConvX.Int64ToString(num, defaultVal);

        /// <summary>
        /// Convert <see cref="ulong"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(ulong num, string defaultVal = "0") => StrConvX.UInt64ToString(num, defaultVal);

        /// <summary>
        /// Convert nullable <see cref="ulong"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(ulong? num, string defaultVal = "") => StrConvX.UInt64ToString(num, defaultVal);

        #endregion

        #region Float32/float

        /// <summary>
        /// Convert <see cref="float"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string ToString(float num) => StrConvX.FloatToString(num);

        /// <summary>
        /// Convert nullable <see cref="float"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string ToString(float? num) => StrConvX.FloatToString(num);

        /// <summary>
        /// Convert <see cref="float"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string ToString(float num, int digits) => StrConvX.FloatToString(num, digits);

        /// <summary>
        /// Convert nullable <see cref="float"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string ToString(float? num, int digits) => StrConvX.FloatToString(num, digits);

        #endregion

        #region Float64/double

        /// <summary>
        /// Convert <see cref="double"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string ToString(double num) => StrConvX.DoubleToString(num);

        /// <summary>
        /// Convert nullable <see cref="double"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string ToString(double? num) => StrConvX.DoubleToString(num);

        /// <summary>
        /// Convert <see cref="double"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string ToString(double num, int digits) => StrConvX.DoubleToString(num, digits);

        /// <summary>
        /// Convert nullable <see cref="double"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static string ToString(double? num, int digits) => StrConvX.DoubleToString(num, digits);

        #endregion

        #region Decimal/decimal

        /// <summary>
        /// Convert <see cref="decimal"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(decimal num, string defaultVal = "0") => StrConvX.DecimalToString(num, defaultVal);

        /// <summary>
        /// Convert nullable <see cref="decimal"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(decimal? num, string defaultVal = "") => StrConvX.DecimalToString(num, defaultVal);

        /// <summary>
        /// Convert <see cref="decimal"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(decimal num, int digits, string defaultVal = "0") => StrConvX.DecimalToString(num, digits, defaultVal);

        /// <summary>
        /// Convert nullable <see cref="decimal"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(decimal? num, int digits, string defaultVal = "") => StrConvX.DecimalToString(num, digits, defaultVal);

        #endregion
    }
}