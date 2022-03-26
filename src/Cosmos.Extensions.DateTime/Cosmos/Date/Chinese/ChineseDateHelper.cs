using Cosmos.Numeric;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Cosmos.Date.Chinese;

/// <summary>
/// Chines Date Helper<br />
/// 农历辅助类
/// </summary>
public static class ChineseDateHelper
{
    private static readonly string[] GANS = {"甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸"};
    private static readonly string[] ZHIS = {"子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥"};
    private static readonly string[] YUES = {"正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "腊"};
    private static readonly string[] PRIS = {"初", "十", "廿", "卅"};
    private static readonly string[] SRIS = {"日", "一", "二", "三", "四", "五", "六", "七", "八", "九"};
    private static readonly string[] MRIS = {"", "初十", "二十", "三十"};
    private static readonly string[] HZNUMS = {"零", "一", "二", "三", "四", "五", "六", "七", "八", "九"};
    private static readonly string RUNS = "闰";
    private static readonly string SHIS = "时";

    private static readonly string[] GANZ = {"甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸"};
    private static readonly string[] ZHIZ = {"子", "醜", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥"};
    private static readonly string[] YUEZ = {"正", "貳", "叁", "肆", "伍", "陸", "柒", "捌", "玖", "拾", "拾壹", "臘"};
    private static readonly string[] PRIZ = {"初", "拾", "廿", "卅"};
    private static readonly string[] SRIZ = {"日", "壹", "貳", "叁", "肆", "伍", "陸", "柒", "捌", "玖"};
    private static readonly string[] MRIZ = {"", "初拾", "貳拾", "叁拾"};
    private static readonly string[] HZNUMZ = {"零", "壹", "貳", "叁", "肆", "伍", "陸", "柒", "捌", "玖"};
    private static readonly string RUNZ = "閏";
    private static readonly string SHIZ = "時";

    /// <summary>
    /// Gets Chinese Year<br />
    /// 获得农历年
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public static string GetChineseYear(DateTime dt, bool traditionalChineseCharacters = false)
    {
        var hzNumP = traditionalChineseCharacters ? HZNUMZ : HZNUMS;

        var year = dt.Year.ToString().ToCharArray();
        var yearStr = new string[year.Length];
        for (var i = 0; i < year.Length; i++)
            yearStr[i] = hzNumP[NumericConv.ToInt32(year[i])];
        return $"{string.Join("", yearStr)}年";
    }

    /// <summary>
    /// Gets Chinese Sexagenary Year<br />
    /// 获得干支年
    /// </summary>
    /// <param name="calendar"></param>
    /// <param name="dt"></param>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public static string GetSexagenaryYear(ChineseLunisolarCalendar calendar, DateTime dt, bool traditionalChineseCharacters = false)
    {
        var ganP = traditionalChineseCharacters ? GANZ : GANS;
        var zhiP = traditionalChineseCharacters ? ZHIZ : ZHIS;

        var sexagenaryYear = calendar.GetSexagenaryYear(dt);
        var stemIndex = calendar.GetCelestialStem(sexagenaryYear) - 1;
        var branchIndex = calendar.GetTerrestrialBranch(sexagenaryYear) - 1;
        return $"{ganP[stemIndex]}{zhiP[branchIndex]}年";
    }

    /// <summary>
    /// Gets Chinese Month<br />
    /// 获得农历月
    /// </summary>
    /// <param name="calendar"></param>
    /// <param name="dt"></param>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public static string GetChineseMonth(ChineseLunisolarCalendar calendar, DateTime dt, bool traditionalChineseCharacters = false)
    {
        var run = traditionalChineseCharacters ? RUNZ : RUNS;
        var yueP = traditionalChineseCharacters ? YUEZ : YUES;

        var isLeapMonth = calendar.IsLeapMonth(dt.Year, dt.Month);
        return $"{(isLeapMonth ? run : string.Empty)}{yueP[calendar.GetMonth(dt)]}月";
    }

    /// <summary>
    /// Gets Chinese Day<br />
    /// 获得农历日
    /// </summary>
    /// <param name="calendar"></param>
    /// <param name="dt"></param>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public static string GetChineseDay(ChineseLunisolarCalendar calendar, DateTime dt, bool traditionalChineseCharacters = false)
    {
        var day = calendar.GetDayOfMonth(dt);
        var priP = traditionalChineseCharacters ? PRIZ : PRIS;
        var sriP = traditionalChineseCharacters ? SRIZ : SRIS;
        var mriP = traditionalChineseCharacters ? MRIZ : MRIS;

        switch (day)
        {
            case 0:
            case 10:
            case 20:
            case 30:
                return mriP[day / 10];

            default:
                return $"{priP[day / 10]}{sriP[day % 10]}";
        }
    }

    /// <summary>
    /// Gets Chinese Hour<br />
    /// 获得农历时辰
    /// </summary>
    /// <param name="calendar"></param>
    /// <param name="dt"></param>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public static string GetChineseHour(ChineseLunisolarCalendar calendar, DateTime dt, bool traditionalChineseCharacters = false)
    {
        var shiP = traditionalChineseCharacters ? SHIZ : SHIS;

        var hour = dt.Hour;
        if (dt.Minute != 0)
            hour += 1;
        var offset = hour / 2;
        if (offset >= 12) offset = 0;

        return $"{ZHIS[offset]}{shiP}";
    }

    /// <summary>
    /// Is special year a leap year<br />
    /// 指定年是否为闰年
    /// </summary>
    /// <param name="calendar"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool IsLeapYear(ChineseLunisolarCalendar calendar, DateTime dt)
    {
        calendar ??= new ChineseLunisolarCalendar();
        return calendar.IsLeapYear(dt.Year);
    }

    /// <summary>
    /// Is special year a leap year<br />
    /// 指定年是否为闰年
    /// </summary>
    /// <param name="calendar"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool IsLeapYear(ChineseLunisolarCalendar calendar, DateInfo dt)
    {
        calendar ??= new ChineseLunisolarCalendar();
        return calendar.IsLeapYear(dt.Year);
    }

    /// <summary>
    /// Is special month a leap month<br />
    /// 指定月是否为闰月
    /// </summary>
    /// <param name="calendar"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool IsLeapMonth(ChineseLunisolarCalendar calendar, DateTime dt)
    {
        calendar ??= new ChineseLunisolarCalendar();
        return calendar.IsLeapMonth(dt.Year, dt.Month);
    }

    /// <summary>
    /// Is special month a leap month<br />
    /// 指定月是否为闰月
    /// </summary>
    /// <param name="calendar"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool IsLeapMonth(ChineseLunisolarCalendar calendar, DateInfo dt)
    {
        calendar ??= new ChineseLunisolarCalendar();
        return calendar.IsLeapMonth(dt.Year, dt.Month);
    }

    /// <summary>
    /// Is special day a leap day<br />
    /// 指定日是否为闰日
    /// </summary>
    /// <param name="calendar"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool IsLeapDay(ChineseLunisolarCalendar calendar, DateTime dt)
    {
        calendar = calendar ?? new ChineseLunisolarCalendar();
        return calendar.IsLeapDay(dt.Year, dt.Month, dt.Day);
    }

    /// <summary>
    /// Is special day a leap day<br />
    /// 指定日是否为闰日
    /// </summary>
    /// <param name="calendar"></param>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static bool IsLeapDay(ChineseLunisolarCalendar calendar, DateInfo dt)
    {
        calendar = calendar ?? new ChineseLunisolarCalendar();
        return calendar.IsLeapDay(dt.Year, dt.Month, dt.Day);
    }
}