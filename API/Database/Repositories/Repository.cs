using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    /// <summary>
    /// Implementation of the <see cref="IRepository{TEntity}"/> interface based on repository instructions.
    /// </summary>
    /// <typeparam name="TEntity">The database model type.</typeparam>
    public partial class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Database session instance.
        /// </summary>
        public DbContext Context { get; }
        private DbSet<TEntity> DbSet => Context.Set<TEntity>();

        /// <summary>
        /// Initializes a new instance of <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">Database session instance.</param>
        public Repository(DbContext context)
        {
            Context = context;
        }

        /// <inheritdoc/>
        public ValueTask<TEntity?> FindAsync(Guid key)
        {
            return DbSet.FindAsync(key);
        }

        /// <inheritdoc/>
        public async ValueTask<TEntity?> AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        /// <inheritdoc/>
        public async ValueTask<TEntity?> RemoveAsync(Guid key)
        {
            TEntity? entity = await FindAsync(key);
            if (entity is not null)
            {
                DbSet.Remove(entity);
                return entity;
            }
            return null;
        }

        /// <inheritdoc/>
        public async ValueTask SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

    }

}