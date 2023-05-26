using Logic.Middlewares.AccessToken;

namespace Web.Extensions
{
    public static class AuthServicesApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAuthServices(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AccessTokenPropagationMiddleware>()
                .UseAuthentication()
                .UseAuthorization();
        }
    }
}