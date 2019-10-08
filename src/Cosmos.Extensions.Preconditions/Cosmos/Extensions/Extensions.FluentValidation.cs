using FluentValidation;

namespace Cosmos.Extensions
{
    /// <summary>
    /// Extensions for fluent validation
    /// </summary>
    public static partial class FluentValidationExtensions
    {
        private static void RaiseInternal<T, TProperty>(this IRuleBuilderOptions<T, TProperty> options, (long, string, string) error)
        {
            options
                .WithErrorCode($"{error.Item1}")
                .WithName(error.Item2)
                .WithMessage(error.Item3);
        }
    }
}