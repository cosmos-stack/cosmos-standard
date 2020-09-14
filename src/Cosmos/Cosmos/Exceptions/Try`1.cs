using System;
using System.Threading.Tasks;

namespace Cosmos.Exceptions
{
    /// <summary>
    /// Try
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Try<T>
    {
        /// <summary>
        /// Is failure
        /// </summary>
        public abstract bool IsFailure { get; }

        /// <summary>
        /// Is success
        /// </summary>
        public abstract bool IsSuccess { get; }

        /// <summary>
        /// Exception
        /// </summary>
        public abstract Exception Exception { get; }

        /// <summary>
        /// Value
        /// </summary>
        public abstract T Value { get; }

        /// <summary>
        /// Gets value
        /// </summary>
        /// <returns></returns>
        public virtual T GetValue() => Value;

        /// <summary>
        /// Get value async
        /// </summary>
        /// <returns></returns>
        public virtual Task<T> GetValueAsync()
        {
            return IsSuccess
                ? Task.FromResult(Value)
                : FromException<T>(Exception);
        }

        /// <summary>
        /// Get safe value
        /// </summary>
        /// <returns></returns>
        public virtual T GetSafeValue()
        {
            return IsSuccess ? Value : default;
        }

        /// <summary>
        /// Get safe value
        /// </summary>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public virtual T GetSafeValue(T defaultVal)
        {
            return IsSuccess ? Value : defaultVal;
        }

        /// <summary>
        /// Get safe value
        /// </summary>
        /// <param name="defaultValFunc"></param>
        /// <returns></returns>
        public virtual T GetSafeValue(Func<T> defaultValFunc)
        {
            return IsSuccess
                ? Value
                : defaultValFunc is null
                    ? default
                    : defaultValFunc();
        }

        /// <summary>
        /// Get safe value
        /// </summary>
        /// <param name="defaultValFunc"></param>
        /// <returns></returns>
        public virtual T GetSafeValue(Func<Exception, T> defaultValFunc)
        {
            return IsSuccess
                ? Value
                : defaultValFunc is null
                    ? default
                    : defaultValFunc(Exception);
        }

        /// <summary>
        /// Get safe value async
        /// </summary>
        /// <returns></returns>
        public virtual Task<T> GetSafeValueAsync()
        {
            return Task.FromResult(GetSafeValue());
        }

        /// <summary>
        /// Get safe value async
        /// </summary>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public virtual Task<T> GetSafeValueAsync(T defaultVal)
        {
            return Task.FromResult(GetSafeValue(defaultVal));
        }

        /// <summary>
        /// Get safe value async
        /// </summary>
        /// <param name="defaultValFunc"></param>
        /// <returns></returns>
        public virtual Task<T> GetSafeValueAsync(Func<T> defaultValFunc)
        {
            return Task.FromResult(GetSafeValue(defaultValFunc));
        }

        /// <summary>
        /// Get safe value async
        /// </summary>
        /// <param name="defaultValFunc"></param>
        /// <returns></returns>
        public virtual Task<T> GetSafeValueAsync(Func<Exception, T> defaultValFunc)
        {
            return Task.FromResult(GetSafeValue(defaultValFunc));
        }

        /// <summary>
        /// Get safe value async
        /// </summary>
        /// <param name="defaultValAsyncFunc"></param>
        /// <returns></returns>
        public virtual Task<T> GetSafeValueAsync(Func<Task<T>> defaultValAsyncFunc)
        {
            return IsSuccess
                ? Task.FromResult(Value)
                : defaultValAsyncFunc is null
                    ? Task.FromResult(default(T))
                    : defaultValAsyncFunc();
        }

        /// <summary>
        /// Get safe value async
        /// </summary>
        /// <param name="defaultValAsyncFunc"></param>
        /// <returns></returns>
        public virtual Task<T> GetSafeValueAsync(Func<Exception, Task<T>> defaultValAsyncFunc)
        {
            return IsSuccess
                ? Task.FromResult(Value)
                : defaultValAsyncFunc is null
                    ? Task.FromResult(default(T))
                    : defaultValAsyncFunc(Exception);
        }

        /// <summary>
        /// Try get value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual bool TryGetValue(out T value)
        {
            value = GetSafeValue();
            return IsSuccess;
        }

        /// <summary>
        /// Try get value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public virtual bool TryGetValue(out T value, T defaultVal)
        {
            value = GetSafeValue(defaultVal);
            return true;
        }

        /// <summary>
        /// Try get value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValFunc"></param>
        /// <returns></returns>
        public virtual bool TryGetValue(out T value, Func<T> defaultValFunc)
        {
            try
            {
                value = GetSafeValue(defaultValFunc);
                return true;
            }
            catch
            {
                value = default;
                return false;
            }
        }

        /// <summary>
        /// Try get value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValFunc"></param>
        /// <returns></returns>
        public virtual bool TryGetValue(out T value, Func<Exception, T> defaultValFunc)
        {
            try
            {
                value = GetSafeValue(defaultValFunc);
                return true;
            }
            catch
            {
                value = default;
                return false;
            }
        }

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Try<T> left, Try<T> right)
        {
            if (left is null && right is null)
                return true;
            if (left is null || right is null)
                return false;
            return left.Equals(right);
        }

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Try<T> left, Try<T> right) => !(left == right);

        /// <inheritdoc/>
        public abstract override string ToString();

        /// <inheritdoc/>
        public abstract override bool Equals(object obj);

        /// <inheritdoc/>
        public abstract override int GetHashCode();

        /// <summary>
        /// Deconstruct
        /// </summary>
        /// <param name="value"></param>
        /// <param name="exception"></param>
        public abstract void Deconstruct(out T value, out Exception exception);

        /// <summary>
        /// Exception as
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public TException ExceptionAs<TException>() where TException : Exception => Exception as TException;

        /// <summary>
        /// Recover
        /// </summary>
        /// <param name="recoverFunction"></param>
        /// <returns></returns>
        public abstract Try<T> Recover(Func<Exception, T> recoverFunction);

        /// <summary>
        /// Recover with
        /// </summary>
        /// <param name="recoverFunction"></param>
        /// <returns></returns>
        public abstract Try<T> RecoverWith(Func<Exception, Try<T>> recoverFunction);

        /// <summary>
        /// Match
        /// </summary>
        /// <param name="whenValue"></param>
        /// <param name="whenException"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public abstract TResult Match<TResult>(Func<T, TResult> whenValue, Func<Exception, TResult> whenException);

        /// <summary>
        /// Map
        /// </summary>
        /// <param name="map"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public Try<TResult> Map<TResult>(Func<T, TResult> map)
        {
            if (map is null)
                throw new ArgumentNullException(nameof(map));
            return Bind(value => Try.Create(() => map(value)));
        }

        /// <summary>
        /// Tap
        /// </summary>
        /// <param name="successFunction"></param>
        /// <param name="failureFunction"></param>
        /// <returns></returns>
        public abstract Try<T> Tap(Action<T> successFunction = null, Action<Exception> failureFunction = null);

        /// <summary>
        /// Bind
        /// </summary>
        /// <param name="bind"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        internal abstract Try<TResult> Bind<TResult>(Func<T, Try<TResult>> bind);

        private static Task<TResult> FromException<TResult>(Exception exception)
        {
#if NET451 || NET452
            var tcs = new TaskCompletionSource<TResult>();
            tcs.TrySetException(exception);
            return tcs.Task;
#else
            return Task.FromException<TResult>(exception);
#endif
        }
    }
}