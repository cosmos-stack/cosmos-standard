using Cosmos.Conversions.StringDeterminers;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// Conversion extensions
    /// </summary>
    public static class ConversionExtensions
    {
        /// <summary>
        /// To DateInfo
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateInfo CastToDateInfo(this string str, DateInfo defaultVal = default)
            => StringDateInfoDeterminer.To(str, defaultVal: defaultVal);

        /// <summary>
        /// To DateTimeSpan
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeSpan CastToDateTimeSpan(this string str, DateTimeSpan defaultVal = default)
            => StringDateTimeSpanDeterminer.To(str, defaultVal: defaultVal);

        /// <summary>
        /// To nullable TimeSpan
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTimeSpan? CastToNullableDateTimeSpan(this string str)
        {
            if (StringDateTimeSpanDeterminer.Is(str))
                return CastToDateTimeSpan(str);
            return null;
        }
    }
}