using System;
using System.Runtime.CompilerServices;
using CosmosStack.Conversions.Common.Core;

namespace CosmosStack.Text
{
    /// <summary>
    /// CosmosStack <see cref="string"/> casting extensions. <br />
    /// 字符串转换扩展
    /// </summary>
    public static partial class StringConvExtensions
    {
        #region Cast String to DateTime

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="DateTime"/> <br />
        /// 将字符串转换为日期和时间
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime CastToDateTime(this string text, DateTime defaultVal = default)
        {
            return DtConvX.StringToDateTime(text, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="DateTime"/> <br />
        /// 将字符串转换为可空的日期和时间
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime? CastToNullableDateTime(this string text)
        {
            return DtConvX.StringToNullableDateTime(text);
        }

        #endregion

        #region Cast String to DateTimeOffset

        /// <summary>
        /// To DateTimeOffset <br />
        /// 将字符串转换为 <see cref="DateTimeOffset"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset CastToDateTimeOffset(this string text, DateTimeOffset defaultVal = default)
        {
            return DtConvX.StringToDateTimeOffset(text, defaultVal);
        }

        /// <summary>
        /// To nullable DateTimeOffset <br />
        /// 将字符串转换为可空的 <see cref="DateTimeOffset"/>
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset? CastToNullableDateTimeOffset(this string text)
        {
            return DtConvX.StringToNullableDateTimeOffset(text);
        }

        #endregion

        #region Cast String to TimeSpan

        /// <summary>
        /// To TimeSpan <br />
        /// 将字符串转换为 <see cref="TimeSpan"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan CastToTimeSpan(this string text, TimeSpan defaultVal = default)
        {
            return DtConvX.StringToTimeSpan(text, defaultVal);
        }

        /// <summary>
        /// To nullable TimeSpan <br />
        /// 将字符串转换为可空 <see cref="TimeSpan"/>
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TimeSpan? CastToNullableTimeSpan(this string text)
        {
            return DtConvX.StringToNullableTimeSpan(text);
        }

        #endregion
    }
}