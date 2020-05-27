using System;
using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// Duration extensions
    /// </summary>
    public static partial class DurationExtensions
    {
        /// <summary>
        /// As duration
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static Duration AsDuration(this TimeSpan ts) => Duration.FromTimeSpan(ts);

        /// <summary>
        /// As duration
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static Duration AsDuration(this DateTimeSpan ts) => Duration.FromTimeSpan(ts);
    }
}