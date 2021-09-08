using AutoMapper;
using ProductVersionManagerBackend.DTOs;
using ProductVersionManagerBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.Helpers
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<CreateProductDTO, Product>();
            CreateMap<ProductVersionDTO, ProductVersion>();
            CreateMap<Product, ProductVersion>()
                .ForMember(pv => pv.ProductId, options => options.MapFrom(p => p.Id));
            CreateMap<ProductVersion, Product>()
                .ForMember(pv => pv.Id, options => options.MapFrom(p => p.ProductId));
        }
    }
}
