using WishLibrary.Core.DTOs;
using WishLibrary.Core.Models;

namespace WishLibrary.Application.Queries.Interfaces
{
    public interface ILivroQuery
    {
        IEnumerable<ObterLivroDto>? PaginationObject(PaginacaoRequestDto obj);
    }
}
