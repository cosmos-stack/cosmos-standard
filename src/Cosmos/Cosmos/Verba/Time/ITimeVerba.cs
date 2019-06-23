using System.Collections.Generic;

namespace Cosmos.Verba.Time
{
    /// <summary>
    /// Interface for time verba
    /// </summary>
    public interface ITimeVerba : IVerba
    {
        /// <summary>
        /// Language Keys
        /// </summary>
        List<string> LanguageKeys { get; }

        /// <summary>
        /// Now <br />
        /// 现在
        /// </summary>
        string Now { get; }

        /// <summary>
        /// Just Now <br />
        /// 刚刚
        /// </summary>
        string JustNow { get; }

        /// <summary>
        /// Future <br />
        /// 未来
        /// </summary>
        string Future { get; }

        /// <summary>
        /// Yesterday <br />
        /// 昨天
        /// </summary>
        string Yesterday { get; }

        /// <summary>
        /// Milliseconds <br />
        /// 毫秒
        /// </summary>
        string Milliseconds { get; }

        /// <summary>
        /// Seconds <br />
        /// 秒
        /// </summary>
        string Seconds { get; }

        /// <summary>
        /// Minutes <br />
        /// 分钟
        /// </summary>
        string Minutes { get; }

        /// <summary>
        /// Hours <br />
        /// 小时
        /// </summary>
        string Hours { get; }

        /// <summary>
        /// Days <br />
        /// 天
        /// </summary>
        string Days { get; }

        /// <summary>
        /// Weeks <br />
        /// 周
        /// </summary>
        string Weeks { get; }

        /// <summary>
        /// Weekends <br />
        /// 周末
        /// </summary>
        string Weekends { get; }

        /// <summary>
        /// Weekdays <br />
        /// 工作日
        /// </summary>
        string Weekdays { get; }

        /// <summary>
        /// Months <br />
        /// 月
        /// </summary>
        string Months { get; }

        /// <summary>
        /// Season <br />
        /// 季
        /// </summary>
        string Season { get; }

        /// <summary>
        /// Year <br />
        /// 年
        /// </summary>
        string Year { get; }

        /// <summary>
        /// Ago <br />
        /// 前
        /// </summary>
        string Ago { get; }

        /// <summary>
        /// ComplexString <br />
        /// 复数后缀
        /// </summary>
        string ComplexString { get; }

        /// <summary>
        /// SpaceString <br />
        /// 单词之间的空格符
        /// </summary>
        string SpaceString { get; }
    }
}