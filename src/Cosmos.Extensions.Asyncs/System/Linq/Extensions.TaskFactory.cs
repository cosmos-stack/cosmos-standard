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

namespace System.Linq
{
    public static class TaskFactoryExtensions
    {
        private static Task<TResult> FromTaskEnumerable<T, TAsyncEnumerable, TResult>(
            this TaskFactory taskFactory, T source,
            Func<TAsyncEnumerable, TResult> func,
            Func<T, CancellationToken, TAsyncEnumerable> converter,
            CancellationToken cancellationToken = default)
        {
            return Task.Run(() => func(converter(source, cancellationToken)), cancellationToken);
        }

        private static async Task<TResult> FromTaskEnumerable<T, TAsyncEnumerable, TResult>(
            this TaskFactory taskFactory, Task<T> task,
            Func<TAsyncEnumerable, TResult> func,
            Func<T, CancellationToken, TAsyncEnumerable> converter,
            CancellationToken cancellationToken = default)
        {
            var result = await task.ConfigureAwait(false);
            return func(converter(result, cancellationToken));
        }

        #region Array

        public static Task<TResult> FromTaskEnumerable<T, TResult>(
            this TaskFactory taskFactory, Task<T[]> task, Func<IEnumerable<T>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TResult>(
            this TaskFactory taskFactory, Task<T[]> task, TP1 p1, Func<IEnumerable<T>, TP1, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TResult>(
            this TaskFactory taskFactory, Task<T[]> task, TP1 p1, TP2 p2, Func<IEnumerable<T>, TP1, TP2, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TResult>(
            this TaskFactory taskFactory, Task<T[]> task, TP1 p1, TP2 p2, TP3 p3, Func<IEnumerable<T>, TP1, TP2, TP3, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TResult>(
            this TaskFactory taskFactory, Task<T[]> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TP5, TResult>(this TaskFactory taskFactory, Task<T[]> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TP5, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4, p5), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        #endregion

        #region AsyncWhereEnumerable`1


        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<AsyncWhereEnumerable<T>> task, Func<IEnumerable<T>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TResult>(this TaskFactory taskFactory, Task<AsyncWhereEnumerable<T>> task, TP1 p1, Func<IEnumerable<T>, TP1, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TResult>(this TaskFactory taskFactory, Task<AsyncWhereEnumerable<T>> task, TP1 p1, TP2 p2, Func<IEnumerable<T>, TP1, TP2, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TResult>(this TaskFactory taskFactory, Task<AsyncWhereEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3, Func<IEnumerable<T>, TP1, TP2, TP3, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TResult>(this TaskFactory taskFactory, Task<AsyncWhereEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TP5, TResult>(this TaskFactory taskFactory, Task<AsyncWhereEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TP5, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4, p5), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        #endregion

        #region Collecton`1

        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<ICollection<T>> task, Func<IEnumerable<T>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<Collection<T>> task, Func<IEnumerable<T>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        #endregion

        #region Dictionary`2

        public static Task<TResult> FromTaskEnumerable<TKey, TValue, TResult>(this TaskFactory taskFactory, Task<Dictionary<TKey, TValue>> task, Func<IEnumerable<KeyValuePair<TKey, TValue>>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<KeyValuePair<TKey, TValue>>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<TKey, TValue, TResult>(this TaskFactory taskFactory, Task<IDictionary<TKey, TValue>> task, Func<IEnumerable<KeyValuePair<TKey, TValue>>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<KeyValuePair<TKey, TValue>>.CreateFrom, cancellationToken);
        }

        #endregion

        #region IEnumerable

        public static Task<TResult> FromTaskEnumerable<TResult>(this TaskFactory taskFactory, IEnumerable source, Func<IEnumerable, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, source, func, AsyncEnumerable.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<TResult>(this TaskFactory taskFactory, Task<IEnumerable> task, Func<IEnumerable, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable.CreateFrom, cancellationToken);
        }

        #endregion

        #region IEnumerable`1

        #region FromEnumerable

        public static Task<TResult> FromEnumerable<T, TResult>(this TaskFactory taskFactory, IEnumerable<T> source, Func<IEnumerable<T>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, source, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromEnumerable<T, TP1, TResult>(this TaskFactory taskFactory, IEnumerable<T> source, TP1 p1, Func<IEnumerable<T>, TP1, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, source, enums => func(enums, p1), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromEnumerable<T, TP1, TP2, TResult>(this TaskFactory taskFactory, IEnumerable<T> source, TP1 p1, TP2 p2, Func<IEnumerable<T>, TP1, TP2, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, source, enums => func(enums, p1, p2), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromEnumerable<T, TP1, TP2, TP3, TResult>(this TaskFactory taskFactory, IEnumerable<T> source, TP1 p1, TP2 p2, TP3 p3, Func<IEnumerable<T>, TP1, TP2, TP3, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, source, enums => func(enums, p1, p2, p3), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromEnumerable<T, TP1, TP2, TP3, TP4, TResult>(this TaskFactory taskFactory, IEnumerable<T> source, TP1 p1, TP2 p2, TP3 p3, TP4 p4, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, source, enums => func(enums, p1, p2, p3, p4), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromEnumerable<T, TP1, TP2, TP3, TP4, TP5, TResult>(this TaskFactory taskFactory, IEnumerable<T> souce, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TP5, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, souce, enums => func(enums, p1, p2, p3, p4, p5), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromEnumerable<T, TP1, TResult>(this TaskFactory taskFactory, IEnumerable<T> source, TP1 p1, Func<IEnumerable<T>, TP1, TResult> func, Func<T, Task<bool>> funcAsync, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, source, enums => func(enums, p1), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromEnumerable<T, TResult>(this TaskFactory taskFactory, IEnumerable<T> source, Func<T, Task<bool>> predicate, Func<IEnumerable<T>, Func<T, bool>, TResult> func, bool skipFilterPredicate, CancellationToken cancellationToken = default(CancellationToken))
        {
            source = new AsyncWhereEnumerable<T>(source, predicate, cancellationToken) { SkipFilterPredicate = skipFilterPredicate };

            Func<T, bool> predicateOrdered = source1 => predicate(source1).Result;
            return Task.Factory.FromEnumerable(source, predicateOrdered, func, cancellationToken);
        }

        #endregion

        #region FromTaskEnumerable

        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, Func<IEnumerable<T>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TResult>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, TP1 p1, Func<IEnumerable<T>, TP1, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TResult>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, TP1 p1, TP2 p2, Func<IEnumerable<T>, TP1, TP2, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TResult>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3, Func<IEnumerable<T>, TP1, TP2, TP3, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TResult>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TP5, TResult>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TP5, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4, p5), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, Func<T, Task<bool>> predicate, Func<IEnumerable<T>, Func<T, bool>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            var source = new AsyncWhereEnumerable<T>(task, predicate, cancellationToken);

            Func<T, bool> predicateOrdered = source1 => predicate(source1).Result;
            return Task.Factory.FromEnumerable(source, predicateOrdered, func, cancellationToken);
        }

        #endregion

        #region FromWhereEnumerable

        public static Task<AsyncWhereEnumerable<T>> FromWhereEnumerable<T>(this TaskFactory taskFactory, IEnumerable<T> source, Func<T, Task<bool>> predicate, Func<IEnumerable<T>, Func<T, bool>, IEnumerable<T>> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            source = new AsyncWhereEnumerable<T>(source, predicate, cancellationToken);

            var taskEnumerable = FromTaskEnumerable(taskFactory, source, enums => enums, AsyncWhereEnumerable<T>.CreateFrom, cancellationToken);
            var taskWhereEnumerable = taskEnumerable.ContinueWith((t, x) => new AsyncWhereEnumerable<T>(t.Result), source, cancellationToken, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

            return taskWhereEnumerable;
        }

        public static Task<AsyncWhereEnumerable<T>> FromWhereEnumerable<T>(this TaskFactory taskFactory, IEnumerable<T> source, Func<T, int, Task<bool>> predicate, Func<IEnumerable<T>, Func<T, int, bool>, IEnumerable<T>> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            source = new AsyncWhereEnumerable<T>(source, predicate, cancellationToken);

            var taskEnumerable = FromTaskEnumerable(taskFactory, source, enums => enums, AsyncWhereEnumerable<T>.CreateFrom, cancellationToken);
            var taskWhereEnumerable = taskEnumerable.ContinueWith((t, x) => new AsyncWhereEnumerable<T>(t.Result), source, cancellationToken, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

            return taskWhereEnumerable;
        }

        #endregion

        #region FromWhereTaskEnumerable

        public static Task<AsyncWhereEnumerable<T>> FromWhereTaskEnumerable<T>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, Func<T, Task<bool>> predicate, Func<IEnumerable<T>, Func<T, bool>, IEnumerable<T>> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            var source = new AsyncWhereEnumerable<T>(task, predicate, cancellationToken);

            var taskEnumerable = FromTaskEnumerable(taskFactory, source, enums => enums, AsyncWhereEnumerable<T>.CreateFrom, cancellationToken);
            var taskWhereEnumerable = taskEnumerable.ContinueWith((t, x) => new AsyncWhereEnumerable<T>(t.Result), source, cancellationToken, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

            return taskWhereEnumerable;
        }

        public static Task<AsyncWhereEnumerable<T>> FromWhereTaskEnumerable<T>(this TaskFactory taskFactory, Task<IEnumerable<T>> task, Func<T, int, Task<bool>> predicate, Func<IEnumerable<T>, Func<T, int, bool>, IEnumerable<T>> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            var source = new AsyncWhereEnumerable<T>(task, predicate, cancellationToken);

            var taskEnumerable = FromTaskEnumerable(taskFactory, source, enums => enums, AsyncWhereEnumerable<T>.CreateFrom, cancellationToken);
            var taskWhereEnumerable = taskEnumerable.ContinueWith((t, x) => new AsyncWhereEnumerable<T>(t.Result), source, cancellationToken, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);

            return taskWhereEnumerable;
        }

        #endregion

        #endregion

        #region IList`1

        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<IList<T>> task, Func<IEnumerable<T>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        #endregion

        #region ILookup`2

        public static Task<TResult> FromTaskEnumerable<TKey, TElement, TResult>(this TaskFactory taskFactory, Task<ILookup<TKey, TElement>> task, Func<IEnumerable<IGrouping<TKey, TElement>>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<IGrouping<TKey, TElement>>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<TKey, TElement, TResult>(this TaskFactory taskFactory, Task<Lookup<TKey, TElement>> task, Func<IEnumerable<IGrouping<TKey, TElement>>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<IGrouping<TKey, TElement>>.CreateFrom, cancellationToken);
        }

        #endregion

        #region IOrderedEnumerable`1

        public static Task<TResult> FromEnumerable<TElement, TP1, TResult>(this TaskFactory taskFactory, IOrderedEnumerable<TElement> source, TP1 p1, Func<IOrderedEnumerable<TElement>, TP1, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, source, enums => func(enums, p1), AsyncOrderedEnumerable<TElement>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromEnumerable<TElement, TP1, TP2, TResult>(this TaskFactory taskFactory, IOrderedEnumerable<TElement> source, TP1 p1, TP2 p2, Func<IOrderedEnumerable<TElement>, TP1, TP2, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, source, enums => func(enums, p1, p2), AsyncOrderedEnumerable<TElement>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<T>> task, Func<IEnumerable<T>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<T>> task, TP1 p1, Func<IEnumerable<T>, TP1, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<T>> task, TP1 p1, TP2 p2, Func<IEnumerable<T>, TP1, TP2, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3, Func<IEnumerable<T>, TP1, TP2, TP3, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TP5, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<T>> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TP5, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4, p5), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<TElement, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<TElement>> task, Func<IOrderedEnumerable<TElement>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncOrderedEnumerable<TElement>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<TElement, TP1, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<TElement>> task, TP1 p1, Func<IOrderedEnumerable<TElement>, TP1, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1), AsyncOrderedEnumerable<TElement>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<TElement, TP1, TP2, TResult>(this TaskFactory taskFactory, Task<IOrderedEnumerable<TElement>> task, TP1 p1, TP2 p2, Func<IOrderedEnumerable<TElement>, TP1, TP2, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2), AsyncOrderedEnumerable<TElement>.CreateFrom, cancellationToken);
        }

        #endregion

        #region IReadOnlyCollection`1

        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<IReadOnlyCollection<T>> task, Func<IEnumerable<T>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<ReadOnlyCollection<T>> task, Func<IEnumerable<T>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        #endregion

        #region IReadOnlyDictionary`2

        public static Task<TResult> FromTaskEnumerable<TKey, TValue, TResult>(this TaskFactory taskFactory, Task<IReadOnlyDictionary<TKey, TValue>> task, Func<IEnumerable<KeyValuePair<TKey, TValue>>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<KeyValuePair<TKey, TValue>>.CreateFrom, cancellationToken);
        }


        #endregion

        #region IReadOnlyList`1

        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<IReadOnlyList<T>> task, Func<IEnumerable<T>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        #endregion

        #region List

        public static Task<TResult> FromTaskEnumerable<T, TResult>(this TaskFactory taskFactory, Task<List<T>> task, Func<IEnumerable<T>, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, func, AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TResult>(this TaskFactory taskFactory, Task<List<T>> task, TP1 p1, Func<IEnumerable<T>, TP1, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TResult>(this TaskFactory taskFactory, Task<List<T>> task, TP1 p1, TP2 p2, Func<IEnumerable<T>, TP1, TP2, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TResult>(this TaskFactory taskFactory, Task<List<T>> task, TP1 p1, TP2 p2, TP3 p3, Func<IEnumerable<T>, TP1, TP2, TP3, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TResult>(this TaskFactory taskFactory, Task<List<T>> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        public static Task<TResult> FromTaskEnumerable<T, TP1, TP2, TP3, TP4, TP5, TResult>(this TaskFactory taskFactory, Task<List<T>> task, TP1 p1, TP2 p2, TP3 p3, TP4 p4, TP5 p5, Func<IEnumerable<T>, TP1, TP2, TP3, TP4, TP5, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
        {
            return FromTaskEnumerable(taskFactory, task, enums => func(enums, p1, p2, p3, p4, p5), AsyncEnumerable<T>.CreateFrom, cancellationToken);
        }

        #endregion
    }
}
