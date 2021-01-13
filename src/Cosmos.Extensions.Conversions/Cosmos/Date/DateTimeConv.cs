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
        public static DateTime ToDateTime(object obj, DateTime defaultVal = default)
        {
            return DtConvX.ObjectToDateTime(obj, defaultVal);
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(object obj)
        {
            return DtConvX.ObjectToNullableDateTime(obj);
        }

        /// <summary>
        /// Convert from an <see cref="string"/> to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string text, DateTime defaultVal = default)
        {
            return DtConvX.StringToDateTime(text, defaultVal);
        }

        /// <summary>
        /// Convert from an <see cref="string"/> to nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DateTime? ToNullableDateTime(string text)
        {
            return DtConvX.StringToNullableDateTime(text);
        }

        #endregion

        #region DateTimeOffset

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(object obj, DateTimeOffset defaultVal = default)
        {
            return DtConvX.ObjectToDateTimeOffset(obj, defaultVal);
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTimeOffset? ToNullableDateTimeOffset(object obj)
        {
            return DtConvX.ObjectToNullableDateTimeOffset(obj);
        }

        /// <summary>
        /// Convert from an <see cref="string"/> to <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(string text, DateTimeOffset defaultVal = default)
        {
            return DtConvX.StringToDateTimeOffset(text, defaultVal);
        }

        /// <summary>
        /// Convert from an <see cref="string"/> to nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DateTimeOffset? ToNullableDateTimeOffset(string text)
        {
            return DtConvX.StringToNullableDateTimeOffset(text);
        }

        #endregion

        #region TimeSpan

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(object obj, TimeSpan defaultVal = default)
        {
            return DtConvX.ObjectToTimeSpan(obj, defaultVal);
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TimeSpan? ToNullableTimeSpan(object obj)
        {
            return DtConvX.ObjectToNullableTimeSpan(obj);
        }

        /// <summary>
        /// Convert from an <see cref="string"/> to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(string text, TimeSpan defaultVal = default)
        {
            return DtConvX.StringToTimeSpan(text, defaultVal);
        }

        /// <summary>
        /// Convert from an <see cref="string"/> to nullable <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static TimeSpan? ToNullableTimeSpan(string text)
        {
            return DtConvX.StringToNullableTimeSpan(text);
        }

        #endregion
    }
}