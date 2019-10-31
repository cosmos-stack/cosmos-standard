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
        /// Is current date between <paramref name="from"/> and <paramref to="to"/>.<br />
        /// 判断当前日期是否在 from 和 to 之间
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="includeBoundary"></param>
        /// <returns></returns>
        public static bool IsBetween(this DateTime dt, DateTime from, DateTime to, bool includeBoundary = true)
        {
            return includeBoundary
                ? dt >= from && dt <= to
                : dt > @from && dt < to;
        }

        /// <summary>
        /// Is current date between <paramref name="min"/> and <paramref name="max"/> with boundary.<br />
        /// 判断当前日期是否在 min 和 max 之间，闭包区间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsDateBetweenWithBoundary(this DateTime dt, DateTime min, DateTime max)
            => dt.IsBetween(min, max.AddDays(+1), false);

        /// <summary>
        /// Is current date between <paramref name="min"/> and <paramref name="max"/> with boundary.<br />
        /// 判断当前日期是否在 min 和 max 之间，闭包区间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsDateBetweenWithBoundary(this DateTime dt, DateTime? min, DateTime? max)
        {
            if (min.HasValue && max.HasValue)
                return dt.IsDateBetweenWithBoundary(min.Value, max.Value);

            if (min.HasValue)
                return dt >= min.Value;

            if (max.HasValue)
                return dt < max.Value.AddDays(+1);

            return true;
        }

        /// <summary>
        /// Is current date between <paramref name="min"/> and <paramref name="max"/> without boundary.<br />
        /// 判断当前日期是否在 min 和 max 之间，开区间。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsDateBetweenWithoutBoundary(this DateTime dt, DateTime min, DateTime max)
            => dt.IsBetween(min, max, false);
    }
}
