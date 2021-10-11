using System;

namespace CosmosStack.Finders
{
    /// <summary>
    /// Interface for finder <br />
    /// Finder 接口
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public interface IFinder<out TItem>
    {
        /// <summary>
        /// Find items based on specified conditions. <br />
        /// 根据指定的条件查找项目。
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <param name="fromCache">是否来自缓存</param>
        /// <returns></returns>
        TItem[] Find(Func<TItem, bool> predicate, bool fromCache = false);

        /// <summary>
        /// Find all items. <br />
        /// 查找所有项目。
        /// </summary>
        /// <param name="fromCache">是否来自缓存</param>
        /// <returns></returns>
        TItem[] FindAll(bool fromCache = false);
    }
}