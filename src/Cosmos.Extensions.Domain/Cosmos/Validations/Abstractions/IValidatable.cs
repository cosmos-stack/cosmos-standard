using System.Collections.Generic;

namespace Cosmos.Validations.Abstractions
{
    /// <summary>
    /// Interface for Validatabble
    /// </summary>
    public interface IValidatable { }

    /// <summary>
    /// Interface for Validatabble
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public interface IValidatable<TObject> : IValidatable
    where TObject : class, IValidatable
    {
        /// <summary>
        /// Set validate handler
        /// </summary>
        /// <param name="handler"></param>
        void SetValidateHandler(IValidationHandler handler);

        /// <summary>
        /// Add strategy
        /// </summary>
        /// <param name="strategy"></param>
        void AddStrategy(IValidateStrategy<TObject> strategy);

        /// <summary>
        /// Add strategy list
        /// </summary>
        /// <param name="strategies"></param>
        void AddStrategyList(IEnumerable<IValidateStrategy<TObject>> strategies);

        /// <summary>
        /// Validate
        /// </summary>
        /// <returns></returns>
        ValidationResultCollection Validate();
    }
}