using System;

namespace Cosmos.Exceptions {
    /// <summary>
    /// Interface for fluent exception builder
    /// </summary>
    public interface IFluentExceptionBuilder<TException> where TException : Exception {
        /// <summary>
        /// Gets target exception's type
        /// </summary>
        Type TargetType { get; }

        /// <summary>
        /// With inner exception.<br />
        /// This value will be used for constructor with param-name 'innerException' and 'inner' (just for <see cref="InvalidProgramException"/>).
        /// </summary>
        /// <param name="innerException"></param>
        /// <returns></returns>
        IFluentExceptionBuilder<TException> InnerException(Exception innerException);

        /// <summary>
        /// With parameter's name.<br />
        /// This value will be used for constructor with param-name 'paramName'.
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        IFluentExceptionBuilder<TException> ParamName(string paramName);

        /// <summary>
        /// With message.<br />
        /// This value will be used for constructor with param-name 'message'.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        IFluentExceptionBuilder<TException> Message(string message);

        /// <summary>
        /// Actual value.<br />
        /// This value will be used for constructor with param-name 'actualValue'.
        /// </summary>
        /// <param name="actualValue"></param>
        /// <returns></returns>
        IFluentExceptionBuilder<TException> ActualValue(object actualValue);

        /// <summary>
        /// Error code.<br />
        /// This value will be used for constructor with param-name 'errorCode'.
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        IFluentExceptionBuilder<TException> ErrorCode(int errorCode);

        /// <summary>
        /// Build and return exception instance
        /// </summary>
        /// <returns></returns>
        TException Build();

        /// <summary>
        /// Build and throw exception
        /// </summary>
        void BuildAndThrow();

        /// <summary>
        /// Build and throw exception as validation error
        /// </summary>
        void BuildAndThrowAsValidationError();
    }
}