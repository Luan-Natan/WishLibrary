using Microsoft.EntityFrameworkCore;
using WishLibrary.Domain.Repositories.Interfaces;
using WishLibrary.Infra.Context;

namespace WishLibrary.Domain.Repositories.Base
{
    public class BaseRepository : IBaseRepository
    {
        private readonly WishLibraryContext _context;

        public BaseRepository(WishLibraryContext context)
        {
            _context = context;
        }

        public async Task<ICollection<T>?> ObterTudo<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> ObterporId<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Adicionar<T>(T entity) where T : class
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Apagar<T>(T entity) where T : class
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Atualizar<T>(T entity) where T : class
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
