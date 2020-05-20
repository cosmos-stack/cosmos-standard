using System;
using NodaTime;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// DateTime extensions
    /// </summary>
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// Apply DateTimeZone leniently
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dateTimeZone"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTimeOffset ApplyDateTimeZoneLeniently(this DateTime dt, DateTimeZone dateTimeZone)
        {
            if (dateTimeZone == null)
                throw new ArgumentNullException(nameof(dateTimeZone));
            var local = dt.ToLocalDateTime();
            return dateTimeZone.AtLeniently(local).ToDateTimeOffset();
        }

        /// <summary>
        /// Apply DateTimeZone strictly
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dateTimeZone"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTimeOffset ApplyDateTimeZoneStrictly(this DateTime dt, DateTimeZone dateTimeZone)
        {
            if (dateTimeZone == null)
                throw new ArgumentNullException(nameof(dateTimeZone));
            var local = dt.ToLocalDateTime();
            return dateTimeZone.AtStrictly(local).ToDateTimeOffset();
        }
    }
}