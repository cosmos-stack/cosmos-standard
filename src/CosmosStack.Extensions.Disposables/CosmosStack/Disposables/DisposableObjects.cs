using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosStack.Disposables
{
    /// <summary>
    /// Disposable objects <br />
    /// 抽象的可释放对象
    /// </summary>
    public abstract class DisposableObjects : DisposableBase
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
            if (obj is not null)
            {
                _collectionDisposableObjects.Add(obj);
            }
        }

        /// <summary>
        /// Add a set of disposable objects <br />
        /// 添加一个可是放对象
        /// </summary>
        /// <param name="objs"></param>
        protected void AddDisposableObjects(params object[] objs)
        {
            foreach (var obj in objs.Select(x => x as IDisposable).Where(o => o is not null))
            {
                _collectionDisposableObjects.Add(obj);
            }
        }

        /// <summary>
        /// Add disposable action <br />
        /// 添加一个可释放操作
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
        protected void AddDisposableAction(string name, Action action)
        {
            if (_disposableActionRegister.Contains(name))
                return;

            if (action is not null)
            {
                var disposable = AnonymousDisposableObject.Create(action);
                _collectionDisposableObjects.Add(disposable);
                _disposableActionRegister.Add(name);
            }
        }

        /// <summary>
        /// Add disposable action <br />
        /// 添加一个可释放操作
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
        protected void AddDisposableAction(string name, DisposableAction action)
        {
            if (_disposableActionRegister.Contains(name))
                return;

            if (action is not null)
            {
                var disposable = AnonymousDisposableObject.Create(action);
                _collectionDisposableObjects.Add(disposable);
                _disposableActionRegister.Add(name);
            }
        }

        /// <summary>
        /// Add disposable action <br />
        /// 添加一个可释放操作
        /// </summary>
        /// <param name="name"></param>
        /// <param name="anonymous"></param>
        protected void AddDisposableAction(string name, AnonymousDisposableObject anonymous)
        {
            if (_disposableActionRegister.Contains(name))
                return;

            if (anonymous is not null)
            {
                _collectionDisposableObjects.Add(anonymous);
                _disposableActionRegister.Add(name);
            }
        }

        /// <summary>
        /// On Dispose
        /// </summary>
        protected override void OnDispose() => _collectionDisposableObjects.Dispose();
    }
}