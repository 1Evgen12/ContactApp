using ContactAppFull.Server.Middleware;

namespace ContactAppFull.Server.Extensions
{
    public static class ConfigMiddlewareExtensions
    {
        public static IApplicationBuilder UseConfigMiddleware(
            this IApplicationBuilder app)
        {
            return app.UseMiddleware<ConfigMiddleware>();
        }
    }
}
