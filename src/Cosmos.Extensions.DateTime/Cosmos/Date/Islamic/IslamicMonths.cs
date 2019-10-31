using System.ComponentModel;

namespace Cosmos.Date.Islamic
{
    /// <summary>
    /// Islamic / Hijri Months
    /// </summary>
    /// <remarks>
    /// Reference to:
    ///     https://en.wikipedia.org/wiki/Islamic_calendar
    /// </remarks>
    public enum IslamicMonths
    {
        /// <summary>
        /// Muharram/Mohram
        /// </summary>
        [Description("Muharram")]
        Muharram = 1,

        /// <summary>
        /// Saphar/Safar
        /// </summary>
        [Description("Saphar")]
        Saphar = 2,

        /// <summary>
        /// Rabi al-Awwal
        /// </summary>
        [Description("Rabi al-awwal")]
        RabiAlAwwal = 3,

        /// <summary>
        /// Rabi al-Thani (Rabī’ al-Ākhir)
        /// </summary>
        [Description("Rabi al-Thani")]
        RabiAlThani = 4,

        /// <summary>
        /// Jomada Al Awwel/Jumada al-Ula
        /// </summary>
        [Description("Jomada al-Awwel")]
        JomadaAlAwwel = 5,

        /// <summary>
        /// Jomada Al Thani/Jumada al-Akhirah
        /// </summary>
        [Description("Jomada al-Thani")]
        JomadaAlThani = 6,

        /// <summary>
        /// Rajab/Rojab
        /// </summary>
        [Description("Rajab")]
        Rajab = 7,

        /// <summary>
        /// Sha'ban/Shaban
        /// </summary>
        [Description("Shaban")]
        Shaban = 8,

        /// <summary>
        /// Ramadan
        /// </summary>
        [Description("Ramadan")]
        Ramadan = 9,

        /// <summary>
        /// Shawwal
        /// </summary>
        [Description("Shawwal")]
        Shawwal = 10,

        /// <summary>
        /// Dul Qa'dah/Zulqiddah
        /// </summary>
        [Description("Dul Qadah")]
        DulQaDah = 11,

        /// <summary>
        /// Dul Hijjah/Zulhijjah
        /// </summary>
        [Description("Dhu al-Hijjah")]
        DulHijjah = 12
    }
}