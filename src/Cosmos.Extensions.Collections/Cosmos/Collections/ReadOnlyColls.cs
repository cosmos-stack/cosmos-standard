using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cosmos.Collections.Internals;

namespace Cosmos.Collections
{
    internal static class ReadOnlyCollsHelper
    {
        /// <summary>
        /// Wrap in readonly connection
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyCollection<T> WrapInReadOnlyCollection<T>(IList<T> source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return new ReadOnlyCollection<T>(source);
        }

        /// <summary>
        /// Append
        /// </summary>
        /// <param name="source"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Append<T>(IEnumerable<T> source, params T[] items)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return items is null ? source : source.Concat(items);
        }
    }
    
    public static partial class ReadOnlyColls
    {
        
        #region AddRange

        /// <summary>
        /// Add range
        /// </summary>
        /// <param name="set"></param>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyCollection<SetAddRangeResult<T>> AddRange<T>(ISet<T> set, IEnumerable<T> items)
        {
            if (set is null)
                throw new ArgumentNullException(nameof(set));
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            var added = new List<SetAddRangeResult<T>>(items is ICollection<T> collection ? collection.Count : 1);

            added.AddRange(items.Select(i => new SetAddRangeResult<T>(i, set.Add(i))));

            return ReadOnlyCollsHelper.WrapInReadOnlyCollection(added);
        }

        #endregion

        #region Append

        /// <summary>
        /// Append
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyCollection<T> Append<T>(IReadOnlyCollection<T> source, T item)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return new AppendedReadOnlyCollection<T>(source, item);
        }

        #endregion
        
        #region Empty

        /// <summary>
        /// Gets empty readonly collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ReadOnlyCollection<T> Empty<T>()
        {
            return EmptyReadOnlyCollectionSingleton<T>.OneInstance;
        }

        private static class EmptyReadOnlyCollectionSingleton<T>
        {
            internal static readonly ReadOnlyCollection<T> OneInstance = new(new T[0]);
        }

        #endregion

        #region Of

        /// <summary>
        /// Create a readonly list instance of the specified type T. <br />
        /// 创建一个指定类型 T 的只读列表实例。
        /// </summary>
        /// <param name="params"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IReadOnlyList<T> OfList<T>(params T[] @params)
        {
            return Colls.OfList(@params).AsReadOnly();
        }

        /// <summary>
        /// Create a readonly list instance of the specified type T. <br />
        /// 创建一个指定类型 T 的只读列表实例。
        /// </summary>
        /// <param name="listParams"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IReadOnlyList<T> OfList<T>(params IEnumerable<T>[] listParams)
        {
            return Colls.OfList(listParams).AsReadOnly();
        }

        /// <summary>
        /// Create a readonly list instance of the specified type T. <br />
        /// 创建一个指定类型 T 的只读列表实例。
        /// </summary>
        /// <param name="list"></param>
        /// <param name="listParams"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IReadOnlyList<T> OfList<T>(IEnumerable<T> list, params IEnumerable<T>[] listParams)
        {
            return Colls.OfList(list, listParams).AsReadOnly();
        }

        #endregion
    }

    public static partial class ReadOnlyCollsExtensions
    {
        #region Append

        /// <summary>
        /// Append
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IReadOnlyCollection<T> Append<T>(this IReadOnlyCollection<T> source, T item)
        {
            return ReadOnlyColls.Append(source, item);
        }

        #endregion
    }
}