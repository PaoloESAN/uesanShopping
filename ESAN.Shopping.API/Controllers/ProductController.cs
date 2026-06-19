using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UESAN.SHOPPING.CORE.core.DTOs;
using UESAN.SHOPPING.CORE.core.Interfaces;
namespace ESAN.Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productServices.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productServices.GetProductsById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDTO product)
        {
            await _productServices.AddProduct(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDTO product)
        {
            if (id != product.Id)
                return BadRequest();
            await _productServices.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productServices.GetProductsById(id);
            if (product == null)
                return NotFound();
            await _productServices.DeleteProduct(new ProductDeleteDTO { Id = id });
            return NoContent();
        }
    }
}
