using Microsoft.EntityFrameworkCore;
using ProductVersionManagerBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductVersionManagerBackend.Data
{
    public class SQLRepository<T> : IRepository<T> where T : class, IId
    {
        private readonly AppDbContext context;
        public DbSet<T> Entities { get { return context.Set<T>(); } }

        public SQLRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await Entities.AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                Entities.Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<T>> GetAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                Entities.Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
