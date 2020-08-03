using System.Globalization;

namespace Cosmos.Date.Chinese
{
    /// <summary>
    /// Cosmos <see cref="DateInfo"/> leap extensions.
    /// </summary>
    public static class CosmosDateInfoLeapExtensions
    {
        /// <summary>
        /// Determine whether the specified year is a leap year.<br />
        /// 判断指定的年份是否为闰年。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsLeapYear(this DateInfo d) => ChineseDateHelper.IsLeapYear(null, d);

        /// <summary>
        /// Determine whether the specified year is a leap year.<br />
        /// 判断指定的年份是否为闰年。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static bool IsLeapYear(this DateInfo d, ChineseLunisolarCalendar calendar) => ChineseDateHelper.IsLeapYear(calendar, d);

        /// <summary>
        /// Determine whether the specified month is a leap month.<br />
        /// 判断指定的月份是否为闰月。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsLeapMonth(this DateInfo d) => ChineseDateHelper.IsLeapMonth(null, d);

        /// <summary>
        /// Determine whether the specified month is a leap month.<br />
        /// 判断指定的月份是否为闰月。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static bool IsLeapMonth(this DateInfo d, ChineseLunisolarCalendar calendar) => ChineseDateHelper.IsLeapMonth(calendar, d);

        /// <summary>
        /// Determine whether the specified day is a leap day.<br />
        /// 判断指定的日是否为闰日。
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsLeapDay(this DateInfo d) => ChineseDateHelper.IsLeapDay(null, d);

        /// <summary>
        /// Determine whether the specified day is a leap day.<br />
        /// 判断指定的日是否为闰日。
        /// </summary>
        /// <param name="d"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static bool IsLeapDay(this DateInfo d, ChineseLunisolarCalendar calendar) => ChineseDateHelper.IsLeapDay(calendar, d);
    }
}