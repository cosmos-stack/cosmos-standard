namespace Cosmos.Optionals;

/// <summary>
/// Extensions for optional
/// </summary>
public static partial class OptionalsExtensions
{
    #region Collections Maybe async

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
    public static Task<Maybe<TResult>> MapAsync<T, TResult>(this Maybe<T> option, Func<T, Task<TResult>> mapping)
    {
        ArgumentNullException.ThrowIfNull(mapping);
        return option.Map(mapping).Match(
            someFactory: async valueTask =>
            {
                if (valueTask is null) throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
                var value = await valueTask.ConfigureAwait(continueOnCapturedContext: false);
                return value.AsOptionals();
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
    public static async Task<Maybe<TResult>> MapAsync<T, TResult>(this Task<Maybe<T>> optionTask, Func<T, TResult> mapping, bool executeOnCapturedContext = false)
    {
        ArgumentNullException.ThrowIfNull(optionTask);
        ArgumentNullException.ThrowIfNull(mapping);
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
    public static async Task<Maybe<TResult>> MapAsync<T, TResult>(this Task<Maybe<T>> optionTask, Func<T, Task<TResult>> mapping, bool executeOnCapturedContext = false)
    {
        ArgumentNullException.ThrowIfNull(optionTask);
        ArgumentNullException.ThrowIfNull(mapping);
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
    public static Task<Maybe<TResult>> FlatMapAsync<T, TResult>(this Maybe<T> option, Func<T, Task<Maybe<TResult>>> mapping)
    {
        ArgumentNullException.ThrowIfNull(mapping);
        return option.Map(mapping).Match(
            someFactory: resultOptionTask =>
            {
                if (resultOptionTask is null) throw new InvalidOperationException($"{nameof(mapping)} must not return a null task.");
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
    public static async Task<Maybe<TResult>> FlatMapAsync<T, TResult>(this Task<Maybe<T>> optionTask, Func<T, Maybe<TResult>> mapping, bool executeOnCapturedContext = false)
    {
        ArgumentNullException.ThrowIfNull(optionTask);
        ArgumentNullException.ThrowIfNull(mapping);
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
        bool executeOnCapturedContext = false)
    {
        ArgumentNullException.ThrowIfNull(optionTask);
        ArgumentNullException.ThrowIfNull(mapping);
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
    public static Task<Maybe<TResult>> FlatMapAsync<T, TResult, TException>(this Maybe<T> option, Func<T, Task<Either<TResult, TException>>> mapping)
    {
        ArgumentNullException.ThrowIfNull(mapping);
        return option.FlatMapAsync(async value =>
        {
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
        bool executeOnCapturedContext = false)
    {
        ArgumentNullException.ThrowIfNull(optionTask);
        ArgumentNullException.ThrowIfNull(mapping);
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
        bool executeOnCapturedContext = false)
    {
        ArgumentNullException.ThrowIfNull(optionTask);
        ArgumentNullException.ThrowIfNull(mapping);
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
    public static Task<Maybe<T>> FilterAsync<T>(this Maybe<T> option, Func<T, Task<bool>> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return option.Match(
            someFactory: async value =>
            {
                var predicateTask = predicate(value);
                if (predicateTask is null) throw new InvalidOperationException($"{nameof(predicate)} must not return a null task.");

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
    public static async Task<Maybe<T>> FilterAsync<T>(this Task<Maybe<T>> optionTask, Func<T, bool> predicate, bool executeOnCapturedContext = false)
    {
        ArgumentNullException.ThrowIfNull(optionTask);
        ArgumentNullException.ThrowIfNull(predicate);
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
    public static async Task<Maybe<T>> FilterAsync<T>(this Task<Maybe<T>> optionTask, Func<T, Task<bool>> predicate, bool executeOnCapturedContext = false)
    {
        ArgumentNullException.ThrowIfNull(optionTask);
        ArgumentNullException.ThrowIfNull(predicate);
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
    public static Task<Maybe<T>> NotNullAsync<T>(this Task<Maybe<T>> optionTask)
    {
        ArgumentNullException.ThrowIfNull(optionTask);
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
    public static async Task<Maybe<T>> OrAsync<T>(this Maybe<T> option, Func<Task<T>> alternativeFactory)
    {
        ArgumentNullException.ThrowIfNull(alternativeFactory);

        if (option.HasValue) return option;

        var alternativeTask = alternativeFactory();
        if (alternativeTask is null)
            throw new InvalidOperationException($"{nameof(alternativeFactory)} must not return a null task.");

        var alternative = await alternativeTask.ConfigureAwait(continueOnCapturedContext: false);
        return alternative.AsOptionals();
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
    public static async Task<Maybe<T>> OrAsync<T>(this Task<Maybe<T>> optionTask, Func<T> alternativeFactory, bool executeOnCapturedContext = false)
    {
        ArgumentNullException.ThrowIfNull(optionTask);
        ArgumentNullException.ThrowIfNull(alternativeFactory);
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
    public static async Task<Maybe<T>> OrAsync<T>(this Task<Maybe<T>> optionTask, Func<Task<T>> alternativeFactory, bool executeOnCapturedContext = false)
    {
        ArgumentNullException.ThrowIfNull(optionTask);
        ArgumentNullException.ThrowIfNull(alternativeFactory);
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
    public static async Task<Maybe<T>> ElseAsync<T>(this Maybe<T> option, Func<Task<Maybe<T>>> alternativeOptionFactory)
    {
        ArgumentNullException.ThrowIfNull(alternativeOptionFactory);

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
    public static async Task<Maybe<T>> ElseAsync<T>(this Task<Maybe<T>> optionTask, Func<Maybe<T>> alternativeOptionFactory, bool executeOnCapturedContext = false)
    {
        ArgumentNullException.ThrowIfNull(optionTask);
        ArgumentNullException.ThrowIfNull(alternativeOptionFactory);
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
    public static async Task<Maybe<T>> ElseAsync<T>(this Task<Maybe<T>> optionTask, Func<Task<Maybe<T>>> alternativeOptionFactory, bool executeOnCapturedContext = false)
    {
        ArgumentNullException.ThrowIfNull(optionTask);
        ArgumentNullException.ThrowIfNull(alternativeOptionFactory);
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
        bool executeOnCapturedContext = false)
    {
        ArgumentNullException.ThrowIfNull(optionTask);
        ArgumentNullException.ThrowIfNull(exceptionFactory);
        var option = await optionTask.ConfigureAwait(executeOnCapturedContext);
        return option.WithException(exceptionFactory());
    }

    /// <summary>
    /// Flatten async
    /// </summary>
    /// <param name="optionTask"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<Maybe<T>> FlattenAsync<T>(this Task<Maybe<Maybe<T>>> optionTask)
    {
        ArgumentNullException.ThrowIfNull(optionTask);
        var option = await optionTask.ConfigureAwait(continueOnCapturedContext: false);
        return option.Flatten();
    }

    #endregion
}