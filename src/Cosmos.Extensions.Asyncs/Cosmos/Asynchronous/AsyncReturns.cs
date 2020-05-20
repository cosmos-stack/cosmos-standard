using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Asynchronous
{
    /// <summary>
    /// Async returns
    /// </summary>
    public static partial class AsyncReturns
    {
        /// <summary>
        /// Returns canceled
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> Canceled<T>(CancellationToken cancellationToken) => Tasks.FromCanceled<T>(cancellationToken);

        /// <summary>
        /// Returns canceled
        /// </summary>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> Canceled<T>(OperationCanceledException exception) => Tasks.FromCanceled<T>(exception);

        /// <summary>
        /// Returns Completed Task
        /// </summary>
        /// <returns></returns>
        public static Task CompletedTask() => Tasks.CompletedTask();

        /// <summary>
        /// Returns Delegate
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static Task Delegate(Action action) => new Task(action);

        /// <summary>
        /// Returns Delegate
        /// </summary>
        /// <param name="func"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> Delegate<T>(Func<T> func) => new Task<T>(func);

        /// <summary>
        /// Returns Delegate
        /// </summary>
        /// <param name="taskFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> Delegate<T>(Func<Task<T>> taskFunc) => taskFunc?.Invoke();

        /// <summary>
        /// Returns exception
        /// </summary>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> Exception<T>(Exception exception) => Tasks.FromException<T>(exception);

        /// <summary>
        /// Returns exception
        /// </summary>
        /// <param name="exceptionFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> Exception<T>(Func<Exception> exceptionFunc) => Tasks.FromException<T>(exceptionFunc());

        /// <summary>
        /// Returns default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> Default<T>() => Task.FromResult(default(T));

        /// <summary>
        /// Returns value
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> Value<T>(T value) => Task.FromResult(value);

        /// <summary>
        /// Returns value
        /// </summary>
        /// <param name="valueFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> Value<T>(Func<T> valueFunc) => Value(valueFunc());

        /// <summary>
        /// Return value or
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> ValueOr<T>(T value, T defaultVal) => Value(value ?? defaultVal);

        /// <summary>
        /// Return value or
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> ValueOr<T>(T value, Func<T> defaultValFunc) => value is null ? Value(defaultValFunc) : Value(value);

        /// <summary>
        /// Return value or
        /// </summary>
        /// <param name="valueFunc"></param>
        /// <param name="defaultVal"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> ValueOr<T>(Func<T> valueFunc, T defaultVal) => valueFunc is null ? Value(defaultVal) : Value(valueFunc);

        /// <summary>
        /// Return value or
        /// </summary>
        /// <param name="valueFunc"></param>
        /// <param name="defaultValFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> ValueOr<T>(Func<T> valueFunc, Func<T> defaultValFunc) => valueFunc is null ? Value(defaultValFunc) : Value(valueFunc);

        /// <summary>
        /// Return value or default
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> ValueOrDefault<T>(T value) => Value(value ?? default);

        /// <summary>
        /// Return value or default
        /// </summary>
        /// <param name="valueFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> ValueOrDefault<T>(Func<T> valueFunc) => valueFunc is null ? Default<T>() : Value(valueFunc);

        /// <summary>
        /// Value or default
        /// </summary>
        /// <param name="value"></param>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> ValueOrException<T>(T value, Exception exception) => value is null ? Exception<T>(exception) : Value(value);

        /// <summary>
        /// Value or default
        /// </summary>
        /// <param name="value"></param>
        /// <param name="exceptionFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> ValueOrException<T>(T value, Func<Exception> exceptionFunc) => value is null ? Exception<T>(exceptionFunc) : Value(value);

        /// <summary>
        /// Value or default
        /// </summary>
        /// <param name="valueFunc"></param>
        /// <param name="exceptionFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> ValueOrException<T>(Func<T> valueFunc, Func<Exception> exceptionFunc) => valueFunc is null ? Exception<T>(exceptionFunc) : Value(valueFunc);
    }
}