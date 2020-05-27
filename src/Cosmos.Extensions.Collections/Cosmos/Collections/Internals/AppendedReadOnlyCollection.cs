using System;
using System.Collections;
using System.Collections.Generic;

namespace Cosmos.Collections.Internals
{
    internal class AppendedReadOnlyCollection<T> : IReadOnlyCollection<T>
    {
        private readonly IEnumerable<T> _enumerable;

        internal AppendedReadOnlyCollection(IReadOnlyCollection<T> root, T item)
        {
            // Validate parameters.

            // Assign values.
            _enumerable = root?.Append(item) ?? throw new ArgumentNullException(nameof(root));
            Count = root.Count + 1;
        }

        public IEnumerator<T> GetEnumerator() => _enumerable.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count { get; }
    }
}