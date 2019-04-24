using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos
{
    public class CosmosExceptionOptions
    {
        protected const string EMPTY_FLAG = "__EMPTY_FLG";
        protected const string DEFAULT_ERROR_MESSAGE = "_DEFAULT_ERROR";
        protected const long DEFAULT_EXTEND_ERROR_CODE = 1002;

        public string Message { get; set; } = DEFAULT_ERROR_MESSAGE;

        public string Flag { get; set; } = EMPTY_FLAG;

        public long ErrorCode { get; set; } = DEFAULT_EXTEND_ERROR_CODE;

        public Exception InnerException { get; set; }
    }
}
