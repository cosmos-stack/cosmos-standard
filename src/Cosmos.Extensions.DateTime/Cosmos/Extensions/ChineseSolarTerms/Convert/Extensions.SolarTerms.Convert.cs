using Cosmos.Date.Chinese;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// Chinese Solar Terms Extensions<br />
    /// 节气扩展
    /// </summary>
    public static partial class ChineseSolarTermsExtensions
    {
        /// <summary>
        /// Get Chinese name<br />
        /// 获取中文名称
        /// </summary>
        /// <param name="chineseSolarTerms"></param>
        /// <param name="traditionalChineseCharacters"></param>
        /// <returns></returns>
        public static string GetName(this ChineseSolarTerms chineseSolarTerms, bool traditionalChineseCharacters = false)
        {
            return ChineseSolarTermHelper.GetName(chineseSolarTerms, traditionalChineseCharacters);
        }

        /// <summary>
        /// Get English name<br />
        /// 获取英文名称
        /// </summary>
        /// <param name="chineseSolarTerms"></param>
        /// <returns></returns>
        public static string GetEnglishName(this ChineseSolarTerms chineseSolarTerms)
        {
            return Enums.GetDescription<ChineseSolarTerms>(chineseSolarTerms);
        }
    }
}
