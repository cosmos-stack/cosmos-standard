using Cosmos.Domain.Core;
using Cosmos.Validations;
using Cosmos.Validations.Abstractions;

namespace Cosmos.Domain
{
    /// <summary>
    /// Aggregate Root
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class AggregateRoot<TEntity, TKey> : EntityBase<TEntity, TKey>, IAggregateRoot<TEntity, TKey>
        where TEntity : class, IAggregateRoot, IValidatable<TEntity>
    {
        /// <summary>
        /// Create a new instance of <see cref="AggregateRoot{TEntity, TKey}"/>.
        /// </summary>
        protected AggregateRoot() : base() { }

        /// <summary>
        /// Create a new instance of <see cref="AggregateRoot{TEntity, TKey}"/>.
        /// </summary>
        /// <param name="id"></param>
        protected AggregateRoot(TKey id) : base(id) { }

        /// <inheritdoc />
        public byte[] Version { get; set; }
    }
}