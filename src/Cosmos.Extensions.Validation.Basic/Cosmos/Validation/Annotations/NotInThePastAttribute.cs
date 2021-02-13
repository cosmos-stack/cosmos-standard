using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Date;
using Cosmos.Validation.Annotations.Core;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// /Not in past
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class NotInThePastAttribute : ValidationParameterAttribute
    {
        /// <summary>
        /// Name of this Attribute/Annotation
        /// </summary>
        public override string Name => "Not-In-The-Past Annotation";
        
        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.IsDateTimeType())
                DateGuard.ShouldBeInTheFuture(context.Parameter.TryTo<DateTime?>(), context.Parameter.Name, ErrorMessage);
            return next(context);
        }
    }
}