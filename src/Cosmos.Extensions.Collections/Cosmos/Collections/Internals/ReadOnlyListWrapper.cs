using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Cosmos.Collections.Internals {
    internal sealed class ReadOnlyListWrapper<T> : IList<T> {
        private readonly IReadOnlyList<T> _list;

        internal ReadOnlyListWrapper(IReadOnlyList<T> list) {
            _list = list ?? throw new ArgumentNullException(nameof(list));
        }

        private object ThrowNotSupportedException([CallerMemberName] string member = "") {
            if (member == null)
                throw new ArgumentNullException(nameof(member));
            throw new NotSupportedException($"{GetType().FullName} does not support the {member} member.");
        }

        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(T item) => ThrowNotSupportedException();

        public void Clear() => ThrowNotSupportedException();

        public bool Contains(T item) => _list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => Buffer.BlockCopy(this.ToArray(), 0, array, arrayIndex, Count);

        public bool Remove(T item) => (bool) ThrowNotSupportedException();

        public int Count => _list.Count;

        public bool IsReadOnly => true;

        public int IndexOf(T item) {
            IEqualityComparer<T> comparer = EqualityComparer<T>.Default;
            return _list.Select((t, i) => new {Item = t, Index = i}).FirstOrDefault(p => comparer.Equals(p.Item, item))?.Index ?? -1;
        }

        public void Insert(int index, T item) => ThrowNotSupportedException();

        public void RemoveAt(int index) => ThrowNotSupportedException();

        public T this[int index] {
            get => _list[index];
            set => ThrowNotSupportedException();
        }
    }
}