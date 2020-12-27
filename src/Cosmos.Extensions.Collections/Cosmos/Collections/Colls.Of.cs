using System.Collections.Generic;
using System.Linq;
using DotNetCore.Collections.Paginable;

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
        public static List<T> OfList<T>() => new();

        /// <summary>
        /// Create a list instance of the specified type T. <br />
        /// 创建一个指定类型 T 的列表实例。
        /// </summary>
        /// <param name="params"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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

            if (listParams != null)
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
        public static EnumerablePage<T> OfPage<T>(IEnumerable<T> enumerable, int pageNumber, int itemCountPerPage)
        {
            return enumerable.GetPage(pageNumber, itemCountPerPage) as EnumerablePage<T>;
        }
    }
}