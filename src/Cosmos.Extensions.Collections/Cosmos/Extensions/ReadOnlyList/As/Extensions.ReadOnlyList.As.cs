using System;
using System.Collections.Generic;
using Cosmos.Collections.Internals;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// ReadOnly list extensions
    /// </summary>
    public static partial class ReadOnlyListExtensions
    {
        /// <summary>
        /// As list
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<T> AsList<T>(this IReadOnlyList<T> list)
        {
            // Validate parameters.
            if (list == null) throw new ArgumentNullException(nameof(list));

            // Wrap and return.
            return new ReadOnlyListWrapper<T>(list);
        }
    }
}