// ReSharper disable InconsistentNaming

namespace Cosmos.Exceptions;

/// <summary>
/// Options for cosmos exception <br />
/// 异常选项
/// </summary>
public class ExceptionOptions
{
    /// <summary>
    /// Empty flag <br />
    /// 空标识
    /// </summary>
    protected const string EMPTY_FLAG = "__EMPTY_FLG";

    /// <summary>
    /// Default error message <br />
    /// 默认的异常信息
    /// </summary>
    protected const string DEFAULT_ERROR_MESSAGE = "_DEFAULT_ERROR";

    /// <summary>
    /// Default extend error code <br />
    /// 默认的扩展异常编号
    /// </summary>
    protected const long DEFAULT_EXTEND_ERROR_CODE = 1002;

    /// <summary>
    /// Gets for sets error message, default is <see cref="DEFAULT_ERROR_MESSAGE"/>. <br />
    /// 异常信息
    /// </summary>
    public string Message { get; set; } = DEFAULT_ERROR_MESSAGE;

    /// <summary>
    /// Gets or sets error flag, default is <see cref="EMPTY_FLAG"/>. <br />
    /// 标识
    /// </summary>
    public string Flag { get; set; } = EMPTY_FLAG;

    /// <summary>
    /// Gets or sets error code, default is <see cref="DEFAULT_EXTEND_ERROR_CODE"/>. <br />
    /// 错误编号
    /// </summary>
    public long ErrorCode { get; set; } = DEFAULT_EXTEND_ERROR_CODE;

    /// <summary>
    /// Gets or sets inner exception. <br />
    /// 内部异常
    /// </summary>
    public Exception? InnerException { get; set; }

    /// <summary>
    /// Gets or sets extra errors <br />
    /// 获取或写入额外的错误信息
    /// </summary>
    public Dictionary<string, object> ExtraErrors { get; set; } = new();
}