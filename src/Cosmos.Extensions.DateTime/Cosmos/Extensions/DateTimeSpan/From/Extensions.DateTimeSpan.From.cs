using System;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// DateTimeSpan Extensions<br />
    /// DateTimeSpan 扩展方法
    /// </summary>
    public static partial class DateTimeSpanExtensions {
        /// <summary>
        /// From now
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTime FromNow(this DateTimeSpan ts) {
            return ts.From(DateTime.Now);
        }

        /// <summary>
        /// From
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTime From(this DateTimeSpan ts, DateTime originalValue) {
            return originalValue.AddMonths(ts.Months).AddYears(ts.Years).Add(ts.TimeSpan);
        }

        /// <summary>
        /// DateTimeOffset from now
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTimeOffset OffsetFromNow(this DateTimeSpan ts) {
            return ts.From(DateTimeOffset.Now);
        }

        /// <summary>
        /// DateTimeOffset from
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTimeOffset From(this DateTimeSpan ts, DateTimeOffset originalValue) {
            return originalValue.AddMonths(ts.Months).AddYears(ts.Years).Add(ts.TimeSpan);
        }
    }
}