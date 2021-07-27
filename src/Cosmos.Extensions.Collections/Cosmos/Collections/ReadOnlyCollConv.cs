using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Cosmos.Collections.Internals;

namespace Cosmos.Collections
{
    public static class ReadOnlyCollConv
    {
        #region AsList

        /// <summary>
        /// As list
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<T> AsList<T>(IReadOnlyList<T> list)
        {
            if (list is null)
                throw new ArgumentNullException(nameof(list));
            return new ReadOnlyListWrapper<T>(list);
        }

        #endregion
    }

    public static class ReadOnlyCollConvExtensions
    {
        #region AsReadOnly

        /// <summary>
        /// To readonly collection
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyCollection<T> AsReadOnly<T>(this IEnumerable<T> src)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            return ReadOnlyCollsHelper.WrapInReadOnlyCollection(src.ToList());
        }

        #endregion
        
        #region AsList

        /// <summary>
        /// As list
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IList<T> AsList<T>(this IReadOnlyList<T> list)
        {
            return ReadOnlyCollConv.AsList(list);
        }

        #endregion
    }
}