#if !NET451 && !NET452

using Cosmos.Validation;
using Cosmos.Exceptions.BuildingServices;

// ReSharper disable RedundantExtendsListEntry

namespace Cosmos.Exceptions;

/// <summary>
/// Exception builder<br />
/// 异常构建器。
/// </summary>
/// <typeparam name="TException"></typeparam>
internal class FluentExceptionBuilder<TException> : FluentExceptionBuilder, IFluentExceptionBuilder<TException>, IParamsCheckable
    where TException : Exception
{
    /// <summary>
    /// Create a new instance of <see cref="FluentExceptionBuilder{TException}"/>. <br />
    /// 创建一个新的 <see cref="FluentExceptionBuilder{TException}"/> 实例。
    /// </summary>
    public FluentExceptionBuilder() : base(Types.Of<TException>()) { }

    /// <summary>
    /// Create a new instance of <see cref="FluentExceptionBuilder{TException}"/>. <br />
    /// 创建一个新的 <see cref="FluentExceptionBuilder{TException}"/> 实例。
    /// </summary>
    public FluentExceptionBuilder(Action<Dictionary<string, IArgDescriptionVal>, ExceptionBuildingOptions> additionalOps)
        : base(Types.Of<TException>(), additionalOps) { }

    /// <summary>
    /// Sets inner exception.<br />
    /// 设置内部异常。
    /// </summary>
    /// <param name="innerException"></param>
    /// <returns></returns>
    public new IFluentExceptionBuilder<TException> InnerException(Exception innerException)
    {
        if (innerException is null)
            return this;

        _innerException = innerException;
        return this;
    }

    /// <summary>
    /// Sets parameter's name.<br />
    /// 设置参数名称。
    /// </summary>
    /// <param name="paramName"></param>
    /// <returns></returns>
    public new IFluentExceptionBuilder<TException> ParamName(string paramName)
    {
        if (string.IsNullOrWhiteSpace(paramName))
            return this;

        _paramName = paramName;
        return this;
    }

    /// <summary>
    /// Sets exception message.<br />
    /// 设置异常消息。
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public new IFluentExceptionBuilder<TException> Message(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
            return this;

        _message = message;
        return this;
    }

    /// <summary>
    /// Sets actual value.<br />
    /// 设置实际的值。
    /// </summary>
    /// <param name="actualValue"></param>
    /// <returns></returns>
    public new IFluentExceptionBuilder<TException> ActualValue(object actualValue)
    {
        _actualValue = actualValue;
        return this;
    }

    /// <summary>
    /// Sets error code.<br />
    /// 设置错误代码（Error Code）。
    /// </summary>
    /// <param name="errorCode"></param>
    /// <returns></returns>
    public new IFluentExceptionBuilder<TException> ErrorCode(int errorCode)
    {
        _errorCode = errorCode;
        return this;
    }

    /// <summary>
    /// Build.<br />
    /// 构建。
    /// </summary>
    /// <returns></returns>
    public new TException Build()
    {
        return Build(null);
    }

    /// <summary>
    /// Build.<br />
    /// 构建。
    /// </summary>
    /// <returns></returns>
    public new TException Build(Dictionary<string, IArgDescriptionVal> exceptionParams)
    {
        CreateAndCacheExceptionInstance(exceptionParams);
        return CachedException.As<TException>();
    }

    /// <summary>
    /// Build, and throw exception.<br />
    /// 构建，并抛出异常。
    /// </summary>
    public new void BuildAndThrow()
    {
        BuildAndThrow(null);
    }

    /// <summary>
    /// Build, and throw exception.<br />
    /// 构建，并抛出异常。
    /// </summary>
    public new void BuildAndThrow(Dictionary<string, IArgDescriptionVal> exceptionParams)
    {
        CreateAndCacheExceptionInstance(exceptionParams);
        ExceptionHelper.PrepareForRethrow(CachedException.As<TException>());
    }

    /// <summary>
    /// Build, and throw as Validation error.<br />
    /// 构建，并抛出验证错误。
    /// </summary>
    public new void BuildAndThrowAsValidationError()
    {
        BuildAndThrowAsValidationError(null);
    }

    /// <summary>
    /// Build, and throw as Validation error.<br />
    /// 构建，并抛出验证错误。
    /// </summary>
    public new void BuildAndThrowAsValidationError(Dictionary<string, IArgDescriptionVal> exceptionParams)
    {
        CreateAndCacheExceptionInstance(exceptionParams);
        switch (CachedException)
        {
            case ArgumentNullException exception01:
                exception01.ThrowAsValidationError();
                break;

            case ArgumentOutOfRangeException exception02:
                exception02.ThrowAsValidationError();
                break;

            case ArgumentInvalidException exception03:
                exception03.ThrowAsValidationError();
                break;

            default:
                var invalidOps = new InvalidOperationException("Unhandled exception type here.");
                ExceptionHelper.PrepareForRethrow(invalidOps);
                break;
        }
    }
}

#endif