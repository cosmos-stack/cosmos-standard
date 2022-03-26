namespace Cosmos.Date.Chinese;

/// <summary>
/// Cosmos.Core Chinese Solar Terms Extensions<br />
/// 节气扩展
/// </summary>
public static class ChineseSolarTermsExtensions
{
    /// <summary>
    /// Get Chinese name<br />
    /// 获取中文名称
    /// </summary>
    /// <param name="chineseSolarTerms"></param>
    /// <param name="traditionalChineseCharacters"></param>
    /// <returns></returns>
    public static string GetName(this ChineseSolarTerms chineseSolarTerms, bool traditionalChineseCharacters = false) =>
        ChineseSolarTermHelper.GetName(chineseSolarTerms, traditionalChineseCharacters);

    /// <summary>
    /// Get English name<br />
    /// 获取英文名称
    /// </summary>
    /// <param name="chineseSolarTerms"></param>
    /// <returns></returns>
    public static string GetEnglishName(this ChineseSolarTerms chineseSolarTerms) =>
        ChineseSolarTermHelper.GetEnglishName(chineseSolarTerms);
}