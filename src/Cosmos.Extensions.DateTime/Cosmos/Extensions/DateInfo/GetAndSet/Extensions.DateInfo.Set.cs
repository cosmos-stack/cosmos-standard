using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// DateInfo Extensions<br />
    /// DateInfo 扩展方法
    /// </summary>
    public static partial class DateInfoExtensions
    {
        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="d"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateInfo SetDate(this DateInfo d, int year)
        {
            d.Year = year;
            return d;
        }

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="d"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateInfo SetDate(this DateInfo d, int year, int month)
        {
            d.Year = year;
            d.Month = month;
            return d;
        }

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="d"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateInfo SetDate(this DateInfo d, int year, int month, int day)
        {
            d.Year = year;
            d.Month = month;
            d.Day = day;
            return d;
        }

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="d"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateInfo SetYear(this DateInfo d, int year)
        {
            d.Year = year;
            return d;
        }

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="d"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateInfo SetMonth(this DateInfo d, int month)
        {
            d.Month = month;
            return d;
        }

        /// <summary>
        /// Set date
        /// </summary>
        /// <param name="d"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateInfo SetDay(this DateInfo d, int day)
        {
            d.Day = day;
            return d;
        }
    }
}