using System;
using System.Collections.Generic;

namespace Cosmos.Verba.Time {
    /// <summary>
    /// Default Simplified Chinese time verba
    /// </summary>
    [Obsolete("将会被 Cosmos.I18N 取代")]
    public class DefaultSimplifiedChineseTimeVerba : ITimeVerba {
        /// <summary>
        /// Simplified Chinese
        /// </summary>
        public const string SimplifiedChinese = "zh-CN";

        static DefaultSimplifiedChineseTimeVerba() {
            Instance = new DefaultSimplifiedChineseTimeVerba();
        }

        /// <summary>
        /// Get a simplified chinese time verba instance
        /// </summary>
        public static DefaultSimplifiedChineseTimeVerba Instance { get; }

        private DefaultSimplifiedChineseTimeVerba() { }

        /// <summary>
        /// Verba name
        /// </summary>
        public string VerbaName { get; } = "DefaultSimplifiedChineseTimeVerba";

        /// <summary>
        /// Language Keys
        /// </summary>
        public List<string> LanguageKeys { get; } = new List<string> {SimplifiedChinese};

        /// <summary>
        /// Now
        /// </summary>
        public string Now { get; } = "现在";

        /// <summary>
        /// JustNow
        /// </summary>
        public string JustNow { get; } = "刚刚";

        /// <summary>
        /// Future
        /// </summary>
        public string Future { get; } = "未来";

        /// <summary>
        /// Yesterday
        /// </summary>
        public string Yesterday { get; } = "昨天";

        /// <summary>
        /// Milliseconds
        /// </summary>
        public string Milliseconds { get; } = "毫秒";

        /// <summary>
        /// Seconds
        /// </summary>
        public string Seconds { get; } = "秒";

        /// <summary>
        /// Minutes
        /// </summary>
        public string Minutes { get; } = "分钟";

        /// <summary>
        /// Hours
        /// </summary>
        public string Hours { get; } = "小时";

        /// <summary>
        /// Days
        /// </summary>
        public string Days { get; } = "天";

        /// <summary>
        /// Weeks
        /// </summary>
        public string Weeks { get; } = "周";

        /// <summary>
        /// Weekends
        /// </summary>
        public string Weekends { get; } = "周末";

        /// <summary>
        /// Weekdays
        /// </summary>
        public string Weekdays { get; } = "工作日";

        /// <summary>
        /// Months
        /// </summary>
        public string Months { get; } = "月";

        /// <summary>
        /// Season
        /// </summary>
        public string Season { get; } = "季";

        /// <summary>
        /// Year
        /// </summary>
        public string Year { get; } = "年";

        /// <summary>
        /// Ago
        /// </summary>
        public string Ago { get; } = "前";

        /// <summary>
        /// ComplexString
        /// </summary>
        public string ComplexString { get; } = "";

        /// <summary>
        /// SpaceString
        /// </summary>
        public string SpaceString { get; } = "";
    }
}