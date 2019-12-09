using System;
using Cosmos.Domain.Core;
using Cosmos.Domain.EntityDescriptors;
using Cosmos.Validations;
using Cosmos.Validations.Abstractions;

namespace Cosmos.Domain {
    /// <summary>
    /// Expirable entity base
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class ExpirableEntityBase<TEntity, TKey> : EntityBase<TEntity, TKey>, IExpireable
        where TEntity : class, IEntity, IValidatable<TEntity> {
        /// <summary>
        /// Create a new instance of <see cref="ExpirableEntityBase{TEntity, TKey}"/>.
        /// </summary>
        protected ExpirableEntityBase() : base() { }

        /// <summary>
        /// Create a new instance of <see cref="ExpirableEntityBase{TEntity, TKey}"/>.
        /// </summary>
        /// <param name="id"></param>
        protected ExpirableEntityBase(TKey id) : base(id) { }

        /// <inheritdoc />
        public DateTime? ExpireLimitedFromTime { get; set; }

        /// <inheritdoc />
        public DateTime? ExpireLimitedToTime { get; set; }

        /// <summary>
        /// Raise exception if time is invalid
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void RaiseExceptionIfTimeInvalid() {
            if (!ExpireLimitedFromTime.HasValue) return;
            if (!ExpireLimitedToTime.HasValue) return;
            if (ExpireLimitedFromTime.Value < ExpireLimitedToTime.Value) return;
            throw new IndexOutOfRangeException("ExpireLimitedFromTime for expire limied cannot be greater than ExpireLimitedToTime.");
        }

        /// <inheritdoc />
        public bool IsStart() => IsStart(DateTime.Now);

        /// <inheritdoc />
        public bool IsExpired() => IsExpired(DateTime.Now);

        /// <inheritdoc />
        public bool IsActive() => IsActive(DateTime.Now);

        /// <inheritdoc />
        public virtual bool IsStart(DateTime targetTime) {
            if (ExpireLimitedFromTime.HasValue)
                return targetTime >= ExpireLimitedFromTime.Value;
            return false;
        }

        /// <inheritdoc />
        public virtual bool IsExpired(DateTime targetTime) {
            if (ExpireLimitedToTime.HasValue)
                return targetTime > ExpireLimitedToTime.Value;
            return false;
        }

        /// <inheritdoc />
        public virtual bool IsActive(DateTime targetTime) {
            if (ExpireLimitedFromTime.HasValue && ExpireLimitedToTime.HasValue)
                return targetTime >= ExpireLimitedFromTime.Value && targetTime < ExpireLimitedToTime.Value;
            if (ExpireLimitedFromTime.HasValue)
                return targetTime >= ExpireLimitedFromTime.Value;
            if (ExpireLimitedToTime.HasValue)
                return targetTime < ExpireLimitedToTime.Value;
            return false;
        }
    }
}