#if !NET451 && !NET461

namespace Cosmos.Exceptions.BuildingDescriptors {
    /// <summary>
    /// Exception arg constants
    /// </summary>
    public class ExceptionArgConstants {
        /// <summary>
        /// Message
        /// </summary>
        public const string MESSAGE = "message";

        /// <summary>
        /// Param Name
        /// </summary>
        public const string PARAM_NAME = "paramName";

        /// <summary>
        /// Inner exception
        /// </summary>
        public const string INNER_EXCEPTION = "innerException";

        /// <summary>
        /// Inner exception, usage for InvalidProgramException
        /// </summary>
        public const string INNER = "inner";

        /// <summary>
        /// Actual value
        /// </summary>
        public const string ACTUAL_VALUE = "actualValue";

        /// <summary>
        /// Error code
        /// </summary>
        public const string ERROR_CODE = "errorCode";
    }
}

#endif