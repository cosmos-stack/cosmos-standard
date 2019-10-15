using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Asynchronous
{
    /// <summary>
    /// AsyncHashSet extensions
    /// </summary>
    public static class AsyncHashSetExtensions
    {
        /// <summary>
        /// To hashset async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<HashSet<T>> ToHashSetAsync<T>(
            this IAsyncEnumerable<T> source, CancellationToken cancellationToken)
            => source.ToHashSetAsync(EqualityComparer<T>.Default, cancellationToken);

        /// <summary>
        /// To hashset async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<HashSet<T>> ToHashSetAsync<T>(
            this IAsyncEnumerable<T> source, IEqualityComparer<T> comparer, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            var hashSet = new HashSet<T>(comparer);

            using (var enumerator = source.GetEnumerator())
                while (await enumerator.MoveNext(cancellationToken).ConfigureAwait(false))
                    hashSet.Add(enumerator.Current);

            return hashSet;
        }
    }
}