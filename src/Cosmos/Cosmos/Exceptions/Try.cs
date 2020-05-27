using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Exceptions
{
    /// <summary>
    /// Try
    /// </summary>
    public static class Try
    {
        /// <summary>
        /// Create a new instance of <see cref="Try{T}"/>.
        /// </summary>
        /// <param name="createFunction"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> Create<T>(Func<T> createFunction)
        {
            try
            {
                return LiftValue(createFunction());
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Create for asynchronous functions.
        /// </summary>
        /// <param name="createFunctionAsync"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> CreateFromTask<T>(Func<Task<T>> createFunctionAsync)
        {
            try
            {
                return LiftValue(CallAsyncInSync(createFunctionAsync));
            }
            catch (Exception ex)
            {
                return LiftException<T>(ex);
            }
        }

        /// <summary>
        /// Lifts a value.
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> LiftValue<T>(T value) => new Success<T>(value);

        /// <summary>
        /// Lifts
        /// </summary>
        /// <param name="ex"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Try<T> LiftException<T>(Exception ex) => new Failure<T>(ex);

        private static TResult CallAsyncInSync<TResult>(Func<Task<TResult>> taskFunc, CancellationToken cancellationToken = default)
        {
            if (taskFunc is null)
                throw new ArgumentNullException(nameof(taskFunc));

            var task = Create(taskFunc).GetValue();

            if (task is null)
                throw new InvalidOperationException($"The task factory {nameof(taskFunc)} failed to run.");

            return ThenWaitAndUnwrapException(task, cancellationToken);
        }

        private static TResult ThenWaitAndUnwrapException<TResult>(Task<TResult> task, CancellationToken cancellationToken)
        {
            if (task is null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            try
            {
                task.Wait(cancellationToken);
                return task.Result;
            }
            catch (AggregateException ex)
            {
                throw ExceptionHelper.PrepareForRethrow(ex.InnerException);
            }
        }
    }
}