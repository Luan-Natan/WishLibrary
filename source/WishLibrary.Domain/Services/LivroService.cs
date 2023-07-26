using WishLibrary.Core.Models;
using WishLibrary.Domain.Repositories.Interfaces;
using WishLibrary.Domain.Services.Interfaces;

namespace WishLibrary.Domain.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _LivroRepository;
        private readonly IBaseRepository _baseRepository;

        public LivroService(ILivroRepository LivroRepository, IBaseRepository baseRepository)
        {
            _LivroRepository = LivroRepository;
            _baseRepository = baseRepository;
        }

        public async Task<Livro?> ObterLivroPorId(int id)
        {
            return await _LivroRepository.ObterLivroPorId(id);
        }

        public async Task<ICollection<Livro>?> ObterLivros()
        {
            return await _LivroRepository.ObterLivros();
        }

        public async Task CadastrarLivro(Livro Livro)
        {
            await _baseRepository.Adicionar(Livro);
        }
    }
}
