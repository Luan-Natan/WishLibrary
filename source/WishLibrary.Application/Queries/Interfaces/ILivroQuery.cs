using WishLibrary.Core.DTOs;

namespace WishLibrary.Application.Queries.Interfaces
{
    public interface ILivroQuery
    {
        IEnumerable<ObterLivroDto>? ObterLivroPorPaginacao(PaginacaoRequestDto obj);
    }
}
