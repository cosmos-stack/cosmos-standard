// ReSharper disable once CheckNamespace

namespace Cosmos.Date
{
    /// <summary>
    /// DateTime Extensions<br />
    /// DateTime 扩展方法
    /// </summary>
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// Gets Constellation name<br />
        /// 获取星座名
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetConstellationName(this DateInfo dt) => ConstellationHelper.Get(dt);
    }
}