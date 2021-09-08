using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductVersionManagerBackend.Entities;
using ProductVersionManagerBackend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.Controllers
{
    public class CustomControllerBase<T> : ControllerBase where T : class, IId
    {
        private readonly IServiceBase<T> service;
        private readonly IMapper mapper;

        public CustomControllerBase(IServiceBase<T> service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<ActionResult<List<TDTO>>> Get<TDTO>() where TDTO : class
        {
            var entities = await service.GetAsync();
            return mapper.Map<List<TDTO>>(entities);
        }

        public async Task<ActionResult<TDTO>> Get<TDTO>(int id) where TDTO : class
        {
            var entiti = await service.GetAsync(id);
            if (entiti == null) return NotFound();
            return mapper.Map<TDTO>(entiti);
        }

        public async Task<ActionResult> Post<TDTO, TCreateDTO>(TCreateDTO createDTO, string routeName) where TDTO : class
        {
            var entity = mapper.Map<T>(createDTO);
            entity = await service.AddAsync(entity);
            var dto = mapper.Map<TDTO>(entity);
            return new CreatedAtRouteResult(routeName, new { id = entity.Id }, dto);
        }
    }
}
