using Auth;
using Database;
using Database.Models;
using Database.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().CreateDefault();

/// HostBuilder
builder.Host
    .UseSerilog();

/// MvcBuilder
builder.Services
    .AddControllers()
    .ConfigureJsonSerializer();

/// ServiceCollection
builder.Services
    .AddSerilog()
    .AddJwtTokenService<User>()
    .ConfigureSqlDatabase<ApplicationDbContext>(builder.Configuration)
    .AddScoped<IRepositoryWrapper, RepositoryWrapper>()
    .AddAuthorization();

if (builder.Environment.IsDevelopment())
{
    /// ServiceCollection
    builder.Services
        .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
        .AddSwaggerGenWithAuth()
        .AddEndpointsApiExplorer();
}

/// AuthenticationBuilder
builder.Services
.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer((JwtBearerOptions options) =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = AuthOptions.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(AuthOptions.GetEncryptionKeyBytes()),
    };
});

/// IdentityBuilder
builder.Services
    .AddIdentityCore<User>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireDigit = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
        .UseSwaggerUI();
    app.SeedDatabase();
}

/// ApplicationBuilder
app.UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization();

app.MapControllers();

app.Run();