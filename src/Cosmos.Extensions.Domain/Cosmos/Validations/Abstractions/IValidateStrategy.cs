using FluentValidation.Results;

namespace Cosmos.Validations.Abstractions
{
    /// <summary>
    /// Interface for validate strategy
    /// </summary>
    public interface IValidateStrategy
    {
        /// <summary>
        /// Strategy Name
        /// </summary>
        string StrategyName { get; }
    }

    /// <summary>
    /// Interface for validate strategy
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public interface IValidateStrategy<in TObject> : IValidateStrategy
    where TObject : class, IValidatable
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        ValidationResult Validate(TObject obj);
    }
}