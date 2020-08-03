using Cosmos.Date;
using NodaTime;

namespace System
{
    /// <summary>
    /// Cosmos <see cref="DateTimeZone"/> extensions
    /// </summary>
    public static class CosmosDateTimeZoneExtensions
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
            if (dateTimeZone == null)
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
        public static DateTimeOffset ApplyDateTimeZoneStrictly(this DateTime dt, DateTimeZone dateTimeZone)
        {
            if (dateTimeZone == null)
                throw new ArgumentNullException(nameof(dateTimeZone));
            var local = dt.ToLocalDateTime();
            return dateTimeZone.AtStrictly(local).ToDateTimeOffset();
        }
    }
}