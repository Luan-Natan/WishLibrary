using MediatR;
using WishLibrary.Application.Queries.Interfaces;
using WishLibrary.Core.DTOs;
using WishLibrary.Core.Enums;
using WishLibrary.Core.Models;

namespace WishLibrary.Application.Commands.PainelControle
{
    public class PainelControleCommandHandler : IRequestHandler<PainelControleCommand, object?>
    {
        private readonly ILivroQuery _livroQuery;

        public PainelControleCommandHandler(ILivroQuery livroQuery)
        {
            _livroQuery = livroQuery;
        }

        public async Task<object?> Handle(PainelControleCommand request, CancellationToken cancellationToken)
        {

            switch (request.Modelo)
            {
                case PainelControleEnum.Livro:
                    var listaLivro = _livroQuery.ObterLivroPorPaginacao(request.PaginacaoObj);
                    var numeroPaginasLivro = listaLivro?.FirstOrDefault()?.Paginacao?.NumeroPaginas;
                    var livroPaginacao = new GenericPaginacaoQueryDTO<ObterLivroDto>(
                                                       result: listaLivro,
                                                       numeroPaginas: numeroPaginasLivro,
                                                       paginaAnterior: request.PaginacaoObj.PaginaAtual == 1 ? 1 : request.PaginacaoObj.PaginaAtual - 1,
                                                       proximaPagina: request.PaginacaoObj.PaginaAtual == numeroPaginasLivro ? numeroPaginasLivro : request.PaginacaoObj.PaginaAtual + 1);

                    return livroPaginacao;
                case PainelControleEnum.Genero:
                    return null;
            }

            return null;
        }
    }
}
