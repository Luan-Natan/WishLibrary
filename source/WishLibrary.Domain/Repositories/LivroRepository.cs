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

        public async Task<ICollection<Livro>?> ObterLivrosComIncludes()
        {
            return await _context.Livro.AsQueryable()
                                       .Include(livro => livro.Genero)
                                       .ToListAsync();
        }

        public async Task<Livro?> ObterLivroPorIdComIncludes(int id)
        {
            return await _context.Livro.Where(livro => livro.Id == id)
                           .AsQueryable()
                           .Include(livro => livro.Genero)
                           .FirstOrDefaultAsync();
        }
    }
}
