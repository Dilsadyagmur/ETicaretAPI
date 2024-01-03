using ETicaretAPI.Application.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;

        public ProductsController(IProductService service) 
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
           var products =  service.GetAllProducts();
            return Ok(products);    
        }
    }
}
