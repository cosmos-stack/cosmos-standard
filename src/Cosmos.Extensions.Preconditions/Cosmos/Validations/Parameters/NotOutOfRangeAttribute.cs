using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Extensions;
using Cosmos.Numeric;
using Cosmos.Optionals;
using Cosmos.Validations.Parameters.Internals;

namespace Cosmos.Validations.Parameters
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
                context.Parameter.TryTo<int?>().SafeValue().CheckOutOfRange(IntMin, IntMax, context.Parameter.Name, Message);
            else if (context.Parameter.IsLongType())
                context.Parameter.TryTo<long?>().SafeValue().CheckOutOfRange(LongMin, LongMax, context.Parameter.Name, Message);
            else if (context.Parameter.IsFloatType())
                context.Parameter.TryTo<float?>().SafeValue().CheckOutOfRange(FloatMin, FloatMax, context.Parameter.Name, Message);
            else if (context.Parameter.IsDoubleType())
                context.Parameter.TryTo<double?>().SafeValue().CheckOutOfRange(DoubleMin, DoubleMax, context.Parameter.Name, Message);
            else if (context.Parameter.IsDecimalType())
                context.Parameter.TryTo<decimal?>().SafeValue().CheckOutOfRange(DecimalMin, DecimalMax, context.Parameter.Name, Message);
            return next(context);
        }

        private long LongMin => Min.TryTo(NumberConstants.LongMin);

        private long LongMax => Max.TryTo(NumberConstants.LongMax);

        private int IntMin => Min.TryTo(NumberConstants.IntMin);

        private int IntMax => Max.TryTo(NumberConstants.IntMax);

        private float FloatMin => Min.TryTo(NumberConstants.FloatMin);

        private float FloatMax => Max.TryTo(NumberConstants.FloatMax);

        private double DoubleMin => Min.TryTo(NumberConstants.DoubleMin);

        private double DoubleMax => Max.TryTo(NumberConstants.DoubleMax);

        private decimal DecimalMin => Min.TryTo(NumberConstants.DecimalMin);

        private decimal DecimalMax => Max.TryTo(NumberConstants.DecimalMax);
    }
}