using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductVersionManagerBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.Data.products
{
    public class ProductRepository : SQLRepository<Product>, IProductRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ProductRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public override async Task<Product> GetAsync(int id)
        {
            return await context.Products
                .Where(p => p.Deleted == false)
                .Include(p => p.ProductVersions)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<Product> UpdateAsync(Product product)
        {
            try
            {
                var oldProduct = await context.Products
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == product.Id);
                product.Date = oldProduct.Date;
                var lastVersion = context.ProductVersions
                    .OrderBy(v => v.Id)
                    .LastOrDefault(v => v.ProductId == product.Id)?.Version;
                var productVersion = mapper.Map<ProductVersion>(oldProduct);
                productVersion.Version = lastVersion != null? lastVersion.Value + 1 : 1;
                await context.ProductVersions.AddAsync(productVersion);
                product.ModificationDate = DateTime.Now;
                context.Products.Update(product);
                await context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override async Task<bool> DeleteAsync(Product product)
        {
            try
            {
                product.Deleted = true;
                context.Products.Update(product);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
