using System;

namespace Cosmos {
    /// <summary>
    /// DateTime out of range exception.
    /// </summary>
    public class DateTimeOutOfRangeException : CosmosException {
        // ReSharper disable once InconsistentNaming
        private const string FLAG = "DT_OOR_FLG";

        // ReSharper disable once InconsistentNaming
        private const string DEFAULT_MESSAGE = "DateTime is out of range.";

        // ReSharper disable once InconsistentNaming
        private const long DEFAULT_CODE = 1071;

        /// <summary>
        /// Create a new <see cref="DateTimeOutOfRangeException"/> instance.
        /// </summary>
        public DateTimeOutOfRangeException() : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG) { }

        /// <summary>
        /// Create a new <see cref="DateTimeOutOfRangeException"/> instance.
        /// </summary>
        /// <param name="message"></param>
        public DateTimeOutOfRangeException(string message) : base(DEFAULT_CODE, message, FLAG) { }

        /// <summary>
        /// Create a new <see cref="DateTimeOutOfRangeException"/> instance.
        /// </summary>
        /// <param name="code"></param>
        public DateTimeOutOfRangeException(long code) : base(code, DEFAULT_MESSAGE, FLAG) { }

        /// <summary>
        /// Create a new <see cref="DateTimeOutOfRangeException"/> instance.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public DateTimeOutOfRangeException(long code, string message) : base(code, message, FLAG) { }

        /// <summary>
        /// Create a new <see cref="DateTimeOutOfRangeException"/> instance.
        /// </summary>
        /// <param name="innerException"></param>
        public DateTimeOutOfRangeException(Exception innerException) : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG, innerException) { }

        /// <summary>
        /// Create a new <see cref="DateTimeOutOfRangeException"/> instance.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public DateTimeOutOfRangeException(string message, Exception innerException) : base(DEFAULT_CODE, message, FLAG, innerException) { }
    }
}