using Web.Binding.Models;

namespace Web.Extensions
{
    public static class CorsPolicyConfigurationExtensions
    {
        public static string GetPolicyName(this IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration);

            return configuration[$"{CorsPolicy.ConfigurationKey}:{nameof(CorsPolicy.Name)}"] ?? CorsPolicy.DefaultName;
        }
    }
}