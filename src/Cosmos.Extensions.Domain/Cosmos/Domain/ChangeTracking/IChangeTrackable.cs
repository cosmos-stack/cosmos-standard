using Cosmos.Domain.Core;

namespace Cosmos.Domain.ChangeTracking
{
    public interface IChangeTrackable<in TObject> where TObject : IDomainObject
    {
        ChangedValueDescriptorCollection GetChanges(TObject otherObj);
    }
}