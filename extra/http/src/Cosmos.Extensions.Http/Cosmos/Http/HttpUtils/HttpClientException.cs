using System;
using System.Net;
using System.Runtime.Serialization;

namespace Cosmos.Http.HttpUtils {
    /// <summary>
    /// Http Client Exception
    /// </summary>
    public class HttpClientException : CosmosException {
        private const string FLAG = "CosmosHttpClient";
        private const string MESSAGE = "CosmosHttpClient Error";
        private const long ERROR_CODE = 10107;

        internal HttpClientException() : this(ERROR_CODE, MESSAGE, FLAG) { }
        internal HttpClientException(string message) : this(ERROR_CODE, message, FLAG) { }
        internal HttpClientException(string message, Exception innerException) : this(ERROR_CODE, message, FLAG, innerException) { }
        internal HttpClientException(long errorCode, string errorMessage, string flag, Exception innerException = null) : base(errorCode, errorMessage, flag, innerException) { }

        internal HttpClientException(SerializationInfo info, StreamingContext context) : base(info, context) {
            Code = ERROR_CODE;
            Flag = FLAG;
        }

        internal HttpClientException(string message, HttpStatusCode statusCode, Uri uri) : base(ERROR_CODE, message, FLAG) {
            StatusCode = statusCode;
            Uri = uri;
        }

        internal HttpClientException(string message, Uri uri) : base(ERROR_CODE, message, FLAG) {
            Uri = uri;
        }

        internal HttpClientException(string message, Uri uri, Exception innerException) : base(ERROR_CODE, message, FLAG, innerException) {
            Uri = uri;
        }

        /// <summary>
        /// Status code
        /// </summary>
        public HttpStatusCode? StatusCode { get; }

        /// <summary>
        /// Uri
        /// </summary>
        public Uri Uri { get; }
    }
}