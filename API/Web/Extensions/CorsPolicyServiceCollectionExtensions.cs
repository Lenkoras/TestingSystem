using Web.Binding.Models;

namespace Web.Extensions
{
    public static class CorsPolicyServiceCollectionExtensions
    {
        public static IServiceCollection AddCorsFromConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration);

            CorsPolicy? corsPolicy = configuration.GetSection(CorsPolicy.ConfigurationKey).Get<CorsPolicy>();

            if (corsPolicy is null)
            {
                throw new InvalidOperationException("Configuration file does not contain CorsPolicy field.");
            }

            string[] allowedOrigins = corsPolicy.AllowOrigins ?? Array.Empty<string>();
            string policyName = corsPolicy.Name ?? CorsPolicy.DefaultName;

            return service.AddCors(options => options.AddPolicy(policyName, builder =>
            {
                builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(host => allowedOrigins.Contains(host))
                    .AllowCredentials();
            }));
        }
    }
}