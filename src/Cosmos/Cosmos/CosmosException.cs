using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Cosmos.Exceptions;

namespace Cosmos {
    // ReSharper disable InconsistentNaming
    /// <summary>
    /// Cosmos base exception
    /// </summary>
    public abstract class CosmosException : Exception {
        /// <summary>
        /// Empty flag
        /// </summary>
        protected const string EMPTY_FLAG = "__EMPTY_FLG";

        /// <summary>
        /// Default error message for cosmos exception
        /// </summary>
        protected const string DEFAULT_ERROR_MESSAGE = "_DEFAULT_ERROR";

        /// <summary>
        /// Default error code for cosmos exception
        /// </summary>
        protected const long DEFAULT_ERROR_CODE = 1001;

        /// <summary>
        /// Default extend error code for cosmos exception
        /// </summary>
        protected const long DEFAULT_EXTEND_ERROR_CODE = 1002;

        /// <summary>
        /// Create a new cosmos exception instance.
        /// </summary>
        protected CosmosException()
            : this(DEFAULT_ERROR_CODE, DEFAULT_ERROR_MESSAGE, EMPTY_FLAG) { }

        /// <summary>
        /// Create a new cosmos exception instance.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="innerException"></param>
        protected CosmosException(string errorMessage, Exception innerException = null)
            : this(errorMessage, EMPTY_FLAG, innerException) { }

        /// <summary>
        /// Create a new cosmos exception instance.
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="flag"></param>
        /// <param name="innerException"></param>
        protected CosmosException(string errorMessage, string flag, Exception innerException = null)
            : this(DEFAULT_EXTEND_ERROR_CODE, errorMessage, flag, innerException) { }

        /// <summary>
        /// Create a new cosmos exception instance.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorMessage"></param>
        /// <param name="innerException"></param>
        protected CosmosException(long errorCode, string errorMessage, Exception innerException = null)
            : this(errorCode, errorMessage, EMPTY_FLAG, innerException) { }

        /// <summary>
        /// Create a new cosmos exception instance.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected CosmosException(SerializationInfo info, StreamingContext context) : base(info, context) {
            ExtraData = new Dictionary<string, object>();
            Code = DEFAULT_EXTEND_ERROR_CODE;
            Flag = EMPTY_FLAG;
        }

        /// <summary>
        /// Create a new cosmos exception instance.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorMessage"></param>
        /// <param name="flag"></param>
        /// <param name="innerException"></param>
        protected CosmosException(long errorCode, string errorMessage, string flag, Exception innerException = null)
            : base(errorMessage, innerException) {
            if (string.IsNullOrWhiteSpace(flag)) {
                flag = EMPTY_FLAG;
            }

            ExtraData = new Dictionary<string, object>();
            Code = errorCode;
            Flag = flag;
        }

        /// <summary>
        /// Create a new cosmos exception instance.
        /// </summary>
        /// <param name="options"></param>
        protected CosmosException(CosmosExceptionOptions options) : base(options.Message, options.InnerException) {
            ExtraData = options.ExtraErrors;
            Code = options.ErrorCode;
            Flag = options.Flag;
        }

        /// <summary>
        /// Error code
        /// </summary>
        public long Code { get; protected set; }

        /// <summary>
        /// Error flag
        /// </summary>
        public string Flag { get; protected set; }

        /// <summary>
        /// Extra data
        /// </summary>
        public Dictionary<string, object> ExtraData { get; }

        /// <summary>
        /// Get full message
        /// </summary>
        /// <returns></returns>
        public virtual string GetFullMessage() => $"{Code}:({Flag}){Message}";

        /// <summary>
        /// Throw me.
        /// </summary>
        public virtual void Throw() {
            ExceptionHelper.PrepareForRethrow(this);
        }
    }
}