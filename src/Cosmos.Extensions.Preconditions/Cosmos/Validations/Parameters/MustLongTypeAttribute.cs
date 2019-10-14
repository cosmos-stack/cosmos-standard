using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Validations.Parameters.Internals;

namespace Cosmos.Validations.Parameters
{
    /// <summary>
    /// Must long
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class MustLongTypeAttribute : ParameterInterceptorAttribute, IValidationParameter
    {
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// My be nullable
        /// </summary>
        public bool MayBeNullable { get; set; }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            var condition = MayBeNullable
                ? context.Parameter.IsNot(TypeClass.LongClass).OrNot(TypeClass.LongNullableClass)
                : context.Parameter.Type.IsNot(TypeClass.LongClass);
            if (condition)
                throw new ArgumentException(Message, context.Parameter.Name);
            return next(context);
        }
    }
}