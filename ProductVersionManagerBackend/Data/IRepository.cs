using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.Data
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAsync();
        Task<T> GetAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
