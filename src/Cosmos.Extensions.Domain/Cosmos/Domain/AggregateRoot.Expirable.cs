using Cosmos.Domain.Core;
using Cosmos.Validations;
using Cosmos.Validations.Abstractions;

namespace Cosmos.Domain
{
    /// <summary>
    /// Expireable aggregate root
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class ExpirableAggregateRoot<TEntity, TKey> : ExpirableEntityBase<TEntity, TKey>, IAggregateRoot<TEntity, TKey>
    where TEntity : class, IAggregateRoot, IValidatable<TEntity>
    {
        /// <summary>
        /// Create a new instance of <see cref="ExpirableAggregateRoot{TEntity, TKey}"/>.
        /// </summary>
        protected ExpirableAggregateRoot() : base() { }

        /// <summary>
        /// Create a new instance of <see cref="ExpirableAggregateRoot{TEntity, TKey}"/>.
        /// </summary>
        /// <param name="id"></param>
        protected ExpirableAggregateRoot(TKey id) : base(id) { }

        /// <inheritdoc />
        public byte[] Version { get; set; }
    }
}