using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            this.context = context;
        }

        public Microsoft.EntityFrameworkCore.DbSet<T> Table => context.Set<T>();

        public IQueryable<T> GetAll() => Table;

        public IQueryable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> method)
            =>Table.Where(method);
   
        public Task<T> GetSingleAsync(System.Linq.Expressions.Expression<Func<T, bool>> method)
            =>Table.FirstOrDefaultAsync(method);

        public Task<T> GetByIdAsync(string id)
            =>Table.FirstOrDefaultAsync(data=>data.Id ==Guid.Parse(id));
    }
}
