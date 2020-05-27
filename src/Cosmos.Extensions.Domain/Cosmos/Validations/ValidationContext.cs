using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Validations.Abstractions;

namespace Cosmos.Validations
{
    /// <summary>
    /// Validation context
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public class ValidationContext<TObject>
    where TObject : class, IValidatable<TObject>
    {
        private TObject Instance { get; set; }
        private List<IValidateStrategy<TObject>> ValidateStrategyList { get; }
        private ValidationResultCollection ResultCollection { get; set; }
        private Action<ValidationHandleOperation> Handle { get; set; }

        /// <summary>
        /// Create a new instance of <see><cref>ValidationContext</cref></see>.
        /// </summary>
        /// <param name="instanceToValidate"></param>
        public ValidationContext(TObject instanceToValidate)
        {
            Instance = instanceToValidate;
            ValidateStrategyList = new List<IValidateStrategy<TObject>>();
        }

        /// <summary>
        /// Add strategy
        /// </summary>
        /// <param name="strategy"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddStrategy(IValidateStrategy<TObject> strategy)
        {
            if (strategy == null)
                throw new ArgumentNullException(nameof(strategy));
            if (ValidateStrategyList.Any(x => x.StrategyName == strategy.StrategyName))
                return;
            ValidateStrategyList.Add(strategy);
        }

        /// <summary>
        /// Add strategy list
        /// </summary>
        /// <param name="strategies"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddStrategyList(IEnumerable<IValidateStrategy<TObject>> strategies)
        {
            if (strategies == null)
                throw new ArgumentNullException(nameof(strategies));

            foreach (var strategy in strategies)
                AddStrategy(strategy);
        }

        /// <summary>
        /// Set handler
        /// </summary>
        /// <param name="action"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetHandler(Action<ValidationHandleOperation> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (Handle == null)
            {
                Handle = action;
            }
            else
            {
                Handle += action;
            }
        }

        /// <summary>
        /// Raise exception
        /// </summary>
        /// <param name="appendAction"></param>
        /// <typeparam name="TException"></typeparam>
        public void RaiseException<TException>(Action<TException, ValidationResultCollection> appendAction = null)
        where TException : CosmosException, new()
        {
            if (ResultCollection != null && !ResultCollection.IsValid)
                ResultCollection.RaiseException(appendAction);
        }

        /// <summary>
        /// Validate
        /// </summary>
        public void Validate()
        {
            var tempList = ValidateStrategyList.Select(strategy => strategy.Validate(Instance)).ToList();
            ResultCollection = new ValidationResultCollection(tempList);
            Handle?.Invoke(ResultCollection.Handle());
        }

        /// <summary>
        /// Validate and raise
        /// </summary>
        /// <param name="appendAction"></param>
        /// <typeparam name="TException"></typeparam>
        public void ValidateAndRaise<TException>(Action<TException, ValidationResultCollection> appendAction = null)
        where TException : CosmosException, new()
        {
            Validate();
            RaiseException(appendAction);
        }

        /// <summary>
        /// Get validation result collection.
        /// </summary>
        /// <returns></returns>
        public ValidationResultCollection GetValidationResultCollection()
        {
            return ResultCollection;
        }

        /// <summary>
        /// Is valid
        /// </summary>
        public bool IsValid => ResultCollection?.IsValid ?? true;
    }
}