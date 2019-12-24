using System;

namespace Cosmos.Optionals {
    /// <summary>
    /// Optional value missing exception
    /// </summary>
    public class OptionalValueMissingException : CosmosException {
        // ReSharper disable once InconsistentNaming
        private const string FLAG = "OPTIONAL_VAL_MISSING_FLG";

        // ReSharper disable once InconsistentNaming
        private const string DEFAULT_MESSAGE = "Optional value missing.";

        // ReSharper disable once InconsistentNaming
        private const long DEFAULT_CODE = 1011;

        /// <summary>
        /// Create a new <see cref="OptionalValueMissingException"/> instance.
        /// </summary>
        public OptionalValueMissingException() : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG) { }

        /// <summary>
        /// Create a new <see cref="OptionalValueMissingException"/> instance.
        /// </summary>
        /// <param name="message"></param>
        public OptionalValueMissingException(string message) : base(DEFAULT_CODE, message, FLAG) { }

        /// <summary>
        /// Create a new <see cref="OptionalValueMissingException"/> instance.
        /// </summary>
        /// <param name="code"></param>
        public OptionalValueMissingException(long code) : base(code, DEFAULT_MESSAGE, FLAG) { }

        /// <summary>
        /// Create a new <see cref="OptionalValueMissingException"/> instance.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public OptionalValueMissingException(long code, string message) : base(code, message, FLAG) { }

        /// <summary>
        /// Create a new <see cref="OptionalValueMissingException"/> instance.
        /// </summary>
        /// <param name="innerException"></param>
        public OptionalValueMissingException(Exception innerException) : base(DEFAULT_CODE, DEFAULT_MESSAGE, FLAG, innerException) { }

        /// <summary>
        /// Create a new <see cref="OptionalValueMissingException"/> instance.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public OptionalValueMissingException(string message, Exception innerException) : base(DEFAULT_CODE, message, FLAG, innerException) { }
    }
}