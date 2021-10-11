using System;
using System.Collections.Generic;

namespace CosmosStack.Verba.Time
{
    /// <summary>
    /// Default English time verba <br />
    /// 默认的英语时间言词
    /// </summary>
    [Obsolete("将会被 CosmosStack.I18N 取代")]
    public class DefaultEnglishTimeVerba : ITimeVerba
    {
        /// <summary>
        /// USA English <br />
        /// 美国
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public const string USEnglish = "en-US";

        static DefaultEnglishTimeVerba()
        {
            Instance = new DefaultEnglishTimeVerba();
        }

        /// <summary>
        /// Get an english time verba instance <br />
        /// 获取一个英语时间言词实例
        /// </summary>
        public static DefaultEnglishTimeVerba Instance { get; }

        private DefaultEnglishTimeVerba() { }

        /// <summary>
        /// Verba name <br />
        /// 言词名
        /// </summary>
        public string VerbaName { get; } = "DefaultEnglishTimeVerba";

        /// <summary>
        /// Language Keys <br />
        /// 语言键集合
        /// </summary>
        public List<string> LanguageKeys { get; } = new List<string> {USEnglish};

        /// <summary>
        /// Now <br />
        /// 现在
        /// </summary>
        public string Now { get; } = "Now";

        /// <summary>
        /// Just now <br />
        /// 刚刚
        /// </summary>
        public string JustNow { get; } = "Just Now";

        /// <summary>
        /// Future <br />
        /// 未来
        /// </summary>
        public string Future { get; } = "Future";

        /// <summary>
        /// Yesterday <br />
        /// 昨天
        /// </summary>
        public string Yesterday { get; } = "Yesterday";

        /// <summary>
        /// Milliseconds <br />
        /// 毫秒
        /// </summary>
        public string Milliseconds { get; } = "Millisecond";

        /// <summary>
        /// Seconds <br />
        /// 秒
        /// </summary>
        public string Seconds { get; } = "Second";

        /// <summary>
        /// Minutes <br />
        /// 分钟
        /// </summary>
        public string Minutes { get; } = "Minute";

        /// <summary>
        /// Hours <br />
        /// 小时
        /// </summary>
        public string Hours { get; } = "Hour";

        /// <summary>
        /// Days <br />
        /// 天
        /// </summary>
        public string Days { get; } = "Day";

        /// <summary>
        /// Weeks <br />
        /// 周
        /// </summary>
        public string Weeks { get; } = "Week";

        /// <summary>
        /// Weekends <br />
        /// 周末
        /// </summary>
        public string Weekends { get; } = "Weekend";

        /// <summary>
        /// Weekdays <br />
        /// 工作日
        /// </summary>
        public string Weekdays { get; } = "Weekday";

        /// <summary>
        /// Months <br />
        /// 月
        /// </summary>
        public string Months { get; } = "Month";

        /// <summary>
        /// Season <br />
        /// 季
        /// </summary>
        public string Season { get; } = "Season";

        /// <summary>
        /// Year <br />
        /// 年
        /// </summary>
        public string Year { get; } = "Year";

        /// <summary>
        /// Ago <br />
        /// 在……之前
        /// </summary>
        public string Ago { get; } = "Ago";

        /// <summary>
        /// ComplexString <br />
        /// 复数后缀
        /// </summary>
        public string ComplexString { get; } = "s";

        /// <summary>
        /// SpaceString <br />
        /// 分隔符
        /// </summary>
        public string SpaceString { get; } = " ";
    }
}