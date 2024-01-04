﻿using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext context;

        public WriteRepository(ETicaretAPIDbContext context)
        {
            this.context = context;
        }

        public DbSet<T> Table => context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
                EntityEntry<T> entityEntry = await Table.AddAsync(entity);

            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entities)
        {
           await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Delete (T entity)
        {

            EntityEntry<T> entityEntry =  Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> DeleteById(string id)
        {
          T model = await Table.FirstOrDefaultAsync(data=>data.Id == Guid.Parse(id));
           return Delete(model);
        }

        public bool DeleteRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;    
        }

        public bool UpdateAsync(T entity)
        {
           EntityEntry entityEntry = Table.Update(entity);
           return entityEntry.State == EntityState.Modified;
        }

        public async  Task<int> SaveAsync()
             =>  await context.SaveChangesAsync();
      

       
    }
}
