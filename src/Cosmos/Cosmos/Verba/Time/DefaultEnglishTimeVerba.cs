using System;
using System.Collections.Generic;

namespace Cosmos.Verba.Time {
    /// <summary>
    /// Default English time verba
    /// </summary>
    [Obsolete("将会被 Cosmos.I18N 取代")]
    public class DefaultEnglishTimeVerba : ITimeVerba {
        /// <summary>
        /// USA English
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string USEnglish = "en-US";

        static DefaultEnglishTimeVerba() {
            Instance = new DefaultEnglishTimeVerba();
        }

        /// <summary>
        /// Get an english time verba instance
        /// </summary>
        public static DefaultEnglishTimeVerba Instance { get; }

        private DefaultEnglishTimeVerba() { }

        /// <summary>
        /// Verba name
        /// </summary>
        public string VerbaName { get; } = "DefaultEnglishTimeVerba";

        /// <summary>
        /// Language Keys
        /// </summary>
        public List<string> LanguageKeys { get; } = new List<string> {USEnglish};

        /// <summary>
        /// Now
        /// </summary>
        public string Now { get; } = "Now";

        /// <summary>
        /// Just now
        /// </summary>
        public string JustNow { get; } = "Just Now";

        /// <summary>
        /// Future
        /// </summary>
        public string Future { get; } = "Future";

        /// <summary>
        /// Yesterday
        /// </summary>
        public string Yesterday { get; } = "Yesterday";

        /// <summary>
        /// Milliseconds
        /// </summary>
        public string Milliseconds { get; } = "Millisecond";

        /// <summary>
        /// Seconds
        /// </summary>
        public string Seconds { get; } = "Second";

        /// <summary>
        /// Minutes
        /// </summary>
        public string Minutes { get; } = "Minute";

        /// <summary>
        /// Hours
        /// </summary>
        public string Hours { get; } = "Hour";

        /// <summary>
        /// Days
        /// </summary>
        public string Days { get; } = "Day";

        /// <summary>
        /// Weeks
        /// </summary>
        public string Weeks { get; } = "Week";

        /// <summary>
        /// Weekends
        /// </summary>
        public string Weekends { get; } = "Weekend";

        /// <summary>
        /// Weekdays
        /// </summary>
        public string Weekdays { get; } = "Weekday";

        /// <summary>
        /// Months
        /// </summary>
        public string Months { get; } = "Month";

        /// <summary>
        /// Season
        /// </summary>
        public string Season { get; } = "Season";

        /// <summary>
        /// Year
        /// </summary>
        public string Year { get; } = "Year";

        /// <summary>
        /// Ago
        /// </summary>
        public string Ago { get; } = "Ago";

        /// <summary>
        /// ComplexString
        /// </summary>
        public string ComplexString { get; } = "s";

        /// <summary>
        /// SpaceString
        /// </summary>
        public string SpaceString { get; } = " ";
    }
}