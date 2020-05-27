using System;

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
        /// Gets two time intervals.
        /// </summary>
        /// <param name="leftDt"></param>
        /// <param name="rightDt">  </param>
        /// <returns></returns>
        public static TimeSpan GetTimeSpan(this DateTime leftDt, DateTime rightDt)
            => rightDt - leftDt;
    }
}