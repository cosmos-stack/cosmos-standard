using System;
using System.Collections.Generic;

namespace Cosmos.Date
{
    public class DateInfoCache<TDateInfo> where TDateInfo : DateInfo
    {
        private readonly IList<TDateInfo> _dateInfoCache;

        private TDateInfo LastDateInfo { get; set; }
        private Func<TDateInfo, TDateInfo> ItemCreateFunc { get; set; }

        public DateInfoCache(Func<TDateInfo, TDateInfo> itemCreateFunc)
        {
            _dateInfoCache = new List<TDateInfo>();
            ItemCreateFunc = itemCreateFunc ?? throw new ArgumentNullException(nameof(itemCreateFunc));
        }

        public int Count() => _dateInfoCache.Count;

        public void Add(TDateInfo date)
        {
            if (!Contains(date))
            {
                LastDateInfo = ItemCreateFunc(date);
                _dateInfoCache.Add(LastDateInfo);
            }
        }

        public bool Contains(TDateInfo date)
        {
            if (date == null)
                return false;
            return _dateInfoCache.Contains(date);
        }

        public IEnumerator<TDateInfo> GetEnumerator()
        {
            return _dateInfoCache.GetEnumerator();
        }

        public bool IsInitialized { get; set; }

        public TDateInfo Get(int index) => _dateInfoCache[index];
    }
}
