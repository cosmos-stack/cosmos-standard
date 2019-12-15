// Description: Async extension methods for LINQ (Language Integrated Query).
// Website & Documentation: https://github.com/zzzprojects/LINQ-Async
// Forum: https://github.com/zzzprojects/LINQ-Async/issues
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

/*
 * Reference to:
 *  ZZZProjects/LINQ-Async
 *  Author: JonathanMagnan
 *  URL: https://github.com/zzzprojects/LINQ-Async
 *  MIT
 */

namespace System.Linq.Async {
    /// <summary>
    /// Async Where Enumerable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsyncWhereEnumerable<T> : IEnumerable<T> {
        /// <summary>
        /// Create a new instance of <see cref="AsyncWhereEnumerable{T}"/>.
        /// </summary>
        /// <param name="source"></param>
        public AsyncWhereEnumerable(Task<IEnumerable<T>> source) {
            SourceTask = source;
        }

        /// <summary>
        /// Create a new instance of <see cref="AsyncWhereEnumerable{T}"/>.
        /// </summary>
        /// <param name="source"></param>
        public AsyncWhereEnumerable(IEnumerable<T> source) {
            Source = source;
        }

        /// <summary>
        /// Create a new instance of <see cref="AsyncWhereEnumerable{T}"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        public AsyncWhereEnumerable(IEnumerable<T> source, CancellationToken cancellationToken) {
            Source = source;
            CancellationToken = cancellationToken;
        }

        /// <summary>
        /// Create a new instance of <see cref="AsyncWhereEnumerable{T}"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        public AsyncWhereEnumerable(IEnumerable<T> source, Func<T, Task<bool>> predicate, CancellationToken cancellationToken) {
            CancellationToken = cancellationToken;
            Predicate = predicate;
            Source = source;

            OrderByPredicateCompletion = LinqAsyncManager.DefaultValue.OrderByPredicateCompletion;
            StartPredicateConcurrently = LinqAsyncManager.DefaultValue.StartPredicateConcurrently;
        }

        /// <summary>
        /// Create a new instance of <see cref="AsyncWhereEnumerable{T}"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        public AsyncWhereEnumerable(IEnumerable<T> source, Func<T, int, Task<bool>> predicate, CancellationToken cancellationToken) {
            CancellationToken = cancellationToken;
            Predicate2 = predicate;
            Source = source;

            OrderByPredicateCompletion = LinqAsyncManager.DefaultValue.OrderByPredicateCompletion;
            StartPredicateConcurrently = LinqAsyncManager.DefaultValue.StartPredicateConcurrently;
        }

        /// <summary>
        /// Create a new instance of <see cref="AsyncWhereEnumerable{T}"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        public AsyncWhereEnumerable(Task<IEnumerable<T>> source, Func<T, Task<bool>> predicate, CancellationToken cancellationToken) {
            CancellationToken = cancellationToken;
            Predicate = predicate;
            SourceTask = source;

            OrderByPredicateCompletion = LinqAsyncManager.DefaultValue.OrderByPredicateCompletion;
            StartPredicateConcurrently = LinqAsyncManager.DefaultValue.StartPredicateConcurrently;
        }

        /// <summary>
        /// Create a new instance of <see cref="AsyncWhereEnumerable{T}"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <param name="cancellationToken"></param>
        public AsyncWhereEnumerable(Task<IEnumerable<T>> source, Func<T, int, Task<bool>> predicate, CancellationToken cancellationToken) {
            CancellationToken = cancellationToken;
            Predicate2 = predicate;
            SourceTask = source;

            OrderByPredicateCompletion = LinqAsyncManager.DefaultValue.OrderByPredicateCompletion;
            StartPredicateConcurrently = LinqAsyncManager.DefaultValue.StartPredicateConcurrently;
        }

        private Func<T, Task<bool>> Predicate { get; }

        private Func<T, int, Task<bool>> Predicate2 { get; }

        /// <summary>
        /// Start Predicate Concurrently
        /// </summary>
        public bool StartPredicateConcurrently { get; set; }

        /// <summary>
        /// Order By Predicate Completion
        /// </summary>
        public bool OrderByPredicateCompletion { get; set; }

        /// <summary>
        /// Skip Filter Predicate
        /// </summary>
        public bool SkipFilterPredicate { get; set; }

        private Task<IEnumerable<T>> SourceTask { get; }

        private IEnumerable<T> Source { get; set; }

        /// <summary>
        /// CancellationToken
        /// </summary>
        public CancellationToken CancellationToken { get; set; }

        /// <inheritdoc />
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public IEnumerator<T> GetEnumerator() {
            IEnumerator<T> enumerator;

            if (Source == null && SourceTask != null) {
                Source = SourceTask.Result;
            }

            if (Predicate != null) {
                if (SkipFilterPredicate) {
                    if (OrderByPredicateCompletion) {
                        var enumerator2 = Source.Select(x => Task.Run(() => new Tuple<T, bool>(x, Predicate(x).Result), CancellationToken)).OrderByCompletion()
                                                .Select(x => x.Result.Item1);
                        enumerator = enumerator2.GetEnumerator();
                    }
                    else if (StartPredicateConcurrently) {
                        var enumerator2 = Source.Select(x => Task.Run(() => new Tuple<T, bool>(x, Predicate(x).Result), CancellationToken)).ToList().Select(x => x.Result.Item1);
                        enumerator = enumerator2.GetEnumerator();
                    }
                    else {
                        var enumerator2 = Source.Select(x => Task.Run(() => new Tuple<T, bool>(x, Predicate(x).Result), CancellationToken)).Select(x => x.Result.Item1);
                        enumerator = enumerator2.GetEnumerator();
                    }
                }
                else {
                    if (OrderByPredicateCompletion) {
                        var enumerator2 = Source.Select(x => Task.Run(() => new Tuple<T, bool>(x, Predicate(x).Result), CancellationToken)).OrderByCompletion()
                                                .Where(x => x.Result.Item2).Select(x => x.Result.Item1);
                        enumerator = enumerator2.GetEnumerator();
                    }
                    else if (StartPredicateConcurrently) {
                        var enumerator2 = Source.Select(x => Task.Run(() => new Tuple<T, bool>(x, Predicate(x).Result), CancellationToken)).ToList().Where(x => x.Result.Item2)
                                                .Select(x => x.Result.Item1);
                        enumerator = enumerator2.GetEnumerator();
                    }
                    else {
                        var enumerator2 = Source.Select(x => Task.Run(() => new Tuple<T, bool>(x, Predicate(x).Result), CancellationToken)).Where(x => x.Result.Item2)
                                                .Select(x => x.Result.Item1);
                        enumerator = enumerator2.GetEnumerator();
                    }
                }
            }
            else if (Predicate2 != null) {
                if (OrderByPredicateCompletion) {
                    var enumerator2 = Source.Select(x => Task.Run(() => new Tuple<T, bool>(x, Predicate(x).Result), CancellationToken)).OrderByCompletion()
                                            .Where(x => x.Result.Item2).Select(x => x.Result.Item1);
                    enumerator = enumerator2.GetEnumerator();
                }
                else if (StartPredicateConcurrently) {
                    var enumerator2 = Source.Select(x => Task.Run(() => new Tuple<T, bool>(x, Predicate(x).Result), CancellationToken)).ToList().Where(x => x.Result.Item2)
                                            .Select(x => x.Result.Item1);
                    enumerator = enumerator2.GetEnumerator();
                }
                else {
                    var enumerator2 = Source.Select(x => Task.Run(() => new Tuple<T, bool>(x, Predicate(x).Result), CancellationToken)).Where(x => x.Result.Item2)
                                            .Select(x => x.Result.Item1);
                    enumerator = enumerator2.GetEnumerator();
                }
            }
            else {
                enumerator = Source.GetEnumerator();
            }

            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        /// <summary>
        /// Create from...
        /// </summary>
        /// <param name="source"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static AsyncWhereEnumerable<T> CreateFrom(IEnumerable<T> source, CancellationToken cancellationToken) {
            return new AsyncWhereEnumerable<T>(source, cancellationToken);
        }
    }
}