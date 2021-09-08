using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductVersionManagerBackend.DTOs;
using ProductVersionManagerBackend.Entities;
using ProductVersionManagerBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomControllerBase<Product>
    {
        public ProductsController(IServiceBase<Product> service, IMapper mapper) : base(service, mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get()
        {
            return await Get<ProductDTO>();
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            return await Get<ProductDTO>(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateProductDTO createProduct)
        {
            return await Post<ProductDTO, CreateProductDTO>(createProduct, "GetProduct");
        }
    }
}
