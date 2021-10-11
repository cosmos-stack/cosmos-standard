using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Cosmos.Collections;
using CosmosStack.Collections.Internals;

namespace CosmosStack.Collections
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
    
    /// <summary>
    /// ReadOnly Collection Utilities <br />
    /// 只读集合工具
    /// </summary>
    public static partial class ReadOnlyColls
    {
        #region Append

        /// <summary>
        /// Append <br />
        /// 附加
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
        /// Gets empty readonly collection. <br />
        /// 获取一个空只读集合
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IReadOnlyList<T> OfList<T>(IEnumerable<T> list, params IEnumerable<T>[] listParams)
        {
            return Colls.OfList(list, listParams).AsReadOnly();
        }

        #endregion
    }

    /// <summary>
    /// ReadOnly Collection Utilities Extensions <br />
    /// 只读集合工具扩展
    /// </summary>
    public static class ReadOnlyCollsExtensions
    {
        #region Append

        /// <summary>
        /// Append <br />
        /// 附加
        /// </summary>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IReadOnlyCollection<T> Append<T>(this IReadOnlyCollection<T> source, T item)
        {
            return ReadOnlyColls.Append(source, item);
        }

        #endregion
    }
}