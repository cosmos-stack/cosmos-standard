using System;
using Cosmos.Validations.Abstractions;
using FluentValidation;

namespace Cosmos.Validations
{
    /// <summary>
    /// Abstract validate strategy
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public abstract class ValidateStrategy<TObject> : AbstractValidator<TObject>, IValidateStrategy<TObject>
        where TObject : class, IValidatable
    {
        /// <summary>
        /// ValidateStrategy
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected ValidateStrategy(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(name);

            StrategyName = name;
        }

        /// <inheritdoc />
        public string StrategyName { get; }
    }
}