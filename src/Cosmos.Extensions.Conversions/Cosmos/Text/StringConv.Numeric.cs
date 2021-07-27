using System.Runtime.CompilerServices;
using Cosmos.Conversions;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Text
{
    public enum NumericConvOptions
    {
        Default,
        ZeroAsEmpty
    }

    /// <summary>
    /// Object converter
    /// </summary>
    public static partial class StringConv
    {
        #region Cast Numeric to String

        #region Byte/SByte

        /// <summary>
        /// Convert <see cref="byte"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(byte num, string defaultVal = "0")
        {
            return StrConvX.ByteToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="byte"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(byte? num, string defaultVal = "")
        {
            return StrConvX.ByteToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="byte"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(byte? num, byte defaultVal)
        {
            return StrConvX.ByteToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="byte"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(byte num, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.ByteToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="byte"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(byte? num, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.ByteToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="byte"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(byte? num, NumericConvOptions options, byte defaultVal)
        {
            return StrConvX.ByteToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="sbyte"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(sbyte num, string defaultVal = "0")
        {
            return StrConvX.SByteToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="sbyte"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(sbyte? num, sbyte defaultVal)
        {
            return StrConvX.SByteToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="sbyte"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(sbyte? num, string defaultVal = "")
        {
            return StrConvX.SByteToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="sbyte"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(sbyte num, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.SByteToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="sbyte"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(sbyte? num, NumericConvOptions options, sbyte defaultVal)
        {
            return StrConvX.SByteToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="sbyte"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(sbyte? num, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.SByteToString(num, options, defaultVal);
        }

        #endregion

        #region Int16/short

        /// <summary>
        /// Convert <see cref="short"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(short num, string defaultVal = "0")
        {
            return StrConvX.Int16ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="short"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(short? num, short defaultVal)
        {
            return StrConvX.Int16ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="short"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(short? num, string defaultVal = "")
        {
            return StrConvX.Int16ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="short"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(short num, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.Int16ToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="short"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(short? num, NumericConvOptions options, short defaultVal)
        {
            return StrConvX.Int16ToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="short"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(short? num, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.Int16ToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="ushort"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(ushort num, string defaultVal = "0")
        {
            return StrConvX.UInt16ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="ushort"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(ushort? num, string defaultVal = "")
        {
            return StrConvX.UInt16ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="ushort"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(ushort? num, ushort defaultVal)
        {
            return StrConvX.UInt16ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="ushort"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(ushort num, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.UInt16ToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="ushort"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(ushort? num, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.UInt16ToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="ushort"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(ushort? num, NumericConvOptions options, ushort defaultVal)
        {
            return StrConvX.UInt16ToString(num, options, defaultVal);
        }

        #endregion

        #region Int32/int

        /// <summary>
        /// Convert <see cref="int"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(int num, string defaultVal = "0")
        {
            return StrConvX.Int32ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="int"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(int? num, string defaultVal = "")
        {
            return StrConvX.Int32ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="int"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(int? num, int defaultVal)
        {
            return StrConvX.Int32ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="int"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(int num, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.Int32ToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="int"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(int? num, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.Int32ToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="int"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(int? num, NumericConvOptions options, int defaultVal)
        {
            return StrConvX.Int32ToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="uint"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(uint num, string defaultVal = "0")
        {
            return StrConvX.UInt32ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="uint"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(uint? num, string defaultVal = "")
        {
            return StrConvX.UInt32ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="uint"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(uint? num, uint defaultVal)
        {
            return StrConvX.UInt32ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="uint"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(uint num, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.UInt32ToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="uint"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(uint? num, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.UInt32ToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="uint"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(uint? num, NumericConvOptions options, uint defaultVal)
        {
            return StrConvX.UInt32ToString(num, options, defaultVal);
        }

        #endregion

        #region Int64/long

        /// <summary>
        /// Convert <see cref="long"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(long num, string defaultVal = "0")
        {
            return StrConvX.Int64ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="long"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(long? num, string defaultVal = "")
        {
            return StrConvX.Int64ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="long"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(long? num, long defaultVal)
        {
            return StrConvX.Int64ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="long"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(long num, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.Int64ToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="long"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(long? num, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.Int64ToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="long"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(long? num, NumericConvOptions options, long defaultVal)
        {
            return StrConvX.Int64ToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="ulong"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(ulong num, string defaultVal = "0")
        {
            return StrConvX.UInt64ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="ulong"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(ulong? num, string defaultVal = "")
        {
            return StrConvX.UInt64ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="ulong"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(ulong? num, ulong defaultVal)
        {
            return StrConvX.UInt64ToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="ulong"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(ulong num, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.UInt64ToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="ulong"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(ulong? num, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.UInt64ToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="ulong"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(ulong? num, NumericConvOptions options, ulong defaultVal)
        {
            return StrConvX.UInt64ToString(num, options, defaultVal);
        }

        #endregion

        #region Float32/float

        /// <summary>
        /// Convert <see cref="float"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(float num, string defaultVal = "0.00")
        {
            return StrConvX.FloatToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="float"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(float? num, string defaultVal = "")
        {
            return StrConvX.FloatToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="float"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(float? num, float defaultVal)
        {
            return StrConvX.FloatToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="float"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(float num, NumericConvOptions options, string defaultVal = "0.00")
        {
            return StrConvX.FloatToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="float"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(float? num, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.FloatToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="float"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(float? num, NumericConvOptions options, float defaultVal)
        {
            return StrConvX.FloatToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="float"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(float num, int digits, string defaultVal = "0.00")
        {
            return StrConvX.FloatToString(num, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="float"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(float? num, int digits, string defaultVal = "")
        {
            return StrConvX.FloatToString(num, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="float"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(float? num, int digits, float defaultVal)
        {
            return StrConvX.FloatToString(num, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="float"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(float num, int digits, NumericConvOptions options, string defaultVal = "0.00")
        {
            return StrConvX.FloatToString(num, digits, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="float"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(float? num, int digits, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.FloatToString(num, digits, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="float"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(float? num, int digits, NumericConvOptions options, float defaultVal)
        {
            return StrConvX.FloatToString(num, digits, options, defaultVal);
        }

        #endregion

        #region Float64/double

        /// <summary>
        /// Convert <see cref="double"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(double num, string defaultVal = "0.00")
        {
            return StrConvX.DoubleToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="double"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(double? num, string defaultVal = "")
        {
            return StrConvX.DoubleToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="double"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(double? num, double defaultVal)
        {
            return StrConvX.DoubleToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="double"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(double num, NumericConvOptions options, string defaultVal = "0.00")
        {
            return StrConvX.DoubleToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="double"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(double? num, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.DoubleToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="double"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(double? num, NumericConvOptions options, double defaultVal)
        {
            return StrConvX.DoubleToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="double"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(double num, int digits, string defaultVal = "0.00")
        {
            return StrConvX.DoubleToString(num, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="double"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(double? num, int digits, string defaultVal = "")
        {
            return StrConvX.DoubleToString(num, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="double"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(double? num, int digits, double defaultVal)
        {
            return StrConvX.DoubleToString(num, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="double"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(double num, int digits, NumericConvOptions options, string defaultVal = "0.00")
        {
            return StrConvX.DoubleToString(num, digits, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="double"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(double? num, int digits, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.DoubleToString(num, digits, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="double"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(double? num, int digits, NumericConvOptions options, double defaultVal)
        {
            return StrConvX.DoubleToString(num, digits, options, defaultVal);
        }

        #endregion

        #region Decimal/decimal

        /// <summary>
        /// Convert <see cref="decimal"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(decimal num, string defaultVal = "0")
        {
            return StrConvX.DecimalToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="decimal"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(decimal? num, string defaultVal = "")
        {
            return StrConvX.DecimalToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="decimal"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(decimal? num, decimal defaultVal)
        {
            return StrConvX.DecimalToString(num, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="decimal"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(decimal num, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.DecimalToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="decimal"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(decimal? num, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.DecimalToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="decimal"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(decimal? num, NumericConvOptions options, decimal defaultVal)
        {
            return StrConvX.DecimalToString(num, options, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="decimal"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(decimal num, int digits, string defaultVal = "0")
        {
            return StrConvX.DecimalToString(num, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="decimal"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(decimal? num, int digits, string defaultVal = "")
        {
            return StrConvX.DecimalToString(num, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="decimal"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(decimal? num, int digits, decimal defaultVal)
        {
            return StrConvX.DecimalToString(num, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="decimal"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(decimal num, int digits, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.DecimalToString(num, digits, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="decimal"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(decimal? num, int digits, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.DecimalToString(num, digits, options, defaultVal);
        }

        /// <summary>
        /// Convert nullable <see cref="decimal"/> to <see cref="string"/> with specified precision.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ToString(decimal? num, int digits, NumericConvOptions options, decimal defaultVal)
        {
            return StrConvX.DecimalToString(num, digits, options, defaultVal);
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// Cosmos <see cref="string"/> casting extensions.
    /// </summary>
    public static partial class StringConvExtensions
    {
        #region Cast String to Numeric

        #region SByte/sbyte

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="sbyte"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte CastToSByte(this string text, sbyte defaultVal = default)
        {
            return NumConvX.StringToSByte(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="sbyte"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte CastToSByte(this string text, params IConversionImpl<string, sbyte>[] impls)
        {
            return NumConvX.StringToSByte(text, impls);
        }

        /// <summary>
        /// Cast TEnum to <see cref="sbyte"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte CastToSByte<TEnum>(this TEnum @enum, sbyte defaultVal = default) where TEnum : struct
        {
            return NumConvX.EnumToSByte(@enum, defaultVal);
        }

        #endregion

        #region Byte/byte

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="byte"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte CastToByte(this string text, byte defaultVal = default)
        {
            return NumConvX.StringToByte(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="byte"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte CastToByte(this string text, params IConversionImpl<string, byte>[] impls)
        {
            return NumConvX.StringToByte(text, impls);
        }

        /// <summary>
        /// Cast TEnum to <see cref="byte"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte CastToByte<TEnum>(this TEnum @enum, byte defaultVal = default) where TEnum : struct
        {
            return NumConvX.EnumToByte(@enum, defaultVal);
        }

        #endregion

        #region Int16/short

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="short"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short CastToShort(this string text, short defaultVal = default)
        {
            return NumConvX.StringToInt16(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="short"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short CastToShort(this string text, params IConversionImpl<string, short>[] impls)
        {
            return NumConvX.StringToInt16(text, impls);
        }

        /// <summary>
        /// Cast TEnum to <see cref="short"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short CastToShort<TEnum>(this TEnum @enum, short defaultVal = default) where TEnum : struct
        {
            return NumConvX.EnumToInt16(@enum, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="short"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short CastToInt16(this string text, short defaultVal = default)
        {
            return NumConvX.StringToInt16(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="short"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short CastToInt16(this string text, params IConversionImpl<string, short>[] impls)
        {
            return NumConvX.StringToInt16(text, impls);
        }

        /// <summary>
        /// Cast TEnum to <see cref="short"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short CastToInt16<TEnum>(this TEnum @enum, short defaultVal = default) where TEnum : struct
        {
            return NumConvX.EnumToInt16(@enum, defaultVal);
        }

        #endregion

        #region UInt16/ushort

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ushort"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort CastToUShort(this string text, ushort defaultVal = default)
        {
            return NumConvX.StringToUInt16(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ushort"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort CastToUShort(this string text, params IConversionImpl<string, ushort>[] impls)
        {
            return NumConvX.StringToUInt16(text, impls);
        }

        /// <summary>
        /// Cast TEnum to <see cref="ushort"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort CastToUShort<TEnum>(this TEnum @enum, ushort defaultVal = default) where TEnum : struct
        {
            return NumConvX.EnumToUInt16(@enum, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ushort"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort CastToUInt16(this string text, ushort defaultVal = default)
        {
            return NumConvX.StringToUInt16(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ushort"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort CastToUInt16(this string text, params IConversionImpl<string, ushort>[] impls)
        {
            return NumConvX.StringToUInt16(text, impls);
        }

        /// <summary>
        /// Cast TEnum to <see cref="ushort"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort CastToUInt16<TEnum>(this TEnum @enum, ushort defaultVal = default) where TEnum : struct
        {
            return NumConvX.EnumToUInt16(@enum, defaultVal);
        }

        #endregion

        #region Int32/int

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="int"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CastToInt(this string text, int defaultVal = default)
        {
            return NumConvX.StringToInt32(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="int"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CastToInt(this string text, params IConversionImpl<string, int>[] impls)
        {
            return NumConvX.StringToInt32(text, impls);
        }

        /// <summary>
        /// Cast TEnum to <see cref="int"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CastToInt<TEnum>(this TEnum @enum, int defaultVal = default) where TEnum : struct
        {
            return NumConvX.EnumToInt32(@enum, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="int"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CastToInt32(this string text, int defaultVal = default)
        {
            return NumConvX.StringToInt32(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="int"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CastToInt32(this string text, params IConversionImpl<string, int>[] impls)
        {
            return NumConvX.StringToInt32(text, impls);
        }

        /// <summary>
        /// Cast TEnum to <see cref="int"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CastToInt32<TEnum>(this TEnum @enum, int defaultVal = default) where TEnum : struct
        {
            return NumConvX.EnumToInt32(@enum, defaultVal);
        }

        #endregion

        #region UInt32/uint

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="uint"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint CastToUInt(this string text, uint defaultVal = default)
        {
            return NumConvX.StringToUInt32(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="uint"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint CastToUInt(this string text, params IConversionImpl<string, uint>[] impls)
        {
            return NumConvX.StringToUInt32(text, impls);
        }

        /// <summary>
        /// Cast TEnum to <see cref="uint"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint CastToUInt<TEnum>(this TEnum @enum, uint defaultVal = default) where TEnum : struct
        {
            return NumConvX.EnumToUInt32(@enum, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="uint"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint CastToUInt32(this string text, uint defaultVal = default)
        {
            return NumConvX.StringToUInt32(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="uint"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint CastToUInt32(this string text, params IConversionImpl<string, uint>[] impls)
        {
            return NumConvX.StringToUInt32(text, impls);
        }

        /// <summary>
        /// Cast TEnum to <see cref="uint"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint CastToUInt32<TEnum>(this TEnum @enum, uint defaultVal = default) where TEnum : struct
        {
            return NumConvX.EnumToUInt32(@enum, defaultVal);
        }

        #endregion

        #region Int64/long

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="long"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long CastToLong(this string text, long defaultVal = default)
        {
            return NumConvX.StringToInt64(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="long"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long CastToLong(this string text, params IConversionImpl<string, long>[] impls)
        {
            return NumConvX.StringToInt64(text, impls);
        }

        /// <summary>
        /// Cast TEnum to <see cref="long"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long CastToLong<TEnum>(this TEnum @enum, long defaultVal = default) where TEnum : struct
        {
            return NumConvX.EnumToInt64(@enum, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="long"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long CastToInt64(this string text, long defaultVal = default)
        {
            return NumConvX.StringToInt64(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="long"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long CastToInt64(this string text, params IConversionImpl<string, long>[] impls)
        {
            return NumConvX.StringToInt64(text, impls);
        }

        /// <summary>
        /// Cast TEnum to <see cref="long"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long CastToInt64<TEnum>(this TEnum @enum, long defaultVal = default) where TEnum : struct
        {
            return NumConvX.EnumToInt64(@enum, defaultVal);
        }

        #endregion

        #region UInt64/ulong

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ulong"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong CastToULong(this string text, ulong defaultVal = default)
        {
            return NumConvX.StringToUInt64(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ulong"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong CastToULong(this string text, params IConversionImpl<string, ulong>[] impls)
        {
            return NumConvX.StringToUInt64(text, impls);
        }

        /// <summary>
        /// Cast TEnum to <see cref="ulong"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong CastToULong<TEnum>(this TEnum @enum, ulong defaultVal = default) where TEnum : struct
        {
            return NumConvX.EnumToUInt64(@enum, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ulong"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong CastToUInt64(this string text, ulong defaultVal = default)
        {
            return NumConvX.StringToUInt64(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="ulong"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong CastToUInt64(this string text, params IConversionImpl<string, ulong>[] impls)
        {
            return NumConvX.StringToUInt64(text, impls);
        }

        /// <summary>
        /// Cast TEnum to <see cref="ulong"/>
        /// </summary>
        /// <param name="enum"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong CastToUInt64<TEnum>(this TEnum @enum, ulong defaultVal = default) where TEnum : struct
        {
            return NumConvX.EnumToUInt64(@enum, defaultVal);
        }

        #endregion

        #region Float32/float

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="float"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CastToFloat(this string text, float defaultVal = default)
        {
            return NumConvX.StringToFloat(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="float"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CastToFloat(this string text, params IConversionImpl<string, float>[] impls)
        {
            return NumConvX.StringToFloat(text, impls);
        }

        #endregion

        #region Float64/double

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="double"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CastToDouble(this string text, double defaultVal = default)
        {
            return NumConvX.StringToDouble(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="double"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CastToDouble(this string text, params IConversionImpl<string, double>[] impls)
        {
            return NumConvX.StringToDouble(text, impls);
        }

        #endregion

        #region Decimal/decimal

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="decimal"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal CastToDecimal(this string text, decimal defaultVal = default)
        {
            return NumConvX.StringToDecimal(text, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="string"/> to <see cref="decimal"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="impls"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal CastToDecimal(this string text, params IConversionImpl<string, decimal>[] impls)
        {
            return NumConvX.StringToDecimal(text, impls);
        }

        #endregion

        #endregion

        #region Cast Numeric to String

        /// <summary>
        /// Cast <see cref="byte"/> to <see cref="string"/>. <br />
        /// 将 <see cref="byte"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this byte number, string defaultVal = "0")
        {
            return StrConvX.ByteToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="byte"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="byte"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this byte? number, string defaultVal = "")
        {
            return StrConvX.ByteToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="byte"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="byte"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this byte? number, byte defaultVal)
        {
            return StrConvX.ByteToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="byte"/> to <see cref="string"/>. <br />
        /// 将 <see cref="byte"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this byte number, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.ByteToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="byte"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="byte"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this byte? number, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.ByteToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="byte"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="byte"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this byte? number, NumericConvOptions options, byte defaultVal)
        {
            return StrConvX.ByteToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="sbyte"/> to <see cref="string"/>. <br />
        /// 将 <see cref="sbyte"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this sbyte number, string defaultVal = "0")
        {
            return StrConvX.SByteToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="sbyte"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="sbyte"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this sbyte? number, string defaultVal = "")
        {
            return StrConvX.SByteToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="sbyte"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="sbyte"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this sbyte? number, sbyte defaultVal)
        {
            return StrConvX.SByteToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="sbyte"/> to <see cref="string"/>. <br />
        /// 将 <see cref="sbyte"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this sbyte number, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.SByteToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="sbyte"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="sbyte"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this sbyte? number, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.SByteToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="sbyte"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="sbyte"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this sbyte? number, NumericConvOptions options, sbyte defaultVal)
        {
            return StrConvX.SByteToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="short"/> to <see cref="string"/>. <br />
        /// 将 <see cref="short"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this short number, string defaultVal = "0")
        {
            return StrConvX.Int16ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="short"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="short"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this short? number, string defaultVal = "")
        {
            return StrConvX.Int16ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="short"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="short"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this short? number, short defaultVal)
        {
            return StrConvX.Int16ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="short"/> to <see cref="string"/>. <br />
        /// 将 <see cref="short"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this short number, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.Int16ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="short"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="short"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this short? number, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.Int16ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="short"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="short"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this short? number, NumericConvOptions options, short defaultVal)
        {
            return StrConvX.Int16ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="ushort"/> to <see cref="string"/>. <br />
        /// 将 <see cref="ushort"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this ushort number, string defaultVal = "0")
        {
            return StrConvX.UInt16ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="ushort"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="ushort"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this ushort? number, string defaultVal = "")
        {
            return StrConvX.UInt16ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="ushort"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="ushort"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this ushort? number, ushort defaultVal)
        {
            return StrConvX.UInt16ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="ushort"/> to <see cref="string"/>. <br />
        /// 将 <see cref="ushort"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this ushort number, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.UInt16ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="ushort"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="ushort"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this ushort? number, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.UInt16ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="ushort"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="ushort"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this ushort? number, NumericConvOptions options, ushort defaultVal)
        {
            return StrConvX.UInt16ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="int"/> to <see cref="string"/>. <br />
        /// 将 <see cref="int"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this int number, string defaultVal = "0")
        {
            return StrConvX.Int32ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="int"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="int"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this int? number, string defaultVal = "")
        {
            return StrConvX.Int32ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="int"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="int"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this int? number, int defaultVal)
        {
            return StrConvX.Int32ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="int"/> to <see cref="string"/>. <br />
        /// 将 <see cref="int"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this int number, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.Int32ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="int"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="int"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this int? number, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.Int32ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="int"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="int"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this int? number, NumericConvOptions options, int defaultVal)
        {
            return StrConvX.Int32ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="uint"/> to <see cref="string"/>. <br />
        /// 将 <see cref="uint"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this uint number, string defaultVal = "0")
        {
            return StrConvX.UInt32ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="uint"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="uint"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this uint? number, string defaultVal = "")
        {
            return StrConvX.UInt32ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="uint"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="uint"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this uint? number, uint defaultVal)
        {
            return StrConvX.UInt32ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="uint"/> to <see cref="string"/>. <br />
        /// 将 <see cref="uint"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this uint number, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.UInt32ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="uint"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="uint"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this uint? number, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.UInt32ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="uint"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="uint"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this uint? number, NumericConvOptions options, uint defaultVal)
        {
            return StrConvX.UInt32ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="long"/> to <see cref="string"/>. <br />
        /// 将 <see cref="long"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this long number, string defaultVal = "0")
        {
            return StrConvX.Int64ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="long"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="long"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this long? number, string defaultVal = "")
        {
            return StrConvX.Int64ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="long"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="long"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this long? number, long defaultVal)
        {
            return StrConvX.Int64ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="long"/> to <see cref="string"/>. <br />
        /// 将 <see cref="long"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this long number, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.Int64ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="long"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="long"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this long? number, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.Int64ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="long"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="long"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this long? number, NumericConvOptions options, long defaultVal)
        {
            return StrConvX.Int64ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="ulong"/> to <see cref="string"/>. <br />
        /// 将 <see cref="ulong"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this ulong number, string defaultVal = "0")
        {
            return StrConvX.UInt64ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="ulong"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="ulong"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this ulong? number, string defaultVal = "")
        {
            return StrConvX.UInt64ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="ulong"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="ulong"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this ulong? number, ulong defaultVal)
        {
            return StrConvX.UInt64ToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="ulong"/> to <see cref="string"/>. <br />
        /// 将 <see cref="ulong"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this ulong number, NumericConvOptions options, string defaultVal = "0")
        {
            return StrConvX.UInt64ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="ulong"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="ulong"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this ulong? number, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.UInt64ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="ulong"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="ulong"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this ulong? number, NumericConvOptions options, ulong defaultVal)
        {
            return StrConvX.UInt64ToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="float"/> to <see cref="string"/>. <br />
        /// 将 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this float number, string defaultVal = "0.00")
        {
            return StrConvX.FloatToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="float"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this float number, int digits, string defaultVal = "0.00")
        {
            return StrConvX.FloatToString(number, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="float"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this float? number, string defaultVal = "")
        {
            return StrConvX.FloatToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="float"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this float? number, int digits, string defaultVal = "")
        {
            return StrConvX.FloatToString(number, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="float"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this float? number, float defaultVal)
        {
            return StrConvX.FloatToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="float"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this float? number, int digits, float defaultVal)
        {
            return StrConvX.FloatToString(number, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="float"/> to <see cref="string"/>. <br />
        /// 将 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this float number, NumericConvOptions options, string defaultVal = "0.00")
        {
            return StrConvX.FloatToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="float"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this float number, int digits, NumericConvOptions options, string defaultVal = "0.00")
        {
            return StrConvX.FloatToString(number, digits, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="float"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this float? number, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.FloatToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="float"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this float? number, int digits, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.FloatToString(number, digits, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="float"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this float? number, NumericConvOptions options, float defaultVal)
        {
            return StrConvX.FloatToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="float"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="float"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this float? number, int digits, NumericConvOptions options, float defaultVal)
        {
            return StrConvX.FloatToString(number, digits, options, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="double"/> to <see cref="string"/>. <br />
        /// 将 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this double number, string defaultVal = "0.00")
        {
            return StrConvX.DoubleToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="double"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this double number, int digits, string defaultVal = "0.00")
        {
            return StrConvX.DoubleToString(number, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="double"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this double? number, string defaultVal = "")
        {
            return StrConvX.DoubleToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="double"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this double? number, int digits, string defaultVal = "")
        {
            return StrConvX.DoubleToString(number, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="double"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this double? number, double defaultVal)
        {
            return StrConvX.DoubleToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="double"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this double? number, int digits, double defaultVal)
        {
            return StrConvX.DoubleToString(number, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="double"/> to <see cref="string"/>. <br />
        /// 将 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this double number, NumericConvOptions options, string defaultVal = "0.00")
        {
            return StrConvX.DoubleToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="double"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this double number, int digits, NumericConvOptions options, string defaultVal = "0.00")
        {
            return StrConvX.DoubleToString(number, digits, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="double"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this double? number, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.DoubleToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="double"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this double? number, int digits, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.DoubleToString(number, digits, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="double"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this double? number, NumericConvOptions options, double defaultVal)
        {
            return StrConvX.DoubleToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="double"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="double"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this double? number, int digits, NumericConvOptions options, double defaultVal)
        {
            return StrConvX.DoubleToString(number, digits, options, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="decimal"/> to <see cref="string"/>. <br />
        /// 将 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this decimal number, string defaultVal = "0.00")
        {
            return StrConvX.DecimalToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="decimal"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this decimal number, int digits, string defaultVal = "0.00")
        {
            return StrConvX.DecimalToString(number, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="decimal"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this decimal? number, string defaultVal = "")
        {
            return StrConvX.DecimalToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="decimal"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this decimal? number, int digits, string defaultVal = "")
        {
            return StrConvX.DecimalToString(number, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="decimal"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this decimal? number, decimal defaultVal)
        {
            return StrConvX.DecimalToString(number, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="decimal"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this decimal? number, int digits, decimal defaultVal)
        {
            return StrConvX.DecimalToString(number, digits, NumericConvOptions.Default, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="decimal"/> to <see cref="string"/>. <br />
        /// 将 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this decimal number, NumericConvOptions options, string defaultVal = "0.00")
        {
            return StrConvX.DecimalToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast <see cref="decimal"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this decimal number, int digits, NumericConvOptions options, string defaultVal = "0.00")
        {
            return StrConvX.DecimalToString(number, digits, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="decimal"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this decimal? number, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.DecimalToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="decimal"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this decimal? number, int digits, NumericConvOptions options, string defaultVal = "")
        {
            return StrConvX.DecimalToString(number, digits, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="decimal"/> to <see cref="string"/>. <br />
        /// 将可空 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this decimal? number, NumericConvOptions options, decimal defaultVal)
        {
            return StrConvX.DecimalToString(number, options, defaultVal);
        }

        /// <summary>
        /// Cast nullable <see cref="decimal"/> to <see cref="string"/> with specified precision. <br />
        /// 将指定精度的可空 <see cref="decimal"/> 转换为字符串。
        /// </summary>
        /// <param name="number"></param>
        /// <param name="digits"></param>
        /// <param name="options"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string CastToString(this decimal? number, int digits, NumericConvOptions options, decimal defaultVal)
        {
            return StrConvX.DecimalToString(number, digits, options, defaultVal);
        }

        #endregion
    }
}