namespace Cosmos {
    /// <summary>
    /// Some
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Some<T> : Optional<T> {
        /// <summary>
        /// Some
        /// </summary>
        /// <param name="value"></param>
        public Some(T value) : base(true) => Value = value;

        /// <inheritdoc />
        public override T Value { get; }
    }
}