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
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<CreateProductDTO, Product>();
            CreateMap<ProductVersionDTO, ProductVersion>().ReverseMap();
            CreateMap<Product, ProductVersion>()
                .ForMember(pv => pv.ProductId, options => options.MapFrom(p => p.Id))
                .ForMember(pv => pv.Id, options => options.Ignore());
            CreateMap<ProductVersion, Product>()
                .ForMember(pv => pv.Id, options => options.MapFrom(p => p.ProductId));
        }
    }
}
