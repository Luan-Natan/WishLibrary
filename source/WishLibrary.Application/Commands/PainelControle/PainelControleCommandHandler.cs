using MediatR;
using WishLibrary.Application.Queries.Interfaces;
using WishLibrary.Core.DTOs;
using WishLibrary.Core.Enums;

namespace WishLibrary.Application.Commands.PainelControle
{
    public class PainelControleCommandHandler : IRequestHandler<PainelControleCommand, PaginacaoDto?>
    {
        private readonly ILivroQuery _livroQuery;
        private readonly IGeneroQuery _generoQuery;

        public PainelControleCommandHandler(ILivroQuery livroQuery, IGeneroQuery generoQuery)
        {
            _livroQuery = livroQuery;
            _generoQuery = generoQuery;
        }

        public async Task<PaginacaoDto?> Handle(PainelControleCommand request, CancellationToken cancellationToken)
        {
            switch (request.Modelo)
            {
                case PainelControleEnum.Livro:
                    return ListaLivro(request);                    
                case PainelControleEnum.Genero:
                    return ListaGenero(request);
            }

            return null;
        }

        public PaginacaoDto ListaLivro(PainelControleCommand request)
        {
            var listaLivro = _livroQuery.ObterLivroPorPaginacao(request.PaginacaoObj);
            var numeroPaginasLivro = listaLivro?.FirstOrDefault()?.Paginacao?.NumeroPaginas;

            var livroPaginacao = new PaginacaoDto(numeroPaginasLivro, request.PaginacaoObj.PaginaAtual, listaLivro);

            return livroPaginacao;
        }

        public PaginacaoDto ListaGenero(PainelControleCommand request)
        {
            var listaGenero= _generoQuery.ObterGeneroPorPaginacao(request.PaginacaoObj);
            var numeroPaginasGenero = listaGenero?.FirstOrDefault()?.Paginacao?.NumeroPaginas;

            var livroPaginacao = new PaginacaoDto(numeroPaginasGenero, request.PaginacaoObj.PaginaAtual, listaGenero);

            return livroPaginacao;
        }
    }
}
