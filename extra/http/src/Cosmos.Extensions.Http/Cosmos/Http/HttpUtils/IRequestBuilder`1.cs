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
    public interface IRequestBuilder<T>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        IRequestBuilder Inner { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        Func<HttpResponseMessage, Task<T>> Handler { get; }
    }
}
