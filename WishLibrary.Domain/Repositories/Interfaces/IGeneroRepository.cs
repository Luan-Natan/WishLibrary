using WishLibrary.Core.Models;

namespace WishLibrary.Domain.Repositories.Interfaces
{
    public interface IGeneroRepository
    {
        Task<Genero> Create(Genero genero);
    }
}
