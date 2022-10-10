namespace Cosmos.Expressions;

public class TokenParseException : CosmosException
{
    private const string DEFAULT_ERROR_MSG = "Token parse failed.";
    private const string FLAG = "__TOKEN_PARSE_FLG";
    private const long ERROR_CODE = 1061;

    /// <summary>
    /// Create a new instance of <see cref="TokenParseException"/>. <br />
    /// 创建一个新的 <see cref="TokenParseException"/> 实例。
    /// </summary>
    /// <param name="cause"></param>
    public TokenParseException(string cause)
        : base(ERROR_CODE, cause, FLAG)
    {
        Cause = string.IsNullOrWhiteSpace(cause) ? DEFAULT_ERROR_MSG : cause;
    }

    /// <summary>
    /// Create a new instance of <see cref="TokenParseException"/>. <br />
    /// 创建一个新的 <see cref="TokenParseException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    public TokenParseException(Exception exception, string cause)
        : base(ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, FLAG, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="TokenParseException"/>. <br />
    /// 创建一个新的 <see cref="TokenParseException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    /// <param name="flag"></param>
    public TokenParseException(Exception exception, string cause, string flag)
        : base(ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, flag, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="TokenParseException"/>. <br />
    /// 创建一个新的 <see cref="TokenParseException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    /// <param name="errorCode"></param>
    public TokenParseException(Exception exception, string cause, long errorCode)
        : base(errorCode, exception?.Message ?? DEFAULT_ERROR_MSG, FLAG, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="TokenParseException"/>. <br />
    /// 创建一个新的 <see cref="TokenParseException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    /// <param name="flag"></param>
    /// <param name="errorCode"></param>
    public TokenParseException(Exception exception, string cause, string flag, long errorCode)
        : base(errorCode, exception?.Message ?? DEFAULT_ERROR_MSG, flag, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="TokenParseException"/>. <br />
    /// 创建一个新的 <see cref="TokenParseException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    public TokenParseException(CosmosException exception, string cause)
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