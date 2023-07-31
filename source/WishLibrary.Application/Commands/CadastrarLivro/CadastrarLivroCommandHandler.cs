using AspNetCoreHero.ToastNotification.Abstractions;
using MediatR;
using WishLibrary.Core.Models;
using WishLibrary.Domain.Services.Interfaces;

namespace WishLibrary.Application.Commands.CadastrarLivro
{
    public class CadastrarLivroCommandHandler : IRequestHandler<CadastrarLivroCommand, Livro?>
    {
        private readonly ILivroService _livroService;
        private readonly INotyfService _notification;

        public CadastrarLivroCommandHandler(ILivroService livroService, INotyfService notification)
        {
            _livroService = livroService;
            _notification = notification;
        }

        public async Task<Livro?> Handle(CadastrarLivroCommand request, CancellationToken cancellationToken)
        {
            var livroNovo = request.ToEntity();

            var livroExistente = _livroService.ObterLivros().Result?.Where(lv => lv.Nome == livroNovo.Nome);

            if (livroExistente!.Any())
            {
                _notification.Error("Livro com nome existente!");
                return null;
            }

            await _livroService.CadastrarLivro(livroNovo);
            _notification.Success("Livro cadastrado com sucesso!");

            return livroNovo;
        }
    }
}
