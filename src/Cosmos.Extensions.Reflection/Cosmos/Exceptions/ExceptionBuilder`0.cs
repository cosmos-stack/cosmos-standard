#if !NET451 && !NET452
using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Exceptions.BuildingDescriptors;
using Cosmos.Reflection;
using Cosmos.Validation;

namespace Cosmos.Exceptions
{
    /// <summary>
    /// Exception builder<br />
    /// 异常构建器。
    /// </summary>
    internal class CommonExceptionBuilder : ICommonExceptionBuilder
    {
        private readonly Type _typeOfException;

        /// <summary>
        /// Create a new instance of <see cref="ExceptionBuilder{TException}"/>. <br />
        /// 创建一个新的 <see cref="ExceptionBuilder{TException}"/> 实例。
        /// </summary>
        public CommonExceptionBuilder(Type typeOfException)
        {
            if (typeOfException is null)
                throw new ArgumentNullException(nameof(typeOfException));
            if (!typeOfException.IsSubclassOf(typeof(Exception)))
                throw new ArgumentException($"Type '{typeOfException}' does not be divided from {typeof(Exception)}", nameof(typeOfException));
            _typeOfException = typeOfException;
            _additionalOps = null;
        }

        /// <summary>
        /// Create a new instance of <see cref="ExceptionBuilder{TException}"/>. <br />
        /// 创建一个新的 <see cref="ExceptionBuilder{TException}"/> 实例。
        /// </summary>
        public CommonExceptionBuilder(Type typeOfException,
            Action<Dictionary<string, IArgDescriptionVal>, ExceptionBuildingOptions> additionalOps)
        {
            if (typeOfException is null)
                throw new ArgumentNullException(nameof(typeOfException));
            if (!typeOfException.IsSubclassOf(typeof(Exception)))
                throw new ArgumentException($"Type '{typeOfException}' does not be divided from {typeof(Exception)}", nameof(typeOfException));
            _typeOfException = typeOfException;
            _additionalOps = additionalOps;
        }

        /// <summary>
        /// Target type of exception.<br />
        /// 目标异常的类型
        /// </summary>
        // ReSharper disable once ConvertToAutoProperty
        public Type TargetType => _typeOfException;

        private Exception _innerException;

        /// <summary>
        /// Sets inner exception.<br />
        /// 设置内部异常。
        /// </summary>
        /// <param name="innerException"></param>
        /// <returns></returns>
        public ICommonExceptionBuilder InnerException(Exception innerException)
        {
            if (innerException is null)
                return this;

            _innerException = innerException;
            return this;
        }

        private string _paramName;

        /// <summary>
        /// Sets parameter's name.<br />
        /// 设置参数名称。
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public ICommonExceptionBuilder ParamName(string paramName)
        {
            if (string.IsNullOrWhiteSpace(paramName))
                return this;

            _paramName = paramName;
            return this;
        }

        private string _message;

        /// <summary>
        /// Sets exception message.<br />
        /// 设置异常消息。
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ICommonExceptionBuilder Message(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return this;

            _message = message;
            return this;
        }

        private object _actualValue;

        /// <summary>
        /// Sets actual value.<br />
        /// 设置实际的值。
        /// </summary>
        /// <param name="actualValue"></param>
        /// <returns></returns>
        public ICommonExceptionBuilder ActualValue(object actualValue)
        {
            _actualValue = actualValue;
            return this;
        }

        private int _errorCode;

        /// <summary>
        /// Sets error code.<br />
        /// 设置错误代码（Error Code）。
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public ICommonExceptionBuilder ErrorCode(int errorCode)
        {
            _errorCode = errorCode;
            return this;
        }

        private Exception CachedException { get; set; }

        private readonly Action<Dictionary<string, IArgDescriptionVal>, ExceptionBuildingOptions> _additionalOps;

        private void CreateAndCacheExceptionInstance(Dictionary<string, IArgDescriptionVal> exceptionParams)
        {
            if (CachedException is null)
            {
                var options = new ExceptionBuildingOptions(TargetType, exceptionParams)
                              .AddArg(ExceptionArgConstants.INNER, _innerException, x => x != null)
                              .AddArg(ExceptionArgConstants.INNER_EXCEPTION, _innerException, x => x != null)
                              .AddArg(ExceptionArgConstants.MESSAGE, _message, x => !string.IsNullOrWhiteSpace(x))
                              .AddArg(ExceptionArgConstants.PARAM_NAME, _paramName, x => !string.IsNullOrWhiteSpace(x))
                              .AddArg(ExceptionArgConstants.ACTUAL_VALUE, _actualValue, x => x is not null)
                              .AddArg(ExceptionArgConstants.ERROR_CODE, _errorCode, x => x > 0);

                if (exceptionParams is not null)
                    _additionalOps?.Invoke(exceptionParams, options);
#if !NETFRAMEWORK
                CachedException = TypeVisit.CreateInstance(options.ExceptionType, options.ArgumentDescriptors).As<Exception>();
#else
                CachedException = TypeVisit.CreateInstance(options.ExceptionType, options.ArgumentDescriptors.ToArray()).As<Exception>();
#endif
            }
        }

        /// <summary>
        /// Build.<br />
        /// 构建。
        /// </summary>
        /// <returns></returns>
        public Exception Build()
        {
            return Build(null);
        }

        /// <summary>
        /// Build.<br />
        /// 构建。
        /// </summary>
        /// <returns></returns>
        public Exception Build(Dictionary<string, IArgDescriptionVal> exceptionParams)
        {
            CreateAndCacheExceptionInstance(exceptionParams);
            return CachedException;
        }

        /// <summary>
        /// Build, and throw exception.<br />
        /// 构建，并抛出异常。
        /// </summary>
        public void BuildAndThrow()
        {
            BuildAndThrow(null);
        }

        /// <summary>
        /// Build, and throw exception.<br />
        /// 构建，并抛出异常。
        /// </summary>
        public void BuildAndThrow(Dictionary<string, IArgDescriptionVal> exceptionParams)
        {
            CreateAndCacheExceptionInstance(exceptionParams);
            ExceptionHelper.PrepareForRethrow(CachedException);
        }

        /// <summary>
        /// Build, and throw as Validation error.<br />
        /// 构建，并抛出验证错误。
        /// </summary>
        public void BuildAndThrowAsValidationError()
        {
            BuildAndThrowAsValidationError(null);
        }

        /// <summary>
        /// Build, and throw as Validation error.<br />
        /// 构建，并抛出验证错误。
        /// </summary>
        public void BuildAndThrowAsValidationError(Dictionary<string, IArgDescriptionVal> exceptionParams)
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
}

#endif