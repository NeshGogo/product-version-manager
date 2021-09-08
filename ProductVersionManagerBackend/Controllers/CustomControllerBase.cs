using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductVersionManagerBackend.DTOs;
using ProductVersionManagerBackend.Entities;
using ProductVersionManagerBackend.Helpers;
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

        protected async Task<List<TDTO>> Get<TDTO>(PaginationDTO pagination)
        {
            var queryable = service.Get();
            return await Get<TDTO>(pagination, queryable);
        }

        protected async Task<List<TDTO>> Get<TDTO>(PaginationDTO pagination, IQueryable<T> queryable)
        {
            await HttpContext.InsertPaginationParams(queryable, pagination.RecordPerPage);
            var entities = await queryable.Pagination(pagination).ToListAsync();
            return mapper.Map<List<TDTO>>(entities);
        }

        protected async Task<ActionResult<List<TDTO>>> Get<TDTO>() where TDTO : class
        {
            var entities = await service.GetAsync();
            return mapper.Map<List<TDTO>>(entities);
        }

        protected async Task<ActionResult<TDTO>> Get<TDTO>(int id) where TDTO : class
        {
            var entiti = await service.GetAsync(id);
            if (entiti == null) return NotFound();
            return mapper.Map<TDTO>(entiti);
        }

        protected async Task<ActionResult> Post<TDTO, TCreateDTO>(TCreateDTO createDTO, string routeName) where TDTO : class
        {
            var entity = mapper.Map<T>(createDTO);
            entity = await service.AddAsync(entity);
            var dto = mapper.Map<TDTO>(entity);
            return new CreatedAtRouteResult(routeName, new { id = entity.Id }, dto);
        }

        protected async Task<ActionResult> Put<TUpdateDTO>(int id,TUpdateDTO updateDTO) where TUpdateDTO : class
        {
            var entity = mapper.Map<T>(updateDTO);
            entity.Id = id;
            await service.UpdateAsync(entity);
            return NoContent();
        }

        protected async Task<ActionResult> Delete(int id)
        {
            var entity = await service.GetAsync(id);
            if (entity == null) return NotFound();
            await service.DeleteAsync(entity);
            return NoContent();
        }
    }
}
