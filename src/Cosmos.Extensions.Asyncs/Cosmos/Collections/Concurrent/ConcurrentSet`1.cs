using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Cosmos.Collections.Concurrent
{
    /// <summary>
    /// Concurrent Set
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConcurrentSet<T> : IReadOnlyCollection<T>, ICollection<T>
    {
        private readonly ConcurrentDictionary<T, bool> _dictionary = new ConcurrentDictionary<T, bool>();

        /// <summary>
        /// Is empty
        /// </summary>
        public bool IsEmpty => _dictionary.IsEmpty;

        /// <inheritdoc />
        public int Count => _dictionary.Count;

        /// <inheritdoc />
        public bool IsReadOnly => false;

        /// <inheritdoc />
        public bool Contains(T t) => _dictionary.ContainsKey(t);

        /// <summary>
        /// Try add
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool TryAdd(T t) => _dictionary.TryAdd(t, false);

        /// <summary>
        /// Try remove
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool TryRemove(T t) => _dictionary.TryRemove(t, out _);

        /// <summary>
        /// Values
        /// </summary>
        /// <returns></returns>
        public ICollection<T> Values() => _dictionary.Keys;

        /// <inheritdoc />
        public void Clear() => _dictionary.Clear();

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            return _dictionary.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc />
        public void Add(T item)
        {
            TryAdd(item);
        }

        /// <inheritdoc />
        public void CopyTo(T[] array, int arrayIndex)
        {
            _dictionary.Keys.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc />
        public bool Remove(T item)
        {
            return TryRemove(item);
        }
    }
}