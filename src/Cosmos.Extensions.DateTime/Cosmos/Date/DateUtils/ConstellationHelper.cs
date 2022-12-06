// ReSharper disable ConditionIsAlwaysTrueOrFalse

namespace Cosmos.Date.DateUtils;

/// <summary>
/// Cosmos.Core Constellation helper<br />
/// 星座辅助类
/// </summary>
public static class ConstellationHelper
{
    private static readonly string[] ConstellationName =
    {
        "白羊座",
        "金牛座",
        "双子座",
        "巨蟹座",
        "狮子座",
        "处女座",
        "天秤座",
        "天蝎座",
        "射手座",
        "摩羯座",
        "水瓶座",
        "双鱼座"
    };

    /// <summary>
    /// Gets Constellation name<br />
    /// 获取星座名
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string Get(DateTime dt)
    {
        int index;
        var m = dt.Month;
        var d = dt.Day;
        var y = m * 100 + d;
        switch (y)
        {
            case >= 321 and <= 419:
                index = 0;
                break;
            case >= 420 and <= 520:
                index = 1;
                break;
            case >= 521 and <= 620:
                index = 2;
                break;
            case >= 621 and <= 722:
                index = 3;
                break;
            case >= 723 and <= 822:
                index = 4;
                break;
            case >= 823 and <= 922:
                index = 5;
                break;
            case >= 923 and <= 1022:
                index = 6;
                break;
            case >= 1023 and <= 1121:
                index = 7;
                break;
            case >= 1122 and <= 1221:
                index = 8;
                break;
            case >= 1222:
            case <= 119:
                index = 9;
                break;
            case >= 120 and <= 218:
                index = 10;
                break;
            case >= 219 and <= 320:
                index = 11;
                break;
        }

        return ConstellationName[index];
    }
}