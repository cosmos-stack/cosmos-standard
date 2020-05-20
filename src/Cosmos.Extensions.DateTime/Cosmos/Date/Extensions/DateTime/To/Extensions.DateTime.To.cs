using System;
using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// DateTime Extensions<br />
    /// DateTime 扩展方法
    /// </summary>
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// Convert to utc date<br />
        /// 转换为 UTC 时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime ToUtc(this DateTime date) => new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Utc);

        /// <summary>
        /// Convert <see cref="DateTime"/> to <see cref="DateInfo"/>.<br />
        /// 将 <see cref="DateTime"/> 转换为 <see cref="DateInfo"/>。
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateInfo ToDateInfo(this DateTime date) => new DateInfo(date);

        /// <summary>
        /// Convert <see cref="DateTime"/> to <see cref="LocalDateTime"/>.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static LocalDateTime ToLocalDateTime(this DateTime dateTime) => LocalDateTime.FromDateTime(dateTime);

        /// <summary>
        /// Convert <see cref="DateTime"/> to <see cref="LocalDate"/>.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static LocalDate ToLocalDate(this DateTime date) => LocalDate.FromDateTime(date);

        /// <summary>
        /// Convert <see cref="DateTime"/> to <see cref="LocalTime"/>.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static LocalTime ToLocalTime(this DateTime t) => new LocalTime(t.Hour, t.Minute, t.Second, t.Millisecond);

        /// <summary>
        /// Convert <see cref="DateTime"/> to Epoch time span.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static TimeSpan ToEpochTimeSpan(this DateTime dt) => dt.Subtract(DateTimeFactory.Create(1970, 1, 1));
    }
}