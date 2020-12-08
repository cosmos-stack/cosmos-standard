using Cosmos.Conversions.Determiners;

namespace Cosmos.Numeric
{
    public static class NumericJudge
    {
        /// <summary>
        /// To judge whether the string is short or not.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt16(string str) => StringShortDeterminer.Is(str);

        /// <summary>
        /// To judge whether the string is integer or not.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt32(string str) => StringIntDeterminer.Is(str);

        /// <summary>
        /// To judge whether the string is long or not.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt64(string str) => StringLongDeterminer.Is(str);

        /// <summary>
        /// To judge whether the string is ushort or not.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUInt16(string str) => StringUShortDeterminer.Is(str);

        /// <summary>
        /// To judge whether the string is uinteger or not.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUInt32(string str) => StringUIntDeterminer.Is(str);

        /// <summary>
        /// To judge whether the string is ulong or not.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUInt64(string str) => StringULongDeterminer.Is(str);

        /// <summary>
        /// To judge whether the string is numeric or not.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str) => StringDecimalDeterminer.Is(str);

        /// <summary>
        /// To judge whether the short value is between left and right.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(short value, short left, short right) => value >= left && value <= right;

        /// <summary>
        /// To judge whether the int value is between left and right.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(int value, int left, int right) => value >= left && value <= right;

        /// <summary>
        /// To judge whether the long value is between left and right.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(long value, long left, long right) => value >= left && value <= right;

        /// <summary>
        /// To judge whether the float value is between left and right.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(float value, float left, float right) => value >= left && value <= right;

        /// <summary>
        /// To judge whether the double value is between left and right.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(double value, double left, double right) => value >= left && value <= right;

        /// <summary>
        /// To judge whether the decimal value is between left and right.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool IsBetween(decimal value, decimal left, decimal right) => value >= left && value <= right;

        /// <summary>
        /// Is NaN
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNaN(double value) => Numbers.IsNaN(value);

        /// <summary>
        /// Is NaN
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNaN(float value) => Numbers.IsNaN(value);
    }
}