using WishLibrary.Core.DTOs;

namespace WishLibrary.Application.Queries.Interfaces
{
    public interface IGeneroQuery
    {
        IEnumerable<ObterGeneroDto>? ObterGeneroPorPaginacao(PaginacaoRequestDto obj);
    }
}
