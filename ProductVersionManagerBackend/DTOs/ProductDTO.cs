using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string Seller { get; set; }
        public DateTime Date { get; set; }
        public List<ProductVersionDTO> ProductVersions { get; set; }
    }
}
