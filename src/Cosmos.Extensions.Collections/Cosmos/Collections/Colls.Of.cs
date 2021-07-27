using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cosmos.Collections.Pagination;
using Cosmos.Collections.Pagination.Internals;

// ReSharper disable MemberHidesStaticFromOuterClass

namespace Cosmos.Collections
{
    /// <summary>
    /// Collections utilities
    /// </summary>
    public static partial class Colls
    {
        /// <summary>
        /// Create a list instance of the specified type T. <br />
        /// 创建一个指定类型 T 的列表实例。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<T> OfList<T>() => new();

        /// <summary>
        /// Create a list instance of the specified type T. <br />
        /// 创建一个指定类型 T 的列表实例。
        /// </summary>
        /// <param name="params"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static List<T> OfList<T>(params T[] @params) => new(@params);

        /// <summary>
        /// Create a list instance of the specified type T. <br />
        /// 创建一个指定类型 T 的列表实例。
        /// </summary>
        /// <param name="listParams"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> OfList<T>(IEnumerable<T>[] listParams)
        {
            var ret = new List<T>();

            if (listParams is not null)
            {
                foreach (var list in listParams)
                {
                    ret.AddRange(list);
                }
            }

            return ret;
        }

        /// <summary>
        /// Create a list instance of the specified type T. <br />
        /// 创建一个指定类型 T 的列表实例。
        /// </summary>
        /// <param name="list"></param>
        /// <param name="listParams"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> OfList<T>(IEnumerable<T> list, params IEnumerable<T>[] listParams)
        {
            var ret = new List<T>(list);

            if (listParams is not null)
            {
                foreach (var @params in listParams)
                {
                    ret.AddRange(@params);
                }
            }

            return ret;
        }

        /// <summary>
        /// Queryable page from the given collection by page number and page size.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable">data from database</param>
        /// <param name="pageNumber">page number</param>
        /// <param name="itemCountPerPage">page size</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static QueryablePage<T> OfPage<T>(IQueryable<T> queryable, int pageNumber, int itemCountPerPage)
        {
            return queryable.GetPage(pageNumber, itemCountPerPage) as QueryablePage<T>;
        }

        /// <summary>
        /// Enumerable page from the given collection by page number and page size.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">data in memory</param>
        /// <param name="pageNumber">page number</param>
        /// <param name="itemCountPerPage">page size</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EnumerablePage<T> OfPage<T>(IEnumerable<T> enumerable, int pageNumber, int itemCountPerPage)
        {
            return enumerable.GetPage(pageNumber, itemCountPerPage) as EnumerablePage<T>;
        }

        /// <summary>
        /// Create a page set from the given collection with page size and member count limit.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="pageSize"></param>
        /// <param name="limitedMemberCount"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PageableEnumerable<T> OfPageSet<T>(IEnumerable<T> enumerable, int? pageSize = null, int? limitedMemberCount = null)
        {
            return PageableCollectionFactory.CreatePageSet(enumerable, pageSize, limitedMemberCount);
        }

        /// <summary>
        /// Create a page set from the given collection with page size and member count limit.
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="pageSize"></param>
        /// <param name="limitedMemberCount"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PageableQueryable<T> OfPageSet<T>(IQueryable<T> queryable, int? pageSize = null, int? limitedMemberCount = null)
        {
            return PageableCollectionFactory.CreatePageSet(queryable, pageSize, limitedMemberCount);
        }

        /// <summary>
        /// Create a new instance of <see cref="PageMember{T}"/>
        /// </summary>
        /// <param name="memberValue"></param>
        /// <param name="offset"></param>
        /// <param name="startIndex"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PageMember<T> OfPageMember<T>(T memberValue, int offset, ref int startIndex)
        {
            return PageMemberFactory.Create(memberValue, offset, ref startIndex);
        }

        /// <summary>
        /// Create a new instance of <see cref="PageMember{T}"/>
        /// </summary>
        /// <param name="memberColl"></param>
        /// <param name="index"></param>
        /// <param name="offset"></param>
        /// <param name="startIndex"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PageMember<T> OfPageMember<T>(IEnumerable<T> memberColl, int index, int offset, ref int startIndex)
        {
            return PageMemberFactory.Create(memberColl, index, offset, ref startIndex);
        }

        /// <summary>
        /// Create a new instance of <see cref="PageMember{T}"/>
        /// </summary>
        /// <param name="state"></param>
        /// <param name="offset"></param>
        /// <param name="startIndex"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PageMember<T> OfPageMember<T>(IQueryEntryState<T> state, int offset, ref int startIndex)
        {
            return PageMemberFactory.Create(state, offset, ref startIndex);
        }
    }
}