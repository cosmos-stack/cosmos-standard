using System;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Text
{
    /// <summary>
    /// Cosmos <see cref="string"/> casting extensions.
    /// </summary>
    public static partial class StringCastingExtensions
    {
        #region Cast String to DateTime

        /// <summary>
        /// Convert <see cref="string"/> to <see cref="DateTime"/>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTime CastToDateTime(this string str, DateTime defaultVal = default) => DtConvX.StringToDateTime(str, defaultVal);

        /// <summary>
        /// Convert <see cref="string"/> to nullable <see cref="DateTime"/>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? CastToNullableDateTime(this string str) => DtConvX.StringToNullableDateTime(str);

        #endregion

        #region Cast String to DateTimeOffset

        /// <summary>
        /// To DateTimeOffset
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeOffset CastToDateTimeOffset(this string str, DateTimeOffset defaultVal = default) => DtConvX.StringToDateTimeOffset(str, defaultVal);

        /// <summary>
        /// To nullable DateTimeOffset
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTimeOffset? CastToNullableDateTimeOffset(this string str) => DtConvX.StringToNullableDateTimeOffset(str);

        #endregion

        #region Cast String to TimeSpan

        /// <summary>
        /// To TimeSpan
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TimeSpan CastToTimeSpan(this string str, TimeSpan defaultVal = default) => DtConvX.StringToTimeSpan(str, defaultVal);

        /// <summary>
        /// To nullable TimeSpan
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static TimeSpan? CastToNullableTimeSpan(this string str) => DtConvX.StringToNullableTimeSpan(str);

        #endregion
    }
}