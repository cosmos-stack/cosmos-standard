using System.Collections;
using System.Collections.Generic;
using Cosmos.Collections;

namespace CosmosStack.Collections.Internals
{
    internal class AppendedReadOnlyCollection<T> : IReadOnlyCollection<T>
    {
        private readonly IEnumerable<T> _enumerable;

        internal AppendedReadOnlyCollection(IReadOnlyCollection<T> root, T item)
        {
            _enumerable = ReadOnlyCollsHelper.Append(root, item);
            Count = root.Count + 1;
        }

        public IEnumerator<T> GetEnumerator() => _enumerable.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count { get; }
    }
}