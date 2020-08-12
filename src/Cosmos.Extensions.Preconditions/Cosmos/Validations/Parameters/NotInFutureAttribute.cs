using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Optionals;
using Cosmos.Validations.Parameters.Internals;

namespace Cosmos.Validations.Parameters
{
    /// <summary>
    /// Not in future
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotInFutureAttribute : ParameterInterceptorAttribute, IValidationParameter
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
            if (context.Parameter.IsDateTimeType())
                context.Parameter.TryTo<DateTime?>().SafeValue().CheckNotInFuture(context.Parameter.Name, Message);
            return next(context);
        }
    }
}