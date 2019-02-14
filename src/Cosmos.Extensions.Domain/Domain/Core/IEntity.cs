using Cosmos.Domain.ChangeTracking;
using Cosmos.Domain.EntityDescriptors;

namespace Cosmos.Domain.Core
{
    public interface IEntity : IDomainObject
    {
        void Init();
    }

    public interface IEntity<out TKey> : IKey<TKey>, IEntity { }

    public interface IEntity<in TEntity, out TKey> : IChangeTrackable<TEntity>, IEntity<TKey>
        where TEntity : IEntity { }
}