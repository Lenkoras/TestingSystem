namespace Database.Repositories
{
    /// <summary>
    /// Implementation of the Repository pattern, where <typeparamref name="TEntity"/> is a database model type.
    /// </summary>
    /// <typeparam name="TEntity">The database model.</typeparam>
    public interface IRepository<TKey, TEntity> : IQueryable<TEntity>, IAsyncEnumerable<TEntity>
    {
        /// <summary>
        /// Returns an entity by specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Entity identifier.</param>
        ValueTask<TEntity?> FindAsync(TKey id);

        /// <summary>
        /// Adds an <paramref name="entity"/> instance to the dependent database.
        /// </summary>
        /// <param name="entity">A database model instance.</param>
        ValueTask<TEntity?> AddAsync(TEntity entity);

        /// <summary>
        /// Removes an entity from database by specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Entity identifier.</param>
        ValueTask<TEntity?> RemoveAsync(TKey id);

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        ValueTask SaveChangesAsync();
    }
}