using WishLibrary.Core.Models;
using WishLibrary.Domain.Repositories.Interfaces;
using WishLibrary.Infra.Context;

namespace WishLibrary.Domain.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly WishLibraryContext _context;

        public GeneroRepository(WishLibraryContext context)
        {
            _context = context;
        }

        public async Task<Genero> Create(Genero genero)
        {
            _context.Add(genero);
            await _context.SaveChangesAsync();
            
            return genero;
        }
    }
}
