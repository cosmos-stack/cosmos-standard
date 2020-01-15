using Cosmos.Conversions.Internals;
using Cosmos.Judgments;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions {

        /// <summary>
        /// Is numeric
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string @string) => NumericJudgment.IsNumeric(@string);

        /// <summary>
        /// Is byte
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsByte(this string str) => StringByteHelper.Is(str);

        /// <summary>
        /// Is SByte
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsSByte(this string str) => StringSByteHelper.Is(str);

        /// <summary>
        /// Is short
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsShort(this string str) => StringShortHelper.Is(str);

        /// <summary>
        /// Is int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt(this string str) => StringIntHelper.Is(str);

        /// <summary>
        /// Is long
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsLong(this string str) => StringLongHelper.Is(str);

        /// <summary>
        /// Us ushort
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUShort(this string str) => StringUShortHelper.Is(str);

        /// <summary>
        /// Is uint
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUInt(this string str) => StringUIntHelper.Is(str);

        /// <summary>
        /// Is ulong
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsULong(this string str) => StringULongHelper.Is(str);

        /// <summary>
        /// Is int16
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt16(this string str) => StringShortHelper.Is(str);

        /// <summary>
        /// Is inrt32
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt32(this string str) => StringIntHelper.Is(str);

        /// <summary>
        /// Is int64
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt64(this string str) => StringLongHelper.Is(str);

        /// <summary>
        /// Is uint16
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUInt16(this string str) => StringUShortHelper.Is(str);

        /// <summary>
        /// Is uint32
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUInt32(this string str) => StringUIntHelper.Is(str);

        /// <summary>
        /// Is uint64
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool UsUInt64(this string str) => StringULongHelper.Is(str);

        /// <summary>
        /// Is float
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsFloat(this string str) => StringFloatHelper.Is(str);

        /// <summary>
        /// Is double
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDouble(this string str) => StringDoubleHelper.Is(str);

        /// <summary>
        /// Is decimal
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDecimal(this string str) => StringDecimalHelper.Is(str);
    }
}