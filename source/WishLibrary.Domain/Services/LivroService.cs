using WishLibrary.Core.Models;
using WishLibrary.Domain.Repositories.Interfaces;
using WishLibrary.Domain.Services.Interfaces;

namespace WishLibrary.Domain.Services
{
    public class LivroService : ILivroService
    {
        private readonly IBaseRepository _baseRepository;

        public LivroService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<Livro?> ObterLivroPorId(int id)
        {
            return await _baseRepository.ObterporId<Livro>(id);
        }

        public async Task<ICollection<Livro>?> ObterLivros()
        {
            return await _baseRepository.ObterTudo<Livro>();
        }

        public async Task CadastrarLivro(Livro Livro)
        {
            await _baseRepository.Adicionar(Livro);
        }

        public async Task<Livro?> DeletarLivro(int id)
        {
            var livro = await _baseRepository.ObterporId<Livro>(id);
            await _baseRepository.Apagar<Livro>(livro);

            return livro;
        }

        public async Task<Livro?> AtualizarLivro(int id)
        {
            var livro = await _baseRepository.ObterporId<Livro>(id);
            await _baseRepository.Atualizar<Livro>(livro);

            return livro;
        }
    }
}
