namespace Cosmos.Date.Chinese;

/// <summary>
/// Chinese Constellation helper<br />
/// 二十八星宿辅助类
/// </summary>
public static class ChineseConstellationHelper
{
    // ReSharper disable once InconsistentNaming
    private static readonly string[] NAMES =
    {
        //四        五      六         日        一      二      三
        "角木蛟",
        "亢金龙",
        "女土蝠",
        "房日兔",
        "心月狐",
        "尾火虎",
        "箕水豹",
        "斗木獬",
        "牛金牛",
        "氐土貉",
        "虚日鼠",
        "危月燕",
        "室火猪",
        "壁水獝",
        "奎木狼",
        "娄金狗",
        "胃土彘",
        "昴日鸡",
        "毕月乌",
        "觜火猴",
        "参水猿",
        "井木犴",
        "鬼金羊",
        "柳土獐",
        "星日马",
        "张月鹿",
        "翼火蛇",
        "轸水蚓"
    };

    // ReSharper disable once IdentifierTypo
    // ReSharper disable once InconsistentNaming
    private static readonly string[] NAMEZ =
    {
        "角木蛟",
        "亢金龙",
        "女土蝠",
        "房日兔",
        "心月狐",
        "尾火虎",
        "箕水豹",
        "斗木獬",
        "牛金牛",
        "氐土貉",
        "虚日鼠",
        "危月燕",
        "室火猪",
        "壁水獝",
        "奎木狼",
        "娄金狗",
        "胃土彘",
        "昴日鸡",
        "毕月乌",
        "觜火猴",
        "参水猿",
        "井木犴",
        "鬼金羊",
        "柳土獐",
        "星日马",
        "张月鹿",
        "翼火蛇",
        "轸水蚓"
    };

    private static readonly DateTime ChineseConstellationReferDay = new(2007, 9, 13); //28星宿参考值,本日为角

    /// <summary>
    /// Get Chinese Constellation<br />
    /// 获取二十八星宿
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public static string Get(DateTime dt, bool traditionalChineseCharacters = false)
    {
        var dict = traditionalChineseCharacters ? NAMEZ : NAMES;
        var offset = (dt - ChineseConstellationReferDay).Days;
        var modStarDay = offset % 28;
        return modStarDay >= 0 ? dict[modStarDay] : dict[27 + modStarDay];
    }

    /// <summary>
    /// Get Chinese Constellation<br />
    /// 获取二十八星宿
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public static string Get(DateInfo dt, bool traditionalChineseCharacters = false)
    {
        var dict = traditionalChineseCharacters ? NAMEZ : NAMES;
        var offset = (dt - ChineseConstellationReferDay).Days;
        var modStarDay = offset % 28;
        return modStarDay >= 0 ? dict[modStarDay] : dict[27 + modStarDay];
    }

    /// <summary>
    /// Get Chinese Constellation<br />
    /// 获取二十八星宿
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public static string Get(ChineseDateTime dt, bool traditionalChineseCharacters = false)
    {
        return Get(dt.InternalTime, traditionalChineseCharacters);
    }

    /// <summary>
    /// Get Chinese Constellation<br />
    /// 获取二十八星宿
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public static string Get(ChineseDateInfo dt, bool traditionalChineseCharacters = false)
    {
        return Get(dt.InternalTime, traditionalChineseCharacters);
    }
}