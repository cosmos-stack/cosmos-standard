using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Asynchronous
{
    /// <summary>
    /// AsyncReadOnly dictionary extensions
    /// </summary>
    public static class AsyncReadOnlyDictionaryExtensions
    {
        /// <summary>
        /// To readonly dictionary async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static Task<ReadOnlyDictionary<TKey, TSource>> ToReadOnlyDictionaryAsync<TSource, TKey>(
            this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, CancellationToken cancellationToken)
            => source.ToReadOnlyDictionaryAsync(keySelector, EqualityComparer<TKey>.Default, cancellationToken);

        /// <summary>
        /// To readonly dictionary async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static Task<ReadOnlyDictionary<TKey, TSource>> ToReadOnlyDictionaryAsync<TSource, TKey>(
            this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
            => source.ToReadOnlyDictionaryAsync(keySelector, t => t, EqualityComparer<TKey>.Default, cancellationToken);

        /// <summary>
        /// To readonly dictionary async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        public static Task<ReadOnlyDictionary<TKey, TElement>> ToReadOnlyDictionaryAsync<TSource, TKey, TElement>(
            this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, CancellationToken cancellationToken)
            => source.ToReadOnlyDictionaryAsync(keySelector, elementSelector, EqualityComparer<TKey>.Default, cancellationToken);

        /// <summary>
        /// To readonly dictionary async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <param name="comparer"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<ReadOnlyDictionary<TKey, TElement>> ToReadOnlyDictionaryAsync<TSource, TKey, TElement>(
            this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector,
            IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null)
                throw new ArgumentNullException(nameof(elementSelector));
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            IDictionary<TKey, TElement> dictionary
                = await source.ToDictionary(keySelector, elementSelector, comparer, cancellationToken).ConfigureAwait(false);

            return new ReadOnlyDictionary<TKey, TElement>(dictionary);
        }
    }
}