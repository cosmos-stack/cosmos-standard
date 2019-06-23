using System;

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
        /// Is current date between <see cref="from"/> and <see cref="to"/>.<br />
        /// 判断当前日期是否在 from 和 to 之间
        /// </summary>
        /// <param name="date"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="includeBoundary"></param>
        /// <returns></returns>
        public static bool IsBetween(this DateTime date, DateTime from, DateTime to, bool includeBoundary = true)
        {
            return includeBoundary
                ? date >= from && date <= to
                : date > @from && date < to;
        }

        /// <summary>
        /// Is current date between <see cref="min"/> and <see cref="max"/> with boundary.<br />
        /// 判断当前日期是否在 min 和 max 之间，闭包区间。
        /// </summary>
        /// <param name="date"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsDateBetweenWithBoundary(this DateTime date, DateTime min, DateTime max)
            => date.IsBetween(min, max.AddDays(+1), false);

        /// <summary>
        /// Is current date between <see cref="min"/> and <see cref="max"/> with boundary.<br />
        /// 判断当前日期是否在 min 和 max 之间，闭包区间。
        /// </summary>
        /// <param name="date"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsDateBetweenWithBoundary(this DateTime date, DateTime? min, DateTime? max)
        {
            if (min.HasValue && max.HasValue)
                return date.IsDateBetweenWithBoundary(min.Value, max.Value);

            if (min.HasValue)
                return date >= min.Value;

            if (max.HasValue)
                return date < max.Value.AddDays(+1);

            return true;
        }

        /// <summary>
        /// Is current date between <see cref="min"/> and <see cref="max"/> without boundary.<br />
        /// 判断当前日期是否在 min 和 max 之间，开区间。
        /// </summary>
        /// <param name="date"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsDateBetweenWithoutBoundary(this DateTime date, DateTime min, DateTime max)
            => date.IsBetween(min, max, false);
    }
}
