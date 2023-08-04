
using AspNetCoreHero.ToastNotification;
using MediatR;
using WishLibrary.Application.Commands.CadastrarGenero;
using WishLibrary.Application.Commands.CadastrarLivro;
using WishLibrary.Application.Commands.PainelControle;
using WishLibrary.Application.Queries;
using WishLibrary.Application.Queries.Interfaces;
using WishLibrary.Core.DTOs;
using WishLibrary.Core.Models;
using WishLibrary.Domain.Repositories;
using WishLibrary.Domain.Repositories.Base;
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
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();

            return services;
        }

        private static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGeneroService, GeneroService>();
            services.AddScoped<ILivroService, LivroService>();

            return services;
        }

        private static IServiceCollection ConfigureCommands(IServiceCollection services)
        {
            services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(Program).Assembly));
            services.AddScoped<IRequestHandler<CadastrarLivroCommand, Livro?>, CadastrarLivroCommandHandler>();
            services.AddScoped<IRequestHandler<CadastrarGeneroCommand, Genero?>, CadastrarGeneroCommandHandler>();
            services.AddScoped<IRequestHandler<PainelControleCommand, PaginacaoDto?>, PainelControleCommandHandler>();

            return services;
        }

        private static IServiceCollection ConfigureNotifications(IServiceCollection services)
        {
            services.AddNotyf(config =>
            {
                config.DurationInSeconds = 5;
                config.IsDismissable = true;
                config.Position = NotyfPosition.TopRight;
            });

            return services;
        }

        private static IServiceCollection ConfigureQueries(IServiceCollection services)
        {
            services.AddScoped<ILivroQuery, LivroQuery>();
            services.AddScoped<IGeneroQuery, GeneroQuery>();

            return services;
        }

        public static IServiceCollection AddServices(IServiceCollection services)
        {
            ConfigureNotifications(services);
            ConfigureQueries(services);
            ConfigureContext(services);
            ConfigureServices(services);
            ConfigureCommands(services);
            ConfigureRepositories(services);

            return services;
        }
    }
}
