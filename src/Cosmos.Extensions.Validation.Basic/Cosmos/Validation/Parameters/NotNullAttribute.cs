using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Reflection;
using Cosmos.Validation.Parameters.Internals;

namespace Cosmos.Validation.Parameters
{
    /// <summary>
    /// Not null
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotNullAttribute : ParameterInterceptorAttribute, IValidationParameter
    {
        /// <summary>
        /// Message
        /// </summary>
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
                context.Parameter.TryTo(string.Empty).CheckNull(context.Parameter.Name, Message);
            else
                context.Parameter.Value.CheckNull(context.Parameter.Name, Message);
            return next(context);
        }
    }
}