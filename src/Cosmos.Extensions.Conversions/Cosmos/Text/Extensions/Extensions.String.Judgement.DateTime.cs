using Cosmos.Conversions.Determiners;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StingJudgementExtensions
    {
        /// <summary>
        /// Is DateTime
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string str) => StringDateTimeDeterminer.Is(str);

        /// <summary>
        /// Is DateTimeOffset
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTimeOffset(this string str) => StringDateTimeOffsetDeterminer.Is(str);

        /// <summary>
        /// Is TImeSpan
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsTimeSpan(this string str) => StringTimeSpanDeterminer.Is(str);

        /// <summary>
        /// Is DateTime
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool IsDateTimeExact(this string str, string format) => StringDateTimeDeterminer.Exact.Is(str, format);

        /// <summary>
        /// Is DateTimeOffset
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool IsDateTimeOffsetExact(this string str, string format) => StringDateTimeOffsetDeterminer.Exact.Is(str, format);

        /// <summary>
        /// Is TImeSpan
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool IsTimeSpanExact(this string str, string format) => StringTimeSpanDeterminer.Exact.Is(str, format);
    }
}