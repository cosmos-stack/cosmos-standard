using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

/*
 * Reference to:
 *      StackExchange.Utils
 *      Author: StackExchange / StackOverflow
 *      URL: https://github.com/StackExchange/StackExchange.Utils
 *      MIT
 */

namespace Cosmos.Http.HttpUtils {
    /// <summary>
    /// A request for building request options before issuing.
    /// </summary>
    public interface IRequestBuilder {
        /// <summary>
        /// Settings
        /// </summary>
        HttpSettings Settings { get; }

        /// <summary>
        /// Message
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        HttpRequestMessage Message { get; }

        /// <summary>
        /// Log errors
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool LogErrors { get; set; }

        /// <summary>
        /// Ignore response status
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<HttpStatusCode> IgnoreResponseStatuses { get; set; }

        /// <summary>
        /// Timeout
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        TimeSpan Timeout { get; set; }

        /// <summary>
        /// Before exception log
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        event EventHandler<HttpExceptionArgs> BeforeExceptionLog;

        /// <summary>
        /// On before exception log
        /// </summary>
        /// <param name="args"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        void OnBeforeExceptionLog(HttpExceptionArgs args);

        /// <summary>
        /// With handler
        /// </summary>
        /// <param name="handler"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IRequestBuilder<T> WithHandler<T>(Func<HttpResponseMessage, Task<T>> handler);
    }
}