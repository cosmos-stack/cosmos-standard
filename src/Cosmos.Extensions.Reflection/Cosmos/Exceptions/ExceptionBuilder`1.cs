#if !NET451 && !NET461

using System;
using Cosmos.Exceptions.BuildingDescriptors;

namespace Cosmos.Exceptions {
    /// <summary>
    /// Exception builder
    /// </summary>
    /// <typeparam name="TException"></typeparam>
    internal class ExceptionBuilder<TException> : IFluentExceptionBuilder<TException> where TException : Exception {
        private readonly Type _typeOfException;

        public ExceptionBuilder() {
            _typeOfException = Types.Of<TException>();
        }

        public Type TargetType => _typeOfException;

        private Exception _innerException;

        public IFluentExceptionBuilder<TException> InnerException(Exception innerException) {
            if (innerException is null)
                return this;

            _innerException = innerException;
            return this;
        }

        private string _paramName;

        public IFluentExceptionBuilder<TException> ParamName(string paramName) {
            if (string.IsNullOrWhiteSpace(paramName))
                return this;

            _paramName = paramName;
            return this;
        }

        private string _message;

        public IFluentExceptionBuilder<TException> Message(string message) {
            if (string.IsNullOrWhiteSpace(message))
                return this;

            _message = message;
            return this;
        }

        private object _actualValue;

        public IFluentExceptionBuilder<TException> ActualValue(object actualValue) {
            _actualValue = actualValue;
            return this;
        }

        private int _errorCode;

        public IFluentExceptionBuilder<TException> ErrorCode(int errorCode) {
            _errorCode = errorCode;
            return this;
        }

        private TException CachedException { get; set; }

        private void CreateAndCacheExceptionInstance() {
            if (CachedException is null) {
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

        public TException Build() {
            CreateAndCacheExceptionInstance();
            return CachedException;
        }

        public void BuildAndThrow() {
            CreateAndCacheExceptionInstance();
            ExceptionHelper.PrepareForRethrow(CachedException);
        }
    }
}

#endif