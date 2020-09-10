using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Collections
{
    /// <summary>
    /// Collection extensions
    /// </summary>
    public static partial class CollectionExtensions
    {
        #region Contains

        /// <summary>
        /// 检查一个集合是否拥有指定数量的成员
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool ContainsAtLeast<T>(this ICollection<T> source, int count)
            => source?.Count >= count;

        /// <summary>
        /// 检查两个集合是否拥有相等数量的成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        public static bool ContainsEqualCount<T>(this ICollection<T> source, ICollection<T> that)
        {
            if (source is null && that is null)
                return true;

            if (source is null || that is null)
                return false;

            return source.Count.Equals(that.Count);
        }

        #endregion

        #region AddIf

        /// <summary>
        /// 如果条件成立，添加项
        /// </summary>
        public static void AddIf<T>(this ICollection<T> collection, T value, bool flag)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            if (flag)
            {
                collection.Add(value);
            }
        }

        /// <summary>
        /// 如果条件成立，添加项
        /// </summary>
        public static void AddIf<T>(this ICollection<T> collection, T value, Func<bool> func)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            if (func())
            {
                collection.Add(value);
            }
        }

        /// <summary>
        /// 如果不存在，添加项
        /// </summary>
        public static void AddIfNotExist<T>(this ICollection<T> collection, T value, Func<T, bool> existFunc = null)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            bool exists = existFunc?.Invoke(value) ?? collection.Contains(value);
            if (!exists)
            {
                collection.Add(value);
            }
        }

        /// <summary>
        /// 如果不为空，添加项
        /// </summary>
        public static void AddIfNotNull<T>(this ICollection<T> collection, T value) where T : class
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));
            if (value != null)
            {
                collection.Add(value);
            }
        }

        #endregion

        #region GetOrAdd

        /// <summary>
        /// 获取对象，不存在对使用委托添加对象
        /// </summary>
        public static T GetOrAdd<T>(this ICollection<T> collection, Func<T, bool> selector, Func<T> factory)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            T item = collection.FirstOrDefault(selector);
            if (item == null)
            {
                item = factory();
                collection.Add(item);
            }

            return item;
        }

        #endregion
    }
}