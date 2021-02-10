using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Reflection;
using Cosmos.Text;
using Cosmos.Validation.Annotations.Internals;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Not whitespace
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotWhiteSpaceAttribute : ParameterInterceptorAttribute, IValidationAnnotation
    {
        /// <inheritdoc />
        public string Message { get; set; }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.Type.Is(TypeClass.StringClazz))
                context.Parameter.TryTo(string.Empty).CheckBlank(context.Parameter.Name, Message);
            return next(context);
        }
    }
}