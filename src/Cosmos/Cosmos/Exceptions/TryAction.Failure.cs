using System;

namespace Cosmos.Exceptions
{
    public class FailureAction : TryAction
    {
        private readonly int _hashOfAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="Failure{T}"/> class.
        /// </summary>
        /// <param name="exception">The exception to wrap.</param>
        /// <param name="hashOfAction"></param>
        internal FailureAction(Exception exception, int hashOfAction)
        {
            Exception = exception ?? new ArgumentNullException(nameof(exception));
            _hashOfAction = hashOfAction;
        }

        /// <inheritdoc />
        public override bool IsFailure => true;

        /// <inheritdoc />
        public override bool IsSuccess => false;

        /// <inheritdoc />
        public override Exception Exception { get; }

        /// <inheritdoc />
        public override string ToString() => $"FailureAction<{Exception}>";

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(FailureAction other) => other is not null && ReferenceEquals(Exception, other.Exception);

        /// <inheritdoc/>
        public override bool Equals(object obj) => obj is FailureAction failure && Equals(failure);

        /// <inheritdoc/>
        public override int GetHashCode() => Exception.GetHashCode();

        public override void Deconstruct(out bool tryResult, out Exception exception)
        {
            tryResult = IsSuccess;
            exception = Exception;
        }

        /// <inheritdoc />
        public override TryAction Recover(Action<Exception> recoverFunction)
        {
            return RecoverWith(ex => Try.Invoke(() => recoverFunction(ex)));
        }

        /// <inheritdoc />
        public override TryAction RecoverWith(Func<Exception, TryAction> recoverFunction)
        {
            try
            {
                return recoverFunction(Exception);
            }
            catch (Exception ex)
            {
                return new FailureAction(ex, recoverFunction?.GetHashCode() ?? 0);
            }
        }

        /// <inheritdoc />
        public override TryAction Tap(Action successFunction = null, Action<Exception> failureFunction = null)
        {
            failureFunction?.Invoke(Exception);
            return this;
        }
    }
}