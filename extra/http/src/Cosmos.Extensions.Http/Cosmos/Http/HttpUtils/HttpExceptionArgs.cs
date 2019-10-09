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
    /// <summary>
    /// Http Exception Args
    /// </summary>
    public class HttpExceptionArgs
    {
        /// <summary>
        /// Builder
        /// </summary>
        public IRequestBuilder Builder { get; }

        /// <summary>
        /// Error
        /// </summary>
        public Exception Error { get; }

        /// <summary>
        /// Abort logging
        /// </summary>
        public bool AbortLogging { get; set; }

        internal HttpExceptionArgs(IRequestBuilder builder, Exception ex)
        {
            Builder = builder;
            Error = ex;
        }
    }
}