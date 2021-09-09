﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductVersionManagerBackend.DTOs;
using ProductVersionManagerBackend.Entities;
using ProductVersionManagerBackend.Services;
using ProductVersionManagerBackend.Services.Products;
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

        public ProductsController(IProductService service, IMapper mapper) : base(service, mapper)
        {
            this.service = service;
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

        [HttpGet("{value}")]
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
