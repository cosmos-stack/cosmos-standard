using System.Collections.Generic;

namespace CosmosStack.Validation
{
    /// <summary>
    /// Interface, used to mark containing verification error messages <br />
    /// 接口，用于标记包含验证错误信息
    /// </summary>
    public interface IHasValidationErrors
    {
        /// <summary>
        /// Gets validation message <br />
        /// 获取验证消息
        /// </summary>
        IEnumerable<string> ValidationMessage { get; }
    }
}