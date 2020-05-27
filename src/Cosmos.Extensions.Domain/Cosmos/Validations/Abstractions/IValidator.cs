using System.Collections.Generic;

namespace Cosmos.Validations.Abstractions
{
    /// <summary>
    /// Interface for validator
    /// </summary>
    public interface IValidator { }

    /// <summary>
    /// Interface for validator
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public interface IValidator<out TObject> : IValidator
    where TObject : class, IValidatable
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="strategy"></param>
        void Validate(IValidateStrategy<TObject> strategy);

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="strategies"></param>
        void Validate(IEnumerable<IValidateStrategy<TObject>> strategies);

        /// <summary>
        /// Get validation result
        /// </summary>
        /// <returns></returns>
        ValidationResultCollection GetValidationResult();
    }
}