using System;
using System.Collections.Generic;

namespace Cosmos.Date
{

    public abstract class PeriodDateInfo<TDateInfo> where TDateInfo : DateInfo
    {
        // ReSharper disable once InconsistentNaming
        protected readonly TDateInfo _from;
        // ReSharper disable once InconsistentNaming
        protected readonly TDateInfo _to;
        // ReSharper disable once InconsistentNaming
        protected readonly bool _isInfiniteFuture;

        // ReSharper disable once InconsistentNaming
        protected readonly DateInfoCache<TDateInfo> _cache;

        protected PeriodDateInfo(TDateInfo from, TDateInfo to, Func<TDateInfo, TDateInfo> itemCreateFunc)
        {
            PeriodChecker.CheckFromAndTo(from, to);
            _from = from;
            _to = to;
            _isInfiniteFuture = to is InfiniteFutureInfo;
            _cache = new DateInfoCache<TDateInfo>(itemCreateFunc);
        }

        public int Length => _isInfiniteFuture ? int.MaxValue : (_from.DateTimeRef - _to.DateTimeRef).Days + 1;

        public abstract TDateInfo From { get; }

        public abstract TDateInfo To { get; }

        private static class PeriodChecker
        {
            public static void CheckFromAndTo(TDateInfo from, TDateInfo to)
            {
                if (from == null) throw new ArgumentNullException(nameof(from));
                if (to == null) throw new ArgumentNullException(nameof(to));
                if (from.DateTimeRef > to.DateTimeRef)
                    throw new ArgumentException("FromDateInfo cannot be greater than ToDateInfo.");
            }
        }

        public IEnumerable<TDateInfo> GetAllDates()
        {
            Initialize();
            foreach (var item in _cache)
                yield return item;
        }

        protected virtual void Initialize() { }

        public virtual TDateInfo this[int index] {
            get {
                Initialize();
                if (index >= _cache.Count())
                    throw new ArgumentOutOfRangeException(nameof(index), index, "Index out of range.");
                return _cache.Get(index);
            }
        }
    }

}
