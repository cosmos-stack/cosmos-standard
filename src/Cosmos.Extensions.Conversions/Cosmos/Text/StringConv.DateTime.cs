using System;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Text
{
    /// <summary>
    /// Cosmos <see cref="string"/> casting extensions.
    /// </summary>
    public static partial class StringConvExtensions
    {
        #region Cast String to DateTime

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="DateTime"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTime CastToDateTime(this string text, DateTime defaultVal = default)
        {
            return DtConvX.StringToDateTime(text, defaultVal);
        }

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="DateTime"/>
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DateTime? CastToNullableDateTime(this string text)
        {
            return DtConvX.StringToNullableDateTime(text);
        }

        #endregion

        #region Cast String to DateTimeOffset

        /// <summary>
        /// To DateTimeOffset
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeOffset CastToDateTimeOffset(this string text, DateTimeOffset defaultVal = default)
        {
            return DtConvX.StringToDateTimeOffset(text, defaultVal);
        }

        /// <summary>
        /// To nullable DateTimeOffset
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static DateTimeOffset? CastToNullableDateTimeOffset(this string text)
        {
            return DtConvX.StringToNullableDateTimeOffset(text);
        }

        #endregion

        #region Cast String to TimeSpan

        /// <summary>
        /// To TimeSpan
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TimeSpan CastToTimeSpan(this string text, TimeSpan defaultVal = default)
        {
            return DtConvX.StringToTimeSpan(text, defaultVal);
        }

        /// <summary>
        /// To nullable TimeSpan
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static TimeSpan? CastToNullableTimeSpan(this string text)
        {
            return DtConvX.StringToNullableTimeSpan(text);
        }

        #endregion
    }
}