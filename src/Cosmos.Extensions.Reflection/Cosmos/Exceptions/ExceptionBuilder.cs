#if !NET451

using System;

namespace Cosmos.Exceptions
{
    /// <summary>
    /// Exception builder
    /// </summary>
    public static class ExceptionBuilder
    {
        /// <summary>
        /// Create a new builder for of <typeparamref name="TException"/> <see cref="ExceptionBuilder{TException}"/>.<br />
        /// If you want to use this feature, please add following xml-node in your csproj file:<br />
        /// &lt;PreserveCompilationContext&gt;true&lt;/PreserveCompilationContext&gt;<br />
        /// This feature is supported by LanX, the author of NCC Natasha.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static IFluentExceptionBuilder<TException> Create<TException>() where TException : Exception
        {
            return new ExceptionBuilder<TException>();
        }
    }
}

#endif