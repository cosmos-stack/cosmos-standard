using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Judgments;
using Cosmos.Validations.Parameters.Internals;

namespace Cosmos.Validations.Parameters {
    /// <summary>
    /// Must in type...
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
    public class MustIntTypeAttribute : ParameterInterceptorAttribute, IValidationParameter {
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
        /// <exception cref="ArgumentInvalidException"></exception>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next) {
            var condition = MayBeNullable
                ? context.Parameter.IsNot(TypeClass.IntClass).OrNot(TypeClass.IntNullableClass)
                : context.Parameter.Type.IsNot(TypeClass.IntClass);
            AssertionJudgment.Require2Validation<ArgumentInvalidException>(condition,
                Message, context.Parameter.Name);
            return next(context);
        }
    }
}