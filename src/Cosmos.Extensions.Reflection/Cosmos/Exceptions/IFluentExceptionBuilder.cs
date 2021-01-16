using System;
using System.Collections.Generic;
using Cosmos.Reflection;

namespace Cosmos.Exceptions
{
    /// <summary>
    /// Interface for fluent exception builder.<br />
    /// 流畅异常构建器接口。
    /// </summary>
    public interface IFluentExceptionBuilder
    {
        /// <summary>
        /// Target type of exception.<br />
        /// 目标异常的类型
        /// </summary>
        Type TargetType { get; }

        /// <summary>
        /// Build.<br />
        /// 构建。
        /// </summary>
        /// <returns></returns>
        Exception Build();

        /// <summary>
        /// Build, and throw exception.<br />
        /// 构建，并抛出异常。
        /// </summary>
        void BuildAndThrow();

        /// <summary>
        /// Build, and throw as Validation error.<br />
        /// 构建，并抛出验证错误。
        /// </summary>
        void BuildAndThrowAsValidationError();

        /// <summary>
        /// Build.<br />
        /// 构建。
        /// </summary>
        /// <returns></returns>
        Exception Build(Dictionary<string, IArgDescriptionVal> exceptionParams);

        /// <summary>
        /// Build, and throw exception.<br />
        /// 构建，并抛出异常。
        /// </summary>
        void BuildAndThrow(Dictionary<string, IArgDescriptionVal> exceptionParams);

        /// <summary>
        /// Build, and throw as Validation error.<br />
        /// 构建，并抛出验证错误。
        /// </summary>
        void BuildAndThrowAsValidationError(Dictionary<string, IArgDescriptionVal> exceptionParams);
    }

    /// <summary>
    /// Interface for fluent exception builder.<br />
    /// 流畅异常构建器接口。
    /// </summary>
    public interface IFluentExceptionBuilder<out TException> : IFluentExceptionBuilder
        where TException : Exception
    {
        /// <summary>
        /// With inner exception.<br />
        /// This value will be used for constructor with param-name 'innerException' and 'inner' (just for <see cref="InvalidProgramException"/>).<br />
        /// 设置内部异常。
        /// </summary>
        /// <param name="innerException"></param>
        /// <returns></returns>
        IFluentExceptionBuilder<TException> InnerException(Exception innerException);

        /// <summary>
        /// With parameter's name.<br />
        /// This value will be used for constructor with param-name 'paramName'.<br />
        /// 设置参数名称。
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        IFluentExceptionBuilder<TException> ParamName(string paramName);

        /// <summary>
        /// With message.<br />
        /// This value will be used for constructor with param-name 'message'.<br />
        /// 设置异常消息。
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        IFluentExceptionBuilder<TException> Message(string message);

        /// <summary>
        /// Actual value.<br />
        /// This value will be used for constructor with param-name 'actualValue'.<br />
        /// 设置实际的值。
        /// </summary>
        /// <param name="actualValue"></param>
        /// <returns></returns>
        IFluentExceptionBuilder<TException> ActualValue(object actualValue);

        /// <summary>
        /// Error code.<br />
        /// This value will be used for constructor with param-name 'errorCode'.<br />
        /// 设置错误代码（Error Code）。
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        IFluentExceptionBuilder<TException> ErrorCode(int errorCode);

        /// <summary>
        /// Build.<br />
        /// 构建。
        /// </summary>
        /// <returns></returns>
        new TException Build();

        /// <summary>
        /// Build.<br />
        /// 构建。
        /// </summary>
        /// <returns></returns>
        new TException Build(Dictionary<string, IArgDescriptionVal> exceptionParams);
    }

    /// <summary>
    /// Interface for non-generic fluent exception builder.<br />
    /// 流畅异常构建器接口。
    /// </summary>
    public interface ICommonExceptionBuilder : IFluentExceptionBuilder
    {
        /// <summary>
        /// With inner exception.<br />
        /// This value will be used for constructor with param-name 'innerException' and 'inner' (just for <see cref="InvalidProgramException"/>).<br />
        /// 设置内部异常。
        /// </summary>
        /// <param name="innerException"></param>
        /// <returns></returns>
        ICommonExceptionBuilder InnerException(Exception innerException);

        /// <summary>
        /// With parameter's name.<br />
        /// This value will be used for constructor with param-name 'paramName'.<br />
        /// 设置参数名称。
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        ICommonExceptionBuilder ParamName(string paramName);

        /// <summary>
        /// With message.<br />
        /// This value will be used for constructor with param-name 'message'.<br />
        /// 设置异常消息。
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        ICommonExceptionBuilder Message(string message);

        /// <summary>
        /// Actual value.<br />
        /// This value will be used for constructor with param-name 'actualValue'.<br />
        /// 设置实际的值。
        /// </summary>
        /// <param name="actualValue"></param>
        /// <returns></returns>
        ICommonExceptionBuilder ActualValue(object actualValue);

        /// <summary>
        /// Error code.<br />
        /// This value will be used for constructor with param-name 'errorCode'.<br />
        /// 设置错误代码（Error Code）。
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        ICommonExceptionBuilder ErrorCode(int errorCode);
    }
}