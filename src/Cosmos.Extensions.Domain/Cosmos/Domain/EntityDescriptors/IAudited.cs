namespace Cosmos.Domain.EntityDescriptors {
    /// <summary>
    /// Interface for audited
    /// </summary>
    public interface IAudited : ICreatingAudited, IUpdatingAudited { }
}