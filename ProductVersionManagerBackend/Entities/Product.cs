using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Brand { get; set; }
        [Required]
        public double Price { get; set; }
        [StringLength(30)]
        public string Seller { get; set; }
        public Boolean Deleted { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public DateTime ModificationDate { get; set; }
        public List<ProductVersion> ProductVersions { get; set; }
    }
}
