using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Reflection;
using Cosmos.Validation.Annotations.Core;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Must in type...
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class MustIntTypeAttribute : ValidationParameterAttribute
    {
        /// <summary>
        /// Name of this Attribute/Annotation
        /// </summary>
        public override string Name => "Must-Int32 Annotation";
        
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
                ? context.Parameter.IsNot(TypeClass.IntClazz).OrNot(TypeClass.IntNullableClazz)
                : context.Parameter.Type.IsNot(TypeClass.IntClazz);
            ValidationExceptionHelper.WrapAndRaise<ArgumentInvalidException>(condition,
                ErrorMessage, context.Parameter.Name);
            return next(context);
        }
    }
}