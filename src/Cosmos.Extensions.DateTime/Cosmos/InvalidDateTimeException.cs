using System;

namespace Cosmos {
    /// <summary>
    /// Invalid DateTime Exception
    /// </summary>
    public class InvalidDateTimeException : CosmosException {
        // ReSharper disable once InconsistentNaming
        private const string FLAG = "DT_INV_FLG";

        // ReSharper disable once InconsistentNaming
        private const string DEFAULT_MESSAGE = "DateTime is invalid.";

        // ReSharper disable once InconsistentNaming
        private const long DEFAULT_CODE = 1070;

        /// <summary>
        /// Create a new <see cref="InvalidDateTimeException"/> instance.
        /// </summary>
        public InvalidDateTimeException() : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG) { }

        /// <summary>
        /// Create a new <see cref="InvalidDateTimeException"/> instance.
        /// </summary>
        /// <param name="message"></param>
        public InvalidDateTimeException(string message) : base(DEFAULT_CODE, message, FLAG) { }

        /// <summary>
        /// Create a new <see cref="InvalidDateTimeException"/> instance.
        /// </summary>
        /// <param name="code"></param>
        public InvalidDateTimeException(long code) : base(code, DEFAULT_MESSAGE, FLAG) { }

        /// <summary>
        /// Create a new <see cref="InvalidDateTimeException"/> instance.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public InvalidDateTimeException(long code, string message) : base(code, message, FLAG) { }

        /// <summary>
        /// Create a new <see cref="InvalidDateTimeException"/> instance.
        /// </summary>
        /// <param name="innerException"></param>
        public InvalidDateTimeException(Exception innerException) : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG, innerException) { }

        /// <summary>
        /// Create a new <see cref="InvalidDateTimeException"/> instance.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public InvalidDateTimeException(string message, Exception innerException) : base(DEFAULT_CODE, message, FLAG, innerException) { }
    }
}