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
        /// With inner exception
        /// </summary>
        /// <param name="innerException"></param>
        /// <returns></returns>
        IFluentExceptionBuilder<TException> InnerException(Exception innerException);

        /// <summary>
        /// With parameter's name
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        IFluentExceptionBuilder<TException> ParamName(string paramName);

        /// <summary>
        /// With message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        IFluentExceptionBuilder<TException> Message(string message);

        /// <summary>
        /// Actual value
        /// </summary>
        /// <param name="actualValue"></param>
        /// <returns></returns>
        IFluentExceptionBuilder<TException> ActualValue(object actualValue);

        /// <summary>
        /// Error code
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
    }
}