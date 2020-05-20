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
        /// Add weeks.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="weeks"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTime AddWeeks(this DateTime dt, int weeks)
        {
            if (dt == null)
                throw new ArgumentNullException(nameof(dt));

            return dt + weeks.Weeks();
        }

        /// <summary>
        /// Add quarters
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="quarters"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTime AddQuarters(this DateTime dt, int quarters)
        {
            if (dt == null)
                throw new ArgumentNullException(nameof(dt));

            return dt + quarters.Quarters();
        }

        /// <summary>
        /// Add duration<br />
        /// 添加一段持续的时间
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static DateTime AddDuration(this DateTime dt, Duration duration)
        {
            if (dt == null)
                throw new ArgumentNullException(nameof(dt));

            return dt + duration.ToTimeSpan();
        }

        /// <summary>
        /// Add business days<br />
        /// 添加指定个数量的工作日
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static DateTime AddBusinessDays(this DateTime dt, int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    dt = dt.AddDays(sign);
                }
                while (dt.DayOfWeek == DayOfWeek.Saturday ||
                       dt.DayOfWeek == DayOfWeek.Sunday);
            }

            return dt;
        }

        /// <summary>
        /// Subtract business days<br />
        /// 减去指定个数量的工作日
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static DateTime SubtractBusinessDays(this DateTime dt, int days) => AddBusinessDays(dt, -days);
    }
}