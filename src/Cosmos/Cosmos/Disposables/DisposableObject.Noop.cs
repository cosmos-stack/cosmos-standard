using System;

/*
 * Reference to:
 *    Nito.Disposables
 *      Author: Stephen Cleary
 *      URL: https://github.com/StephenCleary/Disposables
 *      MIT
 */

namespace Cosmos.Disposables
{
    /// <summary>
    /// A disposable implement which does nothing when disposed.
    /// </summary>
    public sealed class NoopDisposableObject : IDisposable
    {
        public static NoopDisposableObject Instance { get; } = new NoopDisposableObject();

        private NoopDisposableObject() { }

        public void Dispose() { }
    }
}
