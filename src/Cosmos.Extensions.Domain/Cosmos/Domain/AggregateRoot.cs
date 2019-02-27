using Cosmos.Domain.Core;
using Cosmos.Validations;
using Cosmos.Validations.Abstractions;

namespace Cosmos.Domain
{
    public abstract class AggregateRoot<TEntity, TKey> : EntityBase<TEntity, TKey>, IAggregateRoot<TEntity, TKey>
        where TEntity : class, IAggregateRoot, IValidatable<TEntity>
    {
        protected AggregateRoot() : base() { }

        protected AggregateRoot(TKey id) : base(id) { }

        public byte[] Version { get; set; }
    }
}