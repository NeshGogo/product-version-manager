using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.DTOs
{
    public class ProductVersionDTO
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string Seller { get; set; }
        public DateTime Date { get; set; }
        public DateTime ModificationDate { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
