using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Think_Digitally_week01.Models;
using Think_Digitally_week01.Services;

namespace Think_Digitally_week01.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            return Ok(_productService.AddProduct(product));
        }

        [HttpGet("paged")]
        public IActionResult GetPaged([FromQuery] string? search, int page = 1, int pageSize = 10, string? sortBy = "id", bool ascending = true)
        {
            return Ok(_productService.GetFilteredProducts(search, page, pageSize, sortBy, ascending));
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            return Ok(_productService.UpdateProduct(product));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetAllProducts().FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            _productService.DeleteProduct(product);
            return Ok($"Product with ID {id} deleted (soft delete).");
        }
    }
}
