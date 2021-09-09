using ProductVersionManagerBackend.Data.ProductVersions;
using ProductVersionManagerBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.Services.ProductVersions
{
    public class ProductVersionService : IProductVersionService
    {
        private readonly IProductVersionRepository repository;

        public ProductVersionService(IProductVersionRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ProductVersion> GetVersionOfProductAsync(int productId, int version)
        {
            return await repository.GetVersionOfProductAsync(productId, version);
        }
    }
}
