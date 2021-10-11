using System;
using System.Collections.Generic;

namespace CosmosStack.Date
{
    /// <summary>
    /// DateInfo Cache <br />
    /// DateInfo 缓存
    /// </summary>
    /// <typeparam name="TDateInfo"></typeparam>
    public class DateInfoCache<TDateInfo> where TDateInfo : DateInfo
    {
        private readonly IList<TDateInfo> _dateInfoCache;

        private TDateInfo LastDateInfo { get; set; }
        private Func<TDateInfo, TDateInfo> ItemCreateFunc { get; }

        /// <summary>
        /// Create a new instance of DateInfoCache
        /// </summary>
        /// <param name="itemCreateFunc"></param>
        public DateInfoCache(Func<TDateInfo, TDateInfo> itemCreateFunc)
        {
            _dateInfoCache = new List<TDateInfo>();
            ItemCreateFunc = itemCreateFunc ?? throw new ArgumentNullException(nameof(itemCreateFunc));
        }

        /// <summary>
        /// Count
        /// </summary>
        /// <returns></returns>
        public int Count() => _dateInfoCache.Count;

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="date"></param>
        public void Add(TDateInfo date)
        {
            if (!Contains(date))
            {
                LastDateInfo = ItemCreateFunc(date);
                _dateInfoCache.Add(LastDateInfo);
            }
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool Contains(TDateInfo date)
        {
            if (date == null)
                return false;
            return _dateInfoCache.Contains(date);
        }

        /// <summary>
        /// Get enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TDateInfo> GetEnumerator()
        {
            return _dateInfoCache.GetEnumerator();
        }

        /// <summary>
        /// Is initialized
        /// </summary>
        public bool IsInitialized { get; set; }

        /// <summary>
        /// Gets cache
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TDateInfo Get(int index) => _dateInfoCache[index];
    }
}