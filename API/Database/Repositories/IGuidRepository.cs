namespace Database.Repositories
{
    public interface IRepository<TEntity> : IRepository<Guid, TEntity>
    {
    }
}
