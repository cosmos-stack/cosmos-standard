using FluentValidation;

namespace Cosmos.Extensions
{
    /// <summary>
    /// Extensions for fluent validation
    /// </summary>
    public static partial class FluentValidationExtensions
    {
        /// <summary>
        /// Raise exception if empty
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="error"></param>
        /// <typeparam name="T"></typeparam>
        public static void RaiseExceptionIfEmpty<T>(this IRuleBuilder<T, string> ruleBuilder, (long, string, string) error)
        {
            ruleBuilder.NotEmpty().RaiseInternal(error);
        }
    }
}