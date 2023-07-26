using WishLibrary.Core.Models;

namespace WishLibrary.Domain.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        Task<ICollection<Livro>?> ObterLivros();
        Task<Livro?> ObterLivroPorId(int id);
    }
}
