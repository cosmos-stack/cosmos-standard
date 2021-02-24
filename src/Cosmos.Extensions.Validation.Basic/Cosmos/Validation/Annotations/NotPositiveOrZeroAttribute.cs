using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Date;
using Cosmos.Numeric;
using Cosmos.Validation.Annotations.Core;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Not positive or zero
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotPositiveOrZeroAttribute: ValidationParameterAttribute
    {
        /// <summary>
        /// Name of this Attribute/Annotation
        /// </summary>
        public override string Name => "Not-Positive-Or-Zero Annotation";
        
        /// <summary>
        /// Gets or sets message<br />
        /// 消息
        /// </summary>
        public override string ErrorMessage { get; set; } = "The current value cannot be positive or zero.";
        
        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.IsIntType())
                context.Parameter.TryTo<int?>().RequireNegative(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsLongType())
                context.Parameter.TryTo<long?>().RequireNegative(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsFloatType())
                context.Parameter.TryTo<float?>().RequireNegative(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsDoubleType())
                context.Parameter.TryTo<double?>().RequireNegative(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsDecimalType())
                context.Parameter.TryTo<decimal?>().RequireNegative(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsTimeSpanType())
                context.Parameter.TryTo<TimeSpan?>().RequireNegative(context.Parameter.Name, ErrorMessage);
            return next(context);
        }
    }
}