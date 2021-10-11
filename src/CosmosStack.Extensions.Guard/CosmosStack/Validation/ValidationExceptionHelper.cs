using System;
using System.Linq;
using System.Reflection;
using AspectCore.Extensions.Reflection;
using CosmosStack.Reflection;
using CosmosStack.Exceptions;

namespace CosmosStack.Validation
{
    internal static class ValidationExceptionHelper
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

            var exception = CreateException(typeof(TException), exceptionParams);

            var wrappedException = exception switch
            {
                ArgumentNullException exception01 => ValidationErrors.Null(exception01),
                ArgumentOutOfRangeException exception02 => ValidationErrors.OutOfRange(exception02),
                ArgumentInvalidException exception03 => ValidationErrors.Invalid(exception03),
                _ => exception
            } as Exception;

            ExceptionHelper.PrepareForRethrow(wrappedException);
        }
        
        private static object CreateException(Type type, params object[] args)
        {
            return args is null || args.Length == 0
                ? type.GetConstructors().FirstOrDefault(WithoutParamPredicate)?.GetReflector().Invoke()
                : type.GetConstructor(Types.Of(args))?.GetReflector().Invoke(args);

            bool WithoutParamPredicate(MethodBase ci) => !ci.GetParameters().Any();
        }
    }
}