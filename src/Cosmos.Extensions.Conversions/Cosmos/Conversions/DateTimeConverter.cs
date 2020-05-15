using System;
using Cosmos.Conversions.Core;

namespace Cosmos.Conversions {
    /// <summary>
    /// DateTime converter
    /// </summary>
    public static class DateTimeConverter {

        #region DateTime

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object obj, DateTime defaultVal = default) => DateTimeConv.ObjectToDateTime(obj, defaultVal);

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(object obj) => DateTimeConv.ObjectToNullableDateTime(obj);

        /// <summary>
        /// Convert from an <see cref="string"/> to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string str, DateTime defaultVal = default) => DateTimeConv.StringToDateTime(str, defaultVal);

        /// <summary>
        /// Convert from an <see cref="string"/> to nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(string str) => DateTimeConv.StringToNullableDateTime(str);

        #endregion

        #region DateTimeOffset

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(object obj, DateTimeOffset defaultVal = default) => DateTimeConv.ObjectToDateTimeOffset(obj, defaultVal);

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTimeOffset? ToNullableDateTimeOffset(object obj) => DateTimeConv.ObjectToNullableDateTimeOffset(obj);

        /// <summary>
        /// Convert from an <see cref="string"/> to <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(string str, DateTimeOffset defaultVal = default) => DateTimeConv.StringToDateTimeOffset(str, defaultVal);

        /// <summary>
        /// Convert from an <see cref="string"/> to nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTimeOffset? ToNullableDateTimeOffset(string str) => DateTimeConv.StringToNullableDateTimeOffset(str);

        #endregion

        #region TimeSpan

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(object obj, TimeSpan defaultVal = default) => DateTimeConv.ObjectToTimeSpan(obj, defaultVal);

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TimeSpan? ToNullableTimeSpan(object obj) => DateTimeConv.ObjectToNullableTimeSpan(obj);

        /// <summary>
        /// Convert from an <see cref="string"/> to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(string str, TimeSpan defaultVal = default) => DateTimeConv.StringToTimeSpan(str, defaultVal);

        /// <summary>
        /// Convert from an <see cref="string"/> to nullable <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static TimeSpan? ToNullableTimeSpan(string str) => DateTimeConv.StringToNullableTimeSpan(str);

        #endregion

    }
}