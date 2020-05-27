using System;
using System.Runtime.Serialization;

namespace Cosmos.Conversions.Mapper
{
    /// <summary>
    /// Exception during mapping or binding
    /// </summary>
    [Serializable]
    public class DefaultMapperException : CosmosException
    {
        // ReSharper disable once InconsistentNaming
        private const string FLAG = "__COSMOS_DEFMAPPER";

        // ReSharper disable once InconsistentNaming
        private const string ERROR_MESSAGE = "Default Mapper Exception";

        // ReSharper disable once InconsistentNaming
        private const long ERROR_CODE = 1003;

        // ReSharper disable once InconsistentNaming
        private const long EXTEND_ERROR_CODE = 1004;

        /// <summary>
        /// Create a new instance of <see cref="DefaultMapperException"/>
        /// </summary>
        public DefaultMapperException() : this(ERROR_CODE, ERROR_MESSAGE, FLAG) { }

        /// <summary>
        /// Create a new instance of <see cref="DefaultMapperException"/>
        /// </summary>
        /// <param name="exception"></param>
        public DefaultMapperException(Exception exception) : this(ERROR_CODE, ERROR_MESSAGE, FLAG, exception) { }

        /// <summary>
        /// Create a new instance of <see cref="DefaultMapperException"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public DefaultMapperException(string message, Exception exception = null) : this(ERROR_CODE, message, FLAG, exception) { }

        /// <summary>
        /// Create a new instance of <see cref="DefaultMapperException"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="flag"></param>
        /// <param name="exception"></param>
        public DefaultMapperException(string message, string flag, Exception exception = null) : this(ERROR_CODE, message, flag, exception) { }

        /// <summary>
        /// Create a new instance of <see cref="DefaultMapperException"/>
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public DefaultMapperException(long errorCode, string message, Exception exception = null) : this(errorCode, message, FLAG, exception) { }

        /// <summary>
        /// Create a new instance of <see cref="DefaultMapperException"/>
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="flag"></param>
        /// <param name="exception"></param>
        public DefaultMapperException(long errorCode, string message, string flag, Exception exception = null) : base(errorCode, message, flag, exception) { }

        /// <summary>
        /// Create a new instance of <see cref="DefaultMapperException"/>
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public DefaultMapperException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}