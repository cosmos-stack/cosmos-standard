using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
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
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToAgo(this DateInfo date)
        {
            return (DateTime.Now - date).ToAgo();
        }
    }
}
