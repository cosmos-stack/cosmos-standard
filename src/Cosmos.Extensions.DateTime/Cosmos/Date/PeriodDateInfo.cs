using System;

namespace Cosmos.Date
{
    /// <summary>
    /// Period DateInfo<br />
    /// 时间段日期信息
    /// </summary>
    public class PeriodDateInfo : PeriodDateInfo<DateInfo>
    {
        /// <summary>
        /// Create a new <see cref="PeriodDateInfo"/> instance.<br />
        /// 创建一个新的 <see cref="PeriodDateInfo"/> 实例。
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public PeriodDateInfo(DateInfo from, DateInfo to) : base(from, to, dt => new DateInfo(dt)) { }

        /// <summary>
        /// From date<br />
        /// 时间起始于...
        /// </summary>
        public override DateInfo From => _from.Clone();

        /// <summary>
        /// To date<br />
        /// 时间截止于...
        /// </summary>
        public override DateInfo To => _to.Clone();

        private static class PeriodChecker
        {
            public static void CheckFromAndTo(DateInfo from, DateInfo to)
            {
                if (from == null) throw new ArgumentNullException(nameof(from));
                if (to == null) throw new ArgumentNullException(nameof(to));
                if (from.DateTimeRef > to.DateTimeRef)
                    throw new ArgumentException("FromDateInfo cannot be greater than ToDateInfo.");
            }
        }

        private static DateInfo Next(DateInfo date) => date.AddDay();

        /// <summary>
        /// Initialize<br />
        /// 初始化
        /// </summary>
        protected override void Initialize()
        {
            if (!_cache.IsInitialized)
            {
                var limited = Length;
                var current = _from;
                if (_isInfiniteFuture) limited = 31;
                for (var i = 0; i < limited; i++)
                {
                    _cache.Add(current);
                    if (i < limited - 1)
                        current = Next(current);
                }

                _cache.IsInitialized = true;
            }
        }
    }
}
