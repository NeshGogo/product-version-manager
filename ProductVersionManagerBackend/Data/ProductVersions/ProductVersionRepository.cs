using Microsoft.EntityFrameworkCore;
using ProductVersionManagerBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.Data.ProductVersions
{
    public class ProductVersionRepository : SQLRepository<ProductVersion>, IProductVersionRepository
    {
        public ProductVersionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<ProductVersion> GetVersionOfProductAsync(int productId, int version)
        {
            return await Entities.FirstOrDefaultAsync(pv => pv.ProductId == productId && pv.Version == version);
        }
    }
}
