#if !NET451 && !NET452

using System;
using System.Collections.Generic;
using Cosmos.Exceptions;
using Cosmos.Reflection;

namespace Cosmos
{
    /// <summary>
    /// Boolean extensions for Exception Builder
    /// </summary>
    public static class BooleanExceptionUtilitiesExtensions
    {
        public static void IfTrueThenThrow<TException>(this bool @this) where TException : Exception
        {
            @this.IfTrue(() => ExceptionBuilder.Create<TException>().BuildAndThrow());
        }

        public static void IfTrueThenThrow<TException>(this bool @this, Dictionary<string, IArgDescriptionVal> exceptionParams) where TException : Exception
        {
            @this.IfTrue(() => ExceptionBuilder.Create<TException>().BuildAndThrow(exceptionParams));
        }

        public static void IfTrueThenThrow<T, TException>(this BooleanVal<T> @this) where TException : Exception
        {
            @this.IfTrue(_ => ExceptionBuilder.Create<TException>().BuildAndThrow());
        }

        public static void IfTrueThenThrow<T, TException>(this BooleanVal<T> @this, Dictionary<string, IArgDescriptionVal> exceptionParams) where TException : Exception
        {
            @this.IfTrue(_ => ExceptionBuilder.Create<TException>().BuildAndThrow(exceptionParams));
        }

        public static void IfFalseThenThrow<TException>(this bool @this) where TException : Exception
        {
            @this.IfFalse(() => ExceptionBuilder.Create<TException>().BuildAndThrow());
        }

        public static void IfFalseThenThrow<TException>(this bool @this, Dictionary<string, IArgDescriptionVal> exceptionParams) where TException : Exception
        {
            @this.IfFalse(() => ExceptionBuilder.Create<TException>().BuildAndThrow(exceptionParams));
        }

        public static void IfFalseThenThrow<T, TException>(this BooleanVal<T> @this) where TException : Exception
        {
            @this.IfFalse(_ => ExceptionBuilder.Create<TException>().BuildAndThrow());
        }

        public static void IfFalseThenThrow<T, TException>(this BooleanVal<T> @this, Dictionary<string, IArgDescriptionVal> exceptionParams) where TException : Exception
        {
            @this.IfFalse(_ => ExceptionBuilder.Create<TException>().BuildAndThrow(exceptionParams));
        }
    }
}

#endif