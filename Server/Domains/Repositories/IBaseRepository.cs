using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domains.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> ListAllAsync();
        Task AddAsync(T item);
        Task<T> FindByIdAsync(int id);
        void Update(T item);
        void Remove(T item);
    }
}
