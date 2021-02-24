using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Date;
using Cosmos.Numeric;
using Cosmos.Validation.Annotations.Core;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Not positive
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotPositiveAttribute: ValidationParameterAttribute
    {
        /// <summary>
        /// Name of this Attribute/Annotation
        /// </summary>
        public override string Name => "Not-Positive Annotation";
        
        /// <summary>
        /// Gets or sets message<br />
        /// 消息
        /// </summary>
        public override string ErrorMessage { get; set; } = "The current value cannot be positive.";
        
        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.IsIntType())
                context.Parameter.TryTo<int?>().RequireNegativeOrZero(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsLongType())
                context.Parameter.TryTo<long?>().RequireNegativeOrZero(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsFloatType())
                context.Parameter.TryTo<float?>().RequireNegativeOrZero(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsDoubleType())
                context.Parameter.TryTo<double?>().RequireNegativeOrZero(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsDecimalType())
                context.Parameter.TryTo<decimal?>().RequireNegativeOrZero(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsTimeSpanType())
                context.Parameter.TryTo<TimeSpan?>().RequireNegativeOrZero(context.Parameter.Name, ErrorMessage);
            return next(context);
        }
    }
}