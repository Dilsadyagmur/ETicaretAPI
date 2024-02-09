﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Persistance.Contexts
{
    public class ETicaretAPIDbContext : DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public ETicaretAPIDbContext() { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

        //changetracker: entityler üzerinden yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında track edilen verileri yakalayıp elde etmemizi sağlar.

        var datas = ChangeTracker
              .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                };

            }




            return await  base.SaveChangesAsync(cancellationToken);
        }
    }
    }
