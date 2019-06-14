namespace System
{
    /// <summary>
    /// Base Type Extensions
    /// </summary>
    public static partial class BaseTypeExtensions
    {
        #region SetDateTime(设置时间)

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static DateTime SetDateTime(this DateTime date, int hours, int minutes, int seconds)
            => date.SetDateTime(new TimeSpan(hours, minutes, seconds));

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime SetDateTime(this DateTime date, TimeSpan time)
            => date.Date.Add(time);

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDateTime(this DateTimeOffset date, int hours, int minutes, int seconds)
            => date.SetDateTime(new TimeSpan(hours, minutes, seconds));

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDateTime(this DateTimeOffset date, TimeSpan time)
            => date.SetDateTime(time, null);

        /// <summary>
        /// 设置时间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="localTimeZone"></param>
        /// <returns></returns>
        public static DateTimeOffset SetDateTime(this DateTimeOffset date, TimeSpan time, TimeZoneInfo localTimeZone)
            => date.ToLocalDateTime(localTimeZone).SetDateTime(time).ToDateTimeOffset(localTimeZone);

        #endregion 设置时间

        #region ToDateTimeString(获取格式化字符串)

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
            => dateTime == null ? string.Empty : ToDateTimeString(dateTime.Value, isRemoveSecond);

        #endregion

        #region ToDateString(获取格式化字符串)

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
            => dateTime == null ? string.Empty : ToDateString(dateTime.Value);

        #endregion

        #region ToTimeString(获取格式化字符串)

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

        #region ToMillisecondString(获取格式化字符串)

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
            => dateTime == null ? string.Empty : ToMillisecondString(dateTime.Value);

        #endregion

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

        /// <summary>
        /// Set time<br />
        /// 设置时间
        /// </summary>
        /// <param name="current"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static DateTime SetTime(this DateTime current, int hour)
        {
            return SetTime(current, hour, 0, 0, 0);
        }

        /// <summary>
        /// Set time<br />
        /// 设置时间
        /// </summary>
        /// <param name="current"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static DateTime SetTime(this DateTime current, int hour, int minute)
        {
            return SetTime(current, hour, minute, 0, 0);
        }

        /// <summary>
        /// Set time<br />
        /// 设置时间
        /// </summary>
        /// <param name="current"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTime SetTime(this DateTime current, int hour, int minute, int second)
        {
            return SetTime(current, hour, minute, second, 0);
        }

        /// <summary>
        /// Set time<br />
        /// 设置时间
        /// </summary>
        /// <param name="current"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <param name="millisecond"></param>
        /// <returns></returns>
        public static DateTime SetTime(this DateTime current, int hour, int minute, int second, int millisecond)
        {
            return new DateTime(current.Year, current.Month, current.Day, hour, minute, second, millisecond);
        }
    }
}
