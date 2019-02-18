using System;
using System.Collections.Generic;
using System.Collections.Immutable;

/*
 * Reference to:
 *    Nito.Disposables
 *      Author: Stephen Cleary
 *      URL: https://github.com/StephenCleary/Disposables
 *      MIT
 */

namespace Cosmos.Disposables
{
    public sealed class CollectionDisposableObjects : SingleDisposableObject<ImmutableQueue<IDisposable>>
    {
        public CollectionDisposableObjects(params IDisposable[] disposables) : this((IEnumerable<IDisposable>)disposables) { }

        public CollectionDisposableObjects(IEnumerable<IDisposable> disposables) : base(ImmutableQueue.CreateRange(disposables)) { }

        protected override void Dispose(ImmutableQueue<IDisposable> context)
        {
            foreach (var disposable in context)
                disposable.Dispose();
        }

        public void Add(IDisposable disposable)
        {
            if (!TryUpdateContext(x => x.Enqueue(disposable)))
                disposable.Dispose();
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
