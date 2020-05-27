using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// DateTimeSpan Extensions<br />
    /// DateTimeSpan 扩展方法
    /// </summary>
    public static partial class DateTimeSpanExtensions
    {
        /// <summary>
        /// Before
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTime Before(this DateTimeSpan ts, DateTime originalValue)
        {
            return originalValue.AddMonths(-ts.Months).AddYears(-ts.Years).Add(-ts.TimeSpan);
        }

        /// <summary>
        /// DateTimeOffset Before
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTimeOffset Before(this DateTimeSpan ts, DateTimeOffset originalValue)
        {
            return originalValue.AddMonths(-ts.Months).AddYears(-ts.Years).Add(-ts.TimeSpan);
        }
    }
}