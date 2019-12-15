using System;

namespace Cosmos.Collections.Internals {
    internal class InternalReleasableDisposable<T> : IDisposable where T : class, IDisposable {
        public InternalReleasableDisposable(T disposable) {
            // Assign values.
            Disposable = disposable;
        }

        public T Disposable { get; private set; }

        public void Release() => Disposable = null;

        public void Dispose() {
            using (Disposable) { }
        }
    }
}