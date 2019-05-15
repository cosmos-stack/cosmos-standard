using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class DateTimeExtensions
    {
        public static bool IsBetween(this DateTime date, DateTime from, DateTime to, bool includeBoundary = true)
        {
            return includeBoundary
                ? date >= from && date <= to
                : date > @from && date < to;
        }

        public static bool IsDateBetweenWithBoundary(this DateTime date, DateTime min, DateTime max)
            => date.IsBetween(min, max.AddDays(+1), false);

        public static bool IsDateBetweenWithBoundary(this DateTime date, DateTime? min, DateTime? max)
        {
            if (min.HasValue && max.HasValue)
                return date.IsDateBetweenWithBoundary(min.Value, max.Value);

            if (min.HasValue)
                return date >= min.Value;

            if (max.HasValue)
                return date < max.Value.AddDays(+1);

            return true;
        }

        public static bool IsDateBetweenWithoutBoundary(this DateTime date, DateTime min, DateTime max)
            => date.IsBetween(min, max, false);
    }
}
