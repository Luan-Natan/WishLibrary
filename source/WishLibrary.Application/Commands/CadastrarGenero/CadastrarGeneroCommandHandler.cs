using AspNetCoreHero.ToastNotification.Abstractions;
using MediatR;
using WishLibrary.Core.Models;
using WishLibrary.Domain.Services.Interfaces;

namespace WishLibrary.Application.Commands.CadastrarGenero
{
    public class CadastrarGeneroCommandHandler : IRequestHandler<CadastrarGeneroCommand, Genero?>
    {
        private readonly IGeneroService _GeneroService;
        private readonly INotyfService _notification;

        public CadastrarGeneroCommandHandler(IGeneroService GeneroService, INotyfService notification)
        {
            _GeneroService = GeneroService;
            _notification = notification;
        }

        public async Task<Genero?> Handle(CadastrarGeneroCommand request, CancellationToken cancellationToken)
        {
            var generoNovo = request.ToEntity();

            var generoExistente = _GeneroService.ObterGeneros().Result?.Where(gn => gn.Nome == generoNovo.Nome);

            if (generoExistente!.Any())
            {
                _notification.Error("Gênero com nome existente!");
                return null;
            }

            await _GeneroService.CadastrarGenero(generoNovo);
            _notification.Success("Gênero cadastrado com sucesso!");

            return generoNovo;
        }
    }
}
