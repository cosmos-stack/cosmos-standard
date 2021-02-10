using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Reflection;
using Cosmos.Validation.Annotations.Core;

namespace Cosmos.Validation.Annotations
{
    /// <summary>
    /// Must
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class MustIntAttribute : ValidationParameterAttribute
    {
        /// <summary>
        /// May be nullable
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
                Message, context.Parameter.Name);
            return next(context);
        }
    }
}