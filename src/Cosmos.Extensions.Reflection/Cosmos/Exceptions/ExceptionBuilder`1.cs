using System;
using Cosmos.Exceptions.BuildingDescriptors;
using Cosmos.Reflection;
using Cosmos.Validations;

namespace Cosmos.Exceptions
{
    /// <summary>
    /// Exception builder<br />
    /// 异常构建器。
    /// </summary>
    /// <typeparam name="TException"></typeparam>
    internal class ExceptionBuilder<TException> : IFluentExceptionBuilder<TException> where TException : Exception
    {
        private readonly Type _typeOfException;

        /// <summary>
        /// Create a new instance of <see cref="ExceptionBuilder{TException}"/>. <br />
        /// 创建一个新的 <see cref="ExceptionBuilder{TException}"/> 实例。
        /// </summary>
        public ExceptionBuilder()
        {
            _typeOfException = Reflection.Types.Of<TException>();
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
        public IFluentExceptionBuilder<TException> InnerException(Exception innerException)
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
        public IFluentExceptionBuilder<TException> ParamName(string paramName)
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
        public IFluentExceptionBuilder<TException> Message(string message)
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
        public IFluentExceptionBuilder<TException> ActualValue(object actualValue)
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
        public IFluentExceptionBuilder<TException> ErrorCode(int errorCode)
        {
            _errorCode = errorCode;
            return this;
        }

        private TException CachedException { get; set; }

        private void CreateAndCacheExceptionInstance()
        {
            if (CachedException is null)
            {
                var options = new ExceptionBuildingOptions(TargetType)
                   .AddArg(ExceptionArgConstants.INNER, _innerException, x => x != null)
                   .AddArg(ExceptionArgConstants.INNER_EXCEPTION, _innerException, x => x != null)
                   .AddArg(ExceptionArgConstants.MESSAGE, _message)
                   .AddArg(ExceptionArgConstants.PARAM_NAME, _paramName, x => !string.IsNullOrWhiteSpace(x))
                   .AddArg(ExceptionArgConstants.ACTUAL_VALUE, _actualValue)
                   .AddArg(ExceptionArgConstants.ERROR_CODE, _errorCode);
                CachedException = NTypes.CreateInstance<TException>(options.ExceptionType, options.ArgumentDescriptors);
            }
        }

        /// <summary>
        /// Build.<br />
        /// 构建。
        /// </summary>
        /// <returns></returns>
        public TException Build()
        {
            CreateAndCacheExceptionInstance();
            return CachedException;
        }

        /// <summary>
        /// Build, and throw exception.<br />
        /// 构建，并抛出异常。
        /// </summary>
        public void BuildAndThrow()
        {
            CreateAndCacheExceptionInstance();
            ExceptionHelper.PrepareForRethrow(CachedException);
        }

        /// <summary>
        /// Build, and throw as Validation error.<br />
        /// 构建，并抛出验证错误。
        /// </summary>
        public void BuildAndThrowAsValidationError()
        {
            CreateAndCacheExceptionInstance();
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