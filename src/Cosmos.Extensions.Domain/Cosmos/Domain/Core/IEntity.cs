using Cosmos.Domain.ChangeTracking;
using Cosmos.Domain.EntityDescriptors;

namespace Cosmos.Domain.Core {
    /// <summary>
    /// Interface for entity
    /// </summary>
    public interface IEntity : IDomainObject {
        /// <summary>
        /// Init
        /// </summary>
        void Init();
    }

    /// <summary>
    /// Interface for entity
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<out TKey> : IKey<TKey>, IEntity { }

    /// <summary>
    /// Interface for entity
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<in TEntity, out TKey> : IChangeTrackable<TEntity>, IEntity<TKey>
        where TEntity : IEntity { }
}