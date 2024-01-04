using ETicaretAPI.Application.Abstraction;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance.Concrete
{
    public class ProductService : IProductService
    {
        public List<Product> GetAllProducts()
       => new()
       {
            new(){ Id= Guid.NewGuid(), CreatedDate = DateTime.Now, Name = "p-1" , Price = 250 , Stock=2000 },
            new(){ Id= Guid.NewGuid(), CreatedDate = DateTime.Now, Name = "p-2" , Price = 250 , Stock=2000 },
            new(){ Id= Guid.NewGuid(), CreatedDate = DateTime.Now, Name = "p-3" , Price = 250 , Stock=2000 },
            new(){ Id= Guid.NewGuid(), CreatedDate = DateTime.Now, Name = "p-4" , Price = 250 , Stock=2000 },
       };

    }
}
