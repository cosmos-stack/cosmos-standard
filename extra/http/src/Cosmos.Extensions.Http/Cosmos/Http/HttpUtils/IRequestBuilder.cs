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

namespace Cosmos.Http.HttpUtils
{
    /// <summary>
    /// A request for building request options before issuing.
    /// </summary>
    public interface IRequestBuilder
    {
        HttpSettings Settings { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        HttpRequestMessage Message { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool LogErrors { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        IEnumerable<HttpStatusCode> IgnoreResponseStatuses { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        TimeSpan Timeout { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        event EventHandler<HttpExceptionArgs> BeforeExceptionLog;

        [EditorBrowsable(EditorBrowsableState.Never)]
        void OnBeforeExceptionLog(HttpExceptionArgs args);

        [EditorBrowsable(EditorBrowsableState.Never)]
        IRequestBuilder<T> WithHandler<T>(Func<HttpResponseMessage, Task<T>> handler);
    }
}
