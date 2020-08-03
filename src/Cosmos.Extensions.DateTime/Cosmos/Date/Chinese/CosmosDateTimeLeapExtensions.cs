using System;
using System.Globalization;

namespace Cosmos.Date.Chinese
{
    /// <summary>
    /// Cosmos <see cref="DateTime"/> leap extensions.
    /// </summary>
    public static class CosmosDateTimeLeapExtensions
    {
        /// <summary>
        /// Determine whether the specified year is a leap year.<br />
        /// 判断指定的年份是否为闰年。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsLeapYear(this DateTime dt) => ChineseDateHelper.IsLeapYear(null, dt);

        /// <summary>
        /// Determine whether the specified year is a leap year.<br />
        /// 判断指定的年份是否为闰年。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static bool IsLeapYear(this DateTime dt, ChineseLunisolarCalendar calendar) => ChineseDateHelper.IsLeapYear(calendar, dt);

        /// <summary>
        /// Determine whether the specified month is a leap month.<br />
        /// 判断指定的月份是否为闰月。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsLeapMonth(this DateTime dt) => ChineseDateHelper.IsLeapMonth(null, dt);

        /// <summary>
        /// Determine whether the specified month is a leap month.<br />
        /// 判断指定的月份是否为闰月。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static bool IsLeapMonth(this DateTime dt, ChineseLunisolarCalendar calendar) => ChineseDateHelper.IsLeapMonth(calendar, dt);

        /// <summary>
        /// Determine whether the specified day is a leap day.<br />
        /// 判断指定的日是否为闰日。
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsLeapDay(this DateTime dt) => ChineseDateHelper.IsLeapDay(null, dt);

        /// <summary>
        /// Determine whether the specified day is a leap day.<br />
        /// 判断指定的日是否为闰日。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static bool IsLeapDay(this DateTime dt, ChineseLunisolarCalendar calendar) => ChineseDateHelper.IsLeapDay(calendar, dt);
    }
}