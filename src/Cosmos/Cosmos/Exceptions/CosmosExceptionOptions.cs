using System;
using System.Collections.Generic;

namespace Cosmos.Exceptions
{
    /// <summary>
    /// Options for cosmos exception
    /// </summary>
    public class CosmosExceptionOptions
    {
        /// <summary>
        /// Empty flag
        /// </summary>
        protected const string EMPTY_FLAG = "__EMPTY_FLG";

        /// <summary>
        /// Default error message
        /// </summary>
        protected const string DEFAULT_ERROR_MESSAGE = "_DEFAULT_ERROR";

        /// <summary>
        /// Default extend error code
        /// </summary>
        protected const long DEFAULT_EXTEND_ERROR_CODE = 1002;

        /// <summary>
        /// Gets for sets error message, default is <see cref="DEFAULT_ERROR_MESSAGE"/>.
        /// </summary>
        public string Message { get; set; } = DEFAULT_ERROR_MESSAGE;

        /// <summary>
        /// Gets or sets error flag, default is <see cref="EMPTY_FLAG"/>.
        /// </summary>
        public string Flag { get; set; } = EMPTY_FLAG;

        /// <summary>
        /// Gets or sets error code, default is <see cref="DEFAULT_EXTEND_ERROR_CODE"/>.
        /// </summary>
        public long ErrorCode { get; set; } = DEFAULT_EXTEND_ERROR_CODE;

        /// <summary>
        /// Gets or sets inner exception.
        /// </summary>
        public Exception InnerException { get; set; }

        /// <summary>
        /// Gets or sets extra errors
        /// </summary>
        public Dictionary<string, object> ExtraErrors { get; set; } = new Dictionary<string, object>();
    }
}