using System;
using System.Globalization;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class DateInfoExtensions
    {
        public static DateInfo AddDay(this DateInfo date) => date.AddDays(1);

        public static DateInfo AddMonth(this DateInfo date) => date.AddMonths(1);

        public static DateInfo AddYear(this DateInfo date) => date.AddYears(1);

        public static bool IsNextMatched(this DateInfo date, DateInfo next)
        {
            if (date == null || next == null)
                return false;

            var tomorrow = date.AddDay();
            return tomorrow.Equals(next);
        }
    }
}
