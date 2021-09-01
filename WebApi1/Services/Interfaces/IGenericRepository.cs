using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Services.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        T GetById(string id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void AddRange(IEnumerable<T> entities);
        void RemoveRang(IEnumerable<T> entities);

    }
}
