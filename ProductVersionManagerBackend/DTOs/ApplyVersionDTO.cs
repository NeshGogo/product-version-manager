using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.DTOs
{
    public class ApplyVersionDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Version { get; set; }

    }
}
