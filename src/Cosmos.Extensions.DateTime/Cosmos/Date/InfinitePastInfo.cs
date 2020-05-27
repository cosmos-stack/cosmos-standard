using System;

namespace Cosmos.Date
{
    /// <summary>
    /// Infinite Past Info<br />
    /// 无限过去
    /// </summary>
    public class InfinitePastInfo : DateInfo
    {
        // ReSharper disable once InconsistentNaming
        private static readonly DateTime _internalDateTime = DateTime.MinValue;

        /// <summary>
        /// Create a new <see cref="InfinitePastInfo"/> instance.<br />
        /// 创建一个新的 <see cref="InfinitePastInfo"/> 实例。
        /// </summary>
        public static InfinitePastInfo Instance { get; } = new InfinitePastInfo();

        private InfinitePastInfo() { }

        /// <summary>
        /// Year.<br />
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
        /// Convert <see cref="InfinitePastInfo"/> to <see cref="DateTime"/><br />
        /// 将 <see cref="InfinitePastInfo"/> 转换为 <see cref="DateTime"/>。
        /// </summary>
        /// <returns></returns>
        public override DateTime ToDateTime() => DateTime.MinValue;
    }
}