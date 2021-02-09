using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Reflection;
using Cosmos.Validation.Annotations.Internals;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Must string type
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class MustStringTypeAttribute : ParameterInterceptorAttribute, IValidationParameter
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
        /// <exception cref="ArgumentInvalidException"></exception>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            ValidationExceptionHelper.WrapAndRaise<ArgumentInvalidException>(
                context.Parameter.Type.Is(TypeClass.StringClazz),
                Message, context.Parameter.Name);
            return next(context);
        }
    }
}