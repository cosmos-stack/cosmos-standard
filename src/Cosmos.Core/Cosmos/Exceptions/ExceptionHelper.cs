using System.Runtime.ExceptionServices;
using Cosmos.Reflection;

namespace Cosmos.Exceptions;

/// <summary>
/// Exception helper <br />
/// 异常工具
/// </summary>
public static class ExceptionHelper
{
    /// <summary>
    /// Prepare for rethrow <br />
    /// 重新抛出异常
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Exception PrepareForRethrow(Exception exception)
    {
        ExceptionDispatchInfo.Capture(exception).Throw();

        // The code cannot ever get here. We just return a value to work around a badly-designed API (ExceptionDispatchInfo.Throw):
        //  https://connect.microsoft.com/VisualStudio/feedback/details/689516/exceptiondispatchinfo-api-modifications (http://www.webcitation.org/6XQ7RoJmO)
        return exception;
    }

    /// <summary>
    /// Unwrap<br />
    /// 解包
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public static Exception Unwrap(Exception exception)
    {
        ArgumentNullException.ThrowIfNull(exception);
        while (exception.InnerException != null)
            exception = exception.InnerException;
        return exception;
    }

    /// <summary>
    /// Unwrap<br />
    /// 解包
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="untilType"></param>
    /// <param name="mayDerivedClass"></param>
    /// <returns></returns>
    public static Exception Unwrap(Exception exception, Type untilType, bool mayDerivedClass = true)
    {
        ArgumentNullException.ThrowIfNull(exception);
        ArgumentNullException.ThrowIfNull(untilType);
        if (!untilType.IsSubclassOf(typeof(Exception)))
            throw new ArgumentException($"Type '{untilType}' does not be divided from {typeof(Exception)}", nameof(untilType));

        return exception.GetType() == untilType || mayDerivedClass && exception.GetType().IsSubclassOf(untilType)
            ? exception
            : exception.InnerException is null
                ? null
                : Unwrap(exception.InnerException, untilType, mayDerivedClass);
    }

    /// <summary>
    /// Unwrap<br />
    /// 解包
    /// </summary>
    /// <typeparam name="TException"></typeparam>
    /// <param name="exception"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Exception Unwrap<TException>(Exception exception) where TException : Exception
    {
        return exception.Unwrap(Types.Of<TException>());
    }
}

/// <summary>
/// Cosmos.Core <see cref="Exception"/> extensions. <br />
/// 异常工具扩展
/// </summary>
public static class ExceptionHelperExtensions
{
    /// <summary>
    /// Unwrap<br />
    /// 解包
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public static Exception Unwrap(this Exception exception)
    {
        return ExceptionHelper.Unwrap(exception);
    }

    /// <summary>
    /// Unwrap<br />
    /// 解包
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="untilType"></param>
    /// <param name="mayDerivedClass"></param>
    /// <returns></returns>
    public static Exception Unwrap(this Exception exception, Type untilType, bool mayDerivedClass = true)
    {
        return ExceptionHelper.Unwrap(exception, untilType, mayDerivedClass);
    }

    /// <summary>
    /// Unwrap<br />
    /// 解包
    /// </summary>
    /// <typeparam name="TException"></typeparam>
    /// <param name="exception"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Exception Unwrap<TException>(this Exception exception) where TException : Exception
    {
        return ExceptionHelper.Unwrap<TException>(exception);
    }

    /// <summary>
    /// Unwrap and gets message<br />
    /// 解包并返回消息
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToUnwrappedString(this Exception exception)
    {
        return exception.Unwrap().Message;
    }

    /// <summary>
    /// Unwrap and gets full message<br />
    /// 解包，尝试返回完整信息
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public static string ToFullUnwrappedString(this Exception exception)
    {
        var sb = new StringBuilder();
        if (exception is CosmosException cosmosException)
        {
            sb.AppendLine(cosmosException.GetFullMessage());
            if (exception.InnerException != null)
            {
                sb.Append(exception.InnerException.ToUnwrappedString());
            }
        }
        else
        {
            sb.Append(exception.ToUnwrappedString());
        }

        return sb.ToString();
    }
}