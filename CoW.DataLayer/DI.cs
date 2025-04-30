using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace CoW.DataLayer
{
    public static class DI
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // Add your data layer services here
            // For example:
            //services.AddDbContext<CoWDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
