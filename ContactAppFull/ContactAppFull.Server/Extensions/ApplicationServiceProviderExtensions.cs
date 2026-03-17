using ContactAppFull.Server.Seed;
using ContactAppFull.Server.Storage;

namespace ContactAppFull.Server.Extensions
{
    public static class ApplicationServiceProviderExtensions
    {
        public static IServiceProvider AddCustomService(
            this IServiceProvider services,
            IConfiguration configuration)
        {
            using var scope = services.CreateScope();
            //var storage = scope.ServiceProvider.GetService<IStorage>();
            //var dbStorage = storage as SqliteStorage;
            //if (dbStorage != null) {
            //    string connectionString = configuration.GetConnectionString("SqliteStringConnection");

            //    new FakerInitializer(connectionString).Initialize();
            //}
            var initializer = scope.ServiceProvider.GetRequiredService<IInitializer>();
            initializer.Initialize();
            return services;
        }
    }
}
