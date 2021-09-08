using AutoMapper;
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

        public override async Task<Product> UpdateAsync(Product product)
        {
            try
            {
                var productVersion = mapper.Map<ProductVersion>(product);
                await context.ProductVersions.AddAsync(productVersion);
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
