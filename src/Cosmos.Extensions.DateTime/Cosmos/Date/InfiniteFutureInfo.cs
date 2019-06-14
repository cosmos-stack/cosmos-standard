using System;

namespace Cosmos.Date
{
    /// <summary>
    /// Infinite Future Info<br />
    /// 无限未来
    /// </summary>
    public class InfiniteFutureInfo : DateInfo
    {
        // ReSharper disable once InconsistentNaming
        private static readonly DateTime _internalDateTime = DateTime.MaxValue;

        /// <summary>
        /// Gets an <see cref="InfiniteFutureInfo"/> instance.<br />
        /// 获得一个 <see cref="InfiniteFutureInfo"/> 实例。
        /// </summary>
        public static InfiniteFutureInfo Instance { get; } = new InfiniteFutureInfo();

        private InfiniteFutureInfo() { }

        /// <summary>
        /// Year<br />
        /// 年
        /// </summary>
        public override int Year => _internalDateTime.Year;

        /// <summary>
        /// Month<br />
        /// 月
        /// </summary>
        public override int Month => _internalDateTime.Month;

        /// <summary>
        /// Day<br />
        /// 日
        /// </summary>
        public override int Day => _internalDateTime.Day;

        /// <summary>
        /// Convert <see cref="InfiniteFutureInfo"/> to <see cref="DateTime"/><br />
        /// 将 <see cref="InfiniteFutureInfo"/> 转换为 <see cref="DateTime"/>。
        /// </summary>
        /// <returns></returns>
        public override DateTime ToDateTime() => DateTime.MaxValue;
    }
}
