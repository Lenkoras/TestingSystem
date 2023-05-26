using Microsoft.EntityFrameworkCore;

namespace Web.Extensions
{
    public static class DatabaseServiceCollectionExtensions
    {
        private static readonly string ConnectionStringKey;

        static DatabaseServiceCollectionExtensions()
        {
            ConnectionStringKey = "DefaultConnection";
        }

        public static IServiceCollection ConfigureSqlDatabase<TContext>(this IServiceCollection services, IConfiguration config) where TContext : DbContext
        {
            var connectionString = config.GetConnectionString(ConnectionStringKey);
            return services.AddDbContext<TContext>(options =>
                options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString));
        }

    }
}
