using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Date
{
    /// <summary>
    /// DateInfo Extensions<br />
    /// DateInfo 扩展方法
    /// </summary>
    public static class DateInfoAgoExtensions
    {
        /// <summary>
        /// To ago.<br />
        /// 转换为 Ago
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
#pragma warning disable 618
        public static string ToAgo(this DateInfo d) => (DateTime.Now - d).ToAgo();
#pragma warning restore 618
    }
}