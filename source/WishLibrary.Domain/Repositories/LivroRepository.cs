using Microsoft.EntityFrameworkCore;
using WishLibrary.Core.Models;
using WishLibrary.Domain.Repositories.Interfaces;
using WishLibrary.Infra.Context;

namespace WishLibrary.Domain.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly WishLibraryContext _context;

        public LivroRepository(WishLibraryContext context)
        {
            _context = context;
        }

        public async Task<Livro?> ObterLivroPorId(int id)
        {
           return await _context.Livro.AsQueryable().Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Livro>?> ObterLivros()
        {
            return await _context.Livro.AsQueryable().ToListAsync();
        }
    }
}
