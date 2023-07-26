using WishLibrary.Core.Models;
using WishLibrary.Domain.Repositories.Interfaces;
using WishLibrary.Domain.Services.Interfaces;

namespace WishLibrary.Domain.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly IBaseRepository _baseRepository;

        public GeneroService(IGeneroRepository generoRepository, IBaseRepository baseRepository)
        {
            _generoRepository = generoRepository;
            _baseRepository = baseRepository;
        }

        public async Task<Genero?> ObterGeneroPorId(int id)
        {
            return await _generoRepository.ObterGeneroPorId(id);
        }

        public async Task<ICollection<Genero>?> ObterGeneros()
        {
            return await _generoRepository.ObterGeneros();
        }

        public async Task CadastrarGenero(Genero genero)
        {
            await _baseRepository.Adicionar(genero);
        }
    }
}
