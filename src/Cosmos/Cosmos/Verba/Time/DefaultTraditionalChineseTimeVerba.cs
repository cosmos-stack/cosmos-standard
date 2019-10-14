using System;
using System.Collections.Generic;

namespace Cosmos.Verba.Time
{
    /// <summary>
    /// Default Traditional Chines time verba
    /// </summary>
    [Obsolete("将会被 Cosmos.I18N 取代")]
    public class DefaultTraditionalChineseTimeVerba : ITimeVerba
    {
        /// <summary>
        /// China Taiwan Traditional Chinese
        /// </summary>
        public const string TaiwanTraditionalChinese = "zh-TW";

        /// <summary>
        /// China HongKong Traditional Chinese
        /// </summary>
        public const string HongKongTraditionalChinese = "zh-HK";

        static DefaultTraditionalChineseTimeVerba()
        {
            Instance = new DefaultTraditionalChineseTimeVerba();
        }

        /// <summary>
        /// Get a traditional chinese time verba instance
        /// </summary>
        public static DefaultTraditionalChineseTimeVerba Instance { get; }

        private DefaultTraditionalChineseTimeVerba() { }

        /// <summary>
        /// Verba name
        /// </summary>
        public string VerbaName { get; } = "DefaultTraditionalChineseTimeVerba";

        /// <summary>
        /// Language Keys
        /// </summary>
        public List<string> LanguageKeys { get; } = new List<string> {TaiwanTraditionalChinese, HongKongTraditionalChinese};

        /// <summary>
        /// Now
        /// </summary>
        public string Now { get; } = "現在";

        /// <summary>
        /// Just Now
        /// </summary>
        public string JustNow { get; } = "剛剛";

        /// <summary>
        /// Future
        /// </summary>
        public string Future { get; } = "未來";

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
        public string Minutes { get; } = "分鐘";

        /// <summary>
        /// Hours
        /// </summary>
        public string Hours { get; } = "小時";

        /// <summary>
        /// Days
        /// </summary>
        public string Days { get; } = "天";

        /// <summary>
        /// Weeks
        /// </summary>
        public string Weeks { get; } = "週";

        /// <summary>
        /// Weekends
        /// </summary>
        public string Weekends { get; } = "週末";

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