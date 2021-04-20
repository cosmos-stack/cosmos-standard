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
        public abstract TryCreatingValueException Exception { get; }

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
        public virtual T GetSafeValue(Func<TryCreatingValueException, T> defaultValFunc)
        {
            return IsSuccess
                ? Value
                : defaultValFunc is null
                    ? default
                    : defaultValFunc(Exception);
        }

        /// <summary>
        /// Get safe value
        /// </summary>
        /// <param name="defaultValFunc"></param>
        /// <returns></returns>
        public virtual T GetSafeValue(Func<Exception, string, T> defaultValFunc)
        {
            return IsSuccess
                ? Value
                : defaultValFunc is null
                    ? default
                    : defaultValFunc(Exception.InnerException, Exception.Cause);
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
        public virtual Task<T> GetSafeValueAsync(Func<TryCreatingValueException, T> defaultValFunc)
        {
            return Task.FromResult(GetSafeValue(defaultValFunc));
        }

        /// <summary>
        /// Get safe value async
        /// </summary>
        /// <param name="defaultValFunc"></param>
        /// <returns></returns>
        public virtual Task<T> GetSafeValueAsync(Func<Exception, string, T> defaultValFunc)
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
        public virtual Task<T> GetSafeValueAsync(Func<TryCreatingValueException, Task<T>> defaultValAsyncFunc)
        {
            return IsSuccess
                ? Task.FromResult(Value)
                : defaultValAsyncFunc is null
                    ? Task.FromResult(default(T))
                    : defaultValAsyncFunc(Exception);
        }

        /// <summary>
        /// Get safe value async
        /// </summary>
        /// <param name="defaultValAsyncFunc"></param>
        /// <returns></returns>
        public virtual Task<T> GetSafeValueAsync(Func<Exception, string, Task<T>> defaultValAsyncFunc)
        {
            return IsSuccess
                ? Task.FromResult(Value)
                : defaultValAsyncFunc is null
                    ? Task.FromResult(default(T))
                    : defaultValAsyncFunc(Exception.InnerException, Exception.Cause);
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
        public virtual bool TryGetValue(out T value, Func<TryCreatingValueException, T> defaultValFunc)
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
        public virtual bool TryGetValue(out T value, Func<Exception, string, T> defaultValFunc)
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

        public virtual Try<T> GetValueOut(out T value)
        {
            value = GetValue();
            return this;
        }

        public virtual Try<T> GetValueOutAsync(out Task<T> value)
        {
            value = GetValueAsync();
            return this;
        }

        public virtual Try<T> GetSafeValueOut(out T value)
        {
            value = GetSafeValue();
            return this;
        }

        public virtual Try<T> GetSafeValueOut(out T value, T defaultVal)
        {
            value = GetSafeValue(defaultVal);
            return this;
        }

        public virtual Try<T> GetSafeValueOut(out T value, Func<T> defaultValFunc)
        {
            value = GetSafeValue(defaultValFunc);
            return this;
        }

        public virtual Try<T> GetSafeValueOut(out T value, Func<TryCreatingValueException, T> defaultValFunc)
        {
            value = GetSafeValue(defaultValFunc);
            return this;
        }

        public virtual Try<T> GetSafeValueOut(out T value, Func<Exception, string, T> defaultValFunc)
        {
            value = GetSafeValue(defaultValFunc);
            return this;
        }

        public virtual Try<T> GetSafeValueOutAsync(out Task<T> value)
        {
            value = GetSafeValueAsync();
            return this;
        }

        public virtual Try<T> GetSafeValueOutAsync(out Task<T> value, T defaultVal)
        {
            value = GetSafeValueAsync(defaultVal);
            return this;
        }

        public virtual Try<T> GetSafeValueOutAsync(out Task<T> value, Func<T> defaultValFunc)
        {
            value = GetSafeValueAsync(defaultValFunc);
            return this;
        }

        public virtual Try<T> GetSafeValueOutAsync(out Task<T> value, Func<TryCreatingValueException, T> defaultValFunc)
        {
            value = GetSafeValueAsync(defaultValFunc);
            return this;
        }

        public virtual Try<T> GetSafeValueOutAsync(out Task<T> value, Func<Exception, string, T> defaultValFunc)
        {
            value = GetSafeValueAsync(defaultValFunc);
            return this;
        }

        public virtual Try<T> GetSafeValueOutAsync(out Task<T> value, Func<Task<T>> defaultValAsyncFunc)
        {
            value = GetSafeValueAsync(defaultValAsyncFunc);
            return this;
        }

        public virtual Try<T> GetSafeValueOutAsync(out Task<T> value, Func<TryCreatingValueException, Task<T>> defaultValAsyncFunc)
        {
            value = GetSafeValueAsync(defaultValAsyncFunc);
            return this;
        }

        public virtual Try<T> GetSafeValueOutAsync(out Task<T> value, Func<Exception, string, Task<T>> defaultValAsyncFunc)
        {
            value = GetSafeValueAsync(defaultValAsyncFunc);
            return this;
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
        /// Deconstruct
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tryResult"></param>
        /// <param name="exception"></param>
        public abstract void Deconstruct(out T value, out bool tryResult, out Exception exception);

        /// <summary>
        /// Exception as
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public TException ExceptionAs<TException>() where TException : Exception => Exception.InnerException as TException;

        /// <summary>
        /// Recover
        /// </summary>
        /// <param name="recoverFunction"></param>
        /// <returns></returns>
        public abstract Try<T> Recover(Func<TryCreatingValueException, T> recoverFunction);

        /// <summary>
        /// Recover
        /// </summary>
        /// <param name="recoverFunction"></param>
        /// <returns></returns>
        public abstract Try<T> Recover(Func<Exception, string, T> recoverFunction);

        /// <summary>
        /// Recover with
        /// </summary>
        /// <param name="recoverFunction"></param>
        /// <returns></returns>
        public abstract Try<T> RecoverWith(Func<TryCreatingValueException, Try<T>> recoverFunction);

        /// <summary>
        /// Recover with
        /// </summary>
        /// <param name="recoverFunction"></param>
        /// <returns></returns>
        public abstract Try<T> RecoverWith(Func<Exception, string, Try<T>> recoverFunction);

        /// <summary>
        /// Match
        /// </summary>
        /// <param name="whenValue"></param>
        /// <param name="whenException"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public abstract TResult Match<TResult>(Func<T, TResult> whenValue, Func<TryCreatingValueException, TResult> whenException);

        /// <summary>
        /// Match
        /// </summary>
        /// <param name="whenValue"></param>
        /// <param name="whenException"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public abstract TResult Match<TResult>(Func<T, TResult> whenValue, Func<Exception, string, TResult> whenException);

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
        public abstract Try<T> Tap(Action<T> successFunction = null, Action<TryCreatingValueException> failureFunction = null);

        /// <summary>
        /// Tap
        /// </summary>
        /// <param name="successFunction"></param>
        /// <param name="failureFunction"></param>
        /// <returns></returns>
        public abstract Try<T> Tap(Action<T> successFunction = null, Action<Exception, string> failureFunction = null);

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