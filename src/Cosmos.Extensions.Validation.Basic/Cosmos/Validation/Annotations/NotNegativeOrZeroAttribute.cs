using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Date;
using Cosmos.Numeric;
using Cosmos.Validation.Annotations.Internals;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Not negative or zero
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotNegativeOrZeroAttribute : ParameterInterceptorAttribute, IValidationParameter
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
            if (context.Parameter.IsIntType())
                context.Parameter.TryTo<int?>().RequirePositive(context.Parameter.Name, Message);
            else if (context.Parameter.IsLongType())
                context.Parameter.TryTo<long?>().RequirePositive(context.Parameter.Name, Message);
            else if (context.Parameter.IsFloatType())
                context.Parameter.TryTo<float?>().RequirePositive(context.Parameter.Name, Message);
            else if (context.Parameter.IsDoubleType())
                context.Parameter.TryTo<double?>().RequirePositive(context.Parameter.Name, Message);
            else if (context.Parameter.IsDecimalType())
                context.Parameter.TryTo<decimal?>().RequirePositive(context.Parameter.Name, Message);
            else if (context.Parameter.IsTimeSpanType())
                context.Parameter.TryTo<TimeSpan?>().RequirePositive(context.Parameter.Name, Message);
            return next(context);
        }
    }
}