using System;

namespace Cosmos.Exceptions
{
    public sealed class TryCreatingValueException : CosmosException
    {
        private const string DEFAULT_ERROR_MSG = "An unknown exception occurred while trying to create value.";
        private const string FLAG = "__TRY_CREATE_FLG";
        private const long ERROR_CODE = 1052;

        public TryCreatingValueException(Exception exception, string cause)
            : base(ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, FLAG, exception)
        {
            Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
        }

        public TryCreatingValueException(Exception exception, string cause, string flag)
            : base(ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, flag, exception)
        {
            Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
        }

        public TryCreatingValueException(Exception exception, string cause, long errorCode)
            : base(errorCode, exception?.Message ?? DEFAULT_ERROR_MSG, FLAG, exception)
        {
            Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
        }

        public TryCreatingValueException(Exception exception, string cause, string flag, long errorCode)
            : base(errorCode, exception?.Message ?? DEFAULT_ERROR_MSG, flag, exception)
        {
            Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
        }

        public TryCreatingValueException(CosmosException exception, string cause)
            : base(exception?.Code ?? ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, exception?.Flag ?? FLAG, exception)
        {
            Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
        }

        public string Cause { get; }
    }
}