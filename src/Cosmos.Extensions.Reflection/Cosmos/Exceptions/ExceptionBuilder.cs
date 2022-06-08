#if !NET451 && !NET452
using Cosmos.Exceptions.BuildingServices;
#endif

namespace Cosmos.Exceptions;

/// <summary>
/// Exception builder
/// </summary>
public static class ExceptionBuilder
{
#if !NET451 && !NET452
    /// <summary>
    /// Create a new builder for of <typeparamref name="TException"/> <see cref="FluentExceptionBuilder{TException}"/>.<br />
    /// 创建一个用于构建 <typeparamref name="TException"/> <see cref="FluentExceptionBuilder{TException}"/> 的 builder。
    /// </summary>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    public static IFluentExceptionBuilder<TException> Create<TException>() where TException : Exception
    {
        if (CustomExceptionBuildingManager.TryGetBuilder<TException>(out var b) && b is FluentExceptionBuilder<TException> builder)
            return builder;
        return new FluentExceptionBuilder<TException>();
    }

    /// <summary>
    /// Create a new builder for the given type of exception for <see cref="FluentExceptionBuilder"/>.<br />
    /// 创建一个用于构建指定异常类型的 builder。
    /// </summary>
    /// <returns></returns>
    public static IFluentExceptionBuilder Create(Type typeOfException)
    {
        if (CustomExceptionBuildingManager.TryGetBuilder(typeOfException, out var b) && b is FluentExceptionBuilder builder)
            return builder;
        return new FluentExceptionBuilder(typeOfException);
    }
#endif

    /// <summary>
    /// Create an exception and raise.
    /// </summary>
    /// <typeparam name="TException">Special type T.</typeparam>
    /// <param name="assertion">Predicate.</param>
    /// <param name="message">Error message.</param>
    public static void Raise<TException>(bool assertion, string message) where TException : Exception
    {
        if (assertion)
            return;

        Exception exception;

        if (string.IsNullOrEmpty(message))
        {
            exception = new ArgumentNullException(nameof(message));
        }
        else
        {
#if !NET451 && !NET452
            exception = Create<TException>().Message(message).Build();
#else
            exception = TypeVisit.CreateInstance<TException>(message);
#endif
        }

        ExceptionHelper.PrepareForRethrow(exception);
    }

    /// <summary>
    /// Create an exception and raise.
    /// </summary>
    /// <typeparam name="TException">Special type T.</typeparam>
    /// <param name="assertion">Predicate.</param>
    /// <param name="message">Error message.</param>
    /// <param name="innerException"></param>
    public static void Raise<TException>(bool assertion, string message, Exception innerException) where TException : Exception
    {
        if (assertion)
            return;

        Exception exception;

        if (string.IsNullOrEmpty(message))
        {
            exception = new ArgumentNullException(nameof(message));
        }
        else
        {
#if !NETFRAMEWORK
            exception = Create<TException>().Message(message).InnerException(innerException).Build();
#else
            exception = TypeVisit.CreateInstance<TException>(message, innerException);
#endif
        }

        ExceptionHelper.PrepareForRethrow(exception);
    }

    /// <summary>
    /// Create an exception and raise.
    /// </summary>
    /// <typeparam name="TException">Special type TException.</typeparam>
    /// <param name="assertion">Predicate.</param>
    /// <param name="exceptionParams">Parameters for exception.</param>
    public static void Raise<TException>(bool assertion, params object[] exceptionParams) where TException : Exception
    {
        if (assertion)
            return;

        var exception = TypeVisit.CreateInstance<TException>(exceptionParams);

        ExceptionHelper.PrepareForRethrow(exception);
    }

    /// <summary>
    /// Create an exception and raise.
    /// </summary>
    /// <typeparam name="TException">Special type TException.</typeparam>
    /// <param name="assertion">Predicate.</param>
    /// <param name="options">Cosmos.Core exception options.</param>
    public static void Raise<TException>(bool assertion, ExceptionOptions options) where TException : CosmosException
    {
        if (assertion)
            return;

        Exception exception;

        if (options is null)
        {
            exception = new ArgumentNullException(nameof(options));
        }
        else
        {
            exception = TypeVisit.CreateInstance<TException>(options);
        }

        ExceptionHelper.PrepareForRethrow(exception);
    }
}