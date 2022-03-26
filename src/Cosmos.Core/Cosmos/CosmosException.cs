using System.Runtime.Serialization;
using Cosmos.Exceptions;

// ReSharper disable InconsistentNaming
namespace Cosmos;

/// <summary>
/// Cosmos.Core base exception <br />
/// 异常基类
/// </summary>
public abstract class CosmosException : Exception
{
    /// <summary>
    /// Empty flag <br />
    /// 空 标记位
    /// </summary>
    protected const string EMPTY_FLAG = "__EMPTY_FLG";

    /// <summary>
    /// Default error message for cosmos exception <br />
    /// 默认错误信息
    /// </summary>
    protected const string DEFAULT_ERROR_MESSAGE = "_DEFAULT_ERROR";

    /// <summary>
    /// Default error code for cosmos exception <br />
    /// 默认错误编码
    /// </summary>
    protected const long DEFAULT_ERROR_CODE = 1001;

    /// <summary>
    /// Default extend error code for cosmos exception <br />
    /// 默认扩展错误编码
    /// </summary>
    protected const long DEFAULT_EXTEND_ERROR_CODE = 1002;

    /// <summary>
    /// Create a new cosmos exception instance. <br />
    /// 创建一个新实例
    /// </summary>
    protected CosmosException()
        : this(DEFAULT_ERROR_CODE, DEFAULT_ERROR_MESSAGE, EMPTY_FLAG) { }

    /// <summary>
    /// Create a new cosmos exception instance. <br />
    /// 创建一个新实例
    /// </summary>
    /// <param name="errorMessage"></param>
    /// <param name="innerException"></param>
    protected CosmosException(string errorMessage, Exception innerException = null)
        : this(errorMessage, EMPTY_FLAG, innerException) { }

    /// <summary>
    /// Create a new cosmos exception instance. <br />
    /// 创建一个新实例
    /// </summary>
    /// <param name="errorMessage"></param>
    /// <param name="flag"></param>
    /// <param name="innerException"></param>
    protected CosmosException(string errorMessage, string flag, Exception innerException = null)
        : this(DEFAULT_EXTEND_ERROR_CODE, errorMessage, flag, innerException) { }

    /// <summary>
    /// Create a new cosmos exception instance. <br />
    /// 创建一个新实例
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="errorMessage"></param>
    /// <param name="innerException"></param>
    protected CosmosException(long errorCode, string errorMessage, Exception innerException = null)
        : this(errorCode, errorMessage, EMPTY_FLAG, innerException) { }

    /// <summary>
    /// Create a new cosmos exception instance. <br />
    /// 创建一个新实例
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected CosmosException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        ExtraData = new Dictionary<string, object>();
        Code = DEFAULT_EXTEND_ERROR_CODE;
        Flag = EMPTY_FLAG;
    }

    /// <summary>
    /// Create a new cosmos exception instance. <br />
    /// 创建一个新实例
    /// </summary>
    /// <param name="errorCode"></param>
    /// <param name="errorMessage"></param>
    /// <param name="flag"></param>
    /// <param name="innerException"></param>
    protected CosmosException(long errorCode, string errorMessage, string flag, Exception innerException = null)
        : base(errorMessage, innerException)
    {
        if (string.IsNullOrWhiteSpace(flag))
        {
            flag = EMPTY_FLAG;
        }

        ExtraData = new Dictionary<string, object>();
        Code = errorCode;
        Flag = flag;
    }

    /// <summary>
    /// Create a new cosmos exception instance. <br />
    /// 创建一个新实例
    /// </summary>
    /// <param name="options"></param>
    protected CosmosException(ExceptionOptions options) : base(options.Message, options.InnerException)
    {
        ExtraData = options.ExtraErrors;
        Code = options.ErrorCode;
        Flag = options.Flag;
    }

    /// <summary>
    /// Error code <br />
    /// 错误编码
    /// </summary>
    public long Code { get; protected set; }

    /// <summary>
    /// Error flag <br />
    /// 错误标记位
    /// </summary>
    public string Flag { get; protected set; }

    /// <summary>
    /// Extra data <br />
    /// 扩展数据
    /// </summary>
    public Dictionary<string, object> ExtraData { get; }

    /// <summary>
    /// Get full message <br />
    /// 获取完整的异常信息
    /// </summary>
    /// <returns></returns>
    public virtual string GetFullMessage() => $"{Code}:({Flag}){Message}";

    /// <summary>
    /// Throw me. <br />
    /// 抛出异常
    /// </summary>
    public virtual void Throw()
    {
        ExceptionHelper.PrepareForRethrow(this);
    }
}