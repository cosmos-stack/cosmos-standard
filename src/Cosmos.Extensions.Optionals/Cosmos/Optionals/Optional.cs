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
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static Either<T, TException> Some<T, TException>(T value)
            => new Either<T, TException>(value, default, true);

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
        }
    }
}