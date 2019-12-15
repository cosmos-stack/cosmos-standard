using System.Globalization;
using Cosmos.Date;
using Cosmos.Date.Chinese;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// DateInfo Extensions<br />
    /// DateInfo 扩展方法
    /// </summary>
    public static partial class DateInfoExtensions {
        /// <summary>
        /// Is special year a leap year.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsLeapYear(this DateInfo d) => ChineseDateHelper.IsLeapYear(null, d);

        /// <summary>
        /// Is special year a leap year.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static bool IsLeapYear(this DateInfo d, ChineseLunisolarCalendar calendar) => ChineseDateHelper.IsLeapYear(calendar, d);

        /// <summary>
        /// Is special month a leap month.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsLeapMonth(this DateInfo d) => ChineseDateHelper.IsLeapMonth(null, d);

        /// <summary>
        /// Is special month a leap month.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static bool IsLeapMonth(this DateInfo d, ChineseLunisolarCalendar calendar) => ChineseDateHelper.IsLeapMonth(calendar, d);

        /// <summary>
        /// Is special day a leap day.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsLeapDay(this DateInfo d) => ChineseDateHelper.IsLeapDay(null, d);

        /// <summary>
        /// Is special day a leap day.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="calendar"></param>
        /// <returns></returns>
        public static bool IsLeapDay(this DateInfo d, ChineseLunisolarCalendar calendar) => ChineseDateHelper.IsLeapDay(calendar, d);
    }
}