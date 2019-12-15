using System.Collections.Generic;
using Cosmos.Validations.Abstractions;

namespace Cosmos.Validations {
    /// <summary>
    /// Validate activator
    /// </summary>
    public static class ValidationActivator {
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="instance"></param>
        /// <typeparam name="TObject"></typeparam>
        /// <returns></returns>
        public static ValidationResultCollection Validate<TObject>(TObject instance)
            where TObject : class, IValidatable<TObject> {
            return instance.Validate();
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="strategy"></param>
        /// <typeparam name="TObject"></typeparam>
        /// <returns></returns>
        public static ValidationResultCollection Validate<TObject>(TObject instance,
            IValidateStrategy<TObject> strategy)
            where TObject : class, IValidatable<TObject> {
            instance.AddStrategy(strategy);
            return instance.Validate();
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="strategy"></param>
        /// <param name="handler"></param>
        /// <typeparam name="TObject"></typeparam>
        /// <returns></returns>
        public static ValidationResultCollection Validate<TObject>(TObject instance,
            IValidateStrategy<TObject> strategy, IValidationHandler handler)
            where TObject : class, IValidatable<TObject> {
            instance.AddStrategy(strategy);
            instance.SetValidateHandler(handler);
            return instance.Validate();
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="strategies"></param>
        /// <typeparam name="TObject"></typeparam>
        /// <returns></returns>
        public static ValidationResultCollection Validate<TObject>(TObject instance,
            IEnumerable<IValidateStrategy<TObject>> strategies)
            where TObject : class, IValidatable<TObject> {
            instance.AddStrategyList(strategies);
            return instance.Validate();
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="strategies"></param>
        /// <param name="handler"></param>
        /// <typeparam name="TObject"></typeparam>
        /// <returns></returns>
        public static ValidationResultCollection Validate<TObject>(TObject instance,
            IEnumerable<IValidateStrategy<TObject>> strategies, IValidationHandler handler)
            where TObject : class, IValidatable<TObject> {
            instance.AddStrategyList(strategies);
            instance.SetValidateHandler(handler);
            return instance.Validate();
        }
    }
}