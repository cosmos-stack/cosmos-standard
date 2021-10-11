using System;
using System.Runtime.CompilerServices;

namespace CosmosStack.Optionals
{
    /// <summary>
    /// Optional utilities <br />
    /// MayBe 组件工具
    /// </summary>
    public static partial class Optional
    {
        /// <summary>
        /// Wrapped optional <br />
        /// 封装的 MayBe 选项
        /// </summary>
        public static class Wrapped
        {
            /// <summary>
            /// For some value
            /// </summary>
            /// <param name="some"></param>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            // ReSharper disable once MemberHidesStaticFromOuterClass
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Some<T> Some<T>(T some) => new(some);

            /// <summary>
            /// For some value
            /// </summary>
            /// <param name="some"></param>
            /// <typeparam name="T"></typeparam>
            /// <typeparam name="TException"></typeparam>
            /// <returns></returns>
            // ReSharper disable once MemberHidesStaticFromOuterClass
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Some<T, TException> Some<T, TException>(T some) => new(some);

            /// <summary>
            /// For nothing
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            // ReSharper disable once MemberHidesStaticFromOuterClass
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static None<T> None<T>() => new();

            /// <summary>
            /// For nothing
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <typeparam name="TException"></typeparam>
            /// <returns></returns>
            // ReSharper disable once MemberHidesStaticFromOuterClass
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static None<T, TException> None<T, TException>(TException exception) => new(exception);

            /// <summary>
            /// For nothing
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Some<T> NoneSlim<T>() => new(CosmosStack.Optionals.Optional.None<T>());

            /// <summary>
            /// For nothing
            /// </summary>
            /// <param name="exception"></param>
            /// <typeparam name="T"></typeparam>
            /// <typeparam name="TException"></typeparam>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Some<T, TException> NoneSlim<T, TException>(TException exception) => new(CosmosStack.Optionals.Optional.None<T, TException>(exception));

            /// <summary>
            /// Create an instance of <see cref="IOptional{T}"/> from the given value.
            /// </summary>
            /// <param name="value"></param>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            // ReSharper disable once MemberHidesStaticFromOuterClass
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static IOptional<T> From<T>(T value)
            {
                return value is null
                    ? None<T>()
                    : Some(value) as IOptional<T>;
            }

            /// <summary>
            /// Create an instance of <see cref="IOptional{T}"/> from the given value.
            /// </summary>
            /// <param name="value"></param>
            /// <param name="condition"></param>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            /// <exception cref="ArgumentNullException"></exception>
            // ReSharper disable once MemberHidesStaticFromOuterClass
            public static IOptional<T> From<T>(T value, Func<T, bool> condition)
            {
                if (condition is null)
                    throw new ArgumentNullException(nameof(condition));
                if (value is null)
                    return None<T>();
                return condition(value) ? Some(value) : None<T>() as IOptional<T>;
            }

            /// <summary>
            /// Create an instance of <see cref="IOptional{T}"/> from the given value.
            /// </summary>
            /// <param name="nullable"></param>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            // ReSharper disable once MemberHidesStaticFromOuterClass
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static IOptional<T> From<T>(T? nullable) where T : struct
            {
                return nullable.HasValue
                    ? Some(nullable.Value)
                    : None<T>() as IOptional<T>;
            }
        }
    }
}