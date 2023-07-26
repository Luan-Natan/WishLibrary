using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishLibrary.Core.Models;

namespace WishLibrary.Domain.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        Task<T> Adicionar<T>(T entity) where T : class;
    }
}
