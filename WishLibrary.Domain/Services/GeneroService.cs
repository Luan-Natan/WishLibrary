using WishLibrary.Core.Models;
using WishLibrary.Domain.Repositories.Interfaces;
using WishLibrary.Domain.Services.Interfaces;

namespace WishLibrary.Domain.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        public async Task CadastrarGenero(Genero genero)
        {
            await _generoRepository.Create(genero);
            
        }
    }
}
