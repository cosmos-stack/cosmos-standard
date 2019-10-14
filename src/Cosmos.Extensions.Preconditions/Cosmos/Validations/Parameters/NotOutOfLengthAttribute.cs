using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Validations.Parameters.Internals;

namespace Cosmos.Validations.Parameters
{
    /// <summary>
    /// Not out of length
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotOutOfLengthAttribute : ParameterInterceptorAttribute, IValidationParameter
    {
        /// <inheritdoc />
        public string Message { get; set; }

        /// <summary>
        /// Length
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.Type.Is(TypeClass.StringClass))
                context.Parameter.TryTo(TypeDefault.StringEmpty).CheckOutOfLength(Length, context.Parameter.Name, Message);
            return next(context);
        }
    }
}