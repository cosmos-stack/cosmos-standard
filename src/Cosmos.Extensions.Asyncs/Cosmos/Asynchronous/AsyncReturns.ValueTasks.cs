using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

// ReSharper disable MemberHidesStaticFromOuterClass

namespace Cosmos.Asynchronous
{
    /// <summary>
    /// Async returns
    /// </summary>
    public static partial class AsyncReturns
    {
        /// <summary>
        /// Returns for value task
        /// </summary>
        public static class ForValueTask
        {
            /// <summary>
            /// Returns exception
            /// </summary>
            /// <param name="exception"></param>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static ValueTask<T> Exception<T>(Exception exception) => ValueTaskFactory.FromException<T>(exception);

            /// <summary>
            /// Returns default
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static ValueTask<T> Default<T>() => ValueTasks.Create(default(T));

            /// <summary>
            /// Returns value task
            /// </summary>
            /// <param name="result"></param>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static ValueTask<T> Value<T>(T result) => ValueTasks.Create(result);
        }
    }
}