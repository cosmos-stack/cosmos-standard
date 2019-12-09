using System;
using System.Collections;
using System.Collections.Generic;

namespace Cosmos.Collections {
    /// <summary>
    /// Enumerable proxy
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnumerableProxy<T> : IEnumerable<T> {
        private readonly IEnumerable<T> _enumerable;

        /// <inheritdoc />
        public EnumerableProxy(IEnumerable<T> enumerable) {
            // Validate parameters.
            _enumerable = enumerable ?? throw new ArgumentNullException(nameof(enumerable));
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator() => _enumerable.GetEnumerator();
    }
}