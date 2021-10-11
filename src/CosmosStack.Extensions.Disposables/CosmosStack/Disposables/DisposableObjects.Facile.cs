using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmosStack.Disposables
{
    /// <summary>
    /// Facile Disposable Objects <br />
    /// 更易使用的可释放对象
    /// </summary>
    public abstract class FacileDisposableObjects : DisposableBase
    {
        private readonly CollectionDisposableObjects _collectionDisposableObjects;
        private readonly Dictionary<string, AnonymousDisposableObject> _anonymousDisposableObjects;

        /// <summary>
        /// Create a new instance of <see cref="FacileDisposableObjects"/>.
        /// </summary>
        protected FacileDisposableObjects()
        {
            _collectionDisposableObjects = CollectionDisposableObjects.Create();
            _anonymousDisposableObjects = new Dictionary<string, AnonymousDisposableObject>();
        }

        /// <summary>
        /// Add disposable object <br />
        /// 添加可释放对象
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
        /// 添加一组可释放对象
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
        /// 添加可释放操作
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
        protected void AddDisposableAction(string name, Action action)
        {
            CheckDisposed();

            if (!ContainDisposableAction(name))
            {
                _anonymousDisposableObjects.Add(name, AnonymousDisposableObject.Create(action));
            }
        }

        /// <summary>
        /// Add disposable action <br />
        /// 添加可释放操作
        /// </summary>
        /// <param name="name"></param>
        /// <param name="disposableAction"></param>
        protected void AddDisposableAction(string name, DisposableAction disposableAction)
        {
            CheckDisposed();

            if (!ContainDisposableAction(name))
            {
                _anonymousDisposableObjects.Add(name, AnonymousDisposableObject.Create(disposableAction));
            }
        }

        /// <summary>
        /// Add disposable action <br />
        /// 添加可释放操作
        /// </summary>
        /// <param name="name"></param>
        /// <param name="anonymous"></param>
        protected void AddDisposableAction(string name, AnonymousDisposableObject anonymous)
        {
            CheckDisposed();

            if (!ContainDisposableAction(name))
            {
                _anonymousDisposableObjects.Add(name, anonymous);
            }
        }

        /// <summary>
        /// Contains disposable action <br />
        /// 检查是否存在指定名称的可释放操作
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected bool ContainDisposableAction(string name)
        {
            return _anonymousDisposableObjects.ContainsKey(name);
        }

        /// <summary>
        /// Remove disposable action <br />
        /// 移除指定名称的可释放操作
        /// </summary>
        /// <param name="name"></param>
        protected void RemoveDisposableAction(string name)
        {
            CheckDisposed();

            if (_anonymousDisposableObjects.ContainsKey(name))
            {
                _anonymousDisposableObjects.Remove(name);
            }
        }

        /// <summary>
        /// Clear all disposable actions <br />
        /// 清理所有可释放对象
        /// </summary>
        protected void ClearDisposableActions()
        {
            CheckDisposed();

            InternalClearDisposableActions();
        }

        private void InternalClearDisposableActions() => _anonymousDisposableObjects.Clear();

        /// <summary>
        /// On Dispose
        /// </summary>
        protected override void OnDispose()
        {
            _collectionDisposableObjects.Dispose();

            foreach (var anonymous in _anonymousDisposableObjects.Values)
            {
                anonymous?.Dispose();
            }

            InternalClearDisposableActions();
        }

        private void CheckDisposed()
        {
            if (WasDisposed)
            {
                throw new InvalidOperationException("FacileDisposableObjects instance has been disposed.");
            }
        }

        /// <summary>
        /// Facile Disposable Objects
        /// </summary>
        ~FacileDisposableObjects()
        {
            Dispose();
        }
    }
}