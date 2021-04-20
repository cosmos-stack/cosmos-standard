using System;

namespace Cosmos.Exceptions
{
    public sealed class TryInvokingException : CosmosException
    {
        private const string DEFAULT_ERROR_MSG = "An unknown exception occurred while trying to call the delegate.";
        private const string FLAG = "__TRY_INVOK_FLG";
        private const long ERROR_CODE = 1051;

        public TryInvokingException(Exception exception, string cause)
            : base(ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, FLAG, exception)
        {
            Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
        }

        public TryInvokingException(Exception exception, string cause, string flag)
            : base(ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, flag, exception)
        {
            Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
        }

        public TryInvokingException(Exception exception, string cause, long errorCode)
            : base(errorCode, exception?.Message ?? DEFAULT_ERROR_MSG, FLAG, exception)
        {
            Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
        }

        public TryInvokingException(Exception exception, string cause, string flag, long errorCode)
            : base(errorCode, exception?.Message ?? DEFAULT_ERROR_MSG, flag, exception)
        {
            Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
        }

        public TryInvokingException(CosmosException exception, string cause)
            : base(exception?.Code ?? ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, exception?.Flag ?? FLAG, exception)
        {
            Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
        }

        public string Cause { get; }
    }
}