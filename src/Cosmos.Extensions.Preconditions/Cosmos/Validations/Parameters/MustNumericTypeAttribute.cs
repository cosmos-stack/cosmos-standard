using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Judgments;
using Cosmos.Reflection;
using Cosmos.Validations.Parameters.Internals;

namespace Cosmos.Validations.Parameters
{
    /// <summary>
    /// Music numeric type
    /// </summary>
    public class MustNumericTypeAttribute : ParameterInterceptorAttribute, IValidationParameter
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
        /// <exception cref="ArgumentInvalidException"></exception>
        public override Task Invoke(ParameterAspectContext context, ParameterAspectDelegate next)
        {
            var condition = MayBeNullable
                ? TypeJudgment.IsNumericType(context.Parameter.Type)
                : TypeJudgment.IsNumericType(context.Parameter.Type) && !TypeJudgment.IsNullableType(context.Parameter.Type);
            AssertionJudgment.Require2Validation<ArgumentInvalidException>(condition,
                Message, context.Parameter.Name);
            return next(context);
        }
    }
}