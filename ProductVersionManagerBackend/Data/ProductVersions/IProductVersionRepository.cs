using ProductVersionManagerBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.Data.ProductVersions
{
    public interface IProductVersionRepository : IRepository<ProductVersion>
    {
        Task<ProductVersion> GetVersionOfProductAsync(int productId, int version);
    }
}
