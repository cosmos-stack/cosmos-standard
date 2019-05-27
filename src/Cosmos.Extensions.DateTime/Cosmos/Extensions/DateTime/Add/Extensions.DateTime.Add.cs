using System;
using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class DateTimeExtensions
    {
        public static DateTime AddDuration(this DateTime date, Duration duration)
        {
            if (date == null)
                throw new ArgumentNullException(nameof(date));

            return date + duration.ToTimeSpan();
        }
    }
}
