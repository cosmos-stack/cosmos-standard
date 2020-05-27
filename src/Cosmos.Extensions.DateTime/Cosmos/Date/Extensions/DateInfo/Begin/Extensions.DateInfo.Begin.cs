// ReSharper disable once CheckNamespace

namespace Cosmos.Date
{
    /// <summary>
    /// DateInfo Extensions<br />
    /// DateInfo 扩展方法
    /// </summary>
    public static partial class DateInfoExtensions
    {
        /// <summary>
        /// Beginning of week, same as 'GetFirstDayInfoOfWeek'.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo BeginningOfWeek(this DateInfo d) => d.GetFirstDayInfoOfWeek();

        /// <summary>
        /// Beginning of month, same as 'GetLastDayInfoOfMonth'.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo BeginningOfMonth(this DateInfo d) => d.GetFirstDayInfoOfMonth();

        /// <summary>
        /// Beginning of quarter, same as 'GetFirstDayInfoOfQuarter'.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo BeginningOfQuarter(this DateInfo d) => d.GetFirstDayInfoOfQuarter();

        /// <summary>
        /// Beginning of year, same as 'GetFirstDayInfoOfYear'.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo BeginningOfYear(this DateInfo d) => d.GetFirstDayInfoOfYear();
    }
}