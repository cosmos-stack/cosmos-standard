using System;
using System.Runtime.CompilerServices;

namespace CosmosStack.Date.DateUtils
{
    /// <summary>
    /// CosmosStack <see cref="DateTime"/> Constellation extensions <br />
    /// 星座扩展
    /// </summary>
    public static class ConstellationExtensions
    {
        /// <summary>
        /// Gets Constellation name<br />
        /// 获取星座名
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetConstellationName(this DateInfo dt) => ConstellationHelper.Get(dt);

        /// <summary>
        /// Gets Constellation name<br />
        /// 获取星座名
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetConstellationName(this DateTime dt) => ConstellationHelper.Get(dt);
    }
}