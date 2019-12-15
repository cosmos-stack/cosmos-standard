using System;
using System.Linq;
using Cosmos.Validations.Abstractions;

namespace Cosmos.Validations {
    /// <summary>
    /// Validation handler exceptions
    /// </summary>
    public static class ValidationHandleExceptions {
        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static ValidationHandleOperation Handle(this ValidationResultCollection collection) {
            return new ValidationHandleOperation(collection);
        }

        /// <summary>
        /// Handle all
        /// </summary>
        /// <param name="op"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ValidationHandleOperation HandleAll(this ValidationHandleOperation op, IValidationHandler handler) {
            if (op == null)
                throw new ArgumentNullException(nameof(op));
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            op.Handle(handler);

            return op;
        }

        /// <summary>
        /// Handle for success
        /// </summary>
        /// <param name="op"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ValidationHandleOperation HandleForSuccess(this ValidationHandleOperation op, IValidationHandler handler) {
            if (op == null)
                throw new ArgumentNullException(nameof(op));
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            op.Handle(handler, x => x.Where(y => y.IsValid));

            return op;
        }

        /// <summary>
        /// Handle for faliure
        /// </summary>
        /// <param name="op"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ValidationHandleOperation HandleForFailure(this ValidationHandleOperation op, IValidationHandler handler) {
            if (op == null)
                throw new ArgumentNullException(nameof(op));
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            op.Handle(handler, x => x.Where(y => !y.IsValid));

            return op;
        }

        /// <summary>
        /// Handle for strategy
        /// </summary>
        /// <param name="op"></param>
        /// <param name="name"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ValidationHandleOperation HandleForStrategy(this ValidationHandleOperation op, string name, IValidationHandler handler) {
            if (op == null)
                throw new ArgumentNullException(nameof(op));
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            op.Handle(handler, name);

            return op;
        }
    }
}