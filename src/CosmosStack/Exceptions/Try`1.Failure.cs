using System.Runtime.ExceptionServices;

namespace Cosmos.Exceptions;

/// <summary>
/// Failure <br />
/// 失败的 Try 组件
/// </summary>
/// <typeparam name="T"></typeparam>
public class Failure<T> : Try<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Failure{T}"/> class.
    /// </summary>
    /// <param name="exception">The exception to wrap.</param>
    /// <param name="cause"></param>
    internal Failure(Exception? exception, string? cause)
    {
        Exception = new TryCreatingValueException(exception, cause);
    }

    /// <inheritdoc />
    public override bool IsFailure => true;

    /// <inheritdoc />
    public override bool IsSuccess => false;

    /// <inheritdoc />
    public override TryCreatingValueException? Exception { get; }

    /// <inheritdoc />
    public override T Value => throw Rethrow();

    /// <inheritdoc />
    public override string ToString() => $"Failure<{Exception}>";

    /// <summary>
    /// Equals
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(Failure<T>? other) => !(other is null) && ReferenceEquals(Exception, other.Exception);

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Failure<T> failure && Equals(failure);

    /// <inheritdoc/>
    public override int GetHashCode() => Exception?.GetHashCode() ?? 0;

#pragma warning disable CS8601

    /// <inheritdoc />
    public override void Deconstruct(out T value, out Exception exception)
    {
        value = default;
        exception = Exception;
    }

    public override void Deconstruct(out T value, out bool tryResult, out Exception exception)
    {
        value = Value;
        tryResult = IsSuccess;
        exception = Exception;
    }

#pragma warning restore CS8601

    /// <inheritdoc />
    public override Try<T> Recover(Func<TryCreatingValueException?, T> recoverFunction)
    {
        return RecoverWith(ex => Try.LiftValue(recoverFunction(ex)));
    }

    /// <inheritdoc />
    public override Try<T> Recover(Func<Exception?, string?, T> recoverFunction)
    {
        return RecoverWith(ex => Try.LiftValue(recoverFunction(ex?.InnerException, ex?.Cause)));
    }

    /// <inheritdoc />
    public override Try<T> RecoverWith(Func<TryCreatingValueException?, Try<T>> recoverFunction)
    {
        try
        {
            return recoverFunction(Exception);
        }
        catch (Exception ex)
        {
            return new Failure<T>(ex, "An exception occurred during recovery.");
        }
    }

    /// <inheritdoc />
    public override Try<T> RecoverWith(Func<Exception?, string?, Try<T>> recoverFunction)
    {
        try
        {
            return recoverFunction(Exception?.InnerException, Exception?.Cause);
        }
        catch (Exception ex)
        {
            return new Failure<T>(ex, "An exception occurred during recovery.");
        }
    }

    /// <inheritdoc />
    public override TResult Match<TResult>(Func<T?, TResult> whenValue, Func<TryCreatingValueException?, TResult> whenException)
    {
        if (whenException is null)
            throw new ArgumentNullException(nameof(whenException));
        return whenException(Exception);
    }

    /// <inheritdoc />
    public override TResult Match<TResult>(Func<T?, TResult> whenValue, Func<Exception?, string?, TResult> whenException)
    {
        if (whenException is null)
            throw new ArgumentNullException(nameof(whenException));
        return whenException(Exception?.InnerException, Exception?.Cause);
    }

    /// <inheritdoc />
    public override Try<T> Tap(Action<T?>? successFunction = null, Action<TryCreatingValueException?>? failureFunction = null)
    {
        failureFunction?.Invoke(Exception);
        return this;
    }

    /// <inheritdoc />
    public override Try<T> Tap(Action<T?>? successFunction = null, Action<Exception?, string?>? failureFunction = null)
    {
        failureFunction?.Invoke(Exception?.InnerException, Exception?.Cause);
        return this;
    }

    internal override Try<TResult> Bind<TResult>(Func<T?, Try<TResult>> bind) => Try.LiftException<TResult>(Exception);

    private Exception Rethrow() => ExceptionDispatchInfo.Capture(Exception!).SourceException;
}