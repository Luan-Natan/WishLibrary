using WishLibrary.Core.Models;

namespace WishLibrary.Domain.Services.Interfaces
{
    public interface IGeneroService
    {
        Task CadastrarGenero(Genero genero);
    }
}
