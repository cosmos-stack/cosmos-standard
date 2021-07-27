using System;
using System.Runtime.CompilerServices;

namespace Cosmos.Optionals
{
    /// <summary>
    /// Optional utilities
    /// </summary>
    public static partial class Optional
    {
        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Maybe<T> Some<T>(T value)
            => new(value, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Maybe<T> Some<T>(T? value) where T : struct
            => value.HasValue ? Some(value.Value) : None<T>();

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Either<T, TException> Some<T, TException>(T value)
            => new(value, default, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value"></param>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Either<T, TException> Some<T, TException>(T? value, TException exception) where T : struct
            => value.HasValue ? Some<T, TException>(value.Value) : None<T, TException>(exception);

        /// <summary>
        /// None
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Maybe<T> None<T>()
            => new(default, false);

        /// <summary>
        /// None
        /// </summary>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Either<T, TException> None<T, TException>(TException exception)
            => new(default, exception, false);

        /// <summary>
        /// Create an instance of <see cref="IOptional{T}"/> from the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Maybe<T> From<T>(T value)
        {
            return value is null
                ? None<T>()
                : Some(value);
        }

        /// <summary>
        /// Create an instance of <see cref="IOptional{T}"/> from the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Maybe<T> From<T>(T value, Func<T, bool> condition)
        {
            if (condition is null)
                throw new ArgumentNullException(nameof(condition));
            if (value is null)
                return None<T>();
            return condition(value) ? Some(value) : None<T>();
        }

        /// <summary>
        /// Create an instance of <see cref="IOptional{T}"/> from the given value.
        /// </summary>
        /// <param name="nullable"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Maybe<T> From<T>(T? nullable) where T : struct => Some(nullable);
    }
}