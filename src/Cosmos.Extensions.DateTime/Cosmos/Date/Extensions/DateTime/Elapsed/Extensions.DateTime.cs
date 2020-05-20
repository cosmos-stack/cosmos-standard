using System;

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
        /// Elapsed Time<br />
        /// 计算此刻与指定时间之间的时间差
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static TimeSpan ElapsedTime(this DateTime dt) => DateTime.Now - dt;

        /// <summary>
        /// Elapsed Time<br />
        /// 计算此刻与指定时间之间的时间差（毫秒）
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int ElapsedMilliseconds(this DateTime dt) => (int) (DateTime.Now - dt).TotalMilliseconds;
    }
}