﻿using System;

/*
 * Reference to:
 *    Nito.Disposables
 *      Author: Stephen Cleary
 *      URL: https://github.com/StephenCleary/Disposables
 *      MIT
 */

namespace CosmosStack.Disposables
{
    /// <summary>
    /// A disposable implement which does nothing when disposed. <br />
    /// 不做任何事情的可释放对象
    /// </summary>
    public sealed class NoopDisposableObject : IDisposable
    {
        /// <summary>
        /// Gets a <see cref="NoopDisposableObject"/> cache.
        /// </summary>
        public static NoopDisposableObject Instance { get; } = new();

        private NoopDisposableObject() { }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose() { }
    }
}