using Microsoft.EntityFrameworkCore;
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

        public async Task<Genero?> ObterGeneroPorId(int id)
        {
           return await _context.Genero.AsQueryable().Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Genero>?> ObterGeneros()
        {
            return await _context.Genero.AsQueryable().ToListAsync();
        }
    }
}
