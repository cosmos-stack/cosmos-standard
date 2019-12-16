using System;

namespace Cosmos {
    /// <summary>
    /// None
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class None<T> : Optional<T> {
        /// <summary>
        /// None
        /// </summary>
        public None() : base(false) { }

        /// <inheritdoc />
        public override T Value => throw new InvalidOperationException();
    }
}