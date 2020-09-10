using System;
using System.Collections.Generic;
using Cosmos.Collections.Internals;

namespace Cosmos.Collections.ReadOnly
{
    public static class ReadOnlyCollectionExtensions
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
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            return new AppendedReadOnlyCollection<T>(source, item);
        }

        #endregion
    }
}