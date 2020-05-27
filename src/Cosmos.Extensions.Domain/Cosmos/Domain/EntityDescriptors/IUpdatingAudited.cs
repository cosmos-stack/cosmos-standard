using System;

namespace Cosmos.Domain.EntityDescriptors
{
    /// <summary>
    /// Interface for updating audited
    /// </summary>
    public interface IUpdatingAudited
    {
        /// <summary>
        /// Last updated time
        /// </summary>
        DateTime? LastUpdatedTime { get; set; }

        /// <summary>
        /// Last updated-operator id
        /// </summary>
        string LastUpdatedOperatorId { get; set; }
    }
}