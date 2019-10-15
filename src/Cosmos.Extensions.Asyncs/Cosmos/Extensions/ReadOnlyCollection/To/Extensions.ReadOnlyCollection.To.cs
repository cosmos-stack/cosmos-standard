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
    /// AsyncReadOnly collection extensions
    /// </summary>
    public static class AsyncReadOnlyCollectionExtensions
    {
        /// <summary>
        /// To readonly collection async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<ReadOnlyCollection<T>> ToReadOnlyCollectionAsync<T>(
            this IAsyncEnumerable<T> source, CancellationToken cancellationToken)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return new ReadOnlyCollection<T>(await source.ToList(cancellationToken).ConfigureAwait(false));
        }
    }
}