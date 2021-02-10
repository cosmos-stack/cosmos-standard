using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Conversions.Determiners;
using Cosmos.Date;
using Cosmos.Validation.Annotations.Core;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Valid date
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class ValidDateValueAttribute : ValidationParameterAttribute, IQuietVerifiableAnnotation
    {
        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.IsDateTimeType())
                context.Parameter.TryTo<DateTime?>().CheckInvalidDate(context.Parameter.Name, Message);
            return next(context);
        }

        /// <summary>
        /// Quiet Verify
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool QuietVerify<T>(T instance)
        {
            if (instance is null)
                return false;

            if (typeof(T).Is<DateTime>() || typeof(T).Is<DateTime?>())
                return true;

            return instance switch
            {
                string str => StringDateTimeDeterminer.Is(str),
                _ => StringDateTimeDeterminer.Is(instance.ToString())
            };
        }
    }
}