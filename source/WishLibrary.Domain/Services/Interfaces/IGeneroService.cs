using WishLibrary.Core.Models;

namespace WishLibrary.Domain.Services.Interfaces
{
    public interface IGeneroService
    {
        Task CadastrarGenero(Genero genero);
        Task<ICollection<Genero>?> ObterGeneros();
        Task<Genero?>ObterGeneroPorId(int id);
    }
}
