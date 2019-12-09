using System;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// TimeSpan extensions
    /// </summary>
    public static partial class TimeSpanExtensions {
        /// <summary>
        /// From now
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static DateTime FromNow(this TimeSpan from) {
            return from.From(DateTime.Now);
        }

        /// <summary>
        /// From
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTime From(this TimeSpan ts, DateTime originalValue) {
            return originalValue + ts;
        }

        /// <summary>
        /// DateTimeOffset from now
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static DateTimeOffset OffsetFromNow(this TimeSpan ts) {
            return ts.From(DateTimeOffset.Now);
        }

        /// <summary>
        /// DateTimeOffset from
        /// </summary>
        /// <param name="ts"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public static DateTimeOffset From(this TimeSpan ts, DateTimeOffset originalValue) {
            return originalValue + ts;
        }

    }
}