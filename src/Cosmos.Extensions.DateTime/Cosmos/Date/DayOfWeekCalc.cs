using System;
using Cosmos.Conversions;
using NodaTime;

namespace Cosmos.Date
{
    /// <summary>
    /// Calc for DayOfWeek
    /// </summary>
    public static class DayOfWeekCalc
    {
        /// <summary>
        /// Long between left <see cref="DayOfWeek"/> and right <see cref="DayOfWeek"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int DaysBetween(DayOfWeek left, DayOfWeek right)
        {
            var leftVal = left.CastToInt();
            var rightVal = right.CastToInt();

            if (leftVal <= rightVal)
                return rightVal - leftVal;
            return leftVal + 7 - rightVal;
        }

        /// <summary>
        /// Long between left <see cref="IsoDayOfWeek"/> and right <see cref="IsoDayOfWeek"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int DaysBetween(IsoDayOfWeek left, IsoDayOfWeek right)
        {
            if (left == IsoDayOfWeek.None || right == IsoDayOfWeek.None)
                return 0;
            return DaysBetween(left.AsDayOfWeek(), right.AsDayOfWeek());
        }

        /// <summary>
        /// Long between left <see cref="DayOfWeek"/> and right <see cref="DayOfWeek"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static bool TryDaysBetween(DayOfWeek left, DayOfWeek right, out int days)
        {
            days = DaysBetween(left, right);
            return true;
        }

        /// <summary>
        /// Long between left <see cref="IsoDayOfWeek"/> and right <see cref="IsoDayOfWeek"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static bool TryDaysBetween(IsoDayOfWeek left, IsoDayOfWeek right, out int days)
        {
            days = 0;
            if (left == IsoDayOfWeek.None || right == IsoDayOfWeek.None)
                return false;
            return TryDaysBetween(left.AsDayOfWeek(), right.AsDayOfWeek(), out days);
        }
    }
}