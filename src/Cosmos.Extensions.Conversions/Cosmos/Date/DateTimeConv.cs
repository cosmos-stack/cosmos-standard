using System;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Date
{
    /// <summary>
    /// DateTime converter
    /// </summary>
    public static class DateTimeConv
    {
        #region DateTime

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object obj, DateTime defaultVal = default) => DtConvX.ObjectToDateTime(obj, defaultVal);

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(object obj) => DtConvX.ObjectToNullableDateTime(obj);

        /// <summary>
        /// Convert from an <see cref="string"/> to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string str, DateTime defaultVal = default) => DtConvX.StringToDateTime(str, defaultVal);

        /// <summary>
        /// Convert from an <see cref="string"/> to nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(string str) => DtConvX.StringToNullableDateTime(str);

        #endregion

        #region DateTimeOffset

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(object obj, DateTimeOffset defaultVal = default) => DtConvX.ObjectToDateTimeOffset(obj, defaultVal);

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTimeOffset? ToNullableDateTimeOffset(object obj) => DtConvX.ObjectToNullableDateTimeOffset(obj);

        /// <summary>
        /// Convert from an <see cref="string"/> to <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(string str, DateTimeOffset defaultVal = default) => DtConvX.StringToDateTimeOffset(str, defaultVal);

        /// <summary>
        /// Convert from an <see cref="string"/> to nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTimeOffset? ToNullableDateTimeOffset(string str) => DtConvX.StringToNullableDateTimeOffset(str);

        #endregion

        #region TimeSpan

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(object obj, TimeSpan defaultVal = default) => DtConvX.ObjectToTimeSpan(obj, defaultVal);

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TimeSpan? ToNullableTimeSpan(object obj) => DtConvX.ObjectToNullableTimeSpan(obj);

        /// <summary>
        /// Convert from an <see cref="string"/> to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(string str, TimeSpan defaultVal = default) => DtConvX.StringToTimeSpan(str, defaultVal);

        /// <summary>
        /// Convert from an <see cref="string"/> to nullable <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static TimeSpan? ToNullableTimeSpan(string str) => DtConvX.StringToNullableTimeSpan(str);

        #endregion
    }
}