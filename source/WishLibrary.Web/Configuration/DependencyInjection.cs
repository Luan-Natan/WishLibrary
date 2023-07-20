
using Microsoft.EntityFrameworkCore;
using WishLibrary.Domain.Repositories;
using WishLibrary.Domain.Repositories.Interfaces;
using WishLibrary.Domain.Services;
using WishLibrary.Domain.Services.Interfaces;
using WishLibrary.Infra.Context;

namespace WishLibrary.Web.Configuration
{
    public class DependencyInjection
    {
        private static IServiceCollection ConfigureContext(IServiceCollection services)
        {
            services.AddDbContext<WishLibraryContext>();

            return services;
        }

        private static IServiceCollection ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IGeneroRepository, GeneroRepository>();

            return services;
        }

        private static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGeneroService, GeneroService>();

            return services;
        }

        public static IServiceCollection AddServices(IServiceCollection services)
        {
            ConfigureContext(services);
            ConfigureServices(services);
            ConfigureRepositories(services);

            return services;
        }
    }
}
