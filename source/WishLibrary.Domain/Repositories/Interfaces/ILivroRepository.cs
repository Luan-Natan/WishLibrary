using WishLibrary.Core.Models;

namespace WishLibrary.Domain.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        Task<ICollection<Livro>?> ObterLivrosComIncludes();
        Task<Livro?> ObterLivroPorIdComIncludes(int id);
    }
}
