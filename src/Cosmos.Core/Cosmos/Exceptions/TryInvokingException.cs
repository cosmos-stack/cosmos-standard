namespace Cosmos.Exceptions;

/// <summary>
/// Try-invoking exception <br />
/// 尝试调用异常
/// </summary>
public sealed class TryInvokingException : CosmosException
{
    private const string DEFAULT_ERROR_MSG = "An unknown exception occurred while trying to call the delegate.";
    private const string FLAG = "__TRY_INVOK_FLG";
    private const long ERROR_CODE = 1051;

    /// <summary>
    /// Create a new instance of <see cref="TryInvokingException"/>. <br />
    /// 创建一个新的 <see cref="TryInvokingException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    public TryInvokingException(Exception exception, string cause)
        : base(ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, FLAG, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="TryInvokingException"/>. <br />
    /// 创建一个新的 <see cref="TryInvokingException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    /// <param name="flag"></param>
    public TryInvokingException(Exception exception, string cause, string flag)
        : base(ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, flag, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="TryInvokingException"/>. <br />
    /// 创建一个新的 <see cref="TryInvokingException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    /// <param name="errorCode"></param>
    public TryInvokingException(Exception exception, string cause, long errorCode)
        : base(errorCode, exception?.Message ?? DEFAULT_ERROR_MSG, FLAG, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="TryInvokingException"/>. <br />
    /// 创建一个新的 <see cref="TryInvokingException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    /// <param name="flag"></param>
    /// <param name="errorCode"></param>
    public TryInvokingException(Exception exception, string cause, string flag, long errorCode)
        : base(errorCode, exception?.Message ?? DEFAULT_ERROR_MSG, flag, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="TryInvokingException"/>. <br />
    /// 创建一个新的 <see cref="TryInvokingException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    public TryInvokingException(CosmosException exception, string cause)
        : base(exception?.Code ?? ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, exception?.Flag ?? FLAG, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Cause <br />
    /// 导致异常的原因
    /// </summary>
    public string Cause { get; }
}