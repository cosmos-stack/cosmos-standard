using Cosmos.Conversions.Internals;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions {
        /// <summary>
        /// Is DateTime
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string str) => StringDateTimeHelper.Is(str);

        /// <summary>
        /// Is DateTimeOffset
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTimeOffset(this string str) => StringDateTimeOffsetHelper.Is(str);

        /// <summary>
        /// Is TImeSpan
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsTimeSpan(this string str) => StringTimeSpanHelper.Is(str);

        /// <summary>
        /// Is DateTime
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool IsDateTimeExact(this string str, string format) => StringDateTimeExactHelper.Is(str, format);

        /// <summary>
        /// Is DateTimeOffset
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool IsDateTimeOffsetExact(this string str, string format) => StringDateTimeOffsetExactHelper.Is(str, format);

        /// <summary>
        /// Is TImeSpan
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool IsTimeSpanExact(this string str, string format) => StringTimeSpanExactHelper.Is(str, format);

    }
}