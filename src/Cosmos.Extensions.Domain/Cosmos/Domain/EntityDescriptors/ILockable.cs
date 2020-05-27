namespace Cosmos.Domain.EntityDescriptors
{
    /// <summary>
    /// To flag this entity can be locked.
    /// </summary>
    public interface ILockable
    {
        /// <summary>
        /// Is locked
        /// </summary>
        bool IsLocked { get; set; }
    }
}