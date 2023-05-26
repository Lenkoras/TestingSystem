using Database;
using Database.Models;
using Microsoft.AspNetCore.Identity;

namespace Web.Extensions
{
    public static class IdentityUserServiceCollectionExtensions
    {
        public static IdentityBuilder AddIdentityUser(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            /// IdentityBuilder
            return services.AddIdentityCore<User>(ConfigureIdentity)
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }

        private static void ConfigureIdentity(IdentityOptions options)
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
        }
    }
}