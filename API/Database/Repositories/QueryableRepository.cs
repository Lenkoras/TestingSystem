using System.Collections;
using System.Linq.Expressions;

namespace Database.Repositories
{
    public partial class Repository<TEntity> : IQueryable<TEntity>
    {
        Type IQueryable.ElementType => Values.ElementType;

        Expression IQueryable.Expression => Values.Expression;

        IQueryProvider IQueryable.Provider => Values.Provider;

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator() =>
            Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            Values.GetEnumerator();

        private IQueryable<TEntity> Values => DbSet;
    }

}