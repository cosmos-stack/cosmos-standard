using System;
using Cosmos.Conversions.StringDeterminers;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// Conversion extensions
    /// </summary>
    public static partial class ConversionExtensions {

        /// <summary>
        /// To DateTime
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTime CastToDateTime(this string str, DateTime defaultVal = default)
            => StringDateTimeDeterminer.To(str, defaultVal: defaultVal);

        /// <summary>
        /// To DateTimeOffset
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeOffset CastToDateTimeOffset(this string str, DateTimeOffset defaultVal = default)
            => StringDateTimeOffsetDeterminer.To(str, defaultVal: defaultVal);

        /// <summary>
        /// To TimeSpan
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TimeSpan CastToTimeSpan(this string str, TimeSpan defaultVal = default)
            => StringTimeSpanDeterminer.To(str, defaultVal: defaultVal);

        /// <summary>
        /// To nullable DateTime
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? CastToNullableDateTime(this string str) {
            if (StringDateTimeDeterminer.Is(str))
                return CastToDateTime(str);
            return null;
        }

        /// <summary>
        /// To nullable DateTimeOffset
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTimeOffset? CastToNullableDateTimeOffset(this string str) {
            if (StringDateTimeOffsetDeterminer.Is(str))
                return CastToDateTimeOffset(str);
            return null;
        }

        /// <summary>
        /// To nullable TimeSpan
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static TimeSpan? CastToNullableTimeSpan(this string str) {
            if (StringTimeSpanDeterminer.Is(str))
                return CastToTimeSpan(str);
            return null;
        }
    }
}