using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class ProductRepository:IProductRepository
    {
        private readonly StoreContent _context;
        public ProductRepository(StoreContent content)
        {
            _context=content;
        }
        public async Task<IReadOnlyList<Product>>GetProductsAsync()
        {
           return await _context.Products
           .Include(p=>p.ProductBrand)
           .Include(p=>p.ProductType)
           .ToListAsync();

        }
        public async Task<Product>GetProductByIdAsync(int id)
        {
          return await _context.Products
          .Include(p=>p.ProductBrand)
          .Include(p=>p.ProductType)
          .FirstOrDefaultAsync();
        }
         public Task<IReadOnlyList<ProductBrand>>GetProductBrandsAsync()
        {
           throw new System.NotImplementedException();
        }
         public Task<IReadOnlyList<ProductType>>GetProductTypesAsync()
        {
           throw new System.NotImplementedException();
        }
    }
}