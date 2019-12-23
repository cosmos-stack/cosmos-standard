using System;
using System.Threading.Tasks;

// ReSharper disable ArgumentsStyleLiteral
// ReSharper disable ArgumentsStyleAnonymousFunction

namespace Cosmos.Optionals {
    /// <summary>
    /// Extensions for collections
    /// </summary>
    public static class AsyncCollectionExtensions {

        #region Maybe

        /// <summary>
        /// May async
        /// </summary>
        /// <param name="option"></param>
        /// <param name="mapping"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static Task<Maybe<TResult>> MapAsync<T, TResult>(this Maybe<T> option, Func<T, Task<TResult>> mapping) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return option.Map(mapping).Match(
                someFactory: async valueTask => {
                    if (valueTask == null) throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
                    var value = await valueTask.ConfigureAwait(continueOnCapturedContext: false);
                    return value.Maybe();
                },
                noneFactory: () => Task.FromResult(Optional.None<TResult>())
            );
        }

        /// <summary>
        /// Map async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Maybe<TResult>> MapAsync<T, TResult>(this Task<Maybe<T>> optionTask, Func<T, TResult> mapping, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return option.Map(mapping);
        }

        /// <summary>
        /// Map async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Maybe<TResult>> MapAsync<T, TResult>(this Task<Maybe<T>> optionTask, Func<T, Task<TResult>> mapping, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return await option.MapAsync(mapping).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Flat map async
        /// </summary>
        /// <param name="option"></param>
        /// <param name="mapping"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static Task<Maybe<TResult>> FlatMapAsync<T, TResult>(this Maybe<T> option, Func<T, Task<Maybe<TResult>>> mapping) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return option.Map(mapping).Match(
                someFactory: resultOptionTask => {
                    if (resultOptionTask == null) throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
                    return resultOptionTask;
                },
                noneFactory: () => Task.FromResult(Optional.None<TResult>())
            );
        }

        /// <summary>
        /// Flat map async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Maybe<TResult>> FlatMapAsync<T, TResult>(this Task<Maybe<T>> optionTask, Func<T, Maybe<TResult>> mapping, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return option.FlatMap(mapping);
        }

        /// <summary>
        /// Flat map async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Maybe<TResult>> FlatMapAsync<T, TResult>(this Task<Maybe<T>> optionTask, Func<T, Task<Maybe<TResult>>> mapping,
            bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return await option.FlatMapAsync(mapping).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Flat map async
        /// </summary>
        /// <param name="option"></param>
        /// <param name="mapping"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<Maybe<TResult>> FlatMapAsync<T, TResult, TException>(this Maybe<T> option, Func<T, Task<Either<TResult, TException>>> mapping) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            return option.FlatMapAsync(async value => {
                var resultOptionTask = mapping(value) ?? throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
                var resultOption = await (resultOptionTask).ConfigureAwait(false);
                return resultOption.WithoutException();
            });
        }

        /// <summary>
        /// Flat map async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Maybe<TResult>> FlatMapAsync<T, TResult, TException>(this Task<Maybe<T>> optionTask, Func<T, Either<TResult, TException>> mapping,
            bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return option.FlatMap(mapping);
        }

        /// <summary>
        /// Flat map async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Maybe<TResult>> FlatMapAsync<T, TResult, TException>(this Task<Maybe<T>> optionTask, Func<T, Task<Either<TResult, TException>>> mapping,
            bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return await option.FlatMapAsync(mapping).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Filter async
        /// </summary>
        /// <param name="option"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static Task<Maybe<T>> FilterAsync<T>(this Maybe<T> option, Func<T, Task<bool>> predicate) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return option.Match(
                someFactory: async value => {
                    var predicateTask = predicate(value);
                    if (predicateTask == null) throw new InvalidOperationException($"{nameof(predicate)} must not return a null task.");

                    var condition = await predicateTask.ConfigureAwait(continueOnCapturedContext: false);
                    return option.Filter(condition);
                },
                noneFactory: () => Task.FromResult(option)
            );
        }

        /// <summary>
        /// Filter async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="predicate"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Maybe<T>> FilterAsync<T>(this Task<Maybe<T>> optionTask, Func<T, bool> predicate, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return option.Filter(predicate);
        }

        /// <summary>
        /// Filter async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="predicate"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Maybe<T>> FilterAsync<T>(this Task<Maybe<T>> optionTask, Func<T, Task<bool>> predicate, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return await option.FilterAsync(predicate).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Not null async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<Maybe<T>> NotNullAsync<T>(this Task<Maybe<T>> optionTask) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            return optionTask.FilterAsync(value => value != null);
        }

        /// <summary>
        /// Or async
        /// </summary>
        /// <param name="option"></param>
        /// <param name="alternativeFactory"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static async Task<Maybe<T>> OrAsync<T>(this Maybe<T> option, Func<Task<T>> alternativeFactory) {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));

            if (option.HasValue) return option;

            var alternativeTask = alternativeFactory();
            if (alternativeTask is null)
                throw new InvalidOperationException($"{nameof(alternativeFactory)} must not return a null task.");

            var alternative = await alternativeTask.ConfigureAwait(continueOnCapturedContext: false);
            return alternative.Maybe();
        }

        /// <summary>
        /// Or async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="alternativeFactory"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Maybe<T>> OrAsync<T>(this Task<Maybe<T>> optionTask, Func<T> alternativeFactory, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return option.Or(alternativeFactory);
        }

        /// <summary>
        /// Or async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="alternativeFactory"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Maybe<T>> OrAsync<T>(this Task<Maybe<T>> optionTask, Func<Task<T>> alternativeFactory, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return await option.OrAsync(alternativeFactory).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Else async
        /// </summary>
        /// <param name="option"></param>
        /// <param name="alternativeOptionFactory"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static async Task<Maybe<T>> ElseAsync<T>(this Maybe<T> option, Func<Task<Maybe<T>>> alternativeOptionFactory) {
            if (alternativeOptionFactory is null)
                throw new ArgumentNullException(nameof(alternativeOptionFactory));

            if (option.HasValue) return option;

            var alternativeOptionTask = alternativeOptionFactory();
            if (alternativeOptionTask is null)
                throw new InvalidOperationException($"{nameof(alternativeOptionFactory)} must not return a null task.");

            return await alternativeOptionTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Else async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="alternativeOptionFactory"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Maybe<T>> ElseAsync<T>(this Task<Maybe<T>> optionTask, Func<Maybe<T>> alternativeOptionFactory, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (alternativeOptionFactory is null)
                throw new ArgumentNullException(nameof(alternativeOptionFactory));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return option.Else(alternativeOptionFactory);
        }

        /// <summary>
        /// Else async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="alternativeOptionFactory"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Maybe<T>> ElseAsync<T>(this Task<Maybe<T>> optionTask, Func<Task<Maybe<T>>> alternativeOptionFactory, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (alternativeOptionFactory is null)
                throw new ArgumentNullException(nameof(alternativeOptionFactory));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return await option.ElseAsync(alternativeOptionFactory).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// With exception async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static Task<Either<T, TException>> WithExceptionAsync<T, TException>(this Task<Maybe<T>> optionTask, TException exception) =>
            optionTask.WithExceptionAsync(() => exception);

        /// <summary>
        /// With exception async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="exceptionFactory"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<T, TException>> WithExceptionAsync<T, TException>(this Task<Maybe<T>> optionTask, Func<TException> exceptionFactory,
            bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return option.WithException(exceptionFactory);
        }

        /// <summary>
        /// Flatten async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Maybe<T>> FlattenAsync<T>(this Task<Maybe<Maybe<T>>> optionTask) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));

            var option = await optionTask.ConfigureAwait(continueOnCapturedContext: false);
            return option.Flatten();
        }

        #endregion

        #region Either

        /// <summary>
        /// Map async
        /// </summary>
        /// <param name="option"></param>
        /// <param name="mapping"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static Task<Either<TResult, TException>> MapAsync<T, TException, TResult>(this Either<T, TException> option, Func<T, Task<TResult>> mapping) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));

            return option.Map(mapping).Match(
                someFactory: async valueTask => {
                    if (valueTask is null)
                        throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
                    var value = await valueTask.ConfigureAwait(continueOnCapturedContext: false);
                    return value.Maybe<TResult, TException>();
                },
                noneFactory: exception => Task.FromResult(Optional.None<TResult, TException>(exception))
            );
        }

        /// <summary>
        /// Map async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<TResult, TException>> MapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask, Func<T, TResult> mapping,
            bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return option.Map(mapping);
        }

        /// <summary>
        /// Map async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<TResult, TException>> MapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask, Func<T, Task<TResult>> mapping,
            bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return await option.MapAsync(mapping).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Map exception async
        /// </summary>
        /// <param name="option"></param>
        /// <param name="mapping"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TExceptionResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static Task<Either<T, TExceptionResult>> MapExceptionAsync<T, TException, TExceptionResult>(this Either<T, TException> option,
            Func<TException, Task<TExceptionResult>> mapping) {
            return option.MapException(mapping).Match(
                someFactory: value => Task.FromResult(Optional.Some<T, TExceptionResult>(value)),
                noneFactory: async exceptionTask => {
                    if (exceptionTask is null)
                        throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
                    var exception = await exceptionTask.ConfigureAwait(continueOnCapturedContext: false);
                    return Optional.None<T, TExceptionResult>(exception);
                }
            );
        }

        /// <summary>
        /// Map exception async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TExceptionResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<T, TExceptionResult>> MapExceptionAsync<T, TException, TExceptionResult>(this Task<Either<T, TException>> optionTask,
            Func<TException, TExceptionResult> mapping, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return option.MapException(mapping);
        }

        /// <summary>
        /// Map exception async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TExceptionResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<T, TExceptionResult>> MapExceptionAsync<T, TException, TExceptionResult>(this Task<Either<T, TException>> optionTask,
            Func<TException, Task<TExceptionResult>> mapping, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return await option.MapExceptionAsync(mapping).ConfigureAwait(false);
        }

        /// <summary>
        /// Flat map async
        /// </summary>
        /// <param name="option"></param>
        /// <param name="mapping"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(
            this Either<T, TException> option, Func<T, Task<Either<TResult, TException>>> mapping) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));

            return option.Map(mapping).Match(
                someFactory: resultOptionTask => {
                    if (resultOptionTask is null)
                        throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
                    return resultOptionTask;
                },
                noneFactory: exception => Task.FromResult(Optional.None<TResult, TException>(exception))
            );
        }

        /// <summary>
        /// Flat map async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask,
            Func<T, Either<TResult, TException>> mapping, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return option.FlatMap(mapping);
        }

        /// <summary>
        /// Flat map async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask,
            Func<T, Task<Either<TResult, TException>>> mapping, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return await option.FlatMapAsync(mapping).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Flat map async
        /// </summary>
        /// <param name="option"></param>
        /// <param name="mapping"></param>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Either<T, TException> option, Func<T, Task<Maybe<TResult>>> mapping,
            TException exception) =>
            option.FlatMapAsync(mapping, () => exception);

        /// <summary>
        /// Flat map async
        /// </summary>
        /// <param name="option"></param>
        /// <param name="mapping"></param>
        /// <param name="exceptionFactory"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Either<T, TException> option, Func<T, Task<Maybe<TResult>>> mapping,
            Func<TException> exceptionFactory) {
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));

            return option.FlatMapAsync(async value => {
                var resultOptionTask = mapping(value) ?? throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
                var resultOption = await (resultOptionTask).ConfigureAwait(false);
                return resultOption.WithException(exceptionFactory());
            });
        }

        /// <summary>
        /// Flat map async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="exception"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask, Func<T, Maybe<TResult>> mapping,
            TException exception, bool executeOnCapturedContext = false) =>
            optionTask.FlatMapAsync(mapping, () => exception, executeOnCapturedContext);

        /// <summary>
        /// Flat map async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="exceptionFactory"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask, Func<T, Maybe<TResult>> mapping,
            Func<TException> exceptionFactory, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return option.FlatMap(mapping, exceptionFactory);
        }

        /// <summary>
        /// Flat map async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="exception"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask, Func<T, Task<Maybe<TResult>>> mapping,
            TException exception, bool executeOnCapturedContext = false) =>
            optionTask.FlatMapAsync(mapping, () => exception, executeOnCapturedContext);

        /// <summary>
        /// Flat map async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="mapping"></param>
        /// <param name="exceptionFactory"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<TResult, TException>> FlatMapAsync<T, TException, TResult>(this Task<Either<T, TException>> optionTask,
            Func<T, Task<Maybe<TResult>>> mapping, Func<TException> exceptionFactory, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (mapping is null)
                throw new ArgumentNullException(nameof(mapping));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return await option.FlatMapAsync(mapping, exceptionFactory).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Filter async
        /// </summary>
        /// <param name="option"></param>
        /// <param name="predicate"></param>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static Task<Either<T, TException>> FilterAsync<T, TException>(this Either<T, TException> option, Func<T, Task<bool>> predicate, TException exception) =>
            option.FilterAsync(predicate, () => exception);

        /// <summary>
        /// Filter async
        /// </summary>
        /// <param name="option"></param>
        /// <param name="predicate"></param>
        /// <param name="exceptionFactory"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static Task<Either<T, TException>> FilterAsync<T, TException>(this Either<T, TException> option, Func<T, Task<bool>> predicate, Func<TException> exceptionFactory) {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));

            return option.Match(
                someFactory: async value => {
                    var predicateTask = predicate(value);
                    if (predicateTask is null)
                        throw new InvalidOperationException($"{nameof(predicate)} must not return a null task.");

                    var condition = await predicateTask.ConfigureAwait(continueOnCapturedContext: false);
                    return option.Filter(condition, exceptionFactory);
                },
                noneFactory: _ => Task.FromResult(option)
            );
        }

        /// <summary>
        /// filter  async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="predicate"></param>
        /// <param name="exception"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static Task<Either<T, TException>> FilterAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<T, bool> predicate, TException exception,
            bool executeOnCapturedContext = false) =>
            optionTask.FilterAsync(predicate, () => exception, executeOnCapturedContext);

        /// <summary>
        /// Filter async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="predicate"></param>
        /// <param name="exceptionFactory"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<T, TException>> FilterAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<T, bool> predicate,
            Func<TException> exceptionFactory, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return option.Filter(predicate, exceptionFactory);
        }

        /// <summary>
        /// Filter async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="predicate"></param>
        /// <param name="exception"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static Task<Either<T, TException>> FilterAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<T, Task<bool>> predicate, TException exception,
            bool executeOnCapturedContext = false) =>
            optionTask.FilterAsync(predicate, () => exception, executeOnCapturedContext);

        /// <summary>
        /// Filter async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="predicate"></param>
        /// <param name="exceptionFactory"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<T, TException>> FilterAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<T, Task<bool>> predicate,
            Func<TException> exceptionFactory, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return await option.FilterAsync(predicate, exceptionFactory).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Not null async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="exception"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        public static Task<Either<T, TException>> NotNullAsync<T, TException>(this Task<Either<T, TException>> optionTask, TException exception) =>
            optionTask.NotNullAsync(() => exception);

        /// <summary>
        /// Not null async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="exceptionFactory"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<Either<T, TException>> NotNullAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<TException> exceptionFactory) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (exceptionFactory is null)
                throw new ArgumentNullException(nameof(exceptionFactory));
            return optionTask.FilterAsync(value => value != null, exceptionFactory);
        }

        /// <summary>
        /// Or async
        /// </summary>
        /// <param name="option"></param>
        /// <param name="alternativeFactory"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static async Task<Either<T, TException>> OrAsync<T, TException>(this Either<T, TException> option, Func<Task<T>> alternativeFactory) {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));

            if (option.HasValue) return option;

            var alternativeTask = alternativeFactory();
            if (alternativeTask is null)
                throw new InvalidOperationException($"{nameof(alternativeFactory)} must not return a null task.");

            var alternative = await alternativeTask.ConfigureAwait(continueOnCapturedContext: false);
            return alternative.Maybe<T, TException>();
        }

        /// <summary>
        /// Or async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="alternativeFactory"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<T, TException>> OrAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<T> alternativeFactory,
            bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return option.Or(alternativeFactory);
        }

        /// <summary>
        /// Or async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="alternativeFactory"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<T, TException>> OrAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<Task<T>> alternativeFactory,
            bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return await option.OrAsync(alternativeFactory).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Else async
        /// </summary>
        /// <param name="option"></param>
        /// <param name="alternativeOptionFactory"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static async Task<Either<T, TException>> ElseAsync<T, TException>(this Either<T, TException> option, Func<Task<Either<T, TException>>> alternativeOptionFactory) {
            if (alternativeOptionFactory is null)
                throw new ArgumentNullException(nameof(alternativeOptionFactory));

            if (option.HasValue) return option;

            var alternativeOptionTask = alternativeOptionFactory();
            if (alternativeOptionTask is null)
                throw new InvalidOperationException($"{nameof(alternativeOptionFactory)} must not return a null task.");

            return await alternativeOptionTask.ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Else async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="alternativeOptionFactory"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<T, TException>> ElseAsync<T, TException>(this Task<Either<T, TException>> optionTask, Func<Either<T, TException>> alternativeOptionFactory,
            bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (alternativeOptionFactory is null)
                throw new ArgumentNullException(nameof(alternativeOptionFactory));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return option.Else(alternativeOptionFactory);
        }

        /// <summary>
        /// Else async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <param name="alternativeOptionFactory"></param>
        /// <param name="executeOnCapturedContext"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<T, TException>> ElseAsync<T, TException>(this Task<Either<T, TException>> optionTask,
            Func<Task<Either<T, TException>>> alternativeOptionFactory, bool executeOnCapturedContext = false) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));
            if (alternativeOptionFactory is null)
                throw new ArgumentNullException(nameof(alternativeOptionFactory));

            var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
            return await option.ElseAsync(alternativeOptionFactory).ConfigureAwait(continueOnCapturedContext: false);
        }

        /// <summary>
        /// Without exception async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Maybe<T>> WithoutExceptionAsync<T, TException>(this Task<Either<T, TException>> optionTask) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));

            var option = await optionTask.ConfigureAwait(false);
            return option.WithoutException();
        }

        /// <summary>
        /// Flatten async
        /// </summary>
        /// <param name="optionTask"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<Either<T, TException>> FlattenAsync<T, TException>(this Task<Either<Either<T, TException>, TException>> optionTask) {
            if (optionTask is null)
                throw new ArgumentNullException(nameof(optionTask));

            var option = await optionTask.ConfigureAwait(continueOnCapturedContext: false);
            return option.Flatten();
        }

        #endregion

    }
}