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
    }
}
