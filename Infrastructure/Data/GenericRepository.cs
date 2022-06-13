using Core.Interfaces;
using Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Core.Specifications;
using System.Linq;

namespace Infrastructure.Data
{
    public class GenericRepository<T>:IGenericRepository<T> where T:BaseEntity
    {
        private readonly StoreContent _context;
        public GenericRepository(StoreContent context)
        {
            _context=context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync(); 
        }
         public async Task<T>GetEntityWithSpec(ISpecifications<T> spec)
         {
             return await ApplySpecifications(spec).FirstOrDefaultAsync();
         }
        public async Task<IReadOnlyList<T>>ListAllAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }
        public async Task<int>CountAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).CountAsync();
        }
        private IQueryable<T> ApplySpecifications(ISpecifications<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
       
    }
}