using WishLibrary.Core.Models;

namespace WishLibrary.Domain.Repositories.Interfaces
{
    public interface IGeneroRepository
    {
        Task<ICollection<Genero>?> ObterGeneros();
        Task<Genero?> ObterGeneroPorId(int id);
    }
}
