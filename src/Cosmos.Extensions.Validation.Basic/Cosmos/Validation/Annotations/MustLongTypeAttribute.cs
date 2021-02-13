using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Reflection;
using Cosmos.Validation.Annotations.Core;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Must long
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class MustLongTypeAttribute : ValidationParameterAttribute
    {
        /// <summary>
        /// Name of this Attribute/Annotation
        /// </summary>
        public override string Name => "Must-Int64 Annotation";
        
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
        /// <exception cref="ArgumentInvalidException"></exception>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            var condition = MayBeNullable
                ? context.Parameter.IsNot(TypeClass.LongClazz).OrNot(TypeClass.LongNullableClazz)
                : context.Parameter.Type.IsNot(TypeClass.LongClazz);
            ValidationExceptionHelper.WrapAndRaise<ArgumentInvalidException>(condition,
                ErrorMessage, context.Parameter.Name);
            return next(context);
        }
    }
}