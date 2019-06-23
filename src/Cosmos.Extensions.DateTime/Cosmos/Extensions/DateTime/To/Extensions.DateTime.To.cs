using System;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
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
    }
}
