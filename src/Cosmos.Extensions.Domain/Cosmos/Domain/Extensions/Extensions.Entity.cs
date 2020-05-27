using System;
using Cosmos.Domain.EntityDescriptors;

namespace Cosmos.Domain.Extensions
{
    /// <summary>
    /// Entry extensions
    /// </summary>
    public static class EntityExtensions
    {
        /// <summary>
        /// Append created time
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static TEntity AppendCreatedTime<TEntity, TKey>(this TEntity entity) where TEntity : EntityBase<TEntity, TKey>
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (!(entity is ICreatedTime target)) return entity;

            target.CreatedTime = DateTime.Now;

            return entity;
        }

        /// <summary>
        /// Append creating audited info
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="deleteOperatorId"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static TEntity AppendCreatingAuditedInfo<TEntity, TKey>(this TEntity entity, string deleteOperatorId) where TEntity : EntityBase<TEntity, TKey>
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (!(entity is ICreatingAudited target)) return entity;

            target.CreatedOperatorId = deleteOperatorId;

            target.CreatedTime = DateTime.Now;

            return entity;
        }

        /// <summary>
        /// Append creating audited info
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="deleteOperatorId"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static TEntity AppendUpdatingAuditedInfo<TEntity, TKey>(this TEntity entity, string deleteOperatorId) where TEntity : EntityBase<TEntity, TKey>
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (!(entity is IUpdatingAudited target)) return entity;

            target.LastUpdatedOperatorId = deleteOperatorId;

            target.LastUpdatedTime = DateTime.Now;

            return entity;
        }

        /// <summary>
        /// Append deleted info
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="optType"></param>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static TEntity AppendDeletedInfo<TEntity, TKey>(this TEntity entity, DeleteOperationTypes optType) where TEntity : EntityBase<TEntity, TKey>
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (!(entity is IDeletable target)) return entity;

            switch (optType)
            {
                case DeleteOperationTypes.LogicDelete:
                    target.IsDeleted = true;
                    break;

                case DeleteOperationTypes.Restore:
                    target.IsDeleted = false;
                    break;

                case DeleteOperationTypes.PhysicalDelete:
                    if (!target.IsDeleted)
                        throw new InvalidOperationException("Entity cannot be hard-delete because for delete-status is false.");
                    break;
            }

            return entity;
        }
    }
}