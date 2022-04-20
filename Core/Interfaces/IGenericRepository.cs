using Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T>GetEntityWithSpec(ISpecifications<T> spec);
        Task<IReadOnlyList<T>>ListAllAsync(ISpecifications<T> spec);
         
    }
}