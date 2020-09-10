using System;

namespace Cosmos.Date
{
    /// <summary>
    /// Cosmos <see cref="DateTime"/> Constellation extensions
    /// </summary>
    public static class ConstellationExtensions
    {
        /// <summary>
        /// Gets Constellation name<br />
        /// 获取星座名
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetConstellationName(this DateInfo dt) => ConstellationHelper.Get(dt);

        /// <summary>
        /// Gets Constellation name<br />
        /// 获取星座名
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetConstellationName(this DateTime dt) => ConstellationHelper.Get(dt);
    }
}