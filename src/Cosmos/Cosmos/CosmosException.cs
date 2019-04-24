using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Cosmos
{
    // ReSharper disable InconsistentNaming
    public abstract class CosmosException : Exception
    {
        protected const string EMPTY_FLAG = "__EMPTY_FLG";
        protected const string DEFAULT_ERROR_MESSAGE = "_DEFAULT_ERROR";
        protected const long DEFAULT_ERROR_CODE = 1001;
        protected const long DEFAULT_EXTEND_ERROR_CODE = 1002;

        protected CosmosException()
            : this(DEFAULT_ERROR_CODE, DEFAULT_ERROR_MESSAGE, EMPTY_FLAG) { }

        protected CosmosException(string errorMessage, Exception innerException = null)
            : this(errorMessage, EMPTY_FLAG, innerException) { }

        protected CosmosException(string errorMessage, string flag, Exception innerException = null)
            : this(DEFAULT_EXTEND_ERROR_CODE, errorMessage, flag, innerException) { }

        protected CosmosException(long errorCode, string errorMessage, Exception innerException = null)
            : this(errorCode, errorMessage, EMPTY_FLAG, innerException) { }

        protected CosmosException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            ExtraData = new Dictionary<string, object>();
            Code = DEFAULT_EXTEND_ERROR_CODE;
            Flag = EMPTY_FLAG;
        }

        protected CosmosException(long errorCode, string errorMessage, string flag, Exception innerException = null)
            : base(errorMessage, innerException)
        {
            if (string.IsNullOrWhiteSpace(flag))
            {
                flag = EMPTY_FLAG;
            }

            ExtraData = new Dictionary<string, object>();
            Code = errorCode;
            Flag = flag;
        }

        protected CosmosException(CosmosExceptionOptions options) : base(options.Message, options.InnerException)
        {
            ExtraData = new Dictionary<string, object>();
            Code = options.ErrorCode;
            Flag = options.Flag;
        }

        public long Code { get; protected set; }

        public string Flag { get; protected set; }

        public Dictionary<string, object> ExtraData { get; }

        public virtual string GetFullMessage() => $"{Code}:({Flag}){Message}";
    }
}