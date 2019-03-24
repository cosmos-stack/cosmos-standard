using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class DateTimeExtensions
    {
        public static DateTime ToUtc(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Utc);
        }
    }
}
