namespace Database.Repositories
{
    public partial class Repository<TEntity> : IAsyncEnumerable<TEntity>
    {
        IAsyncEnumerator<TEntity> IAsyncEnumerable<TEntity>.GetAsyncEnumerator(CancellationToken cancellationToken) =>
            DbSet.GetAsyncEnumerator(cancellationToken);
    }

}