using System;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// DateTime Extensions<br />
    /// DateTime 扩展方法
    /// </summary>
    public static partial class DateTimeExtensions {
        /// <summary>
        /// Clone<br />
        /// 克隆
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime Clone(this DateTime dt) => new DateTime(dt.Ticks, dt.Kind);
    }
}