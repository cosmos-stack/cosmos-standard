using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Numeric;
using Cosmos.Validation.Annotations.Core;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Not out of range
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotOutOfRangeAttribute : ValidationParameterAttribute 
    {
        /// <summary>
        /// Name of this Attribute/Annotation
        /// </summary>
        public override string Name => "Not-Out-Of-Range Annotation";
        
        /// <summary>
        /// Min
        /// </summary>
        public decimal Min { get; set; }

        /// <summary>
        /// Max
        /// </summary>
        public decimal Max { get; set; }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.IsIntType())
                context.Parameter.TryTo<int?>().RequireWithinRange(IntMin, IntMax, context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsLongType())
                context.Parameter.TryTo<long?>().RequireWithinRange(LongMin, LongMax, context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsFloatType())
                context.Parameter.TryTo<float?>().RequireWithinRange(FloatMin, FloatMax, context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsDoubleType())
                context.Parameter.TryTo<double?>().RequireWithinRange(DoubleMin, DoubleMax, context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.IsDecimalType())
                context.Parameter.TryTo<decimal?>().RequireWithinRange(DecimalMin, DecimalMax, context.Parameter.Name, ErrorMessage);
            return next(context);
        }

        private long LongMin => Min.TryTo(NumericConstants.LONG_MIN);

        private long LongMax => Max.TryTo(NumericConstants.LONG_MAX);

        private int IntMin => Min.TryTo(NumericConstants.INT_MIN);

        private int IntMax => Max.TryTo(NumericConstants.INT_MAX);

        private float FloatMin => Min.TryTo(NumericConstants.FLOAT_MIN);

        private float FloatMax => Max.TryTo(NumericConstants.FLOAT_MAX);

        private double DoubleMin => Min.TryTo(NumericConstants.DOUBLE_MIN);

        private double DoubleMax => Max.TryTo(NumericConstants.DOUBLE_MAX);

        private decimal DecimalMin => Min.TryTo(NumericConstants.DECIMAL_MIN);

        private decimal DecimalMax => Max.TryTo(NumericConstants.DECIMAL_MAX);
    }
}