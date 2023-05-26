using Database;
using Database.Mapping;
using Database.Repositories;
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
    .ConfigureSqlDatabase<ApplicationDbContext>(builder.Configuration)
    .AddScoped<IRepositoryWrapper, RepositoryWrapper>()
    .AddAuthServices()
    .AddAutoMapper(typeof(ApplicationProfile));

if (builder.Environment.IsDevelopment())
{
    /// ServiceCollection
    builder.Services
        .AddScoped<IDatabaseSeeder, DatabaseSeeder>()
        .AddSwaggerGenWithAuth()
        .AddEndpointsApiExplorer();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
        .UseSwaggerUI();
    app.SeedDatabase();
}

/// ApplicationBuilder
app.UseHttpsRedirection()
    .UseAuthServices();

app.MapControllers();

app.Run();