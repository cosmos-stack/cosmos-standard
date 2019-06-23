using System;
using System.Globalization;
using Cosmos.Date;
using Cosmos.Date.Chinese;

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
        /// Is special year a leap year.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsLeapYear(this DateTime dt) => ChineseDateHelper.IsLeapYear(null, dt);

        /// <summary>
        /// Is special year a leap year.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static bool IsLeapYear(this DateTime dt, ChineseLunisolarCalendar calendar) => ChineseDateHelper.IsLeapYear(calendar, dt);

        /// <summary>
        /// Is special month a leap month.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsLeapMonth(this DateTime dt) => ChineseDateHelper.IsLeapMonth(null, dt);

        /// <summary>
        /// Is special month a leap month.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static bool IsLeapMonth(this DateTime dt, ChineseLunisolarCalendar calendar) => ChineseDateHelper.IsLeapMonth(calendar, dt);

        /// <summary>
        /// Is special day a leap day.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsLeapDay(this DateTime dt) => ChineseDateHelper.IsLeapDay(null, dt);

        /// <summary>
        /// Is special day a leap day.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static bool IsLeapDay(this DateTime dt, ChineseLunisolarCalendar calendar) => ChineseDateHelper.IsLeapDay(calendar, dt);
    }
}
