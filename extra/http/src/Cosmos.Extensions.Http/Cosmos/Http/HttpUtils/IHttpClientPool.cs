using System.Net.Http;

/*
 * Reference to:
 *      StackExchange.Utils
 *      Author: StackExchange / StackOverflow
 *      URL: https://github.com/StackExchange/StackExchange.Utils
 *      MIT
 */

namespace Cosmos.Http.HttpUtils {
    /// <summary>
    /// A pool implementation for HttpClient pool.
    /// </summary>
    public interface IHttpClientPool {
        /// <summary>
        /// Gets a client for the specified <see cref="IRequestBuilder"/>
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        HttpClient Get(IRequestBuilder builder);

        /// <summary>
        /// Clears the pool, in case you need to.
        /// </summary>
        void Clear();
    }
}