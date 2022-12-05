using Cosmos.Expressions.Internals;

namespace Cosmos.Expressions;

public class ExpressionParseException : CosmosException
{
    private const string DEFAULT_ERROR_MSG = "Expression parse failed.";
    private const string FLAG = "__EXPRESSION_PARSE_FLG";
    private const long ERROR_CODE = 1062;

    /// <summary>
    /// Create a new instance of <see cref="ExpressionParseException"/>. <br />
    /// 创建一个新的 <see cref="ExpressionParseException"/> 实例。
    /// </summary>
    /// <param name="cause"></param>
    public ExpressionParseException(string cause)
        : base(ERROR_CODE, cause, FLAG)
    {
        Cause = string.IsNullOrWhiteSpace(cause) ? DEFAULT_ERROR_MSG : cause;
    }

    /// <summary>
    /// Create a new instance of <see cref="ExpressionParseException"/>. <br />
    /// 创建一个新的 <see cref="ExpressionParseException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    public ExpressionParseException(Exception exception, string cause)
        : base(ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, FLAG, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="ExpressionParseException"/>. <br />
    /// 创建一个新的 <see cref="ExpressionParseException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    /// <param name="flag"></param>
    public ExpressionParseException(Exception exception, string cause, string flag)
        : base(ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, flag, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="ExpressionParseException"/>. <br />
    /// 创建一个新的 <see cref="ExpressionParseException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    /// <param name="errorCode"></param>
    public ExpressionParseException(Exception exception, string cause, long errorCode)
        : base(errorCode, exception?.Message ?? DEFAULT_ERROR_MSG, FLAG, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="ExpressionParseException"/>. <br />
    /// 创建一个新的 <see cref="ExpressionParseException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    /// <param name="flag"></param>
    /// <param name="errorCode"></param>
    public ExpressionParseException(Exception exception, string cause, string flag, long errorCode)
        : base(errorCode, exception?.Message ?? DEFAULT_ERROR_MSG, flag, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    /// Create a new instance of <see cref="ExpressionParseException"/>. <br />
    /// 创建一个新的 <see cref="ExpressionParseException"/> 实例。
    /// </summary>
    /// <param name="exception"></param>
    /// <param name="cause"></param>
    public ExpressionParseException(CosmosException exception, string cause)
        : base(exception?.Code ?? ERROR_CODE, exception?.Message ?? DEFAULT_ERROR_MSG, exception?.Flag ?? FLAG, exception)
    {
        Cause = cause ?? exception?.Message ?? DEFAULT_ERROR_MSG;
    }

    /// <summary>
    ///Create a new instance of <see cref="ExpressionParseException"/>. <br />
    /// 创建一个新的 <see cref="ExpressionParseException"/> 实例。
    /// </summary>
    /// <param name="cause"></param>
    /// <param name="input"></param>
    /// <param name="token"></param>
    internal ExpressionParseException(string cause, string input, Token token)
        : base(ERROR_CODE, GetErrorMessage(cause, token, input), FLAG)
    {
        Cause = string.IsNullOrWhiteSpace(cause) ? DEFAULT_ERROR_MSG : cause;
    }

    /// <summary>
    /// Cause <br />
    /// 导致异常的原因
    /// </summary>
    public string Cause { get; }

    private static string GetErrorMessage(string cause, Token token, string input = null)
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{cause} at position of index '{token.Index}'");
        if (token.Index - 7 >= 0)
            builder.AppendLine(input?.Substring(token.Index - 7, 7));
        else
            builder.AppendLine(input?[..token.Index] ?? "");
        builder.AppendLine($"`{input?.Substring(token.Index, token.Length)}`");
        return builder.ToString();
    }
}