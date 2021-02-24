using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Conversions.Determiners;
using Cosmos.Date;
using Cosmos.Reflection;
using Cosmos.Text;
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
        /// Name of this Attribute/Annotation
        /// </summary>
        public override string Name => "Valid-Date-Value Annotation";

        /// <summary>
        /// Gets or sets message<br />
        /// 消息
        /// </summary>
        public override string ErrorMessage { get; set; } = "The current value is not a valid time or date.";

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            if (context.Parameter.IsDateTimeType())
                context.Parameter.TryTo<DateTime?>().CheckInvalidDate(context.Parameter.Name, ErrorMessage);
            else if (context.Parameter.Is(TypeClass.StringClazz))
                ValidationExceptionHelper.WrapAndRaise<ArgumentInvalidException>(
                    context.Parameter.TryTo<string>().IsDateTime(),
                    ErrorMessage, context.Parameter.Name);
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

        /// <summary>
        /// Quiet Verify
        /// </summary>
        /// <param name="type"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public bool QuietVerify(Type type, object instance)
        {
            if (instance is null)
                return false;

            if (instance is DateTime)
                return true;

            return instance switch
            {
                string str => StringDateTimeDeterminer.Is(str),
                _ => StringDateTimeDeterminer.Is(instance.ToString())
            };
        }
    }
}