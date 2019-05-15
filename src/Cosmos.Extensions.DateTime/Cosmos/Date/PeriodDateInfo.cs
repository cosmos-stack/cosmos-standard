using System;

namespace Cosmos.Date
{
    public class PeriodDateInfo : PeriodDateInfo<DateInfo>
    {
        public PeriodDateInfo(DateInfo from, DateInfo to) : base(from, to, dt => new DateInfo(dt)) { }

        public override DateInfo From => _from.Clone();

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
