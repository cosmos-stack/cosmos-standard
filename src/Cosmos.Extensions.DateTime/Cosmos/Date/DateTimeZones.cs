using System;
using NodaTime;

namespace Cosmos.Date
{
    public static class DateTimeZones
    {
        /// <summary>
        /// Apply <see cref="DateTimeZone"/> leniently.<br />
        /// 宽松地应用 <see cref="DateTimeZone"/>。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dateTimeZone"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTimeOffset ApplyDateTimeZoneLeniently(DateTime dt, DateTimeZone dateTimeZone)
        {
            if (dateTimeZone is null)
                throw new ArgumentNullException(nameof(dateTimeZone));
            var local = dt.ToLocalDateTime();
            return dateTimeZone.AtLeniently(local).ToDateTimeOffset();
        }

        /// <summary>
        /// Apply DateTimeZone strictly. <br />
        /// 严格地应用 <see cref="DateTimeZone"/>。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dateTimeZone"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTimeOffset ApplyDateTimeZoneStrictly(DateTime dt, DateTimeZone dateTimeZone)
        {
            if (dateTimeZone is null)
                throw new ArgumentNullException(nameof(dateTimeZone));
            var local = dt.ToLocalDateTime();
            return dateTimeZone.AtStrictly(local).ToDateTimeOffset();
        }
    }

    public static class DateTimeZoneExtensions
    {
        /// <summary>
        /// Apply <see cref="DateTimeZone"/> leniently.<br />
        /// 宽松地应用 <see cref="DateTimeZone"/>。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dateTimeZone"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTimeOffset ApplyDateTimeZoneLeniently(this DateTime dt, DateTimeZone dateTimeZone)
        {
            return DateTimeZones.ApplyDateTimeZoneLeniently(dt, dateTimeZone);
        }

        /// <summary>
        /// Apply DateTimeZone strictly. <br />
        /// 严格地应用 <see cref="DateTimeZone"/>。
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dateTimeZone"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DateTimeOffset ApplyDateTimeZoneStrictly(this DateTime dt, DateTimeZone dateTimeZone)
        {
            return DateTimeZones.ApplyDateTimeZoneStrictly(dt, dateTimeZone);
        }
    }
}