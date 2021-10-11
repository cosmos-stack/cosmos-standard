using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosStack.Finders
{
    /// <summary>
    /// Base finder <br />
    /// Finder 基类
    /// </summary>
    public abstract class BaseFinder<TItem> : IFinder<TItem>
    {
        private readonly object _lockObj = new();

        /// <summary>
        /// Cached items. <br />
        /// 已缓存的项目
        /// </summary>
        protected readonly List<TItem> ItemsCache = new();

        /// <summary>
        /// Mark whether the search has been completed.<br />
        /// 标记是否已完成查找。
        /// </summary>
        protected bool Found;

        /// <summary>
        /// 查找指定条件的项
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <param name="fromCache">是否来自缓存</param>
        /// <returns></returns>
        public virtual TItem[] Find(Func<TItem, bool> predicate, bool fromCache = false)
        {
            return FindAll(fromCache).Where(predicate).ToArray();
        }

        /// <summary>
        /// 查找所有项
        /// </summary>
        /// <param name="fromCache">是否来自缓存</param>
        /// <returns></returns>
        public virtual TItem[] FindAll(bool fromCache = false)
        {
            lock (_lockObj)
            {
                if (fromCache && Found)
                {
                    return ItemsCache.ToArray();
                }

                var items = FindAllItems();

                Found = true;
                ItemsCache.Clear();
                ItemsCache.AddRange(items);

                return items;
            }
        }

        /// <summary>
        /// Perform search work for all items. <br />
        /// 执行所有项目的查找工作。
        /// </summary>
        /// <returns></returns>
        protected abstract TItem[] FindAllItems();
    }
}