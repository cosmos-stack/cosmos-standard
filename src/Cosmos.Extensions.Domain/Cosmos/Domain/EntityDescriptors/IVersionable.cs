namespace Cosmos.Domain.EntityDescriptors {
    /// <summary>
    /// Interface for versionable
    /// </summary>
    public interface IVersionable {
        /// <summary>
        /// Version
        /// </summary>
        byte[] Version { get; set; }
    }
}