using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.DTOs
{
    public class CreateProductDTO
    {
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
    }
}
