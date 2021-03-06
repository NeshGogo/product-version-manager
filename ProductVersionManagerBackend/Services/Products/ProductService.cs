using Microsoft.EntityFrameworkCore;
using ProductVersionManagerBackend.Data.products;
using ProductVersionManagerBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Product> AddAsync(Product entity)
        {
            entity.Date = DateTime.Now;
            return await repository.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(Product entity)
        {
            return await repository.DeleteAsync(entity);
        }

        public async Task<List<Product>> GetAsync()
        {
            return await repository.Get().Where(p => p.Deleted == false).ToListAsync();
        }

        public IQueryable<Product> Get()
        {
            return repository.Get().Where(p => p.Deleted == false);
        }

        public async Task<Product> GetAsync(int id)
        {
            return await repository.GetAsync(id);
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            return await repository.UpdateAsync(entity);
        }

        public IQueryable<Product> Filter(string value)
        {
            return repository.Get()
                .Where(p => p.Deleted == false)
                .Where(p =>
                     p.Name.Contains(value) ||
                     p.Brand.Contains(value) ||
                     p.Seller.Contains(value) ||
                     p.Price.ToString() == value);
        }
    }
}
