// ReSharper disable InconsistentNaming
namespace CosmosStack.Exceptions.BuildingServices
{
    /// <summary>
    /// Exception arg constants <br />
    /// 用于异常构建的参数常量
    /// </summary>
    public class ExceptionArgConstants
    {
        /// <summary>
        /// Message <br />
        /// 消息
        /// </summary>
        public const string MESSAGE = "message";

        /// <summary>
        /// Param Name <br />
        /// 参数名
        /// </summary>
        public const string PARAM_NAME = "paramName";

        /// <summary>
        /// Inner exception <br />
        /// 内置异常
        /// </summary>
        public const string INNER_EXCEPTION = "innerException";

        /// <summary>
        /// Inner exception, usage for InvalidProgramException <br />
        /// 内置异常，用于 InvalidProgramException
        /// </summary>
        public const string INNER = "inner";

        /// <summary>
        /// Actual value <br />
        /// 实际值
        /// </summary>
        public const string ACTUAL_VALUE = "actualValue";

        /// <summary>
        /// Error code <br />
        /// 错误码
        /// </summary>
        public const string ERROR_CODE = "errorCode";
    }
}