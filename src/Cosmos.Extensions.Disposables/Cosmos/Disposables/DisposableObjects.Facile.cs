using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Disposables {
    /// <summary>
    /// Facile Disposable Objects
    /// </summary>
    public abstract class FacileDisposableObjects : IDisposable {
        private bool _disposed;
        private readonly CollectionDisposableObjects _collectionDisposableObjects;
        private readonly Dictionary<string, AnonymousDisposableObject> _anonymousDisposableObjects;

        /// <summary>
        /// Create a new instance of <see cref="FacileDisposableObjects"/>.
        /// </summary>
        protected FacileDisposableObjects() {
            _collectionDisposableObjects = CollectionDisposableObjects.Create();
            _anonymousDisposableObjects = new Dictionary<string, AnonymousDisposableObject>();
        }

        /// <summary>
        /// Add disposable object
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="TDisposableObj"></typeparam>
        protected void AddDisposableObject<TDisposableObj>(TDisposableObj obj) where TDisposableObj : class, IDisposable {
            if (obj != null) {
                _collectionDisposableObjects.Add(obj);
            }
        }

        /// <summary>
        /// Add a set of disposable objects
        /// </summary>
        /// <param name="objs"></param>
        protected void AddDisposableObjects(params object[] objs) {
            foreach (var obj in objs.Select(x => x as IDisposable).Where(o => o != null)) {
                _collectionDisposableObjects.Add(obj);
            }
        }

        /// <summary>
        /// Add disposable action
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
        protected void AddDisposableAction(string name, Action action) {
            CheckDisposed();

            if (!ContainDisposableAction(name)) {
                _anonymousDisposableObjects.Add(name, AnonymousDisposableObject.Create(action));
            }
        }

        /// <summary>
        /// Add disposable action
        /// </summary>
        /// <param name="name"></param>
        /// <param name="disposableAction"></param>
        protected void AddDisposableAction(string name, DisposableAction disposableAction) {
            CheckDisposed();

            if (!ContainDisposableAction(name)) {
                _anonymousDisposableObjects.Add(name, AnonymousDisposableObject.Create(disposableAction));
            }
        }

        /// <summary>
        /// Add disposable action
        /// </summary>
        /// <param name="name"></param>
        /// <param name="anonymous"></param>
        protected void AddDisposableAction(string name, AnonymousDisposableObject anonymous) {
            CheckDisposed();

            if (!ContainDisposableAction(name)) {
                _anonymousDisposableObjects.Add(name, anonymous);
            }
        }

        /// <summary>
        /// Contains disposable action
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected bool ContainDisposableAction(string name) {
            return _anonymousDisposableObjects.ContainsKey(name);
        }

        /// <summary>
        /// Remove disposable action
        /// </summary>
        /// <param name="name"></param>
        protected void RemoveDisposableAction(string name) {
            CheckDisposed();

            if (_anonymousDisposableObjects.ContainsKey(name)) {
                _anonymousDisposableObjects.Remove(name);
            }
        }

        /// <summary>
        /// Clear all disposable actions
        /// </summary>
        protected void ClearDisposableActions() {
            CheckDisposed();

            InternalClearDisposableActions();
        }

        private void InternalClearDisposableActions() => _anonymousDisposableObjects.Clear();

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing) {
            if (_disposed) {
                return;
            }

            if (disposing) {
                _collectionDisposableObjects.Dispose();

                foreach (var anonymous in _anonymousDisposableObjects.Values) {
                    anonymous?.Dispose();
                }

                InternalClearDisposableActions();
            }

            _disposed = true;
        }

        private void CheckDisposed() {
            if (_disposed) {
                throw new InvalidOperationException("FacileDisposableObjects instance has been disposed.");
            }
        }

        /// <summary>
        /// Facile Disposable Objects
        /// </summary>
        ~FacileDisposableObjects() {
            Dispose(false);
        }
    }
}