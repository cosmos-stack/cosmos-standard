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
        /// Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTime Ago(this DateTimeSpan ts)
        {
            return ts.Before(DateTime.Now);
        }

        /// <summary>
        /// Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTime Ago(this DateTimeSpan ts, DateTime originalValue)
        {
            return ts.Before(originalValue);
        }

        /// <summary>
        /// DateTimeOffset Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTimeOffset OffsetAgo(this DateTimeSpan ts)
        {
            return ts.Before(DateTimeOffset.Now);
        }

        /// <summary>
        /// DateTimeOffset Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTimeOffset Ago(this DateTimeSpan ts, DateTimeOffset originalValue)
        {
            return ts.Before(originalValue);
        }
    }
}