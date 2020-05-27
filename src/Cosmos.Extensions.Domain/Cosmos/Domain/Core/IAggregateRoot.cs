using Cosmos.Domain.EntityDescriptors;

namespace Cosmos.Domain.Core
{
    /// <summary>
    /// Interface for aggregate root
    /// </summary>
    public interface IAggregateRoot : IEntity, IVersionable { }

    /// <summary>
    /// Interface for aggregate root
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IAggregateRoot<out TKey> : IEntity<TKey>, IAggregateRoot { }

    /// <summary>
    /// Interface for aggregate root
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface IAggregateRoot<in TEntity, out TKey> : IEntity<TEntity, TKey>, IAggregateRoot<TKey>
    where TEntity : IAggregateRoot { }
}