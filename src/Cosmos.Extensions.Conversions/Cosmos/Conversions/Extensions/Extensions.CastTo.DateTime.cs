using System;
using Cosmos.Conversions.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions {
    /// <summary>
    /// Extensions for CastTo opts
    /// </summary>
    public static partial class CastToExtensions {

        #region DateTime

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="DateTime"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTime CastToDateTime(this string str, DateTime defaultVal = default) => DateTimeConv.StringToDateTime(str, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="DateTime"/>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? CastToNullableDateTime(this string str) => DateTimeConv.StringToNullableDateTime(str);

        #endregion

        #region DateTimeOffset

        /// <summary>
        /// To DateTimeOffset
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeOffset CastToDateTimeOffset(this string str, DateTimeOffset defaultVal = default) => DateTimeConv.StringToDateTimeOffset(str, defaultVal);

        /// <summary>
        /// To nullable DateTimeOffset
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTimeOffset? CastToNullableDateTimeOffset(this string str) => DateTimeConv.StringToNullableDateTimeOffset(str);

        #endregion

        #region TimeSpan

        /// <summary>
        /// To TimeSpan
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TimeSpan CastToTimeSpan(this string str, TimeSpan defaultVal = default) => DateTimeConv.StringToTimeSpan(str, defaultVal);

        /// <summary>
        /// To nullable TimeSpan
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static TimeSpan? CastToNullableTimeSpan(this string str) => DateTimeConv.StringToNullableTimeSpan(str);

        #endregion

    }
}