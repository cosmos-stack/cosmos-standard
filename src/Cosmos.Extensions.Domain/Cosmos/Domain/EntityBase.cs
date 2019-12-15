using System;
using System.ComponentModel.DataAnnotations;
using Cosmos.Domain.Core;
using Cosmos.IdUtils;
using Cosmos.Validations;
using Cosmos.Validations.Abstractions;

namespace Cosmos.Domain {
    /// <summary>
    /// Entity base
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class EntityBase<TEntity, TKey> : DomainObject<TEntity>, IEntity<TEntity, TKey>
        where TEntity : class, IEntity, IValidatable<TEntity> {
        /// <summary>
        /// Create a new instance of <see cref="EntityBase{TEntity, TKey}"/>.
        /// </summary>
        protected EntityBase() => Init();

        /// <summary>
        /// Create a new instance of <see cref="EntityBase{TEntity, TKey}"/>.
        /// </summary>
        /// <param name="id"></param>
        protected EntityBase(TKey id) => Id = id;

        /// <summary>
        /// Id
        /// </summary>
        [Key, Required]
        public TKey Id { get; set; }

        /// <inheritdoc />
        public override bool Equals(object other) {
            if (other == null)
                return false;
            var entity = other as EntityBase<TEntity, TKey>;
            if (entity == null)
                return false;
            return entity.Id.Equals(Id);
        }

        /// <inheritdoc />
        public override int GetHashCode() {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return ReferenceEquals(Id, null) ? 0 : Id.GetHashCode();
        }

        /// <summary>
        /// ==
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(EntityBase<TEntity, TKey> left, EntityBase<TEntity, TKey> right) {
            if ((object) left == null && (object) right == null)
                return true;
            if (!(left is TEntity) || !(right is TEntity))
                return false;
            if (Equals(left.Id, null) || left.Id.Equals(default(TKey)))
                return false;
            return left.Id.Equals(right.Id);
        }

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(EntityBase<TEntity, TKey> left, EntityBase<TEntity, TKey> right) {
            return !(left == right);
        }

        /// <inheritdoc />
        public void Init() {
            if (Types.Of<TKey>() == Types.Of<Guid>()) {
                Id = GenerateCombKey().CastTo<TKey>();
            }
            else if (Id?.Equals(default(TKey)) ?? false) {
                Id = GenerateKey();
            }
        }

        #region Misc

        /// <summary>
        /// Generate key
        /// </summary>
        /// <returns></returns>
        protected virtual TKey GenerateKey() {
            return Guid.NewGuid().CastTo<TKey>();
        }

        /// <summary>
        /// Generate combkey
        /// </summary>
        /// <returns></returns>
        protected virtual Guid GenerateCombKey() {
            return GuidProvider.Create(GuidStyle.CombStyle);
        }

        #endregion

    }
}