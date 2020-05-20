using System;
using Cosmos.Date;

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
        /// Since
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTime Since(this DateTimeSpan ts, DateTime originalValue)
        {
            return From(ts, originalValue);
        }

        /// <summary>
        /// DateTimeOffset since
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTimeOffset Since(this DateTimeSpan ts, DateTimeOffset originalValue)
        {
            return From(ts, originalValue);
        }
    }
}