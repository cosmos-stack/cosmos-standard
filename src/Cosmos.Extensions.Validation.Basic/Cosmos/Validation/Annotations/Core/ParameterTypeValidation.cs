using System;

namespace Cosmos.Validation.Annotations.Core
{
    /// <summary>
    /// Parameter type validation<br />
    /// 参数类型验证
    /// </summary>
    internal class ParameterTypeValidation : IOperationResult<bool>
    {
        /// <summary>
        /// Create a new instance of <see cref="ParameterTypeValidation"/><br />
        /// 创建一个参数类型验证实例
        /// </summary>
        /// <param name="result"></param>
        /// <param name="parameterType"></param>
        public ParameterTypeValidation(bool result, Type parameterType)
        {
            Result = result;
            ParameterType = parameterType;
        }

        /// <inheritdoc />
        public bool Result { get; }

        /// <summary>
        /// Gets parameter type<br />
        /// 获取参数类型
        /// </summary>
        public Type ParameterType { get; }

        /// <summary>
        /// Convert instance of <see cref="ParameterTypeValidation"/> to <see cref="System.Boolean"/>.<br />
        /// 隐式转换为布尔值
        /// </summary>
        /// <param name="result">被转换的参数类型验证对象</param>
        /// <returns>返回布尔值结果</returns>
        public static implicit operator bool(ParameterTypeValidation result)
        {
            return result.Result;
        }
    }
}