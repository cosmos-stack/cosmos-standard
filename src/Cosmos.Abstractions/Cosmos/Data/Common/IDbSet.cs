namespace Cosmos.Data.Common
{
    /// <summary>
    /// DbSet Meta Interface<br />
    /// DbSet 元接口
    /// </summary>
    /// <typeparam name="TEntity">指定的实体类型</typeparam>
    public interface IDbSet<TEntity> where TEntity : class { }
}