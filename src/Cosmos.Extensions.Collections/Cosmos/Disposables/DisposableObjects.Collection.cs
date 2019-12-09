using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

/*
 * Reference to:
 *    Nito.Disposables
 *      Author: Stephen Cleary
 *      URL: https://github.com/StephenCleary/Disposables
 *      MIT
 */

namespace Cosmos.Disposables {
    /// <summary>
    /// Collection disposable objects
    /// </summary>
    public sealed class CollectionDisposableObjects : SingleDisposableObject<ImmutableQueue<IDisposable>> {
        /// <summary>
        /// Count
        /// </summary>
        private int _count = 0;

        /// <summary>
        /// Create a new instance of <see cref="CollectionDisposableObjects"/>.
        /// </summary>
        /// <param name="disposables"></param>
        public CollectionDisposableObjects(params IDisposable[] disposables) : this((IEnumerable<IDisposable>) disposables) { }

        /// <summary>
        /// Create a new instance of <see cref="CollectionDisposableObjects"/>.
        /// </summary>
        /// <param name="disposables"></param>
        public CollectionDisposableObjects(IEnumerable<IDisposable> disposables) : base(ImmutableQueue.CreateRange(disposables)) {
            Volatile.Write(ref _count, disposables?.Count() ?? 0);
        }

        /// <summary>
        /// Count
        /// </summary>
        public int Count => Volatile.Read(ref _count);

        /// <inheritdoc />
        protected override void Dispose(ImmutableQueue<IDisposable> context) {
            foreach (var disposable in context)
                disposable.Dispose();
            Volatile.Write(ref _count, 0);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="disposable"></param>
        public void Add(IDisposable disposable) {
            if (disposable == null)
                return;
            if (!TryUpdateContext(x => x.Enqueue(disposable)))
                disposable.Dispose();
            Volatile.Write(ref _count, _count + 1);
        }

        /// <summary>
        /// Create a disposable that disposes a collection of disposables.
        /// </summary>
        /// <param name="disposables">The disposables to dispose</param>
        /// <returns></returns>
        public static CollectionDisposableObjects Create(params IDisposable[] disposables) => new CollectionDisposableObjects(disposables);

        /// <summary>
        /// Create a disposable that disposes a collection of disposables.
        /// </summary>
        /// <param name="disposables">The disposables to dispose</param>
        /// <returns></returns>
        public static CollectionDisposableObjects Create(IEnumerable<IDisposable> disposables) => new CollectionDisposableObjects(disposables);
    }
}