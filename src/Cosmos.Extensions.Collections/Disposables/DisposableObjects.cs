using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Disposables
{
    public abstract class DisposableObjects : IDisposable
    {
        private readonly CollectionDisposableObjects _collectionDisposableObjects;
        private readonly List<string> _disposableActionRegister;

        protected DisposableObjects()
        {
            _collectionDisposableObjects = CollectionDisposableObjects.Create();
            _disposableActionRegister = new List<string>();
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
            if (_disposableActionRegister.Contains(name))
                return;

            if (action != null)
            {
                var disposable = AnonymousDisposableObject.Create(action);
                _collectionDisposableObjects.Add(disposable);
                _disposableActionRegister.Add(name);
            }
        }

        protected void AddDisposableAction(string name, DisposableAction action)
        {
            if (_disposableActionRegister.Contains(name))
                return;

            if (action != null)
            {
                var disposable = AnonymousDisposableObject.Create(action);
                _collectionDisposableObjects.Add(disposable);
                _disposableActionRegister.Add(name);
            }
        }

        protected void AddDisposableAction(string name, AnonymousDisposableObject anonymous)
        {
            if (_disposableActionRegister.Contains(name))
                return;

            if (anonymous != null)
            {
                _collectionDisposableObjects.Add(anonymous);
                _disposableActionRegister.Add(name);
            }
        }

        public void Dispose()
        {
            _collectionDisposableObjects.Dispose();
        }
    }
}
