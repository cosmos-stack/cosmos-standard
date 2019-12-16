namespace Cosmos {
    /// <summary>
    /// Option
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Optional<T> {
        /// <summary>
        /// Option
        /// </summary>
        /// <param name="hasValue"></param>
        protected Optional(bool hasValue) => HasValue = hasValue;

        /// <summary>
        /// Has value
        /// </summary>
        public bool HasValue { get; }

        /// <summary>
        /// Value
        /// </summary>
        public abstract T Value { get; }

        /// <summary>
        /// Create a <see cref="Some"/> wrapper.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Some<T> Some(T value) => new Some<T>(value);

        /// <summary>
        /// Create a <see cref="None"/> wrapper.
        /// </summary>
        /// <returns></returns>
        public static None<T> None() => new None<T>();

        /// <summary>
        /// Create a <see cref="SafeNone"/> wrapper.
        /// </summary>
        /// <returns></returns>
        public static SafeNone<T> SafeNone() => new SafeNone<T>();
    }
}