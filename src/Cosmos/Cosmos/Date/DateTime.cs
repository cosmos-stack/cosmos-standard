using System;
using System.Globalization;

namespace Cosmos.Date
{
    public enum DateTimeOutputStyles
    {
        DateTime,
        Date,
        Time,
        LongDate,
        LongTime,
        ShortDate,
        ShortTime,
        Millisecond,
    }

    internal static class DateTimeHelper
    {
        public static string Ifttt(bool condition, string format1, string format2)
        {
            return condition.Ifttt(() => format1, () => format2);
        }
    }

    public static class DateTimeToStringExtensions
    {
        public static string ToString(this DateTime dt, DateTimeOutputStyles styles, bool isRemoveSecond = false)
        {
            return styles switch
            {
                DateTimeOutputStyles.DateTime => dt.ToString(DateTimeHelper.Ifttt(isRemoveSecond, "yyyy-MM-dd HH:mm", "yyyy-MM-dd HH:mm:ss")),
                DateTimeOutputStyles.Date => dt.ToString("yyyy-MM-dd"),
                DateTimeOutputStyles.Time => dt.ToString(DateTimeHelper.Ifttt(isRemoveSecond, "HH:mm", "HH:mm:ss")),
                DateTimeOutputStyles.LongDate => dt.ToLongDateString(),
                DateTimeOutputStyles.LongTime => dt.ToLongTimeString(),
                DateTimeOutputStyles.ShortDate => dt.ToShortDateString(),
                DateTimeOutputStyles.ShortTime => dt.ToShortTimeString(),
                DateTimeOutputStyles.Millisecond => dt.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                _ => dt.ToString(CultureInfo.InvariantCulture)
            };
        }

        public static string ToString(this DateTime? dt, DateTimeOutputStyles styles, bool isRemoveSecond = false)
        {
            return dt is null ? string.Empty : dt.Value.ToString(styles, isRemoveSecond);
        }

        /// <summary>
        /// 将时间转换为时间点
        /// </summary>
        /// <param name="localDateTime"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this DateTime localDateTime)
        {
            return localDateTime.ToDateTimeOffset(null);
        }

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
        {
            return dateTimeUtc.ToLocalDateTime(null);
        }

        /// <summary>
        /// 将时间点转换为时间
        /// </summary>
        /// <param name="dateTimeUtc"></param>
        /// <param name="localTimeZone"></param>
        /// <returns></returns>
        public static DateTime ToLocalDateTime(this DateTimeOffset dateTimeUtc, TimeZoneInfo localTimeZone)
        {
            return TimeZoneInfo.ConvertTime(dateTimeUtc, localTimeZone ?? TimeZoneInfo.Local).DateTime;
        }

    }
}