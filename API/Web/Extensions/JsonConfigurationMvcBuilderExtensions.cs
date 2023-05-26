using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Web.Extensions
{
    /// <summary>
    /// The <see cref="IMvcBuilder"/> extension for <see cref="JsonOptions"/> configuration.
    /// </summary>
    public static class JsonConfigurationMvcBuilderExtensions
    {
        /// <summary>
        /// Configure json serializer to ignore null condition.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IMvcBuilder ConfigureJsonSerializer(this IMvcBuilder builder) =>
            builder.AddJsonOptions(ConfigureJson);

        private static void ConfigureJson(JsonOptions options) =>
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    }
}
