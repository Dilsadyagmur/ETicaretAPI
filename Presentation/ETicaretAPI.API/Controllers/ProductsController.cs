
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){ Id = Guid.NewGuid(),CreatedDate = DateTime.UtcNow,Name ="product1" , Price = 2500, Stock = 150},
                new(){ Id = Guid.NewGuid(),CreatedDate = DateTime.UtcNow,Name ="product2" , Price = 2600, Stock = 1450},
                new(){ Id = Guid.NewGuid(),CreatedDate = DateTime.UtcNow,Name ="product3" , Price = 2500, Stock = 150},
                new(){ Id = Guid.NewGuid(),CreatedDate = DateTime.UtcNow,Name ="product4" , Price = 2500, Stock = 250},
            });

            var count = await  _productWriteRepository.SaveAsync();
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
          Product product =  await _productReadRepository.GetByIdAsync(id);

            return Ok(product);
        }

    }
}
