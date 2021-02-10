using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Reflection;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Music numeric type
    /// </summary>
    public class MustNumericTypeAttribute : ParameterInterceptorAttribute, IValidationAnnotation
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// My be nullable
        /// </summary>
        public bool MayBeNullable { get; set; }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentInvalidException"></exception>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            var condition = MayBeNullable
                ? Types.IsNumericType(context.Parameter.Type)
                : Types.IsNumericType(context.Parameter.Type) && !Types.IsNullableType(context.Parameter.Type);
            ValidationExceptionHelper.WrapAndRaise<ArgumentInvalidException>(condition,
                Message, context.Parameter.Name);
            return next(context);
        }
    }
}