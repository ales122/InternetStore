using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.DAO
{
    public interface IGenericRepository<T> where T:class
    {
       Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entitties);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);
    }
}
