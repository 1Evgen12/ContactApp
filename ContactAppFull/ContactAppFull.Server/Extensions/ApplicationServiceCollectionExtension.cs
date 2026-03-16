using ContactAppFull.Server.DataContext;
using ContactAppFull.Server.Storage;
using Microsoft.EntityFrameworkCore;
namespace ContactAppFull.Server.Extensions
{
    public static class ApplicationServiceCollectionExtension
    {
        public static IServiceCollection AddServiceCollection(this IServiceCollection services,
            ConfigurationManager configuration)
        {

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
                {
                    Title = "API списка контактов",
                });
            });
            services.AddControllers();
            var stringConnection = configuration.GetConnectionString("SqliteStringConnection");
            services.AddDbContext<SqliteDbContext>(opt => opt.UseSqlite(stringConnection));
            //services.AddSingleton<IStorage>(new SqliteStorage(stringConnection));
            services.AddScoped<IStorage, SqliteEfStorage>();
            services.AddCors(opt =>
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins(configuration["client"]);
                }));

            return services;
        }
    }
}
