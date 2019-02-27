using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Disposables
{
    public abstract class FacileDisposableObjects : IDisposable
    {
        private bool _disposed;
        private readonly CollectionDisposableObjects _collectionDisposableObjects;
        private readonly Dictionary<string, AnonymousDisposableObject> _anonymousDisposableObjects;

        protected FacileDisposableObjects()
        {
            _collectionDisposableObjects = CollectionDisposableObjects.Create();
            _anonymousDisposableObjects = new Dictionary<string, AnonymousDisposableObject>();
        }

        protected void AddDisposableObject<TDisposableObj>(TDisposableObj obj) where TDisposableObj : class, IDisposable
        {
            if (obj != null)
            {
                _collectionDisposableObjects.Add(obj);
            }
        }

        protected void AddDisposableObjects(params object[] objs)
        {
            foreach (var obj in objs.Select(x => x as IDisposable).Where(o => o != null))
            {
                _collectionDisposableObjects.Add(obj);
            }
        }

        protected void AddDisposableAction(string name, Action action)
        {
            CheckDisposed();

            if (!ContainDisposableAction(name))
            {
                _anonymousDisposableObjects.Add(name, AnonymousDisposableObject.Create(action));
            }
        }

        protected void AddDisposableAction(string name, DisposableAction disposableAction)
        {
            CheckDisposed();

            if (!ContainDisposableAction(name))
            {
                _anonymousDisposableObjects.Add(name, AnonymousDisposableObject.Create(disposableAction));
            }
        }

        protected void AddDisposableAction(string name, AnonymousDisposableObject anonymous)
        {
            CheckDisposed();

            if (!ContainDisposableAction(name))
            {
                _anonymousDisposableObjects.Add(name, anonymous);
            }
        }

        protected bool ContainDisposableAction(string name)
        {
            return _anonymousDisposableObjects.ContainsKey(name);
        }


        protected void RemoveDisposableAction(string name)
        {
            CheckDisposed();

            if (_anonymousDisposableObjects.ContainsKey(name))
            {
                _anonymousDisposableObjects.Remove(name);
            }
        }

        protected void ClearDisposableActions()
        {
            CheckDisposed();

            InternalClearDisposableActions();
        }

        private void InternalClearDisposableActions() => _anonymousDisposableObjects.Clear();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _collectionDisposableObjects.Dispose();

                foreach (var anonymous in _anonymousDisposableObjects.Values)
                {
                    anonymous?.Dispose();
                }

                InternalClearDisposableActions();
            }

            _disposed = true;
        }

        private void CheckDisposed()
        {
            if (_disposed)
            {
                throw new InvalidOperationException("FacileDisposableObjects instance has been disposed.");
            }
        }

        ~FacileDisposableObjects()
        {
            Dispose(false);
        }
    }
}
