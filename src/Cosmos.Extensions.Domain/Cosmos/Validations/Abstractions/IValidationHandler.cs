namespace Cosmos.Validations.Abstractions {
    /// <summary>
    /// Interface validation handler
    /// </summary>
    public interface IValidationHandler {
        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="results"></param>
        void Handle(ValidationResultCollection results);
    }
}