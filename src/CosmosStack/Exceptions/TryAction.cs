namespace Cosmos.Exceptions;

/// <summary>
/// Try action <br />
/// Try Action 组件
/// </summary>
public abstract class TryAction
{
    /// <summary>
    /// Is failure <br />
    /// 标记是否为失败
    /// </summary>
    public abstract bool IsFailure { get; }

    /// <summary>
    /// Is success <br />
    /// 标记是否为成功
    /// </summary>
    public abstract bool IsSuccess { get; }

    /// <summary>
    /// Exception <br />
    /// 异常
    /// </summary>
    public abstract TryInvokingException? Exception { get; }

    /// <summary>
    /// Cause <br />
    /// 发生异常的原因
    /// </summary>
    public abstract string Cause { get; }

    /// <summary>
    /// ==
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(TryAction? left, TryAction? right)
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
    public static bool operator !=(TryAction? left, TryAction? right) => !(left == right);

    /// <inheritdoc/>
    public abstract override string ToString();

    /// <inheritdoc/>
    public abstract override bool Equals(object? obj);

    /// <inheritdoc/>
    public abstract override int GetHashCode();

    /// <summary>
    /// Deconstruct
    /// </summary>
    /// <param name="tryResult"></param>
    /// <param name="exception"></param>
    public abstract void Deconstruct(out bool tryResult, out TryInvokingException? exception);

    /// <summary>
    /// Exception as
    /// </summary>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    public TException? ExceptionAs<TException>() where TException : Exception => Exception as TException;

    /// <summary>
    /// Recover
    /// </summary>
    /// <param name="recoverFunction"></param>
    /// <returns></returns>
    public abstract TryAction Recover(Action<Exception?> recoverFunction);

    /// <summary>
    /// Recover with
    /// </summary>
    /// <param name="recoverFunction"></param>
    /// <returns></returns>
    public abstract TryAction RecoverWith(Func<Exception?, TryAction> recoverFunction);

    /// <summary>
    /// Tap
    /// </summary>
    /// <param name="successFunction"></param>
    /// <param name="failureFunction"></param>
    /// <returns></returns>
    public abstract TryAction Tap(Action? successFunction = null, Action<Exception?>? failureFunction = null);
}