using WishLibrary.Core.Models;
using WishLibrary.Domain.Repositories.Interfaces;
using WishLibrary.Domain.Services.Interfaces;

namespace WishLibrary.Domain.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IBaseRepository _baseRepository;

        public GeneroService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<Genero?> ObterGeneroPorId(int id)
        {
            return await _baseRepository.ObterporId<Genero>(id);
        }

        public async Task<ICollection<Genero>?> ObterGeneros()
        {
            return await _baseRepository.ObterTudo<Genero>();
        }

        public async Task CadastrarGenero(Genero genero)
        {
            await _baseRepository.Adicionar(genero);
        }

        public async Task<Genero?> DeletarGenero(int id)
        {
            var genero = await _baseRepository.ObterporId<Genero>(id);
            await _baseRepository.Apagar<Genero>(genero);

            return genero;
        }

        public async Task<Genero?> AtualizarGenero(int id)
        {
            var genero = await _baseRepository.ObterporId<Genero>(id);
            await _baseRepository.Atualizar<Genero>(genero);

            return genero;
        }
    }
}
