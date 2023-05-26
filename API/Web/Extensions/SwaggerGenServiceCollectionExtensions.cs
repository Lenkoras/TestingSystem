using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Net;

namespace Web.Extensions
{
    public static class SwaggerGenServiceCollectionExtensions
    {
        private static readonly string DocsVersion = "v1";
        private static readonly string DocsTitle = "TestingSystem API";

        public static IServiceCollection AddSwaggerGenWithAuth(this IServiceCollection services)
        {
            return services.AddSwaggerGen(option =>
             {
                 option.SwaggerDoc(DocsVersion, CreateApiInfo());
                 option.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, CreateAuthorizationScheme());
                 option.AddSecurityRequirement(CreateSecurityRequirement());
             });
        }

        private static OpenApiInfo CreateApiInfo() =>
            new OpenApiInfo
            {
                Title = DocsTitle,
                Version = DocsVersion
            };

        private static OpenApiSecurityScheme CreateAuthorizationScheme() =>
            new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = HttpRequestHeader.Authorization.ToString(),
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = JwtBearerDefaults.AuthenticationScheme
            };

        private static OpenApiSecurityRequirement CreateSecurityRequirement() =>
            new OpenApiSecurityRequirement()
            {
                /// dictionary pair
                {
                    CreateSecurityScheme(), /// key
                    Array.Empty<string>() /// value
                }
            };

        private static OpenApiSecurityScheme CreateSecurityScheme() =>
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            };
    }
}