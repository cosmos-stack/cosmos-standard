namespace Cosmos.Domain.EntityDescriptors
{
    /// <summary>
    /// Interface for created audited
    /// </summary>
    public interface ICreatingAudited : ICreatedTime
    {
        /// <summary>
        /// Created-operator id
        /// </summary>
        string CreatedOperatorId { get; set; }
    }
}