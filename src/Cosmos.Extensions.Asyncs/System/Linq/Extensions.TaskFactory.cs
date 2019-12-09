// Description: Async extension methods for LINQ (Language Integrated Query).
// Website & Documentation: https://github.com/zzzprojects/LINQ-Async
// Forum: https://github.com/zzzprojects/LINQ-Async/issues
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Async;
using System.Threading;
using System.Threading.Tasks;

/*
 * Reference to:
 *  ZZZProjects/LINQ-Async
 *  Author: JonathanMagnan
 *  URL: https://github.com/zzzprojects/LINQ-Async
 *  MIT
 */

namespace System.Linq {
    /// <summary>
    /// Task factory extensions
    /// </summary>
    public static class TaskFactoryExtensions {
        private static Task<TResult> FromTaskEnumerable<T, TAsyncEnumerable, TResult>(
            this TaskFactory taskFactory, T source,
            Func<TAsyncEnumerable, TResult> func,
            Func<T, CancellationToken, TAsyncEnumerable> converter,
            CancellationToken cancellationToken = default) {
            return Task.Run(() => func(converter(source, cancellationToken)), cancellationToken);
        }

        private static async Task<TResult> FromTaskEnumerable<T, TAsyncEnumerable, TResult>(
            this TaskFactory taskFactory, Task<T> task,
            Func<TAsyncEnumerable, TResult> func,
            Func<T, CancellationToken, TAsyncEnumerable> converter,
            CancellationToken cancellationToken = default) {
            var result = await task.ConfigureAwait(false);
            return func(converter(result, cancellationToken));
        }

        #region Array

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TResult>(
            this TaskFactory taskFactory, Task<T[]> task, Func<IEnumerable<T>, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TResult>(
            this TaskFactory taskFactory, Task<T[]> task, TP1 p1, Func<IEnumerable<T>, TP1, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TResult>(
            this TaskFactory taskFactory, Task<T[]> task, TP1 p1, TP2 p2, Func<IEnumerable<T>, TP1, TP2, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TResult>(
            this TaskFactory taskFactory, Task<T[]> task, TP1 p1, TP2 p2, TP3 p3, Func<IEnumerable<T>, TP1, TP2, TP3, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TP4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TResult>(
            this TaskFactory taskFactory, Task<T[]> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="p5"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TP4"></typeparam>
        /// <typeparam name="TP5"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TP5, TResult>(this TaskFactory taskFactory, Task<T[]> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5,
            Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TP5, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4, p5), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        #endregion

        #region AsyncWhereEnumerable`1

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<AsyncWhereEnumerable<T>> task, Func<IEnumerable<T>, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TResult>(this TaskFactory taskFactory, Task<AsyncWhereEnumerable<T>> task, TP1 p1,
            Func<IEnumerable<T>, TP1, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TResult>(this TaskFactory taskFactory, Task<AsyncWhereEnumerable<T>> task, TP1 p1, TP2 p2,
            Func<IEnumerable<T>, TP1, TP2, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TResult>(this TaskFactory taskFactory, Task<AsyncWhereEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3,
            Func<IEnumerable<T>, TP1, TP2, TP3, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TP4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TResult>(this TaskFactory taskFactory, Task<AsyncWhereEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3,
            TP4 p4, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="p5"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TP4"></typeparam>
        /// <typeparam name="TP5"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TP5, TResult>(this TaskFactory taskFactory, Task<AsyncWhereEnumerable<T>> task, TP1 p1, TP2 p2,
            TP3 p3, TP4 p4, TP5 p5, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TP5, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4, p5), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        #endregion

        #region Collecton`1

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<ICollection<T>> task, Func<IEnumerable<T>, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<Collection<T>> task, Func<IEnumerable<T>, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        #endregion

        #region Dictionary`2

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<TKey, TValue, TResult>(this TaskFactory taskFactory, Task<Dictionary<TKey, TValue>> task,
            Func<IEnumerable<KeyValuePair<TKey, TValue>>, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<KeyValuePair<TKey, TValue>>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<TKey, TValue, TResult>(this TaskFactory taskFactory, Task<IDictionary<TKey, TValue>> task,
            Func<IEnumerable<KeyValuePair<TKey, TValue>>, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<KeyValuePair<TKey, TValue>>.CreateFrom, cancellationToken);
        }

        #endregion

        #region IEnumerable

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<TResult>(this TaskFactory taskFactory, IEnumerable source, Func<IEnumerable, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, source, func, AsyncEnumerable.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<TResult>(this TaskFactory taskFactory, Task<IEnumerable> task, Func<IEnumerable, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable.CreateFrom, cancellationToken);
        }

        #endregion

        #region IEnumerable`1

        #region FromEnumerable

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromEnumerable<T, TResult>(this TaskFactory taskFactory, IEnumerable<T> source, Func<IEnumerable<T>, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, source, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="source"></param>
        /// <param name="p1"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromEnumerable<T, TP1, TResult>(this TaskFactory taskFactory, IEnumerable<T> source, TP1 p1, Func<IEnumerable<T>, TP1, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, source, enums => func(enums, p1), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="source"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromEnumerable<T, TP1, TP2, TResult>(this TaskFactory taskFactory, IEnumerable<T> source, TP1 p1, TP2 p2,
            Func<IEnumerable<T>, TP1, TP2, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, source, enums => func(enums, p1, p2), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="source"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromEnumerable<T, TP1, TP2, TP3, TResult>(this TaskFactory taskFactory, IEnumerable<T> source, TP1 p1, TP2 p2, TP3 p3,
            Func<IEnumerable<T>, TP1, TP2, TP3, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, source, enums => func(enums, p1, p2, p3), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="source"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TP4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromEnumerable<T, TP1, TP2, TP3, TP4, TResult>(this TaskFactory taskFactory, IEnumerable<T> source, TP1 p1, TP2 p2, TP3 p3, TP4 p4,
            Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, source, enums => func(enums, p1, p2, p3, p4), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="souce"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="p5"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TP4"></typeparam>
        /// <typeparam name="TP5"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromEnumerable<T, TP1, TP2, TP3, TP4, TP5, TResult>(this TaskFactory taskFactory, IEnumerable<T> souce, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5,
            Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TP5, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, souce, enums => func(enums, p1, p2, p3, p4, p5), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="source"></param>
        /// <param name="p1"></param>
        /// <param name="func"></param>
        /// <param name="funcAsync"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromEnumerable<T, TP1, TResult>(this TaskFactory taskFactory, IEnumerable<T> source, TP1 p1, Func<IEnumerable<T>, TP1, TResult> func,
            Func<T, Task<bool>> funcAsync, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, source, enums => func(enums, p1), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="func"></param>
        /// <param name="skipFilterPredicate"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromEnumerable<T, TResult>(this TaskFactory taskFactory, IEnumerable<T> source, Func<T, Task<bool>> predicate,
            Func<IEnumerable<T>, Func<T, bool>, TResult> func, bool skipFilterPredicate, CancellationToken cancellationToken = default(CancellationToken)) {
            source = new AsyncWhereEnumerable<T>(source, predicate, cancellationToken) {SkipFilterPredicate = skipFilterPredicate};

            Func<T, bool> predicateOrdered = source1 => predicate(source1).Result;
            return Task.Factory.FromEnumerable(source, predicateOrdered, func, cancellationToken);
        }

        #endregion

        #region FromTaskEnumerable

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, Func<IEnumerable<T>, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TResult>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, TP1 p1, Func<IEnumerable<T>, TP1, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TResult>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, TP1 p1, TP2 p2,
            Func<IEnumerable<T>, TP1, TP2, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TResult>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3,
            Func<IEnumerable<T>, TP1, TP2, TP3, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TP4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TResult>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4,
            Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="p5"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TP4"></typeparam>
        /// <typeparam name="TP5"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TP5, TResult>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4,
            TP5 p5, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TP5, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4, p5), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From task enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="predicate"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, Func<T, Task<bool>> predicate,
            Func<IEnumerable<T>, Func<T, bool>, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            var source = new AsyncWhereEnumerable<T>(task, predicate, cancellationToken);

            Func<T, bool> predicateOrdered = source1 => predicate(source1).Result;
            return Task.Factory.FromEnumerable(source, predicateOrdered, func, cancellationToken);
        }

        #endregion

        #region FromWhereEnumerable

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<T>> FromWhereEnumerable<T>(this TaskFactory taskFactory, IEnumerable<T> source, Func<T, Task<bool>> predicate,
            Func<IEnumerable<T>, Func<T, bool>, IEnumerable<T>> func, CancellationToken cancellationToken = default(CancellationToken)) {
            source = new AsyncWhereEnumerable<T>(source, predicate, cancellationToken);

            var taskEnumerable = FromTaskEnumerable(taskFactory, source, enums => enums, AsyncWhereEnumerable<T>.CreateFrom, cancellationToken);
            var taskWhereEnumerable = taskEnumerable.ContinueWith((t, x) => new AsyncWhereEnumerable<T>(t.Result), source, cancellationToken,
                TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

            return taskWhereEnumerable;
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<T>> FromWhereEnumerable<T>(this TaskFactory taskFactory, IEnumerable<T> source, Func<T, int, Task<bool>> predicate,
            Func<IEnumerable<T>, Func<T, int, bool>, IEnumerable<T>> func, CancellationToken cancellationToken = default(CancellationToken)) {
            source = new AsyncWhereEnumerable<T>(source, predicate, cancellationToken);

            var taskEnumerable = FromTaskEnumerable(taskFactory, source, enums => enums, AsyncWhereEnumerable<T>.CreateFrom, cancellationToken);
            var taskWhereEnumerable = taskEnumerable.ContinueWith((t, x) => new AsyncWhereEnumerable<T>(t.Result), source, cancellationToken,
                TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

            return taskWhereEnumerable;
        }

        #endregion

        #region FromWhereTaskEnumerable

        /// <summary>
        /// From Where Task Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="predicate"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<T>> FromWhereTaskEnumerable<T>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, Func<T, Task<bool>> predicate,
            Func<IEnumerable<T>, Func<T, bool>, IEnumerable<T>> func, CancellationToken cancellationToken = default(CancellationToken)) {
            var source = new AsyncWhereEnumerable<T>(task, predicate, cancellationToken);

            var taskEnumerable = FromTaskEnumerable(taskFactory, source, enums => enums, AsyncWhereEnumerable<T>.CreateFrom, cancellationToken);
            var taskWhereEnumerable = taskEnumerable.ContinueWith((t, x) => new AsyncWhereEnumerable<T>(t.Result), source, cancellationToken,
                TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

            return taskWhereEnumerable;
        }

        /// <summary>
        /// From Where Task Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="predicate"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<AsyncWhereEnumerable<T>> FromWhereTaskEnumerable<T>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, Func<T, int, Task<bool>> predicate,
            Func<IEnumerable<T>, Func<T, int, bool>, IEnumerable<T>> func, CancellationToken cancellationToken = default(CancellationToken)) {
            var source = new AsyncWhereEnumerable<T>(task, predicate, cancellationToken);

            var taskEnumerable = FromTaskEnumerable(taskFactory, source, enums => enums, AsyncWhereEnumerable<T>.CreateFrom, cancellationToken);
            var taskWhereEnumerable = taskEnumerable.ContinueWith((t, x) => new AsyncWhereEnumerable<T>(t.Result), source, cancellationToken,
                TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

            return taskWhereEnumerable;
        }

        #endregion

        #endregion

        #region IList`1

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<IList<T>> task, Func<IEnumerable<T>, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        #endregion

        #region ILookup`2

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<TKey, TElement, TResult>(this TaskFactory taskFactory, Task<ILookup<TKey, TElement>> task,
            Func<IEnumerable<IGrouping<TKey, TElement>>, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<IGrouping<TKey, TElement>>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<TKey, TElement, TResult>(this TaskFactory taskFactory, Task<Lookup<TKey, TElement>> task,
            Func<IEnumerable<IGrouping<TKey, TElement>>, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<IGrouping<TKey, TElement>>.CreateFrom, cancellationToken);
        }

        #endregion

        #region IOrderedEnumerable`1

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="source"></param>
        /// <param name="p1"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromEnumerable<TElement, TP1, TResult>(this TaskFactory taskFactory, IOrderedEnumerable<TElement> source, TP1 p1,
            Func<IOrderedEnumerable<TElement>, TP1, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, source, enums => func(enums, p1), AsyncOrderedEnumerable<TElement>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="source"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromEnumerable<TElement, TP1, TP2, TResult>(this TaskFactory taskFactory, IOrderedEnumerable<TElement> source, TP1 p1, TP2 p2,
            Func<IOrderedEnumerable<TElement>, TP1, TP2, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, source, enums => func(enums, p1, p2), AsyncOrderedEnumerable<TElement>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<T>> task, Func<IEnumerable<T>, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<T>> task, TP1 p1,
            Func<IEnumerable<T>, TP1, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<T>> task, TP1 p1, TP2 p2,
            Func<IEnumerable<T>, TP1, TP2, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3,
            Func<IEnumerable<T>, TP1, TP2, TP3, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TP4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3,
            TP4 p4, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="p5"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TP4"></typeparam>
        /// <typeparam name="TP5"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TP5, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3,
            TP4 p4, TP5 p5, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TP5, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4, p5), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<TElement, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<TElement>> task,
            Func<IOrderedEnumerable<TElement>, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncOrderedEnumerable<TElement>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<TElement, TP1, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<TElement>> task, TP1 p1,
            Func<IOrderedEnumerable<TElement>, TP1, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1), AsyncOrderedEnumerable<TElement>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TElement"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<TElement, TP1, TP2, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<TElement>> task, TP1 p1, TP2 p2,
            Func<IOrderedEnumerable<TElement>, TP1, TP2, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2), AsyncOrderedEnumerable<TElement>.CreateFrom, cancellationToken);
        }

        #endregion

        #region IReadOnlyCollection`1

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<IReadOnlyCollection<T>> task, Func<IEnumerable<T>, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<ReadOnlyCollection<T>> task, Func<IEnumerable<T>, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        #endregion

        #region IReadOnlyDictionary`2

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<TKey, TValue, TResult>(this TaskFactory taskFactory, Task<IReadOnlyDictionary<TKey, TValue>> task,
            Func<IEnumerable<KeyValuePair<TKey, TValue>>, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<KeyValuePair<TKey, TValue>>.CreateFrom, cancellationToken);
        }

        #endregion

        #region IReadOnlyList`1

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<IReadOnlyList<T>> task, Func<IEnumerable<T>, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        #endregion

        #region List

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<List<T>> task, Func<IEnumerable<T>, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TResult>(this TaskFactory taskFactory, Task<List<T>> task, TP1 p1, Func<IEnumerable<T>, TP1, TResult> func,
            CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TResult>(this TaskFactory taskFactory, Task<List<T>> task, TP1 p1, TP2 p2,
            Func<IEnumerable<T>, TP1, TP2, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TResult>(this TaskFactory taskFactory, Task<List<T>> task, TP1 p1, TP2 p2, TP3 p3,
            Func<IEnumerable<T>, TP1, TP2, TP3, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TP4"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TResult>(this TaskFactory taskFactory, Task<List<T>> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4,
            Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        /// <summary>
        /// From Where Enumerable
        /// </summary>
        /// <param name="taskFactory"></param>
        /// <param name="task"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="p5"></param>
        /// <param name="func"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TP1"></typeparam>
        /// <typeparam name="TP2"></typeparam>
        /// <typeparam name="TP3"></typeparam>
        /// <typeparam name="TP4"></typeparam>
        /// <typeparam name="TP5"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TP5, TResult>(this TaskFactory taskFactory, Task<List<T>> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4,
            TP5 p5, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TP5, TResult> func, CancellationToken cancellationToken = default(CancellationToken)) {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4, p5), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        #endregion

    }
}