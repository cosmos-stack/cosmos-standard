using System;
using Cosmos.Date;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// DateInfo Extensions<br />
    /// DateInfo 扩展方法
    /// </summary>
    public static partial class DateInfoExtensions
    {
        /// <summary>
        /// Clone<br />
        /// 克隆
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateInfo Clone(this DateInfo date)
        {
            if (date == null)
                throw new ArgumentNullException(nameof(date));
            return new DateInfo(date.DateTimeRef);
        }
    }
}
