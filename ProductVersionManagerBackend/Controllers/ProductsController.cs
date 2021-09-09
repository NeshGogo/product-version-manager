using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductVersionManagerBackend.DTOs;
using ProductVersionManagerBackend.Entities;
using ProductVersionManagerBackend.Services;
using ProductVersionManagerBackend.Services.Products;
using ProductVersionManagerBackend.Services.ProductVersions;
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
        private readonly IProductService service;
        private readonly IProductVersionService productVersionService;
        private readonly IMapper mapper;

        public ProductsController(IProductService service, IProductVersionService productVersionService, IMapper mapper) : base(service, mapper)
        {
            this.service = service;
            this.productVersionService = productVersionService;
            this.mapper = mapper;
        }

      
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get([FromQuery]PaginationDTO pagination)
        {
            return await Get<ProductDTO>(pagination);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            return await Get<ProductDTO>(id);
        }

        [HttpGet("filter/{value}")]
        public async Task<ActionResult<List<ProductDTO>>> Get(string value, [FromQuery] PaginationDTO pagination)
        {
            var products = service.Filter(value);
            return await Get<ProductDTO>(pagination, products);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateProductDTO createProduct)
        {
            return await Post<ProductDTO, CreateProductDTO>(createProduct, "GetProduct");
        }

        [HttpPost("ApplyVersion")]
        public async Task<ActionResult> ApplyVersion([FromBody] ApplyVersionDTO applyVersion)
        {
            var productVersion = await productVersionService
                .GetVersionOfProductAsync(applyVersion.ProductId, applyVersion.Version);
            var createProduct = mapper.Map<CreateProductDTO>(productVersion);
            return await Put<CreateProductDTO>(applyVersion.ProductId, createProduct);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, CreateProductDTO createProduct)
        {
            return await Put<CreateProductDTO>(id, createProduct);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Put(int id)
        {
            return await Delete(id);
        }
    }
}
