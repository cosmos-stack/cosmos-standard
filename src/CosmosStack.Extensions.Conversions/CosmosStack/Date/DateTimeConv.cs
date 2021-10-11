using System;
using System.Runtime.CompilerServices;
using CosmosStack.Conversions.Common.Core;

namespace CosmosStack.Date
{
    /// <summary>
    /// DateTime converter <br />
    /// 日期时间转换器
    /// </summary>
    public static class DateTimeConv
    {
        #region DateTime

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="DateTime"/>. <br />
        /// 从对象转换为日期与时间
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime ToDateTime(object obj, DateTime defaultVal = default)
        {
            return DtConvX.ObjectToDateTime(obj, defaultVal);
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="DateTime"/>. <br />
        /// 从对象转换为可空的日期与时间
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime? ToNullableDateTime(object obj)
        {
            return DtConvX.ObjectToNullableDateTime(obj);
        }

        /// <summary>
        /// Convert from an <see cref="string"/> to <see cref="DateTime"/>. <br />
        /// 将字符串转换为日期与时间
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime ToDateTime(string text, DateTime defaultVal = default)
        {
            return DtConvX.StringToDateTime(text, defaultVal);
        }

        /// <summary>
        /// Convert from an <see cref="string"/> to nullable <see cref="DateTime"/>. <br />
        /// 将字符串转换为可空的日期与时间
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime? ToNullableDateTime(string text)
        {
            return DtConvX.StringToNullableDateTime(text);
        }

        #endregion

        #region DateTimeOffset

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="DateTimeOffset"/>. <br />
        /// 将对象转换为 <see cref="DateTimeOffset"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset ToDateTimeOffset(object obj, DateTimeOffset defaultVal = default)
        {
            return DtConvX.ObjectToDateTimeOffset(obj, defaultVal);
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="DateTimeOffset"/>. <br />
        /// 将对象转换为可空的 <see cref="DateTimeOffset"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset? ToNullableDateTimeOffset(object obj)
        {
            return DtConvX.ObjectToNullableDateTimeOffset(obj);
        }

        /// <summary>
        /// Convert from an <see cref="string"/> to <see cref="DateTimeOffset"/>. <br />
        /// 将字符串转换为 <see cref="DateTimeOffset"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset ToDateTimeOffset(string text, DateTimeOffset defaultVal = default)
        {
            return DtConvX.StringToDateTimeOffset(text, defaultVal);
        }

        /// <summary>
        /// Convert from an <see cref="string"/> to nullable <see cref="DateTimeOffset"/>. <br />
        /// 将字符串转换为可空的 <see cref="DateTimeOffset"/>
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset? ToNullableDateTimeOffset(string text)
        {
            return DtConvX.StringToNullableDateTimeOffset(text);
        }

        #endregion

        #region TimeSpan

        /// <summary>
        /// Convert from an <see cref="object"/> to <see cref="TimeSpan"/>. <br />
        /// 将对象转换为 <see cref="TimeSpan"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan ToTimeSpan(object obj, TimeSpan defaultVal = default)
        {
            return DtConvX.ObjectToTimeSpan(obj, defaultVal);
        }

        /// <summary>
        /// Convert from an <see cref="object"/> to nullable <see cref="TimeSpan"/>. <br />
        /// 将对象转换为可空的 <see cref="TimeSpan"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan? ToNullableTimeSpan(object obj)
        {
            return DtConvX.ObjectToNullableTimeSpan(obj);
        }

        /// <summary>
        /// Convert from an <see cref="string"/> to <see cref="TimeSpan"/>. <br />
        /// 将字符串转换为 <see cref="TimeSpan"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan ToTimeSpan(string text, TimeSpan defaultVal = default)
        {
            return DtConvX.StringToTimeSpan(text, defaultVal);
        }

        /// <summary>
        /// Convert from an <see cref="string"/> to nullable <see cref="TimeSpan"/>. <br />
        /// 将字符串转换为可空 <see cref="TimeSpan"/>
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan? ToNullableTimeSpan(string text)
        {
            return DtConvX.StringToNullableTimeSpan(text);
        }

        #endregion
    }
}