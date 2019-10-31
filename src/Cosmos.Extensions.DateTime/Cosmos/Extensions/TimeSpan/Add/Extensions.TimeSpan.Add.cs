using System;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// TimeSpan extensions
    /// </summary>
    public static partial class TimeSpanExtensions
    {
        /// <summary>
        /// Adds the given <see cref="DateTimeSpan"/> from a <see cref="TimeSpan"/> and returns resulting <see cref="DateTimeSpan"/>.
        /// </summary>
        public static DateTimeSpan AddFluentTimeSpan(this TimeSpan ts, DateTimeSpan fluentTimeSpan)
        {
            return fluentTimeSpan.Add(ts);
        }

        /// <summary>
        /// Subtracts the given <see cref="DateTimeSpan"/> from a <see cref="TimeSpan"/> and returns resulting <see cref="DateTimeSpan"/>.
        /// </summary>
        public static DateTimeSpan SubtractFluentTimeSpan(this TimeSpan ts, DateTimeSpan fluentTimeSpan)
        {
            return DateTimeSpan.SubtractInternal(ts, fluentTimeSpan);
        }
    }
}