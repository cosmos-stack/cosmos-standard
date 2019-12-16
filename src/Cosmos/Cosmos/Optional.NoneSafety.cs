namespace Cosmos {
    /// <summary>
    /// Safe None
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class SafeNone<T> : Optional<T> {
        /// <summary>
        /// Safe None
        /// </summary>
        public SafeNone() : base(false) { }

        /// <inheritdoc />
        public override T Value => default;
    }
}