using AspectCore.DynamicProxy.Parameters;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Validation Parameter attribute
    /// </summary>
    public abstract class ValidationParameterAttribute : ParameterInterceptorAttribute, IFlagAnnotation
    {
        /// <summary>
        /// Gets or sets message<br />
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }
}