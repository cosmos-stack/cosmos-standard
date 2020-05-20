using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// TimeSpan extensions
    /// </summary>
    public static partial class TimeSpanExtensions
    {
        /// <summary>
        /// Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTime Ago(this TimeSpan ts)
        {
            return ts.Before(DateTime.Now);
        }

        /// <summary>
        /// Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTime Ago(this TimeSpan ts, DateTime originalValue)
        {
            return ts.Before(originalValue);
        }

        /// <summary>
        /// DateTimeOffset Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTimeOffset OffsetAgo(this TimeSpan ts)
        {
            return ts.Before(DateTimeOffset.Now);
        }

        /// <summary>
        /// DateTimeOffset Ago
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTimeOffset Ago(this TimeSpan ts, DateTimeOffset originalValue)
        {
            return ts.Before(originalValue);
        }
    }
}