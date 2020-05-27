using System;
using Cosmos.Judgments;

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
        /// Is today
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTime date) => DateTimeJudgment.IsToday(date);

        /// <summary>
        /// Is today
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsToday(this DateTime? date) => DateTimeJudgment.IsToday(date);

        /// <summary>
        /// Is Morning
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsMorning(this DateTime dt)
        {
            var hour = dt.Hour;
            return 6 <= hour && hour < 12;
        }

        /// <summary>
        /// Is early morning
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsEarlyMorning(this DateTime dt)
        {
            var hour = dt.Hour;
            return 0 <= hour && hour < 6;
        }

        /// <summary>
        /// Is Afternoon
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsAfternoon(this DateTime dt)
        {
            var hour = dt.Hour;
            return 12 <= hour && hour < 18;
        }

        /// <summary>
        /// Is Dusk
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsDusk(this DateTime dt)
        {
            var hour = dt.Hour;
            return 16 <= hour && hour < 19;
        }

        /// <summary>
        /// Is evening
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsEvening(this DateTime dt)
        {
            var hour = dt.Hour;
            return 18 < hour && hour <= 24 || 0 <= hour && hour < 6;
        }

        /// <summary>
        /// Is before
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        public static bool IsBefore(this DateTime dt, DateTime toCompareWith) => dt < toCompareWith;

        /// <summary>
        /// Is after
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="toCompareWith"></param>
        /// <returns></returns>
        public static bool IsAfter(this DateTime dt, DateTime toCompareWith) => dt > toCompareWith;

        /// <summary>
        /// Is in future
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsInFuture(this DateTime dt) => dt > DateTime.Now;

        /// <summary>
        /// Is in past
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsInPast(this DateTime dt) => dt < DateTime.Now;

        /// <summary>
        /// Is Weekday <br />
        /// 判断是否为工作日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekday(this DateTime date) => DateTimeJudgment.IsWeekday(date);

        /// <summary>
        /// Is Weekday <br />
        /// 判断是否为工作日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekday(this DateTime? date) => DateTimeJudgment.IsWeekday(date);

        /// <summary>
        /// Is Weekday <br />
        /// 判断是否为周末
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime date) => DateTimeJudgment.IsWeekend(date);

        /// <summary>
        /// Is Weekday <br />
        /// 判断是否为周末
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime? date) => DateTimeJudgment.IsWeekend(date);

        /// <summary>
        /// Is same day
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameDay(this DateTime dt, DateTime date) => dt.Date == date.Date;

        /// <summary>
        /// Is same month
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameMonth(this DateTime dt, DateTime date) => dt.Month == date.Month;

        /// <summary>
        /// Is same year
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsSameYear(this DateTime dt, DateTime date) => dt.Year == date.Year;

        /// <summary>
        /// Is date equal...
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsDateEqual(this DateTime dt, DateTime date) => dt.IsSameDay(date);

        /// <summary>
        /// Is time equal...
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsTimeEqual(this DateTime dt, DateTime date) => dt.TimeOfDay == date.TimeOfDay;
    }
}