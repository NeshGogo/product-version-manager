using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.Entities
{
    public class ProductVersion: IId
    {
        public int Id { get; set; }
        [Required]
        public int Version { get; set; }
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
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime ModificationDate { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


    }
}
