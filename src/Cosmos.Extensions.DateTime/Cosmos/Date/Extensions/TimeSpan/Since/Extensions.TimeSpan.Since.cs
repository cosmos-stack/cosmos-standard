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
        /// Since
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTime Since(this TimeSpan ts, DateTime originalValue)
        {
            return From(ts, originalValue);
        }

        /// <summary>
        /// DateTimeOffset since
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTimeOffset Since(this TimeSpan ts, DateTimeOffset originalValue)
        {
            return From(ts, originalValue);
        }
    }
}