using System;

/*
 * Reference to:
 *      StackExchange.Utils
 *      Author: StackExchange / StackOverflow
 *      URL: https://github.com/StackExchange/StackExchange.Utils
 *      MIT
 */

namespace Cosmos.Http.HttpUtils
{
    public class HttpExceptionArgs
    {
        public IRequestBuilder Builder { get; }

        public Exception Error { get; }

        public bool AbortLogging { get; set; }

        internal HttpExceptionArgs(IRequestBuilder builder, Exception ex)
        {
            Builder = builder;
            Error = ex;
        }
    }
}
