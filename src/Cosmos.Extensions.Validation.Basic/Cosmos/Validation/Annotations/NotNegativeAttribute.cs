using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Date;
using Cosmos.Numeric;
using Cosmos.Validation.Annotations.Core;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Not negative
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotNegativeAttribute : ValidationParameterAttribute
    {
        /// <summary>
        /// Name of this Attribute/Annotation
        /// </summary>
        public override string Name => "Not-Negative Annotation";
        
        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.IsIntType())
                context.Parameter.TryTo<int?>().RequirePositiveOrZero(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsLongType())
                context.Parameter.TryTo<long?>().RequirePositiveOrZero(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsFloatType())
                context.Parameter.TryTo<float?>().RequirePositiveOrZero(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsDoubleType())
                context.Parameter.TryTo<double?>().RequirePositiveOrZero(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsDecimalType())
                context.Parameter.TryTo<decimal?>().RequirePositiveOrZero(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsTimeSpanType())
                context.Parameter.TryTo<TimeSpan?>().RequirePositiveOrZero(context.Parameter.Name, ErrorMessage);
            return next(context);
        }
    }
}