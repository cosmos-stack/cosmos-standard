using System;

namespace Cosmos.Optionals {
    /// <summary>
    /// Optional utilities
    /// </summary>
    public static class Optional {
        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Maybe<T> Some<T>(T value)
            => new Maybe<T>(value, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Maybe<T> Some<T>(T? value) where T : struct
            => value.HasValue ? Some(value.Value) : None<T>();

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static Either<T, TException> Some<T, TException>(T value)
            => new Either<T, TException>(value, default, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value"></param>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static Either<T, TException> Some<T, TException>(T? value, TException exception) where T : struct
            => value.HasValue ? Some<T, TException>(value.Value) : None<T, TException>(exception);

        /// <summary>
        /// None
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Maybe<T> None<T>()
            => new Maybe<T>(default, false);

        /// <summary>
        /// None
        /// </summary>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static Either<T, TException> None<T, TException>(TException exception)
            => new Either<T, TException>(default, exception, false);

        /// <summary>
        /// Create an instance of <see cref="IOptional{T}"/> from the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Maybe<T> From<T>(T value) {
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
        public static Maybe<T> From<T>(T value, Func<T, bool> condition) {
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
        public static Maybe<T> From<T>(T? nullable) where T : struct => Some(nullable);

        /// <summary>
        /// Wrapped optional
        /// </summary>
        public static class Wrapped {
            /// <summary>
            /// For some value
            /// </summary>
            /// <param name="some"></param>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            // ReSharper disable once MemberHidesStaticFromOuterClass
            public static Some<T> Some<T>(T some) => new Some<T>(some);

            /// <summary>
            /// For some value
            /// </summary>
            /// <param name="some"></param>
            /// <typeparam name="T"></typeparam>
            /// <typeparam name="TException"></typeparam>
            /// <returns></returns>
            // ReSharper disable once MemberHidesStaticFromOuterClass
            public static Some<T, TException> Some<T, TException>(T some) => new Some<T, TException>(some);

            /// <summary>
            /// For nothing
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            // ReSharper disable once MemberHidesStaticFromOuterClass
            public static None<T> None<T>() => new None<T>();

            /// <summary>
            /// For nothing
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <typeparam name="TException"></typeparam>
            /// <returns></returns>
            // ReSharper disable once MemberHidesStaticFromOuterClass
            public static None<T, TException> None<T, TException>(TException exception) => new None<T, TException>(exception);

            /// <summary>
            /// For nothing
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            public static Some<T> NoneSlim<T>() => new Some<T>(Optional.None<T>());

            /// <summary>
            /// For nothing
            /// </summary>
            /// <param name="exception"></param>
            /// <typeparam name="T"></typeparam>
            /// <typeparam name="TException"></typeparam>
            /// <returns></returns>
            public static Some<T, TException> NoneSlim<T, TException>(TException exception) => new Some<T, TException>(Optional.None<T, TException>(exception));

            /// <summary>
            /// Create an instance of <see cref="IOptional{T}"/> from the given value.
            /// </summary>
            /// <param name="value"></param>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            // ReSharper disable once MemberHidesStaticFromOuterClass
            public static IOptional<T> From<T>(T value) {
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
            public static IOptional<T> From<T>(T value, Func<T, bool> condition) {
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
            public static IOptional<T> From<T>(T? nullable) where T : struct {
                return nullable.HasValue
                    ? Some(nullable.Value)
                    : None<T>() as IOptional<T>;
            }
        }

        #region From

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2> From<T1, T2>(T1 value1, T2 value2)
            => new Maybe<T1, T2>(value1, value2, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3> From<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
            => new Maybe<T1, T2, T3>(value1, value2, value3, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4> From<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4)
            => new Maybe<T1, T2, T3, T4>(value1, value2, value3, value4, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <param name="value5"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4, T5> From<T1, T2, T3, T4, T5>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
            => new Maybe<T1, T2, T3, T4, T5>(value1, value2, value3, value4, value5, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <param name="value5"></param>
        /// <param name="value6"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4, T5, T6> From<T1, T2, T3, T4, T5, T6>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
            => new Maybe<T1, T2, T3, T4, T5, T6>(value1, value2, value3, value4, value5, value6, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <param name="value5"></param>
        /// <param name="value6"></param>
        /// <param name="value7"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4, T5, T6, T7> From<T1, T2, T3, T4, T5, T6, T7>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
            => new Maybe<T1, T2, T3, T4, T5, T6, T7>(value1, value2, value3, value4, value5, value6, value7, true);

        #endregion

        #region From tuple

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2> From<T1, T2>((T1, T2) value)
            => new Maybe<T1, T2>(value.Item1, value.Item2, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3> From<T1, T2, T3>((T1, T2, T3) value)
            => new Maybe<T1, T2, T3>(value.Item1, value.Item2, value.Item3, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4> From<T1, T2, T3, T4>((T1, T2, T3, T4) value)
            => new Maybe<T1, T2, T3, T4>(value.Item1, value.Item2, value.Item3, value.Item4, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4, T5> From<T1, T2, T3, T4, T5>((T1, T2, T3, T4, T5) value)
            => new Maybe<T1, T2, T3, T4, T5>(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4, T5, T6> From<T1, T2, T3, T4, T5, T6>((T1, T2, T3, T4, T5, T6) value)
            => new Maybe<T1, T2, T3, T4, T5, T6>(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4, T5, T6, T7> From<T1, T2, T3, T4, T5, T6, T7>((T1, T2, T3, T4, T5, T6, T7) value)
            => new Maybe<T1, T2, T3, T4, T5, T6, T7>(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7, true);

        #endregion

        #region Some

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2> Some<T1, T2>(T1 value1, T2 value2)
            => new Maybe<T1, T2>(value1, value2, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3> Some<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
            => new Maybe<T1, T2, T3>(value1, value2, value3, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4> Some<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4)
            => new Maybe<T1, T2, T3, T4>(value1, value2, value3, value4, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <param name="value5"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4, T5> Some<T1, T2, T3, T4, T5>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
            => new Maybe<T1, T2, T3, T4, T5>(value1, value2, value3, value4, value5, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <param name="value5"></param>
        /// <param name="value6"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4, T5, T6> Some<T1, T2, T3, T4, T5, T6>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
            => new Maybe<T1, T2, T3, T4, T5, T6>(value1, value2, value3, value4, value5, value6, true);

        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <param name="value5"></param>
        /// <param name="value6"></param>
        /// <param name="value7"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4, T5, T6, T7> Some<T1, T2, T3, T4, T5, T6, T7>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
            => new Maybe<T1, T2, T3, T4, T5, T6, T7>(value1, value2, value3, value4, value5, value6, value7, true);

        #endregion

        #region None

        /// <summary>
        /// None
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2> None<T1, T2>()
            => new Maybe<T1, T2>(default, default, false);

        /// <summary>
        /// None
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3> None<T1, T2, T3>()
            => new Maybe<T1, T2, T3>(default, default, default, false);

        /// <summary>
        /// None
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4> None<T1, T2, T3, T4>()
            => new Maybe<T1, T2, T3, T4>(default, default, default, default, false);

        /// <summary>
        /// None
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4, T5> None<T1, T2, T3, T4, T5>()
            => new Maybe<T1, T2, T3, T4, T5>(default, default, default, default, default, false);

        /// <summary>
        /// None
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4, T5, T6> None<T1, T2, T3, T4, T5, T6>()
            => new Maybe<T1, T2, T3, T4, T5, T6>(default, default, default, default, default, default, false);

        /// <summary>
        /// None
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <returns></returns>
        public static Maybe<T1, T2, T3, T4, T5, T6, T7> None<T1, T2, T3, T4, T5, T6, T7>()
            => new Maybe<T1, T2, T3, T4, T5, T6, T7>(default, default, default, default, default, default, default, false);

        #endregion

    }
}