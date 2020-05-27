using System;

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
        /// Clone<br />
        /// 克隆
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateInfo Clone(this DateInfo d)
        {
            if (d == null)
                throw new ArgumentNullException(nameof(d));
            return new DateInfo(d.DateTimeRef);
        }
    }
}