using WishLibrary.Core.Models;

namespace WishLibrary.Domain.Services.Interfaces
{
    public interface ILivroService
    {
        Task CadastrarLivro(Livro Livro);
        Task<ICollection<Livro>?> ObterLivros();
        Task<Livro?> ObterLivroPorId(int id);
        Task<Livro?> DeletarLivro(int id);
        Task<Livro?> AtualizarLivro(int id);
    }
}
