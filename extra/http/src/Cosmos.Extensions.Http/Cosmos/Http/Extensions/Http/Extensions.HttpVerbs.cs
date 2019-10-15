using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Http.HttpUtils;

/*
 * Reference to:
 *      StackExchange.Utils
 *      Author: StackExchange / StackOverflow
 *      URL: https://github.com/StackExchange/StackExchange.Utils
 *      MIT
 */

// ReSharper disable once CheckNamespace
namespace Cosmos.Http
{
    /// <summary>
    /// Http Verbs Extensions
    /// </summary>
    public static class HttpVerbsExtensions
    {
        /// <summary>
        /// Issue the request as a DELETE
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<HttpCallResponse<T>> DeleteAsync<T>(this IRequestBuilder<T> builder, CancellationToken cancellationToken = default)
            => FluentHttp.SendAsync(builder, HttpMethod.Delete, cancellationToken);

        /// <summary>
        /// Issue the request as a GET
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<HttpCallResponse<T>> GetAsync<T>(this IRequestBuilder<T> builder, CancellationToken cancellationToken = default)
            => FluentHttp.SendAsync(builder, HttpMethod.Get, cancellationToken);

        /// <summary>
        /// Issue the request as a POST
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<HttpCallResponse<T>> PostAsync<T>(this IRequestBuilder<T> builder, CancellationToken cancellationToken = default)
            => FluentHttp.SendAsync(builder, HttpMethod.Post, cancellationToken);

        /// <summary>
        /// Issue the request as a PUT
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<HttpCallResponse<T>> PutAsync<T>(this IRequestBuilder<T> builder, CancellationToken cancellationToken = default)
            => FluentHttp.SendAsync(builder, HttpMethod.Put, cancellationToken);
    }
}
