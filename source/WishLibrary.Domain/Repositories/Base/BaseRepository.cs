using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<T> Adicionar<T>(T entity) where T : class
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
