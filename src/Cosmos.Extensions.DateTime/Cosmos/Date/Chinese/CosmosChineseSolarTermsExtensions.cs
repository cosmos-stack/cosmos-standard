using System.Reflection;
using Cosmos.Reflection;

namespace Cosmos.Date.Chinese
{
    /// <summary>
    /// Cosmos Chinese Solar Terms Extensions<br />
    /// 节气扩展
    /// </summary>
    public static class CosmosChineseSolarTermsExtensions
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
        public static string GetEnglishName(this ChineseSolarTerms chineseSolarTerms)
        {
            var fieldName = EnumsNET.Enums.GetName(chineseSolarTerms);
            var typeInfo = typeof(ChineseSolarTerms).GetTypeInfo();
            var fieldInfo = typeInfo.GetField(fieldName!);
            return TypeReflections.GetDescriptionOrDisplayName(fieldInfo);
        }
    }
}