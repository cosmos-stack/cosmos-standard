// ReSharper disable once CheckNamespace

namespace Cosmos.Date
{
    /// <summary>
    /// DateInfo Extensions<br />
    /// DateInfo 扩展方法
    /// </summary>
    public static partial class DateInfoExtensions
    {
        /// <summary>
        /// Gets Constellation name<br />
        /// 获取星座名
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string GetConstellationName(this DateInfo d) => ConstellationHelper.Get(d);
    }
}