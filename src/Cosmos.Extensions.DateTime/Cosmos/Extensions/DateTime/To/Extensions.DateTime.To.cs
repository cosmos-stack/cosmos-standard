using System;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class DateTimeExtensions
    {
        public static DateTime ToUtc(this DateTime date) => new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Utc);

        public static DateInfo ToDateInfo(this DateTime date) => new DateInfo(date);
    }
}
