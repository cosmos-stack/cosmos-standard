using System.Collections.Generic;
using FluentValidation.Results;

namespace Cosmos.Validations.Abstractions
{
    /// <summary>
    /// Interface for validation result
    /// </summary>
    public interface IValidationResult : IEnumerable<ValidationResult>
    {
        /// <summary>
        /// Count
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Is valid
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Error code
        /// </summary>
        long ErrorCode { get; set; }

        /// <summary>
        /// Flag
        /// </summary>
        string Flag { get; set; }

        /// <summary>
        /// Add validated result
        /// </summary>
        /// <param name="result"></param>
        void Add(ValidationResult result);

        /// <summary>
        /// Add a set of validated results
        /// </summary>
        /// <param name="results"></param>
        void AddRange(IEnumerable<ValidationResult> results);

        /// <summary>
        /// To message
        /// </summary>
        /// <returns></returns>
        string ToMessage();

        /// <summary>
        /// To valdation messages
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> ToValidationMessages();
    }
}