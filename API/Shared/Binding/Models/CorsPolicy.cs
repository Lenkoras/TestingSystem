namespace Shared.Binding.Models
{
    public class CorsPolicy
    {
        public static readonly string ConfigurationKey = nameof(CorsPolicy);
        public static readonly string DefaultName = nameof(CorsPolicy);

        public string? Name { get; set; }
        public string[]? AllowOrigins { get; set; }
    }
}