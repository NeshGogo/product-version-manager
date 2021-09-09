using ProductVersionManagerBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.Services.ProductVersions
{
    public interface IProductVersionService
    {
        Task<ProductVersion> GetVersionOfProductAsync(int productId, int version);
    }
}
