using System;
using Cosmos.Exceptions;

namespace Cosmos.Validation.Internals
{
    //todo 临时性 public，最终将使用 internal
    public static class ValidationExceptionHelper
    {
        /// <summary>
        /// Require.
        /// </summary>
        /// <param name="assertion"></param>
        /// <param name="exceptionParams"></param>
        /// <typeparam name="TException"></typeparam>
        public static void WrapAndRaise<TException>(bool assertion, params object[] exceptionParams) where TException : Exception
        {
            if (assertion)
                return;

            var exception = Reflection.Types.CreateInstance<TException>(exceptionParams);

            var wrappedException = exception switch
            {
                ArgumentNullException exception01 => (Exception) ValidationErrors.Null(exception01),
                ArgumentOutOfRangeException exception02 => ValidationErrors.OutOfRange(exception02),
                ArgumentInvalidException exception03 => ValidationErrors.Invalid(exception03),
                _ => exception
            };

            ExceptionHelper.PrepareForRethrow(wrappedException);
        }
    }
}