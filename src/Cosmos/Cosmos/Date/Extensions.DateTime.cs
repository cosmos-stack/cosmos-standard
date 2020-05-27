using System;

namespace Cosmos.Date
{
    /// <summary>
    /// DateTime Extensions
    /// </summary>
    public static class DateTimeExtensions
    {
        #region To DateTime String

        /// <summary>
        /// 获取格式化字符串，带时分秒，格式："yyyy-MM-dd HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="isRemoveSecond">是否移除秒</param>
        public static string ToDateTimeString(this DateTime dateTime, bool isRemoveSecond = false)
            => dateTime.ToString(isRemoveSecond ? "yyyy-MM-dd HH:mm" : "yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 获取格式化字符串，带时分秒，格式："yyyy-MM-dd HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="isRemoveSecond">是否移除秒</param>
        public static string ToDateTimeString(this DateTime? dateTime, bool isRemoveSecond = false)
            => dateTime is null ? string.Empty : ToDateTimeString(dateTime.Value, isRemoveSecond);

        #endregion

        #region To Date String

        /// <summary>
        /// 获取格式化字符串，不带时分秒，格式："yyyy-MM-dd"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToDateString(this DateTime dateTime)
            => dateTime.ToString("yyyy-MM-dd");

        /// <summary>
        /// 获取格式化字符串，不带时分秒，格式："yyyy-MM-dd"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToDateString(this DateTime? dateTime)
            => dateTime is null ? string.Empty : ToDateString(dateTime.Value);

        #endregion

        #region To Time String

        /// <summary>
        /// 获取格式化字符串，不带年月日，格式："HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToTimeString(this DateTime dateTime)
            => dateTime.ToString("HH:mm:ss");

        /// <summary>
        /// 获取格式化字符串，不带年月日，格式："HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToTimeString(this DateTime? dateTime)
            => dateTime == null ? string.Empty : ToTimeString(dateTime.Value);

        #endregion

        #region To Millisecond String

        /// <summary>
        /// 获取格式化字符串，带毫秒，格式："yyyy-MM-dd HH:mm:ss.fff"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToMillisecondString(this DateTime dateTime)
            => dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

        /// <summary>
        /// 获取格式化字符串，带毫秒，格式："yyyy-MM-dd HH:mm:ss.fff"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToMillisecondString(this DateTime? dateTime)
            => dateTime is null ? string.Empty : ToMillisecondString(dateTime.Value);

        #endregion

        #region To DateTimeOffset

        /// <summary>
        /// 将时间转换为时间点
        /// </summary>
        /// <param name="localDateTime"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this DateTime localDateTime)
            => localDateTime.ToDateTimeOffset(null);

        /// <summary>
        /// 将时间转换为时间点
        /// </summary>
        /// <param name="localDateTime"></param>
        /// <param name="localTimeZone"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this DateTime localDateTime, TimeZoneInfo localTimeZone)
        {
            if (localDateTime.Kind != DateTimeKind.Unspecified)
                localDateTime = new DateTime(localDateTime.Ticks, DateTimeKind.Unspecified);

            return TimeZoneInfo.ConvertTime(localDateTime, localTimeZone ?? TimeZoneInfo.Local);
        }

        #endregion

        #region To Local DateTime

        /// <summary>
        /// 将时间点转换为时间
        /// </summary>
        /// <param name="dateTimeUtc"></param>
        /// <returns></returns>
        public static DateTime ToLocalDateTime(this DateTimeOffset dateTimeUtc)
            => dateTimeUtc.ToLocalDateTime(null);

        /// <summary>
        /// 将时间点转换为时间
        /// </summary>
        /// <param name="dateTimeUtc"></param>
        /// <param name="localTimeZone"></param>
        /// <returns></returns>
        public static DateTime ToLocalDateTime(this DateTimeOffset dateTimeUtc, TimeZoneInfo localTimeZone)
            => TimeZoneInfo.ConvertTime(dateTimeUtc, localTimeZone ?? TimeZoneInfo.Local).DateTime;

        #endregion
    }
}