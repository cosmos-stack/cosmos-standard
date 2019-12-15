namespace Cosmos.Domain.EntityDescriptors {
    /// <summary>
    /// To flag this entity can be mark as deleted.
    /// </summary>
    public interface IDeletable {
        /// <summary>
        /// Is deleted
        /// </summary>
        bool IsDeleted { get; set; }
    }
}