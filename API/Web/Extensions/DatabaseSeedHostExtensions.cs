using Database;

namespace Web.Extensions
{
    public static class DatabaseSeedHostExtensions
    {
        public static void SeedDatabase(this IHost host)
        {
            using var scope = host.Services.CreateAsyncScope();
            var dbInitializer = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();
            dbInitializer.Seed();
        }
    }
}
