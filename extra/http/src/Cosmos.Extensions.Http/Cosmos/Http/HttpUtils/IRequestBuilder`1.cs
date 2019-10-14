using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;

/*
 * Reference to:
 *      StackExchange.Utils
 *      Author: StackExchange / StackOverflow
 *      URL: https://github.com/StackExchange/StackExchange.Utils
 *      MIT
 */

namespace Cosmos.Http.HttpUtils
{
    /// <summary>
    /// Generic interface for request builder
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRequestBuilder<T>
    {
        /// <summary>
        /// Inner
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IRequestBuilder Inner { get; }

        /// <summary>
        /// Handler
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Func<HttpResponseMessage, Task<T>> Handler { get; }
    }
}