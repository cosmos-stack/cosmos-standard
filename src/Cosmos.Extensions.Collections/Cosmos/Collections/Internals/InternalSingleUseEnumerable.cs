using System;
using System.Collections;
using System.Collections.Generic;

namespace Cosmos.Collections.Internals
{
    internal class InternalSingleUseEnumerable<T> : IEnumerable<T>
    {
        public InternalSingleUseEnumerable(IEnumerator<T> enumerator)
        {
            // Validate parameters.
            _enumerator = enumerator ?? throw new ArgumentNullException(nameof(enumerator));
        }

        private readonly object _enumeratorLock = new object();

        private IEnumerator<T> _enumerator;

        public IEnumerator<T> GetEnumerator()
        {
            // Lock on the enumerator lock.
            lock (_enumeratorLock)
            {
                // If the enumerator is null, throw.
                if (_enumerator is null)
                    throw new InvalidOperationException($"{nameof(GetEnumerator)} may only be called once on this instance of {nameof(InternalSingleUseEnumerable<T>)}.");

                // Copy the enumerator.
                var enumeratorCopy = _enumerator;

                // Set to null.
                _enumerator = null;

                // Return.
                return enumeratorCopy;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}