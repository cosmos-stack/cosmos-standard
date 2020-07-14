using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// Enumerable extensions
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Harvest
        /// </summary>
        /// <param name="source"></param>
        /// <param name="harvester"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Harvest<T>(this IEnumerable<T> source, ICollection<T> harvester)
            => source.Harvest(null, harvester);

        /// <summary>
        /// Harvest
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="harvester"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> Harvest<T>(this IEnumerable<T> source, Func<T, bool> predicate, ICollection<T> harvester)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (harvester is null)
                throw new ArgumentNullException(nameof(harvester));
            if (predicate is null)
                predicate = t => true;

            foreach (var item in source)
            {
                if (!predicate(item))
                    continue;

                harvester.Add(item);
                yield return item;
            }
        }
    }
}