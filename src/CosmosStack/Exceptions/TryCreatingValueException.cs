namespace Cosmos.Exceptions;

/// <summary>
/// Creating value exception for Try <br />
/// 尝试组件的异常封装
/// </summary>
public sealed class TryCreatingValueException : CosmosException
{
    private const string DEFAULT_ERROR_MSG = "An unknown exception occurred while trying to create value.";
    private const string FLAG = "__TRY_CREATE_FLG";
    private const long ERROR_CODE = 1052;

    /// <summary>
    /// Create a new instance of <see cref="TryCreatingValueException"/>. <br />
    /// 创建一个新的 <see cref="TryCreatingValueException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    public TryCreatingValueException(Exception? exception, string? cause)
        : base(ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, FLAG, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="TryCreatingValueException"/>. <br />
    /// 创建一个新的 <see cref="TryCreatingValueException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    /// <param name="flag"></param>
    public TryCreatingValueException(Exception? exception, string? cause, string flag)
        : base(ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, flag, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="TryCreatingValueException"/>. <br />
    /// 创建一个新的 <see cref="TryCreatingValueException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    /// <param name="errorCode"></param>
    public TryCreatingValueException(Exception? exception, string? cause, long errorCode)
        : base(errorCode, exception?.Message ?? DEFAULT_ERROR_MSG, FLAG, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="TryCreatingValueException"/>. <br />
    /// 创建一个新的 <see cref="TryCreatingValueException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    /// <param name="flag"></param>
    /// <param name="errorCode"></param>
    public TryCreatingValueException(Exception? exception, string? cause, string flag, long errorCode)
        : base(errorCode, exception?.Message ?? DEFAULT_ERROR_MSG, flag, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="TryCreatingValueException"/>. <br />
    /// 创建一个新的 <see cref="TryCreatingValueException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    public TryCreatingValueException(CosmosException? exception, string? cause)
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