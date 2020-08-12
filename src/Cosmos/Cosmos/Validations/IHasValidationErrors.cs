using System.Collections.Generic;

namespace Cosmos.Validations
{
    public interface IHasValidationErrors
    {
        /// <summary>
        /// Gets validation message
        /// </summary>
        IEnumerable<string> ValidationMessage { get; }
    }
}