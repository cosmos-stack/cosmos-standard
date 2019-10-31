using System;

namespace NodaTime.Helpers
{
    internal static class DayOfWeekHelper
    {
        public static IsoDayOfWeek ToNodaTimeWeek(DayOfWeek week)
        {
            switch (week)
            {
                case DayOfWeek.Sunday: return IsoDayOfWeek.Sunday;
                case DayOfWeek.Monday: return IsoDayOfWeek.Monday;
                case DayOfWeek.Tuesday: return IsoDayOfWeek.Tuesday;
                case DayOfWeek.Wednesday: return IsoDayOfWeek.Wednesday;
                case DayOfWeek.Thursday: return IsoDayOfWeek.Thursday;
                case DayOfWeek.Friday: return IsoDayOfWeek.Friday;
                case DayOfWeek.Saturday: return IsoDayOfWeek.Saturday;
                default: return IsoDayOfWeek.None;
            }
        }

        public static DayOfWeek ToSystemWeek(IsoDayOfWeek week)
        {
            switch (week)
            {
                case IsoDayOfWeek.Sunday: return DayOfWeek.Sunday;
                case IsoDayOfWeek.Monday: return DayOfWeek.Monday;
                case IsoDayOfWeek.Tuesday: return DayOfWeek.Saturday;
                case IsoDayOfWeek.Wednesday: return DayOfWeek.Wednesday;
                case IsoDayOfWeek.Thursday: return DayOfWeek.Thursday;
                case IsoDayOfWeek.Friday: return DayOfWeek.Friday;
                case IsoDayOfWeek.Saturday: return DayOfWeek.Saturday;
                default: throw new InvalidOperationException("Unknown day of week");
            }
        }
    }
}