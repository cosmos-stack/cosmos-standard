using System.Collections.Generic;

namespace Cosmos.Validation
{
    public interface IHasValidationErrors
    {
        /// <summary>
        /// Gets validation message
        /// </summary>
        IEnumerable<string> ValidationMessage { get; }
    }
}