namespace Cosmos.Verba.Time;

/// <summary>
/// Default Traditional Chines time verba <br />
/// 默认的繁体中文时间言词
/// </summary>
[Obsolete("将会被 Cosmos.Core.I18N 取代")]
public class DefaultTraditionalChineseTimeVerba : ITimeVerba
{
    /// <summary>
    /// China Taiwan Traditional Chinese <br />
    /// 中国台湾省繁体中文
    /// </summary>
    public const string TaiwanTraditionalChinese = "zh-TW";

    /// <summary>
    /// China HongKong Traditional Chinese <br />
    /// 中国香港特别行政区繁体中文
    /// </summary>
    public const string HongKongTraditionalChinese = "zh-HK";

    static DefaultTraditionalChineseTimeVerba()
    {
        Instance = new DefaultTraditionalChineseTimeVerba();
    }

    /// <summary>
    /// Get a traditional chinese time verba instance <br />
    /// 获取一个繁体中文时间言词实例
    /// </summary>
    public static DefaultTraditionalChineseTimeVerba Instance { get; }

    private DefaultTraditionalChineseTimeVerba() { }

    /// <summary>
    /// Verba name <br />
    /// 言词名
    /// </summary>
    public string VerbaName { get; } = "DefaultTraditionalChineseTimeVerba";

    /// <summary>
    /// Language Keys <br />
    /// 语言键集合
    /// </summary>
    public List<string> LanguageKeys { get; } = new List<string> {TaiwanTraditionalChinese, HongKongTraditionalChinese};

    /// <summary>
    /// Now <br />
    /// 现在
    /// </summary>
    public string Now { get; } = "現在";

    /// <summary>
    /// Just Now <br />
    /// 刚刚
    /// </summary>
    public string JustNow { get; } = "剛剛";

    /// <summary>
    /// Future <br />
    /// 未来
    /// </summary>
    public string Future { get; } = "未來";

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
    public string Minutes { get; } = "分鐘";

    /// <summary>
    /// Hours <br />
    /// 小时
    /// </summary>
    public string Hours { get; } = "小時";

    /// <summary>
    /// Days <br />
    /// 天
    /// </summary>
    public string Days { get; } = "天";

    /// <summary>
    /// Weeks <br />
    /// 周
    /// </summary>
    public string Weeks { get; } = "週";

    /// <summary>
    /// Weekends <br />
    /// 周末
    /// </summary>
    public string Weekends { get; } = "週末";

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
    /// Year
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