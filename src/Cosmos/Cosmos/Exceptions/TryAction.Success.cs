﻿using System;
using System.Collections.Generic;

namespace Cosmos.Exceptions
{
    public class SuccessAction : TryAction
    {
        private readonly int _hashOfAction;

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="hashOfAction"></param>
        internal SuccessAction(int hashOfAction)
        {
            _hashOfAction = hashOfAction;
        }

        /// <inheritdoc />
        public override bool IsFailure => false;

        /// <inheritdoc />
        public override bool IsSuccess => true;

        /// <inheritdoc />
        public override Exception Exception => null;

        /// <inheritdoc />
        public override string ToString() => $"SuccessAction<Void>";

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(SuccessAction other) => other is not null && EqualityComparer<int>.Default.Equals(_hashOfAction, other._hashOfAction);

        /// <inheritdoc />
        public override bool Equals(object obj) => obj is SuccessAction success && Equals(success);

        /// <inheritdoc />
        public override int GetHashCode() => EqualityComparer<int>.Default.GetHashCode(_hashOfAction);

        public override void Deconstruct(out bool tryResult, out Exception exception)
        {
            tryResult = IsSuccess;
            exception = default;
        }

        /// <inheritdoc />
        public override TryAction Recover(Action<Exception> recoverFunction) => this;

        /// <inheritdoc />
        public override TryAction RecoverWith(Func<Exception, TryAction> recoverFunction) => this;

        /// <inheritdoc />
        public override TryAction Tap(Action successFunction = null, Action<Exception> failureFunction = null)
        {
            successFunction?.Invoke();
            return this;
        }
    }
}