using Cosmos.Domain.Core;

namespace Cosmos.Domain.ChangeTracking {
    /// <summary>
    /// Interface for change trackable
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public interface IChangeTrackable<in TObject> where TObject : IDomainObject {
        /// <summary>
        /// Get changes
        /// </summary>
        /// <param name="otherObj"></param>
        /// <returns></returns>
        ChangedValueDescriptorCollection GetChanges(TObject otherObj);
    }
}