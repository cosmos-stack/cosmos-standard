using System;
using AspectCore.DynamicProxy.Parameters;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Validation Parameter attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public abstract class ValidationParameterAttribute : ParameterInterceptorAttribute, IFlagAnnotation
    {
        /// <summary>
        /// Name of this Attribute/Annotation
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets or sets message<br />
        /// 消息
        /// </summary>
        public virtual string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets name of parameter
        /// </summary>
        public string ParamName { get; set; }
    }
}