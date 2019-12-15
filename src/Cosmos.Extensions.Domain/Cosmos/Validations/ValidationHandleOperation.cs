using System;
using System.Collections.Generic;
using Cosmos.Validations.Abstractions;
using FluentValidation.Results;

namespace Cosmos.Validations {
    /// <summary>
    /// Validation handle operation
    /// </summary>
    public sealed class ValidationHandleOperation {
        private readonly ValidationResultCollection _collection;

        /// <summary>
        /// Create a new instance of <see cref="ValidationHandleOperation"/>.
        /// </summary>
        /// <param name="collection"></param>
        public ValidationHandleOperation(ValidationResultCollection collection) {
            _collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }

        internal void Handle(IValidationHandler handler, Action<IEnumerable<ValidationResult>> filterFunc = null) {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));
            var coll = filterFunc == null ? _collection : _collection.Filter(filterFunc);

            if (coll == null)
                return;

            handler.Handle(coll);
        }

        internal void Handle(IValidationHandler handler, string strategyName) {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));
            var coll = _collection.Filter(strategyName);

            if (coll == null)
                return;

            handler.Handle(coll);
        }

        /// <summary>
        /// Raise exception
        /// </summary>
        /// <param name="appendAction"></param>
        /// <typeparam name="TException"></typeparam>
        public void RaiseException<TException>(Action<TException, ValidationResultCollection> appendAction = null)
            where TException : CosmosException, new() {
            _collection.RaiseException(appendAction);
        }
    }
}