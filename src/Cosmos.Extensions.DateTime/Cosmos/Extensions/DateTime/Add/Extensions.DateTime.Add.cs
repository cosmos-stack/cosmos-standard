using System;
using NodaTime;

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
        /// Add duration<br />
        /// 添加一段持续的时间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static DateTime AddDuration(this DateTime date, Duration duration)
        {
            if (date == null)
                throw new ArgumentNullException(nameof(date));

            return date + duration.ToTimeSpan();
        }
    }
}
