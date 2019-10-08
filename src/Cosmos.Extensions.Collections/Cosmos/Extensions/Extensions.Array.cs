using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// Extensions of array
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// To safe array
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static TElement[] ToSafeArray<TElement>(this IEnumerable<TElement> source) => source as TElement[] ?? source.ToArray();
    }
}