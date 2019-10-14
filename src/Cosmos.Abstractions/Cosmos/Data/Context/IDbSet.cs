namespace Cosmos.Data.Context
{
    /// <summary>
    /// DbSet Meta Interface<br />
    /// DbSet 元接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDbSet<TEntity> where TEntity : class { }
}