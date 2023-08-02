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
    }
}
