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
        /// End of week, same as 'GetLastDayInfoOfWeek'.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo EndOfWeek(this DateInfo d) => d.GetLastDayInfoOfWeek();

        /// <summary>
        /// End of month, same as 'GetLastDayInfoOfMonth'.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo EndOfMonth(this DateInfo d) => d.GetLastDayInfoOfMonth();

        /// <summary>
        /// End of quarter, same as 'GetLastDayInfoOfQuarter'.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo EndOfQuarter(this DateInfo d) => d.GetLastDayInfoOfQuarter();

        /// <summary>
        /// End of year, same as 'GetLastDayOfYear'.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo EndOfYear(this DateInfo d) => d.GetLastDayInfoOfYear();
    }
}