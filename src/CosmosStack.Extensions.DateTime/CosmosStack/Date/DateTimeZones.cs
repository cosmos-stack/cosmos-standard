using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CosmosStack.Text;
using NodaTime;

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace CosmosStack.Date
{
    internal static class DateTimeZoneHelper
    {
        public static Dictionary<string, string> AliasMap { get; } = new()
        {
            { "-00:00", "UT|UTC|WET" },
            { "-01:00", "WAT" },
            { "-02:00", "AT" },
            { "-02:30", "NDT" },
            { "-03:00", "ADT|BST|BZT2" },
            { "-03:30", "NFT" },
            { "-04:00", "AST|BET" },
            { "-05:00", "CDT|EST" },
            { "-06:00", "CST|MDT" },
            { "-07:00", "MST|PDT" },
            { "-08:00", "PST|YDT" },
            { "-09:00", "AHDT|HDT|YST" },
            { "-10:00", "AHST|CAT|HST" },
            { "-11:00", "BET|NT" },
            { "-12:00", "IDLW" },
            { "+00:00", "GMT" },
            { "+01:00", "CET|FWT|MET|MEWT|SWT" },
            { "+02:00", "BDST|CED|CEST|EET|FST|MED|MEST|SST" },
            { "+03:00", "BAT|BT|EED|EEST" },
            { "+03:30", "IT" },
            { "+04:00", "USZ3|ZP4" },
            { "+05:00", "USZ4|ZP5" },
            { "+05:30", "IST" },
            { "+06:00", "USZ5|ZP6" },
            { "+06:30", "NST" },
            { "+07:00", "JT|USZ6" },
            { "+08:00", "AWST|CCT|MT|WST" },
            { "+09:00", "AWDT|JST|SAST|SAT|ROK" },
            { "+09:30", "ACST|CAST" },
            { "+10:00", "AEST|EAST|GST|SAD|SDT" },
            { "+10:30", "ACDT|CADT" },
            { "+11:00", "AEDT|NZ|UZ10" },
            { "+12:00", "IDLE|NZST|NZT" },
            { "+13:00", "NZDT" },
        };
    }

    /// <summary>
    /// DateTime Zones <br />
    /// 时区
    /// </summary>
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

    /// <summary>
    /// DateTime Zone Extensions <br />
    /// 时区扩展
    /// </summary>
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTimeOffset ApplyDateTimeZoneStrictly(this DateTime dt, DateTimeZone dateTimeZone)
        {
            return DateTimeZones.ApplyDateTimeZoneStrictly(dt, dateTimeZone);
        }

        /// <summary>
        /// Will return '+7'
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Z(this DateTime dt) => dt.ToString("z");

        /// <summary>
        /// Will return '+07'
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ZZ(this DateTime dt) => dt.ToString("zz");

        /// <summary>
        /// Will return '+07:00'
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ZZZ(this DateTime dt) => dt.ToString("zzz");

        /// <summary>
        /// Will return '+0700'
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ZZZZ(this DateTime dt) => dt.ToString("zzz").Remove(":");

        /// <summary>
        /// Get a set of DateTimeZone alias.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string[] ZoneAliasSet(this DateTime dt)
        {
            var zone = dt.ZZZ();
            return DateTimeZoneHelper.AliasMap[zone].Split('|');
        }
    }
}