using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Numeric;
using Cosmos.Validation.Parameters.Internals;

namespace Cosmos.Validation.Parameters
{
    /// <summary>
    /// Not out of range
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotOutOfRangeAttribute : ParameterInterceptorAttribute, IValidationParameter
    {
        /// <inheritdoc />
        public string Message { get; set; }

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
                context.Parameter.TryTo<int?>().RequireWithinRange(IntMin, IntMax, context.Parameter.Name, Message);
            else if (context.Parameter.IsLongType())
                context.Parameter.TryTo<long?>().RequireWithinRange(LongMin, LongMax, context.Parameter.Name, Message);
            else if (context.Parameter.IsFloatType())
                context.Parameter.TryTo<float?>().RequireWithinRange(FloatMin, FloatMax, context.Parameter.Name, Message);
            else if (context.Parameter.IsDoubleType())
                context.Parameter.TryTo<double?>().RequireWithinRange(DoubleMin, DoubleMax, context.Parameter.Name, Message);
            else if (context.Parameter.IsDecimalType())
                context.Parameter.TryTo<decimal?>().RequireWithinRange(DecimalMin, DecimalMax, context.Parameter.Name, Message);
            return next(context);
        }

        private long LongMin => Min.TryTo(NumericConstants.LongMin);

        private long LongMax => Max.TryTo(NumericConstants.LongMax);

        private int IntMin => Min.TryTo(NumericConstants.IntMin);

        private int IntMax => Max.TryTo(NumericConstants.IntMax);

        private float FloatMin => Min.TryTo(NumericConstants.FloatMin);

        private float FloatMax => Max.TryTo(NumericConstants.FloatMax);

        private double DoubleMin => Min.TryTo(NumericConstants.DoubleMin);

        private double DoubleMax => Max.TryTo(NumericConstants.DoubleMax);

        private decimal DecimalMin => Min.TryTo(NumericConstants.DecimalMin);

        private decimal DecimalMax => Max.TryTo(NumericConstants.DecimalMax);
    }
}