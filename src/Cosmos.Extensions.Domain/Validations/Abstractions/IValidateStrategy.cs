using FluentValidation.Results;

namespace Cosmos.Validations.Abstractions
{
    public interface IValidateStrategy
    {
        string StrategyName { get; }
    }

    public interface IValidateStrategy<in TObject> : IValidateStrategy
        where TObject : class, IValidatable
    {
        ValidationResult Validate(TObject obj);
    }
}