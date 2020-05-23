using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Disposables
{
    /// <summary>
    /// Disposable objects
    /// </summary>
    public abstract class DisposableObjects : IDisposable
    {
        private readonly CollectionDisposableObjects _collectionDisposableObjects;
        private readonly List<string> _disposableActionRegister;

        /// <summary>
        /// Create a new instance of <see cref="DisposableObjects"/>.
        /// </summary>
        protected DisposableObjects()
        {
            _collectionDisposableObjects = CollectionDisposableObjects.Create();
            _disposableActionRegister = new List<string>();
        }

        /// <summary>
        /// Add disposable object
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="TDisposableObj"></typeparam>
        protected void AddDisposableObject<TDisposableObj>(TDisposableObj obj) where TDisposableObj : class, IDisposable
        {
            if (obj != null)
            {
                _collectionDisposableObjects.Add(obj);
            }
        }

        /// <summary>
        /// Add a set of disposable objects
        /// </summary>
        /// <param name="objs"></param>
        protected void AddDisposableObjects(params object[] objs)
        {
            foreach (var obj in objs.Select(x => x as IDisposable).Where(o => o != null))
            {
                _collectionDisposableObjects.Add(obj);
            }
        }

        /// <summary>
        /// Add disposable action
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
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

        /// <summary>
        /// Add disposable action
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
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

        /// <summary>
        /// Add disposable action
        /// </summary>
        /// <param name="name"></param>
        /// <param name="anonymous"></param>
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

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            _collectionDisposableObjects.Dispose();
        }
    }
}