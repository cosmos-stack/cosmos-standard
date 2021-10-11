using System;
using System.Collections.Generic;

namespace CosmosStack.Verba.Time
{
    /// <summary>
    /// Default Simplified Chinese time verba <br />
    /// 默认的简体中文时间言词
    /// </summary>
    [Obsolete("将会被 CosmosStack.I18N 取代")]
    public class DefaultSimplifiedChineseTimeVerba : ITimeVerba
    {
        /// <summary>
        /// Simplified Chinese
        /// </summary>
        public const string SimplifiedChinese = "zh-CN";

        static DefaultSimplifiedChineseTimeVerba()
        {
            Instance = new DefaultSimplifiedChineseTimeVerba();
        }

        /// <summary>
        /// Get a simplified chinese time verba instance <br />
        /// 获取一个简体中文时间言词实例
        /// </summary>
        public static DefaultSimplifiedChineseTimeVerba Instance { get; }

        private DefaultSimplifiedChineseTimeVerba() { }

        /// <summary>
        /// Verba name <br />
        /// 言词名
        /// </summary>
        public string VerbaName { get; } = "DefaultSimplifiedChineseTimeVerba";

        /// <summary>
        /// Language Keys <br />
        /// 语言键集合
        /// </summary>
        public List<string> LanguageKeys { get; } = new List<string> {SimplifiedChinese};

        /// <summary>
        /// Now <br />
        /// 此刻
        /// </summary>
        public string Now { get; } = "现在";

        /// <summary>
        /// JustNow <br />
        /// 刚刚
        /// </summary>
        public string JustNow { get; } = "刚刚";

        /// <summary>
        /// Future <br />
        /// 未来
        /// </summary>
        public string Future { get; } = "未来";

        /// <summary>
        /// Yesterday <br />
        /// 昨天
        /// </summary>
        public string Yesterday { get; } = "昨天";

        /// <summary>
        /// Milliseconds <br />
        /// 毫秒
        /// </summary>
        public string Milliseconds { get; } = "毫秒";

        /// <summary>
        /// Seconds <br />
        /// 秒
        /// </summary>
        public string Seconds { get; } = "秒";

        /// <summary>
        /// Minutes <br />
        /// 分钟
        /// </summary>
        public string Minutes { get; } = "分钟";

        /// <summary>
        /// Hours <br />
        /// 小时
        /// </summary>
        public string Hours { get; } = "小时";

        /// <summary>
        /// Days <br />
        /// 天
        /// </summary>
        public string Days { get; } = "天";

        /// <summary>
        /// Weeks <br />
        /// 周
        /// </summary>
        public string Weeks { get; } = "周";

        /// <summary>
        /// Weekends <br />
        /// 周末
        /// </summary>
        public string Weekends { get; } = "周末";

        /// <summary>
        /// Weekdays <br />
        /// 工作日
        /// </summary>
        public string Weekdays { get; } = "工作日";

        /// <summary>
        /// Months <br />
        /// 月
        /// </summary>
        public string Months { get; } = "月";

        /// <summary>
        /// Season <br />
        /// 季
        /// </summary>
        public string Season { get; } = "季";

        /// <summary>
        /// Year <br />
        /// 年
        /// </summary>
        public string Year { get; } = "年";

        /// <summary>
        /// Ago <br />
        /// 在……之前
        /// </summary>
        public string Ago { get; } = "前";

        /// <summary>
        /// ComplexString <br />
        /// 复数后缀
        /// </summary>
        public string ComplexString { get; } = "";

        /// <summary>
        /// SpaceString <br />
        /// 分隔符
        /// </summary>
        public string SpaceString { get; } = "";
    }
}